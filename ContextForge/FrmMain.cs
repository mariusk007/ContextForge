using System.Text;
using System.Text.RegularExpressions;
using ContextForge.Dialog;

namespace ContextForge
{
    public partial class FrmMain : Form
    {
        private string currentRootPath;
        private readonly List<string> excludedDirectories;
        private string currentFilter = string.Empty;
        private readonly bool showFilesOnly = false;
        private readonly bool showDirectoriesOnly = false;

        // Single source of truth for checked state
        private readonly HashSet<string> checkedPaths = [];

        public FrmMain()
        {
            InitializeComponent();

            excludedDirectories = [];
            LoadExclusions();

            tvSolutionStructure.CheckBoxes = true;
            tvSolutionStructure.AfterCheck += TvSolutionStructure_AfterCheck;

            txtFilter.TextChanged += TxtFilter_TextChanged;

            KeyPreview = true;
            KeyDown += FrmMain_KeyDown;

            txtSolutionStructureResults.TextChanged += (_, _) => UpdateCopyState();
            txtCodeResults.TextChanged += (_, _) => UpdateCopyState();

            UpdateMenuState();
            UpdateCopyState();
            ApplyTheme();
        }

        // Copy actions are only available when their box has something to copy.
        private void UpdateCopyState()
        {
            bool hasStructure = txtSolutionStructureResults.TextLength > 0;
            bool hasCode = txtCodeResults.TextLength > 0;

            btnCopyStructure.Enabled = hasStructure;
            copyStructureMenuItem.Enabled = hasStructure;

            btnCopyCode.Enabled = hasCode;
            copyCodeMenuItem.Enabled = hasCode;
        }

        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            tableLayoutPanel3.BackColor = Theme.Background;
            tlpFilterHeader.BackColor = Theme.Background;
            tlpTreePanel.BackColor = Theme.Background;

            Theme.StyleMenu(menuStrip);

            foreach (var button in new[] { btnRefresh, btnClear, btnCopyStructure, btnCopyCode })
                Theme.StyleButton(button);

            txtFilter.BackColor = Theme.Input;
            txtFilter.ForeColor = Theme.Text;
            txtFilter.BorderStyle = BorderStyle.FixedSingle;

            Theme.StylePane(tvSolutionStructure);
            Theme.StylePane(txtSolutionStructureResults);
            Theme.StylePane(txtCodeResults);
            tvSolutionStructure.LineColor = Theme.Line;

            flpEntities.BackColor = Theme.Band;
            flpEntities.Padding = new Padding(4, 0, 4, 0);
            lblEntities.ForeColor = Theme.Text;
            lblEntities.Font = new Font(lblEntities.Font, FontStyle.Bold);
        }

        #region Menu handlers

        private void OpenFolderMenuItem_Click(object? sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                checkedPaths.Clear();
                currentRootPath = folderBrowserDialog.SelectedPath;
                Text = $"ContextForge - {currentRootPath}";
                PopulateTreeView(currentRootPath);
                UpdateDisplays();
                UpdateMenuState();
                UpdateEntities();
            }
        }

        private void RefreshMenuItem_Click(object? sender, EventArgs e) => RebuildTree();

        private void ClearMenuItem_Click(object? sender, EventArgs e)
        {
            txtFilter.Clear();
            checkedPaths.Clear();

            UncheckAllNodes(tvSolutionStructure.Nodes);

            txtSolutionStructureResults.Clear();
            txtCodeResults.Clear();

            currentFilter = string.Empty;

            if (!string.IsNullOrEmpty(currentRootPath))
            {
                PopulateTreeView(currentRootPath);
            }
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e) => Close();

        private void ManageExclusionsMenuItem_Click(object? sender, EventArgs e)
        {
            using var exclusionsDialog = new ExclusionsDialog(excludedDirectories);

            if (exclusionsDialog.ShowDialog() == DialogResult.OK)
            {
                excludedDirectories.Clear();
                excludedDirectories.AddRange(exclusionsDialog.ExcludedDirectories);
                SaveExclusions();
                RebuildTree();
            }
        }

        private void ReloadExclusionsMenuItem_Click(object? sender, EventArgs e)
        {
            LoadExclusions();
            MessageBox.Show("Exclusions loaded successfully!", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RebuildTree();
        }

        private void CopyStructure_Click(object? sender, EventArgs e) =>
            CopyToClipboard(txtSolutionStructureResults, btnCopyStructure, "Copy Structure");

        private void CopyCode_Click(object? sender, EventArgs e) =>
            CopyToClipboard(txtCodeResults, btnCopyCode, "Copy Code");

        private static async void CopyToClipboard(RichTextBox source, Button feedbackButton, string label)
        {
            if (string.IsNullOrEmpty(source.Text))
                return;

            Clipboard.SetText(source.Text);

            feedbackButton.Text = "Copied ✓";
            await Task.Delay(1500);
            feedbackButton.Text = label;
        }

        private void UpdateMenuState()
        {
            bool hasRoot = !string.IsNullOrEmpty(currentRootPath);
            refreshMenuItem.Enabled = hasRoot;
            btnRefresh.Enabled = hasRoot;
            clearMenuItem.Enabled = hasRoot;
            btnClear.Enabled = hasRoot;
        }

        private void RebuildTree()
        {
            if (string.IsNullOrEmpty(currentRootPath))
                return;

            PopulateTreeView(currentRootPath);
            RestoreTreeState(tvSolutionStructure.Nodes, []);
            UpdateDisplays();
            UpdateEntities();
        }

        private void UpdateEntities()
        {
            flpEntities.SuspendLayout();

            // Keep the label, remove the old entity buttons
            foreach (var old in flpEntities.Controls.OfType<Button>().ToList())
            {
                flpEntities.Controls.Remove(old);
                old.Dispose();
            }

            if (!string.IsNullOrEmpty(currentRootPath))
            {
                var entities = EntityAnalyzer.GetTopEntities(currentRootPath, excludedDirectories);

                lblEntities.Text = entities.Count == 0 ? "Top entities: none found" : "Top entities:";

                foreach (var entity in entities)
                {
                    var chip = new Button
                    {
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        Margin = new Padding(0, 3, 4, 3),
                        Text = $"{entity.Name} ({entity.Count})",
                        Tag = entity.Name
                    };
                    Theme.StyleChip(chip);
                    chip.Click += EntityChip_Click;
                    flpEntities.Controls.Add(chip);
                }
            }

            HighlightActiveChip();
            flpEntities.ResumeLayout(true);
        }

        // Shows which entity is currently being used as the filter.
        private void HighlightActiveChip()
        {
            foreach (var chip in flpEntities.Controls.OfType<Button>())
            {
                Theme.StyleChip(chip);
                if (string.Equals(chip.Tag as string, txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                    Theme.StyleActiveChip(chip);
            }
        }

        // Clicking an entity filters the tree to it; clicking the active one clears the filter.
        private void EntityChip_Click(object? sender, EventArgs e)
        {
            if (sender is not Button { Tag: string entity })
                return;

            txtFilter.Text = string.Equals(txtFilter.Text, entity, StringComparison.OrdinalIgnoreCase)
                ? string.Empty
                : entity;

            // TextChanged has already rebuilt the filtered tree; show every match.
            if (!string.IsNullOrEmpty(txtFilter.Text) && tvSolutionStructure.Nodes.Count > 0)
            {
                tvSolutionStructure.BeginUpdate();
                tvSolutionStructure.ExpandAll();
                tvSolutionStructure.Nodes[0].EnsureVisible();
                tvSolutionStructure.EndUpdate();
            }
        }

        #endregion

        private static void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                UncheckAllNodes(node.Nodes);
            }
        }

        private void TxtFilter_TextChanged(object? sender, EventArgs e)
        {
            currentFilter = txtFilter.Text;
            ApplyFilter();
            HighlightActiveChip();
        }

        private void FrmMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (tvSolutionStructure.Focused)
            {
                switch (e.KeyCode)
                {
                    case Keys.Multiply:
                        ExpandAllNodes();
                        e.Handled = true;
                        break;
                    case Keys.Divide:
                        CollapseAllNodes();
                        e.Handled = true;
                        break;
                    case Keys.Add:
                        ExpandSelectedNode();
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                        CollapseSelectedNode();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void ExpandAllNodes() => tvSolutionStructure.ExpandAll();
        private void CollapseAllNodes() => tvSolutionStructure.CollapseAll();

        private void ExpandSelectedNode()
        {
            tvSolutionStructure.SelectedNode?.ExpandAll();
        }

        private void CollapseSelectedNode()
        {
            tvSolutionStructure.SelectedNode?.Collapse();
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrEmpty(currentRootPath))
                return;

            var expandedNodes = new HashSet<string>();
            StoreExpandedState(tvSolutionStructure.Nodes, expandedNodes);

            PopulateTreeView(currentRootPath);
            RestoreTreeState(tvSolutionStructure.Nodes, expandedNodes);
        }

        private void StoreExpandedState(TreeNodeCollection nodes, HashSet<string> expandedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && node.IsExpanded)
                {
                    expandedNodes.Add(node.Tag.ToString());
                }
                StoreExpandedState(node.Nodes, expandedNodes);
            }
        }

        private void RestoreTreeState(TreeNodeCollection nodes, HashSet<string> expandedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null)
                {
                    string path = node.Tag.ToString();
                    if (expandedNodes.Contains(path))
                        node.Expand();
                    if (checkedPaths.Contains(path))
                        node.Checked = true;
                }
                RestoreTreeState(node.Nodes, expandedNodes);
            }
        }

        private void PopulateTreeView(string path)
        {
            tvSolutionStructure.Nodes.Clear();

            TreeNode rootNode = new(Path.GetFileName(path)) { Tag = path };
            tvSolutionStructure.Nodes.Add(rootNode);

            PopulateTreeNode(rootNode);
            rootNode.Expand();
        }

        private void PopulateTreeNode(TreeNode parentNode)
        {
            string path = parentNode.Tag.ToString();
            DirectoryInfo dirInfo = new(path);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (ShouldIncludeFile(file))
                {
                    TreeNode fileNode = new(file.Name) { Tag = file.FullName };
                    parentNode.Nodes.Add(fileNode);
                }
            }

            foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
            {
                if (!excludedDirectories.Exists(x => x.Equals(subDir.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    TreeNode dirNode = new(subDir.Name) { Tag = subDir.FullName };
                    parentNode.Nodes.Add(dirNode);

                    PopulateTreeNode(dirNode);

                    if (dirNode.Nodes.Count == 0 && !ShouldIncludeDirectory(subDir))
                    {
                        parentNode.Nodes.Remove(dirNode);
                    }
                }
            }
        }

        private bool ShouldIncludeDirectory(DirectoryInfo dir)
        {
            if (showFilesOnly) return false;
            return string.IsNullOrEmpty(currentFilter) ||
                   dir.Name.Contains(currentFilter, StringComparison.OrdinalIgnoreCase);
        }

        private bool ShouldIncludeFile(FileInfo file)
        {
            if (showDirectoriesOnly) return false;
            return string.IsNullOrEmpty(currentFilter) ||
                   file.Name.Contains(currentFilter, StringComparison.OrdinalIgnoreCase);
        }

        private void TvSolutionStructure_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null)
                return;

            string path = e.Node.Tag.ToString();

            if (e.Node.Checked)
                checkedPaths.Add(path);
            else
                checkedPaths.Remove(path);

            UpdateDisplays();
        }

        private void UpdateDisplays()
        {
            UpdateCheckedDirectoriesDisplay();
            UpdateCodeResults();
        }

        private void UpdateCheckedDirectoriesDisplay()
        {
            StringBuilder sb = new();

            foreach (string path in checkedPaths.Where(Directory.Exists))
            {
                if (sb.Length > 0) sb.AppendLine();
                DisplaySelectedDirectoryOnly(path, sb);
            }

            txtSolutionStructureResults.Text = sb.ToString();
        }

        private string GetRelativePath(string fullPath)
        {
            if (fullPath.StartsWith(currentRootPath, StringComparison.OrdinalIgnoreCase))
            {
                var relativePath = fullPath.Substring(currentRootPath.Length);
                return relativePath.TrimStart(Path.DirectorySeparatorChar);
            }
            return fullPath;
        }

        private void UpdateCodeResults()
        {
            StringBuilder sb = new();

            foreach (string path in checkedPaths.Where(File.Exists))
            {
                try
                {
                    sb.AppendLine("".PadLeft(80, '-'));
                    sb.AppendLine($"File: {GetRelativePath(path)}");
                    sb.AppendLine("".PadLeft(80, '-'));

                    var content = File.ReadAllText(path);
                    sb.AppendLine(content);
                    sb.AppendLine();
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"Error reading file {GetRelativePath(path)}: {ex.Message}");
                }
            }

            txtCodeResults.Text = sb.ToString();
            HighlightFileHeaders();
        }

        // Matches the 3-line block: dashes / "File: path" / dashes. RichTextBox stores newlines as \n.
        private static readonly Regex FileHeaderPattern =
            new(@"^-{80}\n(File: .*)\n-{80}$", RegexOptions.Multiline | RegexOptions.Compiled);

        private void HighlightFileHeaders()
        {
            var text = txtCodeResults.Text;
            if (text.Length == 0)
                return;

            using var boldFont = new Font(txtCodeResults.Font, FontStyle.Bold);

            foreach (Match match in FileHeaderPattern.Matches(text))
            {
                // Divider lines
                txtCodeResults.Select(match.Index, match.Length);
                txtCodeResults.SelectionColor = Theme.Line;

                // "File: ..." line
                var fileLine = match.Groups[1];
                txtCodeResults.Select(fileLine.Index, fileLine.Length);
                txtCodeResults.SelectionColor = Theme.Accent;
                txtCodeResults.SelectionFont = boldFont;
            }

            txtCodeResults.Select(0, 0);
        }

        private void DisplaySelectedDirectoryOnly(string path, StringBuilder sb)
        {
            TraverseDirectory(path, sb, 0);
        }

        private void TraverseDirectory(string path, StringBuilder sb, int indentLevel)
        {
            string indent = new(' ', indentLevel * 4);
            DirectoryInfo dirInfo = new(path);

            if (excludedDirectories.Exists(x => x.Equals(dirInfo.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            sb.AppendLine($"{indent}{dirInfo.Name}");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                sb.AppendLine($"{indent}    {file.Name}");
            }

            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                TraverseDirectory(subdir.FullName, sb, indentLevel + 1);
            }
        }

        private void SaveExclusions()
        {
            using StreamWriter writer = new("exclusions.txt");
            writer.WriteLine("[Directories]");
            foreach (string dir in excludedDirectories)
            {
                writer.WriteLine(dir);
            }
        }

        private void LoadExclusions()
        {
            const string exclusionsFilePath = "exclusions.txt";

            if (!File.Exists(exclusionsFilePath))
            {
                using (StreamWriter writer = new(exclusionsFilePath))
                {
                    writer.WriteLine("[Directories]");
                    writer.WriteLine();
                }

                MessageBox.Show("No exclusions file found. A new 'exclusions.txt' file has been created.", "File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            excludedDirectories.Clear();
            string[] lines = File.ReadAllLines(exclusionsFilePath);

            foreach (string line in lines)
            {
                if (line != "[Directories]" && !string.IsNullOrWhiteSpace(line))
                {
                    excludedDirectories.Add(line);
                }
            }
        }
    }
}