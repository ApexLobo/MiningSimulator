using Microsoft.VisualBasic.Devices;
using MiningSimulator.Properties;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using static MiningSimulator.MiningNodeType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiningSimulator {
    // Define the delegate for the stats changed event
    public delegate void StatisticsChangedEventHandler();

    public partial class frmMain : Form {
        public MiningNodeGrid miningNodeGrid { get; set; }
        public bool minerActive { get; set; }
        private int depthToMine { get; set; } = 0;
        private int picksToUse { get; set; } = 0;
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            // Subscribe to the stats changed event
            Stats.statisticsChanged += statsStatisticsChanged;

            // Initialize the labels
            updateStatisticsLabels();

            //Double buffer the datagridview to avoid flickering
            dataGridViewNodes.DoubleBuffered(true);
        }
        private void statsStatisticsChanged() {
            // Update the labels whenever the statistics change
            updateStatisticsLabels();
        }
        private void updateStatisticsLabels() {
            try {
                if (this.InvokeRequired) {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(updateStatisticsLabels));
                    return;
                }
            } catch (Exception ex) {
            }

            lblTotalDirtMined.Text = $"Dirt Mined: {Stats.totalDirtMined}";
            lblTotalLightRockMined.Text = $"Light_Rock Mined: {Stats.totalLightRockMined}";
            lblTotalDarkRockMined.Text = $"Dark_Rock Mined: {Stats.totalDarkRockMined}";
            lblTotalSolidRockMined.Text = $"Solid_Rock Mined: {Stats.totalSolidRockMined}";

            lblTotalDiamondT1Mined.Text = $"Diamond_T1 Mined: {Stats.totalDiamondsT1Mined}";
            lblTotalDiamondT2Mined.Text = $"Diamond_T2 Mined: {Stats.totalDiamondsT2Mined}";
            lblTotalDiamondT3Mined.Text = $"Diamond_T3 Mined: {Stats.totalDiamondsT3Mined}";
            lblTotalDiamondsMined.Text = $"Diamonds Mined: {Stats.totalDiamondValueMined}";

            lblTotalRedDiamondT1Mined.Text = $"Red_Diamond_T1 Mined: {Stats.totalRedDiamondsT1Mined}";
            lblTotalRedDiamondT2Mined.Text = $"Red_Diamond_T2 Mined: {Stats.totalRedDiamondsT2Mined}";
            lblTotalRedDiamondT3Mined.Text = $"Red_Diamond_T3 Mined: {Stats.totalRedDiamondsT3Mined}";
            lblTotalRedDiamondsMined.Text = $"Red Diamonds Mined: {Stats.totalRedDiamondValueMined}";

            lblTotalRuneT1Mined.Text = $"Rune_T1 Mined: {Stats.totalRunesT1Mined}";
            lblTotalRuneT2Mined.Text = $"Rune_T2 Mined: {Stats.totalRunesT2Mined}";
            lblTotalRuneT3Mined.Text = $"Rune_T3 Mined: {Stats.totalRunesT3Mined}";

            lblTotalPicksUsed.Text = $"Picks Used: {Stats.totalPicksUsed}";
            lblDepthMined.Text = $"Depth: {Stats.totalDepthMined}";
        }

        private void btnGenerateGrid_Click(object sender, EventArgs e) {
            this.miningNodeGrid = new MiningNodeGrid(5, 7);
            miningNodeGrid.initGrid();

            // Subscribe to the GridUpdated event
            miningNodeGrid.gridUpdatedEvent += gridUpdatedHandler;

            initDataGridView();
            populateDataGridView();

            miningNodeGrid.findActiveNodes();

            // Print the grid activity to the console
            //nodeGrid.printGridActivityToConsole();
        }
        private void initDataGridView() {
            dataGridViewNodes.AutoGenerateColumns = false;
            for (int i = 0; i < miningNodeGrid.cols; i++) {
                DataGridViewImageColumn column = new DataGridViewImageColumn();
                // Set the width of each column
                column.Width = 88;
                column.ImageLayout = DataGridViewImageCellLayout.Normal;
                dataGridViewNodes.Columns.Add(column);
            }

            // Set the row count
            dataGridViewNodes.RowCount = miningNodeGrid.rows;

            // Set the height of each row
            for (int i = 0; i < miningNodeGrid.rows; i++) {
                dataGridViewNodes.Rows[i].Height = 88;
            }

            // Set the column and row header size modes to disable resizing
            dataGridViewNodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewNodes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }
        private void populateDataGridView() {
            for (int i = 0; i < miningNodeGrid.rows; i++) {
                for (int j = 0; j < miningNodeGrid.cols; j++) {
                    dataGridViewNodes.Rows[i].Cells[j].Value = miningNodeGrid.grid[i, j].type.typeImage;
                }
            }
        }
        private void dataGridViewNodes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                MiningNode node = miningNodeGrid.grid[e.RowIndex, e.ColumnIndex];

                // Get the background image for the cell
                Image backgroundImage = Resources.empty_space;

                // Draw the background image
                if (backgroundImage != null) {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.DrawImage(backgroundImage, e.CellBounds);
                }

                // Get the foreground image
                Image originalImage = dataGridViewNodes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Image;
                if (originalImage != null) {
                    // Create a copy of the original image
                    Image adjustedImage = new Bitmap(originalImage.Width, originalImage.Height);

                    // Create a color matrix that adjusts the image brightness for inactive nodes
                    float brightnessFactor = node.type.active ? 1.0f : 0.5f;
                    float[][] matrixItems ={
                        new float[] {brightnessFactor, 0, 0, 0, 0},
                        new float[] {0, brightnessFactor, 0, 0, 0},
                        new float[] {0, 0, brightnessFactor, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    };
                    ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                    // Create an image attributes object and set the color matrix
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix);

                    // Draw the adjusted image
                    using (Graphics graphics = Graphics.FromImage(adjustedImage)) {
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
                    }

                    // Draw the adjusted image onto the cell
                    e.Graphics.DrawImage(adjustedImage, e.CellBounds.Location);
                }

                e.Handled = true;
            }
        }

        private void dataGridViewNodes_CellClick(object sender, DataGridViewCellEventArgs e) {
            int clickedRow = e.RowIndex;
            int clickedCol = e.ColumnIndex;

            // Check if the clicked cell is active
            if (clickedRow >= 0 && clickedRow < miningNodeGrid.rows && clickedCol >= 0 && clickedCol < miningNodeGrid.cols && miningNodeGrid.grid[clickedRow, clickedCol].type.active) {
                miningNodeGrid.clickNode(clickedRow, clickedCol);
            }
        }


        // Method to handle the grid updated event
        private void gridUpdatedHandler(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                try {
                    this.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        gridUpdatedHandler(sender, e);
                    });
                } catch (Exception ex) {
                }
                return;
            }
            // Refresh the DataGridView to reflect the changes
            populateDataGridView();
            dataGridViewNodes.Invalidate();
            dataGridViewNodes.Update();
        }

        private void btnPrintGrid_Click(object sender, EventArgs e) {
            miningNodeGrid.printGridDetailsToConsole();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e) {
            // Unsubscribe from the events to avoid memory leaks
            Stats.statisticsChanged -= statsStatisticsChanged;
            if (miningNodeGrid != null) {
                miningNodeGrid.gridUpdatedEvent -= gridUpdatedHandler;
            }
        }

        private void btnStartMining_Click(object sender, EventArgs e) {
            minerActive = !minerActive;

            if (!backgroundWorkerMiner.IsBusy) {
                backgroundWorkerMiner.RunWorkerAsync();
            }
        }

        private void backgroundWorkerMiner_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            IPathfinding pathfinding = new DijkstraPathfindingComplete();
            IExecutePathfinding myExecutePathFinding = new MyExecutePathfindingComplete();

            bool depthMining = depthToMine > 0;
            bool pickMining = picksToUse > 0;

            if (miningNodeGrid == null) {
                MessageBox.Show("You must generate a grid first");
                return;
            }

            while (minerActive && !backgroundWorkerMiner.CancellationPending) {
                if (depthMining && Stats.totalDepthMined >= depthToMine) {
                    minerActive = false;
                    // Exit the loop if total depth mined meets or exceeds depthToMine
                    break;
                }
                if (pickMining && Stats.totalPicksUsed >= picksToUse) {
                    minerActive = false;
                    // Exit the loop if total depth mined meets or exceeds picksToUse
                    break;
                }

                bool mineDown = myExecutePathFinding.mineInterestingItems(miningNodeGrid, pathfinding);

                if (mineDown) {
                    bool mineDownComplete = myExecutePathFinding.mineDownOneLevel(miningNodeGrid, pathfinding);

                    if (!mineDownComplete) {
                        break;
                    }
                }
            }
            Stats.printStatistics();

        }

        private void backgroundWorkerMiner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            enableControls();
        }
        private void btnMineToDepth_Click(object sender, EventArgs e) {
            depthToMine = (int)numericUpDownDepth.Value;
            minerActive = !minerActive;
            disableControls();
            if (!backgroundWorkerMiner.IsBusy) {
                backgroundWorkerMiner.RunWorkerAsync();
            }
        }

        private void btnMineToPickCount_Click(object sender, EventArgs e) {
            picksToUse = (int)numericUpDownPickCount.Value;
            minerActive = !minerActive;

            disableControls();
            if (!backgroundWorkerMiner.IsBusy) {
                backgroundWorkerMiner.RunWorkerAsync();
            }
        }

        private void enableControls() {
            numericUpDownPickDamage.Enabled = true;

            btnGenerateGrid.Enabled = true;
            btnPrintGrid.Enabled = true;
            btnStartMining.Enabled = true;
            numericUpDownMiningSpeed.Enabled = true;

            btnMineToDepth.Enabled = true;
            numericUpDownDepth.Enabled = true;
            btnMineToPickCount.Enabled = true;
            numericUpDownPickCount.Enabled = true;
        }
        private void disableControls() {
            numericUpDownPickDamage.Enabled = false;

            btnGenerateGrid.Enabled = false;
            btnPrintGrid.Enabled = false;
            btnStartMining.Enabled = false;
            numericUpDownMiningSpeed.Enabled = false;

            btnMineToDepth.Enabled = false;
            numericUpDownDepth.Enabled = false;
            btnMineToPickCount.Enabled = false;
            numericUpDownPickCount.Enabled = false;
        }
        private void numericUpDownMiningSpeed_ValueChanged(object sender, EventArgs e) {
            // Update the TextBox when the NumericUpDown value changes
            numericUpDownMiningSpeed.Text = numericUpDownMiningSpeed.Value.ToString();
            Globals.miningDelay = (int)numericUpDownMiningSpeed.Value;
        }
        private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e) {
            // Allow digits, backspace, and arrow keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void numericUpDownDepth_ValueChanged(object sender, EventArgs e) {
            // Update the TextBox when the NumericUpDown value changes
            numericUpDownDepth.Text = numericUpDownDepth.Value.ToString();
            depthToMine = (int)numericUpDownDepth.Value;
        }
        private void numericUpDownPickDamage_ValueChanged(object sender, EventArgs e) {
            // Update the TextBox when the NumericUpDown value changes
            numericUpDownPickDamage.Text = numericUpDownPickDamage.Value.ToString();
            Globals.pickDamage = (int)numericUpDownPickDamage.Value;
        }
        private void numericUpDownPickCount_ValueChanged(object sender, EventArgs e) {
            numericUpDownPickCount.Text = numericUpDownPickCount.Value.ToString();
            picksToUse = (int)numericUpDownPickDamage.Value;
        }
    }
}
