using QuikGraph;
using QuikGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiningSimulator {
    public class MiningNodeGrid {
        public int rows { get; set; }
        public int cols { get; set; }
        public int nodeSize { get; set; }
        public MiningNode[,] grid { get; set; }

        public MiningNodeGenerator nodeGenerator { get; set; }

        public event EventHandler gridUpdatedEvent;

        public List<MiningNode> shiftedNodes = new List<MiningNode>();

        public MiningNodeGrid(int rows, int cols, int nodeSize = 88) {
            this.rows = rows;
            this.cols = cols;
            this.nodeSize = nodeSize;
            this.grid = new MiningNode[rows, cols];
            nodeGenerator = new MiningNodeGenerator();

            initGrid();
        }

        public void initGrid() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    MiningNode node;
                    if (j == 3 && i < rows) {
                        node = new MiningNode(88);
                        if (i == rows - 1) {
                            node.type = new MiningNodeType(MiningNodeType.MiningNodeName.Dirt, false);
                        } else {
                            node.type = new MiningNodeType(MiningNodeType.MiningNodeName.Empty, false);
                        }
                    } else {
                        node = nodeGenerator.generateRandomNode();

                        switch (node.type.name) {
                            case MiningNodeType.MiningNodeName.Diamond_T1:
                                Stats.totalDiamondsT1Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Diamond_T2:
                                Stats.totalDiamondsT2Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Diamond_T3:
                                Stats.totalDiamondsT3Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Red_Diamond_T1:
                                Stats.totalRedDiamondsT1Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Red_Diamond_T2:
                                Stats.totalRedDiamondsT2Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Red_Diamond_T3:
                                Stats.totalRedDiamondsT3Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Rune_T1:
                                Stats.totalRunesT1Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Rune_T2:
                                Stats.totalRunesT2Seen++;
                                break;
                            case MiningNodeType.MiningNodeName.Rune_T3:
                                Stats.totalRunesT3Seen++;
                                break;
                        }
                    }

                    node.row = i;
                    node.col = j;
                    grid[i, j] = node;
                }
            }
            for (int i = 0; i < cols; i++) {
                MiningNode initShiftedNode = new MiningNode(-1, i, 88);
                initShiftedNode.type = new MiningNodeType(MiningNodeType.MiningNodeName.Empty, true);

                shiftedNodes.Add(initShiftedNode);
            }
        }

        public List<MiningNode> getMiningNodesFromRow(int row) {
            List<MiningNode> nodes = new List<MiningNode>();

            for (int col = 0; col < cols; col++) {
                nodes.Add(grid[row, col]);
            }

            return nodes;
        }
        public List<MiningNode> getMiningNodesFromCol(int col) {
            List<MiningNode> nodes = new List<MiningNode>();

            for (int row = 0; row < cols; row++) {
                nodes.Add(grid[row, col]);
            }

            return nodes;
        }


        public bool emptyPathToBottomExists() {
            var graph = new BidirectionalGraph<Point, TaggedEdge<Point, int>>();

            // Add vertices and edges to the graph
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
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

                        // Check if the adjacent node is within bounds and add the adjacent node (if it does not already exist in the graph) and edge between them
                        if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols) {
                            Point adjacentNodePosition = new Point(newCol, newRow);
                            int adjacentCost = grid[newRow, newCol].type.cost;
                            if (!graph.ContainsVertex(adjacentNodePosition)) {
                                graph.AddVertex(adjacentNodePosition);
                            }
                            graph.AddEdge(new TaggedEdge<Point, int>(nodePosition, adjacentNodePosition, adjacentCost));
                        }
                    }
                }
            }


            // Iterate through all top nodes
            for (int startCol = 0; startCol < cols; startCol++) {
                var startNode = new Point(startCol, 0);

                // Check if the start node is active and empty
                if (grid[0, startCol].type.active && grid[0, startCol].type.name == MiningNodeType.MiningNodeName.Empty) {
                    // Iterate through all bottom nodes
                    for (int endCol = 0; endCol < cols; endCol++) {
                        var endNode = new Point(endCol, rows - 1);

                        // Check if the end node is active and empty
                        if (grid[rows - 1, endCol].type.active && grid[rows - 1, endCol].type.name == MiningNodeType.MiningNodeName.Empty) {
                            // Use Dijkstra's algorithm to find the shortest path from the start node to the end node
                            var tryGetPaths = graph.ShortestPathsDijkstra(edge => edge.Tag, startNode);

                            IEnumerable<TaggedEdge<Point, int>> shortestPath;
                            int totalCost = 0;

                            // Find the shortest path from the start node to the end node
                            if (tryGetPaths(endNode, out shortestPath)) {
                                // Calculate the total cost of the path
                                foreach (var edge in shortestPath) {
                                    totalCost += edge.Tag;
                                }

                                // If a path with zero cost exists, return true
                                if (totalCost == 0) {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            // Return false if no path with zero cost exists
            return false;
        }
        public void clearActiveNodes() {
            // Mark all nodes as inactive
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    grid[i, j].type.active = false;
                }
            }
        }
        public void findActiveNodes() {
            clearActiveNodes();

            // Mark empty nodes at the top as active if connected to the active path or shifted nodes
            for (int j = 0; j < cols; j++) {
                MiningNode shiftedNode = shiftedNodes[j];
                bool isAboveShiftedEmptyAndActive = grid[0, j].type.name == MiningNodeType.MiningNodeName.Empty && shiftedNode.type.name == MiningNodeType.MiningNodeName.Empty && shiftedNode.type.active == true;
                if (isAboveShiftedEmptyAndActive) {
                    markActivePath(0, j);
                }
            }

            // Mark nodes adjacent to the empty nodes as active
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (grid[i, j].type.name == MiningNodeType.MiningNodeName.Empty && grid[i, j].type.active) {
                        markAdjacentNodesActive(i, j);
                    }
                }
            }
        }
        private void markActivePath(int row, int col) {

            //Set the node to active
            grid[row, col].type.active = true;

            // Check adjacent nodes (up, down, left, right)
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++) {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];

                // Check if the adjacent node is within bounds and an empty node
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols) {

                    //Check if the adjacent node is empty and is not active
                    if (grid[newRow, newCol].type.name == MiningNodeType.MiningNodeName.Empty && !grid[newRow, newCol].type.active) {

                        //Continue to find the active path
                        markActivePath(newRow, newCol);
                    }
                }
            }
        }
        private void markAdjacentNodesActive(int row, int col) {
            // Check adjacent nodes (up, down, left, right)
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++) {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];

                // Check if the adjacent node is within bounds
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols) {

                    //Check if the adjacent node is not empty and is not active
                    if (grid[newRow, newCol].type.name != MiningNodeType.MiningNodeName.Empty && !grid[newRow, newCol].type.active) {

                        //Set the adjacent node active
                        grid[newRow, newCol].type.active = true;
                    }
                }
            }

            // Check shifted adjacent nodes
            for (int i = 0; i < cols; i++) {
                if (shiftedNodes[i].type.name == MiningNodeType.MiningNodeName.Empty && shiftedNodes[i].type.active) {
                    if (grid[0, i].type.name != MiningNodeType.MiningNodeName.Empty && !grid[0, i].type.active) {
                        grid[0, i].type.active = true;
                    }
                }
            }
        }
        public void clickNode(int clickedRow, int clickedCol) {

            // Check if the clicked node is active
            if (clickedRow >= 0 && clickedRow < rows && clickedCol >= 0 && clickedCol < cols && grid[clickedRow, clickedCol].type.active) {
                grid[clickedRow, clickedCol].updateMinedStats();

                // Replace the active node with an empty node
                grid[clickedRow, clickedCol].type = new MiningNodeType(MiningNodeType.MiningNodeName.Empty, false);

                // If the clicked node is in the bottom row, shift the grid up one row and generate a new random bottom row
                if (clickedRow == rows - 1) {
                    shiftGridUp();
                } else {
                    // Find new active nodes
                    findActiveNodes();

                    // Refresh the DataGridView to reflect the changes
                    notifyGridUpdated();

                    if (emptyPathToBottomExists()) {
                        shiftGridUp();
                    }
                }
            }
        }




        // Event to subscribe to to trigger the grid updated event
        protected virtual void onGridUpdated(EventArgs e) {
            gridUpdatedEvent?.Invoke(this, e);
        }

        // Method to trigger the event after making changes to the grid
        public void notifyGridUpdated() {
            onGridUpdated(EventArgs.Empty);
        }

        public void shiftGridUp() {
            shiftedNodes.Clear(); // Clear the list of shifted nodes
            if (Globals.debug) {
                Console.WriteLine("Before shift grid up");
                printGridDetailsToConsole();
            }
            // Iterate through each column of the bottom row
            for (int j = 0; j < cols; j++) {
                // Store the node that is being shifted out
                shiftedNodes.Add(grid[0, j]);
            }

            for (int i = 0; i < rows - 1; i++) {
                for (int j = 0; j < cols; j++) {
                    grid[i, j] = grid[i + 1, j];
                    grid[i, j].row = i;
                }
            }

            generateNewBottomRow();
        }
        public void generateNewBottomRow() {
            // Increment the depth mined since we generated a new row
            Stats.totalDepthMined++;

            // Generate a new bottom row
            for (int j = 0; j < cols; j++) {
                MiningNode newNode = nodeGenerator.generateRandomNode();
                newNode.row = rows - 1;
                newNode.col = j;
                grid[rows - 1, j] = newNode;

                switch (newNode.type.name) {
                    case MiningNodeType.MiningNodeName.Diamond_T1:
                        Stats.totalDiamondsT1Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Diamond_T2:
                        Stats.totalDiamondsT2Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Diamond_T3:
                        Stats.totalDiamondsT3Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Red_Diamond_T1:
                        Stats.totalRedDiamondsT1Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Red_Diamond_T2:
                        Stats.totalRedDiamondsT2Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Red_Diamond_T3:
                        Stats.totalRedDiamondsT3Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Rune_T1:
                        Stats.totalRunesT1Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Rune_T2:
                        Stats.totalRunesT2Seen++;
                        break;
                    case MiningNodeType.MiningNodeName.Rune_T3:
                        Stats.totalRunesT3Seen++;
                        break;
                }
            }
            // Find new active nodes
            findActiveNodes();

            // Refresh the DataGridView to reflect the changes
            notifyGridUpdated();

            // Check for empty nodes in the new grid row to automatically move down
            if (emptyPathToBottomExists()) {
                shiftGridUp();
            }

        }
        public void printGridActivityToConsole() {
            // Iterate through each row of the grid
            for (int i = 0; i < rows; i++) {
                // Iterate through each column of the grid
                for (int j = 0; j < cols; j++) {
                    // Output 1 for active nodes and 0 for inactive nodes
                    string value = grid[i, j].type.active ? "A" : "I";
                    Console.Write(value + " ");
                }
                // Move to the next row
                Console.WriteLine("");
            }
            Console.WriteLine("\r\n");
        }
        public void printGridDetailsToConsole() {
            var TextFormat = "{0,-17}";

            for (int col = 0; col < cols; col++) {
                if (shiftedNodes.Count > 0) {
                    MiningNode shiftedNode = shiftedNodes[col];
                    Console.Write($"{String.Format(TextFormat, shiftedNode.type.name + ":" + (Convert.ToInt32(shiftedNode.type.active)).ToString())}");
                }
            }
            Console.WriteLine("\n");

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    MiningNode node = grid[row, col];
                    Console.Write($"{String.Format(TextFormat, node.type.name + ":" + (Convert.ToInt32(node.type.active)).ToString())}");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\r\n");
        }

    }
}
