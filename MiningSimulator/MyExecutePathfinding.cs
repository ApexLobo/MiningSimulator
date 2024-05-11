using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;

namespace MiningSimulator {
    public class MyExecutePathfinding : IExecutePathfinding {

        public MyExecutePathfinding() {

        }
        internal bool isPointInBounds(MiningNodeGrid miningNodeGrid, Point p) {
            if (p.Y >= 0 && p.Y < miningNodeGrid.rows && p.X >= 0 && p.X < miningNodeGrid.cols) {
                return true;
            } else {
                return false;
            }
        }
        internal void mineDownShortestPath(MiningNodeGrid miningNodeGrid, (int, List<Point>) shortestPath) {
            // Extract the points from the path
            var pathPoints = shortestPath.Item2;
            foreach (var point in pathPoints) {
                MiningNode nextPoint = miningNodeGrid.grid[point.Y, point.X];
                if (nextPoint.type.name != MiningNodeName.Empty) {
                    if (Globals.allowMoveDown) {
                        miningNodeGrid.clickNode(point.Y, point.X);
                    }
                    Thread.Sleep(Globals.miningDelay);
                }
            }
        }
        // Method to randomize a list (Fisher-Yates shuffle algorithm)
        internal static void randomizeList<T>(List<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = Globals.randomPathfinding.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        internal List<(int, List<Point>)> getShortestPathsFromEmptyNodes(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding, List<MiningNode> startingNodes) {
            List<(int, List<Point>)> shortestPaths = new List<(int, List<Point>)>();

            // Calculate shortest paths to all bottom row nodes from all starting nodes
            foreach (MiningNode startNode in startingNodes) {
                foreach (MiningNode endNode in miningNodeGrid.getMiningNodesFromRow(miningNodeGrid.rows - 1)) {
                    var pathFromStartToEnd = pathfinding.getShortestPath(miningNodeGrid, startNode.positionToPoint(), endNode.positionToPoint());
                    shortestPaths.Add(pathFromStartToEnd);
                }
            }

            return shortestPaths;
        }

        public virtual bool mineDownOneLevel(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding) {
            if (Globals.debug) {
                Console.WriteLine($"Mine down one level");
            }

            List<MiningNode> startingNodes = pathfinding.getStartingNodes(miningNodeGrid);
            //Get shortest paths
            List<(int, List<Point>)> shortestPaths = getShortestPathsFromEmptyNodes(miningNodeGrid, pathfinding, startingNodes);

            if (shortestPaths.Count > 0) {
                // Find the minimum cost among the paths
                int minCost = shortestPaths.Min(path => path.Item1);

                // Filter out only the paths with the minimum cost
                var shortestPathsWithMinCost = shortestPaths.Where(path => path.Item1 == minCost).ToList();

                //If there is more than one shortest path
                if (shortestPathsWithMinCost.Count > 1) {
                    //Shuffle the list to choose a random min cost path
                    randomizeList(shortestPathsWithMinCost);
                }
                // Select the first path
                var shortestPath = shortestPathsWithMinCost.First();

                //Click down the shortest path
                mineDownShortestPath(miningNodeGrid, shortestPath);


                if (shortestPath.Item1 == 0) {
                    if (Globals.debug) {
                        Console.WriteLine("Shortest path is 0 cost");
                        Console.WriteLine($"Shortest path -> {string.Join(" -> ", shortestPath.Item2)}");
                    }
                    return false;
                } else {
                    return true;
                }


            } else {
                return false;
            }
        }
        public bool mineInterestingItems(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding) {
            List<MiningNode> interestingItems = pathfinding.getInterestingItemsToMine(miningNodeGrid);
            if (Globals.debug) {
                Console.WriteLine($"Mine interesting items: {interestingItems.Count}");
            }
            if (interestingItems.Count > 0) {
                foreach (MiningNode interestingItem in interestingItems) {
                    if (interestingItem != null) {

                        // Interesting item is active
                        if (interestingItem.type.active) {
                            miningNodeGrid.clickNode(interestingItem.row, interestingItem.col);
                            if (interestingItem.Equals(interestingItems.Last())) {
                                //Mine down one level because no more interesting items
                                return true;
                            }
                        } else { //Interesting item is inactive

                            // Check if the node's name is in the subset of interesting items
                            if (Array.Exists(Globals.itemsToHunt, name => name == interestingItem.type.name)) {

                                // Get the starting nodes for pathfinding
                                List<MiningNode> startingNodes = pathfinding.getStartingNodes(miningNodeGrid);
                                int lowestCost = int.MaxValue;
                                MiningNode selectedNode = null;
                                List<Point> shortestPathPoints = null;

                                // Get the shortest path to the interesting item from all start nodes
                                foreach (MiningNode startNode in startingNodes) {
                                    var shortestPath = pathfinding.getShortestPath(miningNodeGrid, new Point(startNode.col, startNode.row), new Point(interestingItem.col, interestingItem.row));
                                    int totalCost = shortestPath.Item1;
                                    if (totalCost < lowestCost) {
                                        lowestCost = totalCost;
                                        selectedNode = startNode;
                                        shortestPathPoints = shortestPath.Item2;
                                    }
                                }

                                // Mine the path to the inactive node
                                if (selectedNode != null && shortestPathPoints != null) {
                                    foreach (Point p in shortestPathPoints) {
                                        MiningNode pathNode = miningNodeGrid.grid[p.Y, p.X];

                                        // Dont try to click inactive nodes
                                        if (pathNode.type.name != MiningNodeName.Empty) {
                                            miningNodeGrid.clickNode(pathNode.row, pathNode.col);

                                            //  If mining the node caused the grid to shift restart the loop
                                            if (pathNode.row == miningNodeGrid.rows - 1) {
                                                // Return from function and do not mine down a level
                                                return false; 
                                            }
                                            Thread.Sleep(Globals.miningDelay);
                                        }
                                    }
                                }

                            } else { //Item is interesting but not hunt worthy
                                var itemCount = interestingItems.Count;
                                if (interestingItem.Equals(interestingItems.Last())) {
                                    //Mine down one level because no more interesting items
                                    return true;
                                }
                            }
                        }
                    }
                }
            } else { // No interesting items
                //Mine down one level
                return true;
            }

            //This shouldnt happen I think?
            if (Globals.debug) {
                Console.WriteLine("Mine interesting items reached the end");
            }
            return false;
        }
    }
}