using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.TSP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;

namespace MiningSimulator {
    public class TravelingSalesmanPathfinding {
        public TravelingSalesmanPathfinding() {
        }
        public bool areNeighborsActive(MiningNodeGrid miningNodeGrid, MiningNode node) {
            int row = node.row;
            int col = node.col;
            int activeNeighborCount = 0;

            if (col > 0) {
                MiningNode neighbor = miningNodeGrid.grid[row, col - 1];
                if (neighbor.type.active || neighbor.type.name == MiningNodeName.Empty) {

                    activeNeighborCount++;
                }
            } else {
                activeNeighborCount++;
            }
            if (col < miningNodeGrid.cols - 1) {
                MiningNode neighbor = miningNodeGrid.grid[row, col + 1];
                if (neighbor.type.active || neighbor.type.name == MiningNodeName.Empty) {
                    activeNeighborCount++;
                }
            } else {
                activeNeighborCount++;
            }
            if (row > 0) {
                MiningNode neighbor = miningNodeGrid.grid[row - 1, col];
                if (neighbor.type.active || neighbor.type.name == MiningNodeName.Empty) {
                    activeNeighborCount++;
                }
            } else {
                activeNeighborCount++;
            }
            if (row < miningNodeGrid.rows - 1) {
                MiningNode neighbor = miningNodeGrid.grid[row + 1, col];
                if (neighbor.type.active || neighbor.type.name == MiningNodeName.Empty) {
                    if (neighbor.row == miningNodeGrid.rows - 1 && neighbor.type.name == MiningNodeName.Empty) {
                        //ArcherForest bug not replicated in the simulator
                        //Increase the cost of the node because otherwise the pathfinding will try to take it
                        //neighbor.type.cost += 25;
                        activeNeighborCount++;
                    } else {
                        activeNeighborCount++;
                    }
                }
            } else {
                activeNeighborCount++;
            }

            if (activeNeighborCount == 4) {
                return true;
            } else {
                return false;
            }
        }
        public List<MiningNode> getStartingNodes(MiningNodeGrid miningNodeGrid) {
            List<MiningNode> results = new List<MiningNode>();

            // Add all empty active nodes to the list of starting nodes
            for (int row = 0; row < miningNodeGrid.rows; row++) {
                for (int col = 0; col < miningNodeGrid.cols; col++) {
                    MiningNode node = miningNodeGrid.grid[row, col];

                    //Check if empty active node
                    if (node.type.name == MiningNodeName.Empty && node.type.active) {
                        //Check for active neighbors
                        if (areNeighborsActive(miningNodeGrid, node)) {
                            //Check for bugged lowest node
                            if (node.row == miningNodeGrid.rows - 1) {
                                //ArcherForest bug not replicated in the simulator
                                //Increase the cost of the node because otherwise the pathfinding will try to take it
                                //node.type.cost += 25;
                            } else {
                                results.Add(node);
                            }
                        }
                    }
                }
            }
            return results;
        }
        public List<MiningNode> getInterestingItemsToMine(MiningNodeGrid miningNodeGrid) {
            List<MiningNode> items = new List<MiningNode>();
            for (int row = 0; row < miningNodeGrid.rows; row++) {
                for (int col = 0; col < miningNodeGrid.cols; col++) {
                    MiningNode node = miningNodeGrid.grid[row, col];
                    // Check if the node's name is in the subset of interesting items
                    if (Array.Exists(Globals.interestingItems, name => name == node.type.name)) {
                        items.Add(node);
                    }
                }
            }
            // Sort the list by importance, activity and row
            items = items.OrderByDescending(node => node).ToList();
            return items;
        }
        internal void buildGraphVerticesAndEdges(BidirectionalGraph<Point, TaggedEdge<Point, int>> graph, MiningNodeGrid miningNodeGrid) {
            for (int row = 0; row < miningNodeGrid.rows; row++) {
                for (int col = 0; col < miningNodeGrid.cols; col++) {
                    var nodePosition = new Point(col, row);
                    if (!graph.ContainsVertex(nodePosition)) {
                        graph.AddVertex(nodePosition);
                    }

                    // Connect adjacent nodes (up, down, left, right)
                    int[] dRow = { -1, 1, 0, 0 };
                    int[] dCol = { 0, 0, -1, 1 };

                    for (int i = 0; i < 4; i++) {
                        int newRow = row + dRow[i];
                        int newCol = col + dCol[i];

                        // Check if the adjacent node is within bounds and an empty node
                        if (newRow >= 0 && newRow < miningNodeGrid.rows && newCol >= 0 && newCol < miningNodeGrid.cols) {
                            Point adjacentNodePosition = new Point(newCol, newRow);
                            int adjacentCost = miningNodeGrid.grid[newRow, newCol].type.cost;
                            if (!graph.ContainsVertex(adjacentNodePosition)) {
                                graph.AddVertex(adjacentNodePosition);
                            }
                            graph.AddEdge(new TaggedEdge<Point, int>(nodePosition, adjacentNodePosition, adjacentCost));
                        }
                    }
                }
            }
        }
        public (int, List<Point>) getShortestPath(MiningNodeGrid miningNodeGrid, Point startNode, List<Point> endNodes) {
            // Create an instance of DijkstraPathfinding
            var aStarPathfinding = new AStarPathfinding();

            // Create a subgraph that includes only the nodes you want to visit
            var subGraph = new BidirectionalGraph<Point, EquatableEdge<Point>>();
            var edgeWeights = new Dictionary<EquatableEdge<Point>, int>();

            foreach (var sourceNode in endNodes.Prepend(startNode)) {
                foreach (var targetNode in endNodes.Prepend(startNode)) {
                    if (!sourceNode.Equals(targetNode)) {
                        // Use A* algorithm to find the shortest path between sourceNode and targetNode
                        var (pathCost, path) = aStarPathfinding.getShortestPath(miningNodeGrid, sourceNode, targetNode);
                        var edge = new EquatableEdge<Point>(sourceNode, targetNode);
                        subGraph.AddVerticesAndEdge(edge);
                        
                        edgeWeights[edge] = pathCost;

                    }
                }
            }

            // Create a function to get the weight of an edge
            Func<EquatableEdge<Point>, double> edgeCost = edge => edgeWeights[edge];

            // Create the TSP algorithm with the subgraph
            var tsp = new TSP<Point, EquatableEdge<Point>, BidirectionalGraph<Point, EquatableEdge<Point>>>(subGraph, edgeCost);

            // Compute the TSP
            tsp.Compute();

            // Get the shortest path

            if (tsp.ResultPath != null) {
                var shortestPath = tsp.ResultPath.Vertices;

                Console.WriteLine("STSP shortest path:");
                foreach (var pathPoint in shortestPath) {
                    Console.WriteLine($"{pathPoint.Y},{pathPoint.X}");
                }
                Console.WriteLine($"");


                // Create a list to store the full path
                List<Point> fullPath = new List<Point>();


                // Create a clone of the miningNodeGrid for adjusting costs
                var clonedMiningNodeGrid = miningNodeGrid.clone();

                // Iterate over the shortest path
                for (int i = 0; i < shortestPath.Count() - 1; i++) {
                    // Get the start and end points of the current segment
                    Point start = shortestPath.ElementAt(i);
                    Point end = shortestPath.ElementAt(i + 1);

                    // Use A* algorithm to find the shortest path between start and end
                    var (_, path) = aStarPathfinding.getShortestPath(clonedMiningNodeGrid, start, end);

                    // Add the path to the full path
                    fullPath.Add(start);
                    fullPath.AddRange(path);

                    // Set the cost of the nodes in the path to 0 in the clonedMiningNodeGrid
                    foreach (var node in path) {
                        clonedMiningNodeGrid.grid[node.Y, node.X].type.cost = 0;
                    }
                }

                //Remove dupe nodes (should be fine since they would be empty nodes after traveling there once)
                for (int i = 0; i < fullPath.Count; i++) {
                    for (int j = i + 1; j < fullPath.Count; j++) {
                        if (fullPath[i].Equals(fullPath[j])) {
                            fullPath.RemoveAt(j);
                            j--;
                        }
                    }
                }
                // Calculate the total cost of the full path
                int totalCost = fullPath.Select(node => miningNodeGrid.grid[node.Y, node.X].type.cost).Sum();

                // Return the full path and its total cost
                return (totalCost, fullPath);
            } else {
                Console.WriteLine("No STSP path");
                return (-1,null);
            }
            
        }

    }

}
