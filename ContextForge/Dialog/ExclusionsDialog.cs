namespace ContextForge.Dialog
{
    public partial class ExclusionsDialog : Form
    {
        public List<string> ExcludedDirectories { get; private set; }

        public ExclusionsDialog(List<string> excludedDirectories)
        {
            InitializeComponent();

            ExcludedDirectories = new List<string>(excludedDirectories);

            PopulateList();
        }

        private void PopulateList()
        {
            listBoxDirectories.Items.Clear();

            foreach (string dir in ExcludedDirectories)
            {
                listBoxDirectories.Items.Add(dir);
            }
        }

        private void btnAddDirectory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDirectory.Text))
            {
                string dirToAdd = txtDirectory.Text.Trim();
                if (!ExcludedDirectories.Contains(dirToAdd))
                {
                    ExcludedDirectories.Add(dirToAdd);
                    listBoxDirectories.Items.Add(dirToAdd);
                }
                txtDirectory.Clear();
            }
        }

        private void btnRemoveDirectory_Click(object sender, EventArgs e)
        {
            if (listBoxDirectories.SelectedItem != null)
            {
                string selectedDir = listBoxDirectories.SelectedItem.ToString();
                ExcludedDirectories.Remove(selectedDir);
                listBoxDirectories.Items.Remove(selectedDir);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddDirectory_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}