using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;

namespace MiningSimulator {
    public class MyExecutePathfindingOriginal : IExecutePathfinding {
        public MyExecutePathfindingOriginal() {

        }
        private bool isPointInBounds(MiningNodeGrid miningNodeGrid, Point p) {
            if (p.Y >= 0 && p.Y < miningNodeGrid.rows && p.X >= 0 && p.X < miningNodeGrid.cols) {
                return true;
            } else {
                return false;
            }
        }
        private void mineDownShortestPath(MiningNodeGrid miningNodeGrid, (int, List<Point>) shortestPath) {
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
        private static void randomizeList<T>(List<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = Globals.randomPathfinding.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        List<(int, List<Point>)> getShortestPathsFromEmptyNodes(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding, List<MiningNode> lowestEmptyNodes) {
            List<(int, List<Point>)> shortestPaths = new List<(int, List<Point>)>();

            // Calculate shortest paths to lower nodes
            //          o
            //      x x x x x
            foreach (MiningNode node in lowestEmptyNodes) {
                var shortBelowPath = pathfinding.getShortestPath(miningNodeGrid,new Point(node.col, node.row), new Point(node.col, node.row + 1));
                shortestPaths.Add(shortBelowPath);

                for (int i = 1; i <= 2; i++) {
                    Point leftPoint = new Point(node.col - i, node.row + 1);
                    Point rightPoint = new Point(node.col + i, node.row + 1);

                    if (isPointInBounds(miningNodeGrid, leftPoint)) {
                        var shortLeftPath = pathfinding.getShortestPath(miningNodeGrid, new Point(node.col, node.row), leftPoint);
                        shortestPaths.Add(shortLeftPath);
                    }
                    if (isPointInBounds(miningNodeGrid, rightPoint)) {
                        var shortRightPath = pathfinding.getShortestPath(miningNodeGrid, new Point(node.col, node.row), rightPoint);
                        shortestPaths.Add(shortRightPath);
                    }
                }
            }

            return shortestPaths;
        }

        public bool mineDownOneLevel(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding) {
            List<MiningNode> lowestEmptyNodes = pathfinding.getStartingNodes(miningNodeGrid);
            //Get shortest paths
            List<(int, List<Point>)> shortestPaths = getShortestPathsFromEmptyNodes(miningNodeGrid, pathfinding, lowestEmptyNodes);

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
                return true;
            } else {
                return false;
            }
             
        }
        public bool mineInterestingItems(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding) {
            List<MiningNode> interestingItems = pathfinding.getInterestingItemsToMine(miningNodeGrid);

            // Sort the list by importance, activity and row
            interestingItems = interestingItems.OrderByDescending(node => node).ToList();

            if (interestingItems.Count > 0) {
                foreach (MiningNode interestingItem in interestingItems) {
                    if (interestingItem != null) {

                        // Interesting item is active
                        if (interestingItem.type.active) {
                            miningNodeGrid.clickNode(interestingItem.row, interestingItem.col);
                            var itemCount = interestingItems.Count;
                            if (interestingItem.Equals(interestingItems[itemCount - 1])) {
                                //Mine down one level because no more interesting items
                                return true;
                            }
                        } else { //Interesting item is inactive

                            // Check if the node's name is in the subset of interesting items
                            if (Array.Exists(Globals.itemsToHunt, name => name == interestingItem.type.name)) {

                                // Get the starting nodes for pathfinding
                                List<MiningNode> lowestEmptyNodes = pathfinding.getStartingNodes(miningNodeGrid);
                                MiningNode firstEmptyNode = lowestEmptyNodes[0];

                                // Find the shortest path to the interesting item
                                var shortestPath = pathfinding.getShortestPath(miningNodeGrid,new Point(firstEmptyNode.col, firstEmptyNode.row), new Point(interestingItem.col, interestingItem.row));
                                int totalCost = shortestPath.Item1;
                                List<Point> path = shortestPath.Item2;
                                foreach (Point p in path) {
                                    MiningNode pathNode = miningNodeGrid.grid[p.Y, p.X];
                                    if (pathNode.type.name != MiningNodeName.Empty) {
                                        miningNodeGrid.clickNode(pathNode.row, pathNode.col);

                                        //If path causes grid to move and the node is not the hunted item then break out of the path clicking to wait for grid to stop
                                        if (pathNode.row == miningNodeGrid.rows - 1 && pathNode != interestingItem) {
                                            //Return from function and do not mine down a level
                                            return false;
                                        }
                                        Thread.Sleep(Globals.miningDelay);
                                    }
                                }
                            } else { //Item is interesting but not hunt worthy
                                var itemCount = interestingItems.Count;
                                if (interestingItem.Equals(interestingItems[itemCount - 1])) {
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