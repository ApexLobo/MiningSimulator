namespace MiningSimulator {
    partial class frmMain {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panelMine = new Panel();
            dataGridViewNodes = new DataGridView();
            panelStats = new Panel();
            lblTotalDirtMined = new Label();
            lblTotalLightRockMined = new Label();
            lblDepthMined = new Label();
            lblTotalDarkRockMined = new Label();
            lblTotalPicksUsed = new Label();
            lblTotalSolidRockMined = new Label();
            lblTotalRuneT3Mined = new Label();
            lblTotalDiamondT1Mined = new Label();
            lblTotalRuneT2Mined = new Label();
            lblTotalDiamondT2Mined = new Label();
            lblTotalRuneT1Mined = new Label();
            lblTotalDiamondT3Mined = new Label();
            lblTotalRedDiamondsMined = new Label();
            lblTotalRedDiamondT1Mined = new Label();
            lblTotalDiamondsMined = new Label();
            lblTotalRedDiamondT2Mined = new Label();
            lblTotalRedDiamondT3Mined = new Label();
            panelOptions = new Panel();
            lblPickDamage = new Label();
            lblMineToPickCount = new Label();
            btnGenerateGrid = new Button();
            numericUpDownPickCount = new NumericUpDown();
            btnPrintGrid = new Button();
            btnMineToPickCount = new Button();
            btnStartMining = new Button();
            lblMiningSpeed = new Label();
            numericUpDownPickDamage = new NumericUpDown();
            numericUpDownMiningSpeed = new NumericUpDown();
            btnMineToDepth = new Button();
            lblDepth = new Label();
            numericUpDownDepth = new NumericUpDown();
            backgroundWorkerMiner = new System.ComponentModel.BackgroundWorker();
            panelUI = new Panel();
            panelMine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).BeginInit();
            panelStats.SuspendLayout();
            panelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPickCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPickDamage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMiningSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDepth).BeginInit();
            panelUI.SuspendLayout();
            SuspendLayout();
            // 
            // panelMine
            // 
            panelMine.AutoSize = true;
            panelMine.BorderStyle = BorderStyle.FixedSingle;
            panelMine.Controls.Add(dataGridViewNodes);
            panelMine.Location = new Point(5, 5);
            panelMine.Margin = new Padding(5);
            panelMine.Name = "panelMine";
            panelMine.Padding = new Padding(5);
            panelMine.Size = new Size(638, 462);
            panelMine.TabIndex = 0;
            // 
            // dataGridViewNodes
            // 
            dataGridViewNodes.AllowUserToAddRows = false;
            dataGridViewNodes.AllowUserToDeleteRows = false;
            dataGridViewNodes.AllowUserToResizeColumns = false;
            dataGridViewNodes.AllowUserToResizeRows = false;
            dataGridViewNodes.BorderStyle = BorderStyle.None;
            dataGridViewNodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNodes.ColumnHeadersVisible = false;
            dataGridViewNodes.Location = new Point(10, 10);
            dataGridViewNodes.Name = "dataGridViewNodes";
            dataGridViewNodes.RowHeadersVisible = false;
            dataGridViewNodes.ScrollBars = ScrollBars.None;
            dataGridViewNodes.Size = new Size(618, 442);
            dataGridViewNodes.TabIndex = 1;
            dataGridViewNodes.CellClick += dataGridViewNodes_CellClick;
            dataGridViewNodes.CellPainting += dataGridViewNodes_CellPainting;
            // 
            // panelStats
            // 
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(lblTotalDirtMined);
            panelStats.Controls.Add(lblTotalLightRockMined);
            panelStats.Controls.Add(lblDepthMined);
            panelStats.Controls.Add(lblTotalDarkRockMined);
            panelStats.Controls.Add(lblTotalPicksUsed);
            panelStats.Controls.Add(lblTotalSolidRockMined);
            panelStats.Controls.Add(lblTotalRuneT3Mined);
            panelStats.Controls.Add(lblTotalDiamondT1Mined);
            panelStats.Controls.Add(lblTotalRuneT2Mined);
            panelStats.Controls.Add(lblTotalDiamondT2Mined);
            panelStats.Controls.Add(lblTotalRuneT1Mined);
            panelStats.Controls.Add(lblTotalDiamondT3Mined);
            panelStats.Controls.Add(lblTotalRedDiamondsMined);
            panelStats.Controls.Add(lblTotalRedDiamondT1Mined);
            panelStats.Controls.Add(lblTotalDiamondsMined);
            panelStats.Controls.Add(lblTotalRedDiamondT2Mined);
            panelStats.Controls.Add(lblTotalRedDiamondT3Mined);
            panelStats.Location = new Point(5, 475);
            panelStats.Name = "panelStats";
            panelStats.Padding = new Padding(5);
            panelStats.Size = new Size(796, 73);
            panelStats.TabIndex = 33;
            // 
            // lblTotalDirtMined
            // 
            lblTotalDirtMined.AutoSize = true;
            lblTotalDirtMined.Location = new Point(2, 5);
            lblTotalDirtMined.Name = "lblTotalDirtMined";
            lblTotalDirtMined.Size = new Size(75, 15);
            lblTotalDirtMined.TabIndex = 3;
            lblTotalDirtMined.Text = "Dirt Mined: 0";
            // 
            // lblTotalLightRockMined
            // 
            lblTotalLightRockMined.AutoSize = true;
            lblTotalLightRockMined.Location = new Point(2, 20);
            lblTotalLightRockMined.Name = "lblTotalLightRockMined";
            lblTotalLightRockMined.Size = new Size(114, 15);
            lblTotalLightRockMined.TabIndex = 4;
            lblTotalLightRockMined.Text = "Light_Rock Mined: 0";
            // 
            // lblDepthMined
            // 
            lblDepthMined.AutoSize = true;
            lblDepthMined.Location = new Point(665, 20);
            lblDepthMined.Name = "lblDepthMined";
            lblDepthMined.Size = new Size(51, 15);
            lblDepthMined.TabIndex = 26;
            lblDepthMined.Text = "Depth: 0";
            // 
            // lblTotalDarkRockMined
            // 
            lblTotalDarkRockMined.AutoSize = true;
            lblTotalDarkRockMined.Location = new Point(2, 35);
            lblTotalDarkRockMined.Name = "lblTotalDarkRockMined";
            lblTotalDarkRockMined.Size = new Size(111, 15);
            lblTotalDarkRockMined.TabIndex = 5;
            lblTotalDarkRockMined.Text = "Dark_Rock Mined: 0";
            // 
            // lblTotalPicksUsed
            // 
            lblTotalPicksUsed.AutoSize = true;
            lblTotalPicksUsed.Location = new Point(665, 5);
            lblTotalPicksUsed.Name = "lblTotalPicksUsed";
            lblTotalPicksUsed.Size = new Size(75, 15);
            lblTotalPicksUsed.TabIndex = 23;
            lblTotalPicksUsed.Text = "Picks Used: 0";
            // 
            // lblTotalSolidRockMined
            // 
            lblTotalSolidRockMined.AutoSize = true;
            lblTotalSolidRockMined.Location = new Point(2, 50);
            lblTotalSolidRockMined.Name = "lblTotalSolidRockMined";
            lblTotalSolidRockMined.Size = new Size(113, 15);
            lblTotalSolidRockMined.TabIndex = 6;
            lblTotalSolidRockMined.Text = "Solid_Rock Mined: 0";
            // 
            // lblTotalRuneT3Mined
            // 
            lblTotalRuneT3Mined.AutoSize = true;
            lblTotalRuneT3Mined.Location = new Point(524, 35);
            lblTotalRuneT3Mined.Name = "lblTotalRuneT3Mined";
            lblTotalRuneT3Mined.Size = new Size(100, 15);
            lblTotalRuneT3Mined.TabIndex = 17;
            lblTotalRuneT3Mined.Text = "Rune_T3 Mined: 0";
            // 
            // lblTotalDiamondT1Mined
            // 
            lblTotalDiamondT1Mined.AutoSize = true;
            lblTotalDiamondT1Mined.Location = new Point(161, 5);
            lblTotalDiamondT1Mined.Name = "lblTotalDiamondT1Mined";
            lblTotalDiamondT1Mined.Size = new Size(122, 15);
            lblTotalDiamondT1Mined.TabIndex = 7;
            lblTotalDiamondT1Mined.Text = "Diamond_T1 Mined: 0";
            // 
            // lblTotalRuneT2Mined
            // 
            lblTotalRuneT2Mined.AutoSize = true;
            lblTotalRuneT2Mined.Location = new Point(524, 20);
            lblTotalRuneT2Mined.Name = "lblTotalRuneT2Mined";
            lblTotalRuneT2Mined.Size = new Size(100, 15);
            lblTotalRuneT2Mined.TabIndex = 16;
            lblTotalRuneT2Mined.Text = "Rune_T2 Mined: 0";
            // 
            // lblTotalDiamondT2Mined
            // 
            lblTotalDiamondT2Mined.AutoSize = true;
            lblTotalDiamondT2Mined.Location = new Point(161, 20);
            lblTotalDiamondT2Mined.Name = "lblTotalDiamondT2Mined";
            lblTotalDiamondT2Mined.Size = new Size(122, 15);
            lblTotalDiamondT2Mined.TabIndex = 8;
            lblTotalDiamondT2Mined.Text = "Diamond_T2 Mined: 0";
            // 
            // lblTotalRuneT1Mined
            // 
            lblTotalRuneT1Mined.AutoSize = true;
            lblTotalRuneT1Mined.Location = new Point(524, 5);
            lblTotalRuneT1Mined.Name = "lblTotalRuneT1Mined";
            lblTotalRuneT1Mined.Size = new Size(100, 15);
            lblTotalRuneT1Mined.TabIndex = 15;
            lblTotalRuneT1Mined.Text = "Rune_T1 Mined: 0";
            // 
            // lblTotalDiamondT3Mined
            // 
            lblTotalDiamondT3Mined.AutoSize = true;
            lblTotalDiamondT3Mined.Location = new Point(161, 35);
            lblTotalDiamondT3Mined.Name = "lblTotalDiamondT3Mined";
            lblTotalDiamondT3Mined.Size = new Size(122, 15);
            lblTotalDiamondT3Mined.TabIndex = 9;
            lblTotalDiamondT3Mined.Text = "Diamond_T3 Mined: 0";
            // 
            // lblTotalRedDiamondsMined
            // 
            lblTotalRedDiamondsMined.AutoSize = true;
            lblTotalRedDiamondsMined.Location = new Point(338, 50);
            lblTotalRedDiamondsMined.Name = "lblTotalRedDiamondsMined";
            lblTotalRedDiamondsMined.Size = new Size(133, 15);
            lblTotalRedDiamondsMined.TabIndex = 14;
            lblTotalRedDiamondsMined.Text = "Red Diamonds Mined: 0";
            // 
            // lblTotalRedDiamondT1Mined
            // 
            lblTotalRedDiamondT1Mined.AutoSize = true;
            lblTotalRedDiamondT1Mined.Location = new Point(338, 5);
            lblTotalRedDiamondT1Mined.Name = "lblTotalRedDiamondT1Mined";
            lblTotalRedDiamondT1Mined.Size = new Size(147, 15);
            lblTotalRedDiamondT1Mined.TabIndex = 10;
            lblTotalRedDiamondT1Mined.Text = "Red_Diamond_T1 Mined: 0";
            // 
            // lblTotalDiamondsMined
            // 
            lblTotalDiamondsMined.AutoSize = true;
            lblTotalDiamondsMined.Location = new Point(161, 50);
            lblTotalDiamondsMined.Name = "lblTotalDiamondsMined";
            lblTotalDiamondsMined.Size = new Size(110, 15);
            lblTotalDiamondsMined.TabIndex = 13;
            lblTotalDiamondsMined.Text = "Diamonds Mined: 0";
            // 
            // lblTotalRedDiamondT2Mined
            // 
            lblTotalRedDiamondT2Mined.AutoSize = true;
            lblTotalRedDiamondT2Mined.Location = new Point(338, 20);
            lblTotalRedDiamondT2Mined.Name = "lblTotalRedDiamondT2Mined";
            lblTotalRedDiamondT2Mined.Size = new Size(147, 15);
            lblTotalRedDiamondT2Mined.TabIndex = 11;
            lblTotalRedDiamondT2Mined.Text = "Red_Diamond_T2 Mined: 0";
            // 
            // lblTotalRedDiamondT3Mined
            // 
            lblTotalRedDiamondT3Mined.AutoSize = true;
            lblTotalRedDiamondT3Mined.Location = new Point(338, 35);
            lblTotalRedDiamondT3Mined.Name = "lblTotalRedDiamondT3Mined";
            lblTotalRedDiamondT3Mined.Size = new Size(147, 15);
            lblTotalRedDiamondT3Mined.TabIndex = 12;
            lblTotalRedDiamondT3Mined.Text = "Red_Diamond_T3 Mined: 0";
            // 
            // panelOptions
            // 
            panelOptions.BorderStyle = BorderStyle.FixedSingle;
            panelOptions.Controls.Add(lblPickDamage);
            panelOptions.Controls.Add(lblMineToPickCount);
            panelOptions.Controls.Add(btnGenerateGrid);
            panelOptions.Controls.Add(numericUpDownPickCount);
            panelOptions.Controls.Add(btnPrintGrid);
            panelOptions.Controls.Add(btnMineToPickCount);
            panelOptions.Controls.Add(btnStartMining);
            panelOptions.Controls.Add(lblMiningSpeed);
            panelOptions.Controls.Add(numericUpDownPickDamage);
            panelOptions.Controls.Add(numericUpDownMiningSpeed);
            panelOptions.Controls.Add(btnMineToDepth);
            panelOptions.Controls.Add(lblDepth);
            panelOptions.Controls.Add(numericUpDownDepth);
            panelOptions.Location = new Point(649, 5);
            panelOptions.Name = "panelOptions";
            panelOptions.Padding = new Padding(5);
            panelOptions.Size = new Size(152, 462);
            panelOptions.TabIndex = 32;
            // 
            // lblPickDamage
            // 
            lblPickDamage.AutoSize = true;
            lblPickDamage.Location = new Point(8, 5);
            lblPickDamage.Name = "lblPickDamage";
            lblPickDamage.Size = new Size(78, 15);
            lblPickDamage.TabIndex = 28;
            lblPickDamage.Text = "Pick damage:";
            // 
            // lblMineToPickCount
            // 
            lblMineToPickCount.AutoSize = true;
            lblMineToPickCount.Location = new Point(8, 411);
            lblMineToPickCount.Name = "lblMineToPickCount";
            lblMineToPickCount.Size = new Size(37, 15);
            lblMineToPickCount.TabIndex = 31;
            lblMineToPickCount.Text = "Picks:";
            // 
            // btnGenerateGrid
            // 
            btnGenerateGrid.Location = new Point(8, 52);
            btnGenerateGrid.Name = "btnGenerateGrid";
            btnGenerateGrid.Size = new Size(133, 23);
            btnGenerateGrid.TabIndex = 1;
            btnGenerateGrid.Text = "Generate grid";
            btnGenerateGrid.UseVisualStyleBackColor = true;
            btnGenerateGrid.Click += btnGenerateGrid_Click;
            // 
            // numericUpDownPickCount
            // 
            numericUpDownPickCount.Location = new Point(8, 429);
            numericUpDownPickCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPickCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPickCount.Name = "numericUpDownPickCount";
            numericUpDownPickCount.Size = new Size(133, 23);
            numericUpDownPickCount.TabIndex = 30;
            numericUpDownPickCount.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownPickCount.ValueChanged += numericUpDownPickCount_ValueChanged;
            numericUpDownPickCount.KeyPress += numericUpDown_KeyPress;
            // 
            // btnPrintGrid
            // 
            btnPrintGrid.Location = new Point(8, 81);
            btnPrintGrid.Name = "btnPrintGrid";
            btnPrintGrid.Size = new Size(133, 23);
            btnPrintGrid.TabIndex = 2;
            btnPrintGrid.Text = "Print grid";
            btnPrintGrid.UseVisualStyleBackColor = true;
            btnPrintGrid.Click += btnPrintGrid_Click;
            // 
            // btnMineToPickCount
            // 
            btnMineToPickCount.Location = new Point(8, 385);
            btnMineToPickCount.Name = "btnMineToPickCount";
            btnMineToPickCount.Size = new Size(133, 23);
            btnMineToPickCount.TabIndex = 29;
            btnMineToPickCount.Text = "Mine to pick count";
            btnMineToPickCount.UseVisualStyleBackColor = true;
            btnMineToPickCount.Click += btnMineToPickCount_Click;
            // 
            // btnStartMining
            // 
            btnStartMining.Location = new Point(8, 110);
            btnStartMining.Name = "btnStartMining";
            btnStartMining.Size = new Size(133, 23);
            btnStartMining.TabIndex = 18;
            btnStartMining.Text = "Start mining";
            btnStartMining.UseVisualStyleBackColor = true;
            btnStartMining.Click += btnStartMining_Click;
            // 
            // lblMiningSpeed
            // 
            lblMiningSpeed.AutoSize = true;
            lblMiningSpeed.Location = new Point(8, 136);
            lblMiningSpeed.Name = "lblMiningSpeed";
            lblMiningSpeed.Size = new Size(109, 15);
            lblMiningSpeed.TabIndex = 20;
            lblMiningSpeed.Text = "Mining speed (ms):";
            // 
            // numericUpDownPickDamage
            // 
            numericUpDownPickDamage.Location = new Point(8, 23);
            numericUpDownPickDamage.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownPickDamage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPickDamage.Name = "numericUpDownPickDamage";
            numericUpDownPickDamage.Size = new Size(133, 23);
            numericUpDownPickDamage.TabIndex = 27;
            numericUpDownPickDamage.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownPickDamage.ValueChanged += numericUpDownPickDamage_ValueChanged;
            numericUpDownPickDamage.KeyPress += numericUpDown_KeyPress;
            // 
            // numericUpDownMiningSpeed
            // 
            numericUpDownMiningSpeed.Location = new Point(8, 154);
            numericUpDownMiningSpeed.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMiningSpeed.Name = "numericUpDownMiningSpeed";
            numericUpDownMiningSpeed.Size = new Size(133, 23);
            numericUpDownMiningSpeed.TabIndex = 21;
            numericUpDownMiningSpeed.ValueChanged += numericUpDownMiningSpeed_ValueChanged;
            numericUpDownMiningSpeed.KeyPress += numericUpDown_KeyPress;
            // 
            // btnMineToDepth
            // 
            btnMineToDepth.Location = new Point(8, 312);
            btnMineToDepth.Name = "btnMineToDepth";
            btnMineToDepth.Size = new Size(133, 23);
            btnMineToDepth.TabIndex = 22;
            btnMineToDepth.Text = "Mine to depth";
            btnMineToDepth.UseVisualStyleBackColor = true;
            btnMineToDepth.Click += btnMineToDepth_Click;
            // 
            // lblDepth
            // 
            lblDepth.AutoSize = true;
            lblDepth.Location = new Point(8, 338);
            lblDepth.Name = "lblDepth";
            lblDepth.Size = new Size(42, 15);
            lblDepth.TabIndex = 25;
            lblDepth.Text = "Depth:";
            // 
            // numericUpDownDepth
            // 
            numericUpDownDepth.Location = new Point(8, 356);
            numericUpDownDepth.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownDepth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDepth.Name = "numericUpDownDepth";
            numericUpDownDepth.Size = new Size(133, 23);
            numericUpDownDepth.TabIndex = 24;
            numericUpDownDepth.Value = new decimal(new int[] { 1500, 0, 0, 0 });
            numericUpDownDepth.ValueChanged += numericUpDownDepth_ValueChanged;
            numericUpDownDepth.KeyPress += numericUpDown_KeyPress;
            // 
            // backgroundWorkerMiner
            // 
            backgroundWorkerMiner.WorkerSupportsCancellation = true;
            backgroundWorkerMiner.DoWork += backgroundWorkerMiner_DoWork;
            backgroundWorkerMiner.RunWorkerCompleted += backgroundWorkerMiner_RunWorkerCompleted;
            // 
            // panelUI
            // 
            panelUI.Controls.Add(panelStats);
            panelUI.Controls.Add(panelOptions);
            panelUI.Controls.Add(panelMine);
            panelUI.Location = new Point(10, 10);
            panelUI.Name = "panelUI";
            panelUI.Padding = new Padding(5);
            panelUI.Size = new Size(808, 553);
            panelUI.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 570);
            Controls.Add(panelUI);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            Text = "Mining Simulator";
            FormClosed += frmMain_FormClosed;
            Load += frmMain_Load;
            panelMine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelOptions.ResumeLayout(false);
            panelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPickCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPickDamage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMiningSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDepth).EndInit();
            panelUI.ResumeLayout(false);
            panelUI.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMine;
        private DataGridView dataGridViewNodes;
        private Button btnGenerateGrid;
        private Button btnPrintGrid;
        private Label lblTotalDirtMined;
        private Label lblTotalLightRockMined;
        private Label lblTotalDarkRockMined;
        private Label lblTotalSolidRockMined;
        private Label lblTotalDiamondT1Mined;
        private Label lblTotalDiamondT2Mined;
        private Label lblTotalDiamondT3Mined;
        private Label lblTotalRedDiamondT3Mined;
        private Label lblTotalRedDiamondT2Mined;
        private Label lblTotalRedDiamondT1Mined;
        private Label lblTotalDiamondsMined;
        private Label lblTotalRedDiamondsMined;
        private Label lblTotalRuneT3Mined;
        private Label lblTotalRuneT2Mined;
        private Label lblTotalRuneT1Mined;
        private Button btnStartMining;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMiner;
        private Label lblMiningSpeed;
        private NumericUpDown numericUpDownMiningSpeed;
        private Button btnMineToDepth;
        private Label lblTotalPicksUsed;
        private NumericUpDown numericUpDownDepth;
        private Label lblDepth;
        private Label lblDepthMined;
        private Label lblPickDamage;
        private NumericUpDown numericUpDownPickDamage;
        private Label lblMineToPickCount;
        private NumericUpDown numericUpDownPickCount;
        private Button btnMineToPickCount;
        private Panel panelOptions;
        private Panel panelStats;
        private Panel panelUI;
    }
}
