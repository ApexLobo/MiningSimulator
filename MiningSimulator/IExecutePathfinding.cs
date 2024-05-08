using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningSimulator {
    /// <summary>
    /// Interface for executing pathfinding related operations in a mining environment.
    /// </summary>
    public interface IExecutePathfinding {

        /// <summary>
        /// Mines interesting items using pathfinding within the given mining node grid.
        /// </summary>
        /// <param name="miningNodeGrid">The grid representing the mining environment.</param>
        /// <param name="pathfinding">The pathfinding algorithm to use.</param>
        /// <returns>True if you should try to mine downwards after execution otherwise false.</returns>

        bool mineInterestingItems(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding);

        /// <summary>
        /// Mines down one level using pathfinding within the given mining node grid.
        /// </summary>
        /// <param name="miningNodeGrid">The grid representing the mining environment.</param>
        /// <param name="pathfinding">The pathfinding algorithm to use.</param>
        /// /// <returns>True if you were able to mine down 1 level otherwise false.</returns>
        bool mineDownOneLevel(MiningNodeGrid miningNodeGrid, IPathfinding pathfinding);
    }
}
