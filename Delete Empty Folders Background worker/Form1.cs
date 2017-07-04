using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Delete_Empty_Folders_Background_worker
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            this.search_button.Enabled = false;
            this.clean_button.Enabled = false;
            this.browse_button.Enabled = false;
            this.path.Enabled = false;
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.Select_all_checkBox.Enabled = false;
            this.backgroundWorker.RunWorkerAsync();
        }

        private void clean_button_Click(object sender, EventArgs e)
        {
            if (GetCheckedNodesCount(treeView.Nodes) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure You Want Delete " + GetCheckedNodesCount(treeView.Nodes) + " Folder(s) ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    this.search_button.Enabled = false;
                    this.clean_button.Enabled = false;
                    this.browse_button.Enabled = false;
                    this.path.Enabled = false;
                    this.Select_all_checkBox.Enabled = false;
                    this.progressBar.Style = ProgressBarStyle.Marquee;
                    this.backgroundWorker1.RunWorkerAsync();

                }
            }
            else
                MessageBox.Show("No Folders To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetCheckedNodesCount(TreeNodeCollection tree)
        {
            int checkedNodes = 0;
            foreach (TreeNode node in tree)
            {
                if (node.Checked)
                    checkedNodes++;
                if (node.Nodes.Count != 0)
                    checkedNodes += this.GetCheckedNodesCount(node.Nodes);
            }
            return checkedNodes;
        }

        private void DeleteCheckedNodes(TreeNodeCollection nodes, String root)
        {
            foreach (TreeNode aNode in nodes)
            {
                if (aNode.Checked)
                {
                    Directory.Delete(root + aNode.FullPath);
                }
                if (aNode.Nodes.Count != 0)
                {
                    this.DeleteCheckedNodes(aNode.Nodes, root);
                }
            }
        }

        private void ListDirectory(string path)
        {
            this.treeView.Nodes.Clear();
            var rootDirectoryInfo = Tuple.Create(0, new DirectoryInfo(path));
            TreeNode tree = CreateDirectoryNode(rootDirectoryInfo.Item2).Item2;
            this.treeView.Invoke((MethodInvoker)(() => treeView.Nodes.Add(tree)));
        }

        private static Tuple<Boolean, TreeNode> CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            Boolean check = false;
            int count = 0;
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var Node = CreateDirectoryNode(directory);
                    check = Node.Item1;
                    try
                    {
                        if ((Directory.GetFiles(directory.FullName).Length == 0 && Directory.GetDirectories(directory.FullName).Length == 0) || check)
                        {
                            directoryNode.Nodes.Add(Node.Item2);
                            check = true;
                            count++;
                        }
                    }
                    catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message, "unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message, "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    if (count > 0)
                        check = true;
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }
            if (count > 0)
                check = true;
            return Tuple.Create(check, directoryNode);
        }

        private void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                this.CheckChildren(node, true);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                this.CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                this.CheckChildren(node, false);
            }
        }

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);

        private void HideParent(TreeNode tree)
        {
            foreach (TreeNode child in tree.Nodes)
                if (child.Nodes.Count > 0)
                {
                    this.HideParent(child);
                    this.HideCheckBox(this.treeView, child);
                }
        }

        private void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (Select_all_checkBox.Checked == true)
                this.CheckAllNodes(this.treeView.Nodes);
            else
                this.UncheckAllNodes(this.treeView.Nodes);
            foreach (TreeNode parent in this.treeView.Nodes)
                this.HideParent(parent);
            TreeNodeCollection nodes = this.treeView.Nodes;
            if (nodes.Count > 0)
                this.HideCheckBox(this.treeView, nodes[0]);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ListDirectory(this.path.Text);
        }

        private void backgroundWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            this.search_button.Enabled = Enabled;
            this.clean_button.Enabled = Enabled;
            this.browse_button.Enabled = Enabled;
            this.path.Enabled = Enabled;
            this.progressBar.Style = ProgressBarStyle.Blocks;
            this.progressBar.Value = 100;
            this.Select_all_checkBox.Enabled = true;
            this.Select_all_checkBox.Checked = true;
            this.treeView.ExpandAll();
            this.CheckAllNodes(treeView.Nodes);
            foreach (TreeNode parent in treeView.Nodes)
                this.HideParent(parent);
            if (treeView.Nodes.Count > 0)
                this.HideCheckBox(treeView, treeView.Nodes[0]);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string root = path.Text.Substring(0, path.Text.Length - treeView.Nodes[0].Text.Length);
            this.DeleteCheckedNodes(treeView.Nodes, root);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.search_button.Enabled = Enabled;
            this.browse_button.Enabled = Enabled;
            this.path.Enabled = Enabled;
            this.Select_all_checkBox.Enabled = true;
            this.Select_all_checkBox.Checked = true;
            this.progressBar.Style = ProgressBarStyle.Blocks;
            this.progressBar.Value = 100;
            this.treeView.ExpandAll();
            this.CheckAllNodes(treeView.Nodes);
            foreach (TreeNode parent in treeView.Nodes)
                this.HideParent(parent);
            if (treeView.Nodes.Count > 0)
                this.HideCheckBox(treeView, treeView.Nodes[0]);
        }
    }
}
