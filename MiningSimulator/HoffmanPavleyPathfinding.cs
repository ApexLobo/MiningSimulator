﻿using QuikGraph;
using QuikGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;

namespace MiningSimulator {
    public class HoffmanPavleyPathfinding : IPathfinding {

        public HoffmanPavleyPathfinding() {
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

        public (int, List<Point>) getShortestPath(MiningNodeGrid miningNodeGrid, Point startNode, Point endNode) {
            // Create a directed graph representing the grid
            var graph = new BidirectionalGraph<Point, TaggedEdge<Point, int>>();

            // Add vertices and edges to the graph
            buildGraphVerticesAndEdges(graph, miningNodeGrid);

            // Create a function to get the weight of an edge
            Func<TaggedEdge<Point, int>, double> edgeCost = edge => edge.Tag;

            // Compute the K shortest paths
            var paths = graph.RankedShortestPathHoffmanPavley(edgeCost, startNode, endNode, 10);


            // Calculate the cost of the shortest path
            int shortestPathCost = paths.First().Sum(edge => edge.Tag);

            // Filter the paths to include only those with the same cost as the shortest path
            var shortestPaths = paths.Where(path => path.Sum(edge => edge.Tag) == shortestPathCost);

            int shortestPathsCount = shortestPaths.Count();
            if (shortestPathsCount > 1) {
                Console.WriteLine($"More than 1 shortest path = {shortestPathsCount}");
                foreach (var path in shortestPaths) {
                    int totalCost = path.Sum(edge => edge.Tag);
                    Console.WriteLine($"Path with total cost {totalCost}:");
                    foreach (var edge in path) {
                        Console.WriteLine($"({edge.Source.X}, {edge.Source.Y}) to ({edge.Target.X}, {edge.Target.Y})");
                    }
                    Console.WriteLine("\n");
                }
            } else {
                Console.WriteLine($"Only 1 shortest path");
                var path = paths.First();
                int totalCost = path.Sum(edge => edge.Tag);
                Console.WriteLine($"Path with total cost {totalCost}:");
                foreach (var edge in path) {
                    Console.WriteLine($"({edge.Source.X}, {edge.Source.Y}) to ({edge.Target.X}, {edge.Target.Y})");
                }
                Console.WriteLine("\n");
            }
            /*
            foreach (var path in paths) {
                int totalCost = path.Sum(edge => edge.Tag);
                Console.WriteLine($"Path with total cost {totalCost}:");
                foreach (var edge in path) {
                    Console.WriteLine($"({edge.Source.X}, {edge.Source.Y}) to ({edge.Target.X}, {edge.Target.Y})");
                }
                Console.WriteLine("\n");
            }*/

            // Return the shortest path
            var shortestPath = paths.First();
            return (shortestPath.Sum(edge => edge.Tag), shortestPath.Select(edge => edge.Target).ToList());
        }
    }
}
