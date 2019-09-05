using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeSizeApp
{
    public partial class TreeSizeForm : Form
    {
        private readonly long BIGTEXTSIZE = 1024 * 1024 * 100;
        private readonly HashSet<string> textExtNameSet = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase) {
            ".txt", ".log", ".xml", ".dat", ".fil", ".eod", ".cdl", ".cdr"
        };

        public TreeSizeForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Path cannot be empty.");
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Don't exist this folder: " + path);
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("ParentID", typeof(string));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("LastUpdate", typeof(DateTime));
            table.Columns.Add("FileSize", typeof(long));
            table.Columns.Add("FileSize_MB", typeof(long), "FileSize/1024/1024");
            table.Columns.Add("TextSize", typeof(long));
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

            txtComment.Text = "---";
            txtSize.Text = "Checking...";
            string parentId = "";

            Tuple<long, long> fileSize = Lookup(parentId, path, table);

            txtSize.Text = string.Format("TextSize:{0}M TotalSize:{1}M",
                (fileSize.Item2/1024/1024).ToString("###,##0"),
                (fileSize.Item1/1024/1024).ToString("###,##0"));
            treeList.DataSource = table;
        }

        private Tuple<long, long> Lookup(string parentId, string path, DataTable table)
        {
            int index = 0;
            long totalSize = 0;
            long textTotalSize = 0;

            try
            {
                String[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    index++;
                    string id = string.Format("{0}_{1}", parentId, index);
                    DirectoryInfo di = new DirectoryInfo(path);
                    DataRow row = AddRow(id, parentId, table, dir, di.LastWriteTime, -1, -1);
                    Tuple<long, long> temp = Lookup(id, dir, table);
                    row["FileSize"] = temp.Item1;
                    row["TextSize"] = temp.Item2;

                    totalSize += temp.Item1;
                    textTotalSize += temp.Item2;
                    index++;
                }

                Tuple<long, long> tempFileSize = AddFileIntoTree(index, parentId, path, table);
                totalSize += tempFileSize.Item1;
                textTotalSize += tempFileSize.Item2;
            }
            catch (Exception ex)
            {
                AddComment(string.Format("{0}:{1}", path, ex.Message), true);
            }


            return new Tuple<long, long>(totalSize, textTotalSize);
        }

        private Tuple<long, long> AddFileIntoTree(int maxIndex, string parentId, string path, DataTable table)
        {
            long totalSize = 0;
            long textTotalSize = 0;

            StringBuilder sb = new StringBuilder();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fileInfos = di.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                string id = string.Format("{0}_{1}", parentId, maxIndex);
                string fileName = Path.GetFileName(fileInfo.FullName);
                long fileSize = fileInfo.Length;
                bool isTextFile = IsTextFile(fileInfo);
                AddRow(id, parentId, table, fileName, fileInfo.LastWriteTime, fileSize, isTextFile ? fileSize : 0);

                totalSize += fileSize;
                if (isTextFile)
                {
                    textTotalSize += fileSize;
                }
                maxIndex++;
            }
            return new Tuple<long, long>(totalSize, textTotalSize);
        }

        private DataRow AddRow(string Id, string parentId, DataTable table, string fileName, DateTime lastUpdate, long fileSize, long textSize)
        {
            DataRow row = table.NewRow();
            row["ID"] = Id;
            row["ParentID"] = parentId;
            row["FileName"] = fileName;
            row["LastUpdate"] = lastUpdate;
            row["FileSize"] = fileSize;
            row["TextSize"] = textSize;

            table.Rows.Add(row);

            return row;
        }

        private bool IsTextFile(FileInfo fileInfo)
        {
            // Currently only check its extension name
            string extName = fileInfo.Extension;
            return textExtNameSet.Contains(extName);
        }

        private void AddComment(string comment, bool append = true)
        {
            if (!string.IsNullOrEmpty(comment))
            {
                if (append)
                {
                    txtComment.Text += comment + "\r\n";
                }
                else
                {
                    txtComment.Text = comment;
                }
            }
        }

        private void treeList_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e?.Column?.FieldName == "TextSize")
            {
                if (e.CellValue != null)
                {
                    long temp = Convert.ToInt64(e.CellValue);
                    if (temp > 0)
                    {
                        e.Appearance.BackColor = Color.LightYellow;

                        if (temp > BIGTEXTSIZE)
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var focusedNode = treeList.FocusedNode;
            if (focusedNode != null)
            {
                string path = "";
                if (focusedNode.HasChildren)
                {
                    path = focusedNode.GetValue(colFileName) as string;
                }
                else
                {
                    TreeListNode parentNode = focusedNode.ParentNode;
                    path = Path.Combine(parentNode.GetValue(colFileName) as string, focusedNode.GetValue(colFileName) as string);
                }
                if (!string.IsNullOrWhiteSpace(path))
                {
                    System.Diagnostics.Process.Start("explorer", string.Format("/select, \"{0}\"",path));
                }
            }
        }

        private void btnZipFolder_Click(object sender, EventArgs e)
        {
            string path = "";
            var focusedNode = treeList.FocusedNode;
            if (focusedNode != null)
            {
                if (focusedNode.HasChildren)
                {
                    path = focusedNode.GetValue(colFileName) as string;
                }
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                MsgHelper.ShowMessage("Please choose a folder.");
                return;
            }
            
            if (ZipHelper.ZipFolder(path, chkRemoveZippedFolder.Checked))
            {
                MsgHelper.ShowMessage("Zipped successfully.");
            }
            else
            {
                MsgHelper.ShowMessage("Failed to zip.");
            }
        }



    }
}
