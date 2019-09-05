namespace TreeSizeApp
{
    partial class TreeSizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFileSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFileSize_MB = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLastUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTextSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnZipFolder = new System.Windows.Forms.Button();
            this.chkRemoveZippedFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(257, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 18);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(50, 13);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(201, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.Text = "D:\\study";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(12, 456);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(744, 68);
            this.txtComment.TabIndex = 4;
            this.txtComment.Text = "---\r\n---";
            // 
            // treeList
            // 
            this.treeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFileName,
            this.colFileSize,
            this.colFileSize_MB,
            this.colLastUpdate,
            this.colTextSize});
            this.treeList.Location = new System.Drawing.Point(12, 69);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList.OptionsSelection.MultiSelect = true;
            this.treeList.Size = new System.Drawing.Size(744, 378);
            this.treeList.TabIndex = 6;
            this.treeList.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList_CustomDrawNodeCell);
            // 
            // colFileName
            // 
            this.colFileName.Caption = "FileName";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            this.colFileName.Width = 304;
            // 
            // colFileSize
            // 
            this.colFileSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFileSize.Caption = "FileSize";
            this.colFileSize.FieldName = "FileSize";
            this.colFileSize.Format.FormatString = "###,###,###,###,###,###,###,###,###";
            this.colFileSize.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.Visible = true;
            this.colFileSize.VisibleIndex = 1;
            this.colFileSize.Width = 130;
            // 
            // colFileSize_MB
            // 
            this.colFileSize_MB.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileSize_MB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFileSize_MB.Caption = "FileSize(MB)";
            this.colFileSize_MB.FieldName = "FileSize_MB";
            this.colFileSize_MB.Format.FormatString = "###,###,###,###,###,###,###,###,###";
            this.colFileSize_MB.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFileSize_MB.Name = "colFileSize_MB";
            this.colFileSize_MB.Visible = true;
            this.colFileSize_MB.VisibleIndex = 2;
            this.colFileSize_MB.Width = 83;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.Caption = "LastUpdate";
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 3;
            this.colLastUpdate.Width = 106;
            // 
            // colTextSize
            // 
            this.colTextSize.Caption = "TextSize";
            this.colTextSize.FieldName = "TextSize";
            this.colTextSize.Format.FormatString = "###,###,###,###,###,###,###,###,###";
            this.colTextSize.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTextSize.Name = "colTextSize";
            this.colTextSize.Visible = true;
            this.colTextSize.VisibleIndex = 4;
            this.colTextSize.Width = 103;
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(12, 43);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(744, 20);
            this.txtSize.TabIndex = 7;
            this.txtSize.Text = "---";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(338, 11);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(79, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "OpenFolder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnZipFolder
            // 
            this.btnZipFolder.Location = new System.Drawing.Point(488, 11);
            this.btnZipFolder.Name = "btnZipFolder";
            this.btnZipFolder.Size = new System.Drawing.Size(79, 23);
            this.btnZipFolder.TabIndex = 8;
            this.btnZipFolder.Text = "ZipFolder";
            this.btnZipFolder.UseVisualStyleBackColor = true;
            this.btnZipFolder.Click += new System.EventHandler(this.btnZipFolder_Click);
            // 
            // chkRemoveZippedFolder
            // 
            this.chkRemoveZippedFolder.AutoSize = true;
            this.chkRemoveZippedFolder.Location = new System.Drawing.Point(573, 15);
            this.chkRemoveZippedFolder.Name = "chkRemoveZippedFolder";
            this.chkRemoveZippedFolder.Size = new System.Drawing.Size(131, 17);
            this.chkRemoveZippedFolder.TabIndex = 9;
            this.chkRemoveZippedFolder.Text = "Remove ZippedFolder";
            this.chkRemoveZippedFolder.UseVisualStyleBackColor = true;
            // 
            // TreeSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 536);
            this.Controls.Add(this.chkRemoveZippedFolder);
            this.Controls.Add(this.btnZipFolder);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnSearch);
            this.Name = "TreeSizeForm";
            this.Text = "Tree Size";
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtComment;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFileSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFileSize_MB;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLastUpdate;
        private System.Windows.Forms.TextBox txtSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTextSize;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnZipFolder;
        private System.Windows.Forms.CheckBox chkRemoveZippedFolder;
    }
}

