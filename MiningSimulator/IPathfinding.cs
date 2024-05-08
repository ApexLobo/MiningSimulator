using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningSimulator {
    /// <summary>
    /// Interface for implementing pathfinding algorithms.
    /// </summary>
    public interface IPathfinding {
        /// <summary>
        /// Retrieves the starting nodes for pathfinding within the given mining node grid.
        /// </summary>
        /// <param name="miningNodeGrid">The grid representing the mining environment.</param>
        /// <returns>A list of starting nodes for pathfinding.</returns>
        List<MiningNode> getStartingNodes(MiningNodeGrid miningNodeGrid);
        /// <summary>
        /// Retrieves the interesting items to mine within the given mining node grid.
        /// </summary>
        /// <param name="miningNodeGrid">The grid representing the mining environment.</param>
        /// <returns>A list of interesting items to mine.</returns>
        List<MiningNode> getInterestingItemsToMine(MiningNodeGrid miningNodeGrid);
        /// <summary>
        /// Calculates the shortest path between two nodes within the given mining node grid.
        /// </summary>
        /// <param name="miningNodeGrid">The grid representing the mining environment.</param>
        /// <param name="startNode">The starting node of the path.</param>
        /// <param name="endNode">The end node of the path.</param>
        /// <returns>
        /// A tuple containing the cost of the shortest path and the list of points representing the path.
        /// </returns>
        (int, List<Point>) getShortestPath(MiningNodeGrid miningNodeGrid, Point startNode, Point endNode);
    }
}
