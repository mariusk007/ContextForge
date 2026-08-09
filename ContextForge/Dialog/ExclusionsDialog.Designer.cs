namespace ContextForge.Dialog
{
    partial class ExclusionsDialog
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
            groupBoxDirectories = new GroupBox();
            btnRemoveDirectory = new Button();
            btnAddDirectory = new Button();
            txtDirectory = new TextBox();
            listBoxDirectories = new ListBox();
            btnOK = new Button();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBoxDirectories.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxDirectories
            // 
            groupBoxDirectories.Controls.Add(btnRemoveDirectory);
            groupBoxDirectories.Controls.Add(btnAddDirectory);
            groupBoxDirectories.Controls.Add(txtDirectory);
            groupBoxDirectories.Controls.Add(listBoxDirectories);
            groupBoxDirectories.Dock = DockStyle.Fill;
            groupBoxDirectories.ForeColor = Color.White;
            groupBoxDirectories.Location = new Point(3, 3);
            groupBoxDirectories.Name = "groupBoxDirectories";
            groupBoxDirectories.Padding = new Padding(10);
            groupBoxDirectories.Size = new Size(594, 334);
            groupBoxDirectories.TabIndex = 0;
            groupBoxDirectories.TabStop = false;
            groupBoxDirectories.Text = "Excluded Directories";
            // 
            // btnRemoveDirectory
            // 
            btnRemoveDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemoveDirectory.ForeColor = Color.Black;
            btnRemoveDirectory.Location = new Point(13, 298);
            btnRemoveDirectory.Name = "btnRemoveDirectory";
            btnRemoveDirectory.Size = new Size(568, 25);
            btnRemoveDirectory.TabIndex = 3;
            btnRemoveDirectory.Text = "Remove Selected";
            btnRemoveDirectory.UseVisualStyleBackColor = true;
            btnRemoveDirectory.Click += btnRemoveDirectory_Click;
            // 
            // btnAddDirectory
            // 
            btnAddDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAddDirectory.ForeColor = Color.Black;
            btnAddDirectory.Location = new Point(13, 267);
            btnAddDirectory.Name = "btnAddDirectory";
            btnAddDirectory.Size = new Size(568, 25);
            btnAddDirectory.TabIndex = 2;
            btnAddDirectory.Text = "Add Directory";
            btnAddDirectory.UseVisualStyleBackColor = true;
            btnAddDirectory.Click += btnAddDirectory_Click;
            // 
            // txtDirectory
            // 
            txtDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDirectory.Location = new Point(13, 238);
            txtDirectory.Name = "txtDirectory";
            txtDirectory.PlaceholderText = "Enter directory name to exclude";
            txtDirectory.Size = new Size(568, 23);
            txtDirectory.TabIndex = 1;
            txtDirectory.KeyDown += txtDirectory_KeyDown;
            // 
            // listBoxDirectories
            // 
            listBoxDirectories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxDirectories.BackColor = Color.DimGray;
            listBoxDirectories.ForeColor = Color.Black;
            listBoxDirectories.FormattingEnabled = true;
            listBoxDirectories.ItemHeight = 15;
            listBoxDirectories.Location = new Point(13, 26);
            listBoxDirectories.Name = "listBoxDirectories";
            listBoxDirectories.Size = new Size(568, 199);
            listBoxDirectories.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(487, 13);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(90, 30);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(391, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(groupBoxDirectories, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(600, 340);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnOK);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 340);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(600, 50);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // ExclusionsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(600, 390);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(600, 400);
            Name = "ExclusionsDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Exclusions";
            groupBoxDirectories.ResumeLayout(false);
            groupBoxDirectories.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDirectories;
        private Button btnRemoveDirectory;
        private Button btnAddDirectory;
        private TextBox txtDirectory;
        private ListBox listBoxDirectories;
        private Button btnOK;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}