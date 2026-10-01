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
            pnlHeaderSpacer = new Panel();
            btnCopyStructure = new Button();
            btnCopyCode = new Button();
            pnlStructureHeader = new Panel();
            editMenu = new ToolStripMenuItem();
            copyStructureMenuItem = new ToolStripMenuItem();
            copyCodeMenuItem = new ToolStripMenuItem();
            pnlStructureHeader.SuspendLayout();
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
            tvSolutionStructure.ForeColor = Color.Black;
            tvSolutionStructure.Name = "tvSolutionStructure";
            tvSolutionStructure.TabIndex = 1;
            // 
            // txtFilter
            // 
            txtFilter.Dock = DockStyle.Fill;
            txtFilter.Name = "txtFilter";
            txtFilter.PlaceholderText = "Filter files and folders";
            txtFilter.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Left;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += RefreshMenuItem_Click;
            // 
            // pnlHeaderSpacer
            // 
            pnlHeaderSpacer.Dock = DockStyle.Left;
            pnlHeaderSpacer.Name = "pnlHeaderSpacer";
            pnlHeaderSpacer.Size = new Size(6, 23);
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Left;
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear Selection";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += ClearMenuItem_Click;
            // 
            // btnCopyStructure
            // 
            btnCopyStructure.Dock = DockStyle.Right;
            btnCopyStructure.Name = "btnCopyStructure";
            btnCopyStructure.Size = new Size(110, 23);
            btnCopyStructure.TabIndex = 5;
            btnCopyStructure.Text = "Copy Structure";
            btnCopyStructure.UseVisualStyleBackColor = true;
            btnCopyStructure.Click += CopyStructure_Click;
            // 
            // pnlStructureHeader
            // 
            pnlStructureHeader.Controls.Add(btnCopyStructure);
            pnlStructureHeader.Controls.Add(btnClear);
            pnlStructureHeader.Controls.Add(pnlHeaderSpacer);
            pnlStructureHeader.Controls.Add(btnRefresh);
            pnlStructureHeader.Dock = DockStyle.Fill;
            pnlStructureHeader.Margin = new Padding(0);
            pnlStructureHeader.Name = "pnlStructureHeader";
            pnlStructureHeader.Padding = new Padding(3);
            pnlStructureHeader.TabIndex = 4;
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
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Transparent;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.Controls.Add(txtFilter, 0, 0);
            tableLayoutPanel3.Controls.Add(pnlStructureHeader, 1, 0);
            tableLayoutPanel3.Controls.Add(btnCopyCode, 2, 0);
            tableLayoutPanel3.Controls.Add(tvSolutionStructure, 0, 1);
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
            pnlStructureHeader.ResumeLayout(false);
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
        private Panel pnlHeaderSpacer;
        private Button btnCopyStructure;
        private Button btnCopyCode;
        private Panel pnlStructureHeader;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem copyStructureMenuItem;
        private ToolStripMenuItem copyCodeMenuItem;
    }
}