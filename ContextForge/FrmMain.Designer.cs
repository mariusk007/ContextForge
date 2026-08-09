namespace ContextForge
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            buttonBrowse = new Button();
            txtSolutionStructureResults = new RichTextBox();
            buttonLoadExclusions = new Button();
            txtCodeResults = new RichTextBox();
            tvSolutionStructure = new NoClickTree();
            tlpControls = new TableLayoutPanel();
            BtnRefresh = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnManageExclusions = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtFilter = new TextBox();
            BtnClear = new Button();
            tlpControls.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonBrowse
            // 
            buttonBrowse.Dock = DockStyle.Fill;
            buttonBrowse.Location = new Point(415, 3);
            buttonBrowse.MinimumSize = new Size(0, 30);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(200, 30);
            buttonBrowse.TabIndex = 0;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += BtnBrowse_Click;
            // 
            // txtSolutionStructureResults
            // 
            txtSolutionStructureResults.BackColor = Color.DimGray;
            txtSolutionStructureResults.Dock = DockStyle.Fill;
            txtSolutionStructureResults.ForeColor = Color.Black;
            txtSolutionStructureResults.Location = new Point(322, 23);
            txtSolutionStructureResults.Name = "txtSolutionStructureResults";
            txtSolutionStructureResults.Size = new Size(313, 295);
            txtSolutionStructureResults.TabIndex = 1;
            txtSolutionStructureResults.Text = "";
            // 
            // buttonLoadExclusions
            // 
            buttonLoadExclusions.AutoSize = true;
            buttonLoadExclusions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLoadExclusions.Dock = DockStyle.Fill;
            buttonLoadExclusions.Location = new Point(3, 3);
            buttonLoadExclusions.MinimumSize = new Size(0, 30);
            buttonLoadExclusions.Name = "buttonLoadExclusions";
            buttonLoadExclusions.Size = new Size(400, 30);
            buttonLoadExclusions.TabIndex = 8;
            buttonLoadExclusions.Text = "Load Exclusions";
            buttonLoadExclusions.UseVisualStyleBackColor = true;
            buttonLoadExclusions.Click += BtnLoadExclusions_Click;
            // 
            // txtCodeResults
            // 
            txtCodeResults.BackColor = Color.DimGray;
            txtCodeResults.Dock = DockStyle.Fill;
            txtCodeResults.ForeColor = Color.Black;
            txtCodeResults.Location = new Point(641, 23);
            txtCodeResults.Name = "txtCodeResults";
            txtCodeResults.Size = new Size(314, 295);
            txtCodeResults.TabIndex = 9;
            txtCodeResults.Text = "";
            // 
            // tvSolutionStructure
            // 
            tvSolutionStructure.BackColor = Color.DimGray;
            tvSolutionStructure.Dock = DockStyle.Fill;
            tvSolutionStructure.ForeColor = Color.Black;
            tvSolutionStructure.Location = new Point(3, 23);
            tvSolutionStructure.Name = "tvSolutionStructure";
            tvSolutionStructure.Size = new Size(313, 295);
            tvSolutionStructure.TabIndex = 10;

            // 
            // tlpControls
            // 
            tlpControls.AutoSize = true;
            tlpControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpControls.ColumnCount = 3;
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpControls.Controls.Add(BtnClear, 0, 1);
            tlpControls.Controls.Add(BtnRefresh, 0, 0);
            tlpControls.Controls.Add(tableLayoutPanel2, 1, 1);
            tlpControls.Controls.Add(btnManageExclusions, 1, 0);
            tlpControls.Controls.Add(buttonBrowse, 2, 0);
            tlpControls.Location = new Point(331, 3);
            tlpControls.Name = "tlpControls";
            tlpControls.RowCount = 2;
            tlpControls.RowStyles.Add(new RowStyle());
            tlpControls.RowStyles.Add(new RowStyle());
            tlpControls.Size = new Size(618, 78);
            tlpControls.TabIndex = 11;
            // 
            // BtnRefresh
            // 
            BtnRefresh.AutoSize = true;
            BtnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRefresh.Dock = DockStyle.Fill;
            BtnRefresh.Location = new Point(3, 3);
            BtnRefresh.MinimumSize = new Size(0, 30);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(200, 30);
            BtnRefresh.TabIndex = 13;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tlpControls.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(buttonLoadExclusions, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(209, 39);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(406, 36);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // btnManageExclusions
            // 
            btnManageExclusions.AutoSize = true;
            btnManageExclusions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnManageExclusions.Dock = DockStyle.Fill;
            btnManageExclusions.Location = new Point(209, 3);
            btnManageExclusions.MinimumSize = new Size(0, 30);
            btnManageExclusions.Name = "btnManageExclusions";
            btnManageExclusions.Size = new Size(200, 30);
            btnManageExclusions.TabIndex = 14;
            btnManageExclusions.Text = "Manage Exclusions";
            btnManageExclusions.UseVisualStyleBackColor = true;
            btnManageExclusions.Click += BtnManageExclusions_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.BackColor = Color.Transparent;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel3.Controls.Add(txtCodeResults, 2, 1);
            tableLayoutPanel3.Controls.Add(txtSolutionStructureResults, 1, 1);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel3.Controls.Add(tvSolutionStructure, 0, 1);
            tableLayoutPanel3.Controls.Add(txtFilter, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(958, 411);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.FromArgb(15, 15, 15);
            tableLayoutPanel3.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Controls.Add(tlpControls);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 324);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(952, 84);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // txtFilter
            // 
            txtFilter.Dock = DockStyle.Fill;
            txtFilter.Location = new Point(3, 3);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(313, 23);
            txtFilter.TabIndex = 15;
            // 
            // BtnClear
            // 
            BtnClear.AutoSize = true;
            BtnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnClear.Dock = DockStyle.Fill;
            BtnClear.Location = new Point(3, 39);
            BtnClear.MinimumSize = new Size(0, 30);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(200, 36);
            BtnClear.TabIndex = 15;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(958, 411);
            Controls.Add(tableLayoutPanel3);
            Name = "FrmMain";
            Text = "Directory Browser";
            WindowState = FormWindowState.Maximized;
            tlpControls.ResumeLayout(false);
            tlpControls.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.RichTextBox txtSolutionStructureResults;
        private System.Windows.Forms.Button buttonLoadExclusions;
        private RichTextBox txtCodeResults;
        private NoClickTree tvSolutionStructure;
        private TableLayoutPanel tlpControls;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BtnRefresh;
        private Button btnManageExclusions;
        private TextBox txtFilter;
        private Button BtnClear;
    }
}