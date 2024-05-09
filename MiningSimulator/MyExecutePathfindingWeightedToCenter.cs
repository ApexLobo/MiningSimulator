using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningSimulator {
    public class MyExecutePathfindingWeightedToCenter:MyExecutePathfinding {

        public MyExecutePathfindingWeightedToCenter() {
        }

        public override bool mineDownOneLevel(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding) {
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
                    // Choose the path that ends closer to the center column
                    shortestPathsWithMinCost.Sort((path1, path2) => Math.Abs(path1.Item2.Last().X - 3).CompareTo(Math.Abs(path2.Item2.Last().X - 3)));
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
    }
}
