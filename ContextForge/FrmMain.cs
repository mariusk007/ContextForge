using System.Text;
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

            BtnRefresh.Click += BtnRefresh_Click;
            BtnClear.Click += BtnClear_Click;

            txtFilter.TextChanged += TxtFilter_TextChanged;

            this.KeyPreview = true;
            this.KeyDown += FrmMain_KeyDown;
        }

        private void BtnClear_Click(object sender, EventArgs e)
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

        private static void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                UncheckAllNodes(node.Nodes);
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            currentFilter = txtFilter.Text;
            ApplyFilter();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnManageExclusions_Click(object sender, EventArgs e)
        {
            using var exclusionsDialog = new ExclusionsDialog(excludedDirectories);

            if (exclusionsDialog.ShowDialog() == DialogResult.OK)
            {
                excludedDirectories.Clear();
                excludedDirectories.AddRange(exclusionsDialog.ExcludedDirectories);
                SaveExclusions();

                if (!string.IsNullOrEmpty(currentRootPath))
                {
                    PopulateTreeView(currentRootPath);
                    RestoreTreeState(tvSolutionStructure.Nodes, []);
                    UpdateDisplays();
                }
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentRootPath))
            {
                PopulateTreeView(currentRootPath);
                RestoreTreeState(tvSolutionStructure.Nodes, []);
                UpdateDisplays();
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                checkedPaths.Clear();
                currentRootPath = folderBrowserDialog.SelectedPath;
                PopulateTreeView(currentRootPath);
                UpdateDisplays();
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

        // Clean, synchronous event handler
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

        // Single method to update both displays synchronously
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

        // Synchronous method - no async complications
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

        private void BtnLoadExclusions_Click(object sender, EventArgs e)
        {
            LoadExclusions();
            MessageBox.Show("Exclusions loaded successfully!", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!string.IsNullOrEmpty(currentRootPath))
            {
                PopulateTreeView(currentRootPath);
                RestoreTreeState(tvSolutionStructure.Nodes, []);
                UpdateDisplays();
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