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
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            openFolderMenuItem = new ToolStripMenuItem();
            refreshMenuItem = new ToolStripMenuItem();
            clearMenuItem = new ToolStripMenuItem();
            fileSeparator = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            exclusionsMenu = new ToolStripMenuItem();
            manageExclusionsMenuItem = new ToolStripMenuItem();
            reloadExclusionsMenuItem = new ToolStripMenuItem();
            txtSolutionStructureResults = new RichTextBox();
            txtCodeResults = new RichTextBox();
            tvSolutionStructure = new NoClickTree();
            tableLayoutPanel3 = new TableLayoutPanel();
            txtFilter = new TextBox();
            btnRefresh = new Button();
            btnClear = new Button();
            btnCopyStructure = new Button();
            btnCopyCode = new Button();
            tlpFilterHeader = new TableLayoutPanel();
            flpEntities = new FlowLayoutPanel();
            tlpTreePanel = new TableLayoutPanel();
            lblEntities = new Label();
            editMenu = new ToolStripMenuItem();
            copyStructureMenuItem = new ToolStripMenuItem();
            copyCodeMenuItem = new ToolStripMenuItem();
            tlpFilterHeader.SuspendLayout();
            flpEntities.SuspendLayout();
            tlpTreePanel.SuspendLayout();
            menuStrip.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, exclusionsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(958, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openFolderMenuItem, refreshMenuItem, clearMenuItem, fileSeparator, exitMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Text = "&File";
            // 
            // openFolderMenuItem
            // 
            openFolderMenuItem.Name = "openFolderMenuItem";
            openFolderMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openFolderMenuItem.Text = "&Open Folder...";
            openFolderMenuItem.Click += OpenFolderMenuItem_Click;
            // 
            // refreshMenuItem
            // 
            refreshMenuItem.Name = "refreshMenuItem";
            refreshMenuItem.ShortcutKeys = Keys.F5;
            refreshMenuItem.Text = "&Refresh";
            refreshMenuItem.Click += RefreshMenuItem_Click;
            // 
            // clearMenuItem
            // 
            clearMenuItem.Name = "clearMenuItem";
            clearMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Delete;
            clearMenuItem.Text = "&Clear Selection";
            clearMenuItem.Click += ClearMenuItem_Click;
            // 
            // fileSeparator
            // 
            fileSeparator.Name = "fileSeparator";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            exitMenuItem.Text = "E&xit";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // editMenu
            // 
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { copyStructureMenuItem, copyCodeMenuItem });
            editMenu.Name = "editMenu";
            editMenu.Text = "E&dit";
            // 
            // copyStructureMenuItem
            // 
            copyStructureMenuItem.Name = "copyStructureMenuItem";
            copyStructureMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            copyStructureMenuItem.Text = "Copy &Structure";
            copyStructureMenuItem.Click += CopyStructure_Click;
            // 
            // copyCodeMenuItem
            // 
            copyCodeMenuItem.Name = "copyCodeMenuItem";
            copyCodeMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            copyCodeMenuItem.Text = "Copy &Code";
            copyCodeMenuItem.Click += CopyCode_Click;
            // 
            // exclusionsMenu
            // 
            exclusionsMenu.DropDownItems.AddRange(new ToolStripItem[] { manageExclusionsMenuItem, reloadExclusionsMenuItem });
            exclusionsMenu.Name = "exclusionsMenu";
            exclusionsMenu.Text = "&Exclusions";
            // 
            // manageExclusionsMenuItem
            // 
            manageExclusionsMenuItem.Name = "manageExclusionsMenuItem";
            manageExclusionsMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            manageExclusionsMenuItem.Text = "&Manage...";
            manageExclusionsMenuItem.Click += ManageExclusionsMenuItem_Click;
            // 
            // reloadExclusionsMenuItem
            // 
            reloadExclusionsMenuItem.Name = "reloadExclusionsMenuItem";
            reloadExclusionsMenuItem.Text = "&Reload from File";
            reloadExclusionsMenuItem.Click += ReloadExclusionsMenuItem_Click;
            // 
            // txtSolutionStructureResults
            // 
            txtSolutionStructureResults.BackColor = Color.DimGray;
            txtSolutionStructureResults.Dock = DockStyle.Fill;
            txtSolutionStructureResults.ForeColor = Color.Black;
            txtSolutionStructureResults.Name = "txtSolutionStructureResults";
            txtSolutionStructureResults.TabIndex = 2;
            txtSolutionStructureResults.Text = "";
            // 
            // txtCodeResults
            // 
            txtCodeResults.BackColor = Color.DimGray;
            txtCodeResults.Dock = DockStyle.Fill;
            txtCodeResults.ForeColor = Color.Black;
            txtCodeResults.Name = "txtCodeResults";
            txtCodeResults.TabIndex = 3;
            txtCodeResults.Text = "";
            // 
            // tvSolutionStructure
            // 
            tvSolutionStructure.BackColor = Color.DimGray;
            tvSolutionStructure.Dock = DockStyle.Fill;
            tvSolutionStructure.Margin = new Padding(0);
            tvSolutionStructure.ForeColor = Color.Black;
            tvSolutionStructure.Name = "tvSolutionStructure";
            tvSolutionStructure.TabIndex = 1;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFilter.Margin = new Padding(0, 0, 3, 0);
            txtFilter.Name = "txtFilter";
            txtFilter.PlaceholderText = "Filter files and folders";
            txtFilter.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Margin = new Padding(3, 0, 3, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += RefreshMenuItem_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.Margin = new Padding(3, 0, 0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear Selection";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += ClearMenuItem_Click;
            // 
            // btnCopyStructure
            // 
            btnCopyStructure.Anchor = AnchorStyles.Right;
            btnCopyStructure.Name = "btnCopyStructure";
            btnCopyStructure.Size = new Size(110, 23);
            btnCopyStructure.TabIndex = 5;
            btnCopyStructure.Text = "Copy Structure";
            btnCopyStructure.UseVisualStyleBackColor = true;
            btnCopyStructure.Click += CopyStructure_Click;
            // 
            // tlpFilterHeader
            // 
            tlpFilterHeader.ColumnCount = 3;
            tlpFilterHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFilterHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpFilterHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpFilterHeader.Controls.Add(txtFilter, 0, 0);
            tlpFilterHeader.Controls.Add(btnRefresh, 1, 0);
            tlpFilterHeader.Controls.Add(btnClear, 2, 0);
            tlpFilterHeader.Dock = DockStyle.Fill;
            tlpFilterHeader.Margin = new Padding(3, 3, 3, 0);
            tlpFilterHeader.Name = "tlpFilterHeader";
            tlpFilterHeader.RowCount = 1;
            tlpFilterHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFilterHeader.TabIndex = 0;
            // 
            // btnCopyCode
            // 
            btnCopyCode.Anchor = AnchorStyles.Right;
            btnCopyCode.Name = "btnCopyCode";
            btnCopyCode.Size = new Size(110, 23);
            btnCopyCode.TabIndex = 6;
            btnCopyCode.Text = "Copy Code";
            btnCopyCode.UseVisualStyleBackColor = true;
            btnCopyCode.Click += CopyCode_Click;
            // 
            // lblEntities
            // 
            lblEntities.AutoSize = true;
            lblEntities.ForeColor = Color.Gainsboro;
            lblEntities.Margin = new Padding(0, 6, 6, 0);
            lblEntities.Name = "lblEntities";
            lblEntities.Text = "Top entities:";
            // 
            // flpEntities
            // 
            flpEntities.AutoSize = true;
            flpEntities.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpEntities.Controls.Add(lblEntities);
            flpEntities.Dock = DockStyle.Fill;
            flpEntities.Margin = new Padding(0);
            flpEntities.MinimumSize = new Size(0, 29);
            flpEntities.Name = "flpEntities";
            flpEntities.TabIndex = 7;
            flpEntities.WrapContents = true;
            // 
            // tlpTreePanel
            // 
            tlpTreePanel.ColumnCount = 1;
            tlpTreePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTreePanel.Controls.Add(flpEntities, 0, 0);
            tlpTreePanel.Controls.Add(tvSolutionStructure, 0, 1);
            tlpTreePanel.Dock = DockStyle.Fill;
            tlpTreePanel.Name = "tlpTreePanel";
            tlpTreePanel.RowCount = 2;
            tlpTreePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpTreePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTreePanel.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Transparent;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.Controls.Add(tlpFilterHeader, 0, 0);
            tableLayoutPanel3.Controls.Add(btnCopyStructure, 1, 0);
            tableLayoutPanel3.Controls.Add(btnCopyCode, 2, 0);
            tableLayoutPanel3.Controls.Add(tlpTreePanel, 0, 1);
            tableLayoutPanel3.Controls.Add(txtSolutionStructureResults, 1, 1);
            tableLayoutPanel3.Controls.Add(txtCodeResults, 2, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 24);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(958, 387);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(958, 411);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FrmMain";
            Text = "ContextForge";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tlpFilterHeader.ResumeLayout(false);
            tlpFilterHeader.PerformLayout();
            flpEntities.ResumeLayout(false);
            flpEntities.PerformLayout();
            tlpTreePanel.ResumeLayout(false);
            tlpTreePanel.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openFolderMenuItem;
        private ToolStripMenuItem refreshMenuItem;
        private ToolStripMenuItem clearMenuItem;
        private ToolStripSeparator fileSeparator;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem exclusionsMenu;
        private ToolStripMenuItem manageExclusionsMenuItem;
        private ToolStripMenuItem reloadExclusionsMenuItem;
        private RichTextBox txtSolutionStructureResults;
        private RichTextBox txtCodeResults;
        private NoClickTree tvSolutionStructure;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txtFilter;
        private Button btnRefresh;
        private Button btnClear;
        private Button btnCopyStructure;
        private Button btnCopyCode;
        private TableLayoutPanel tlpFilterHeader;
        private FlowLayoutPanel flpEntities;
        private TableLayoutPanel tlpTreePanel;
        private Label lblEntities;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem copyStructureMenuItem;
        private ToolStripMenuItem copyCodeMenuItem;
    }
}