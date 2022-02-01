namespace MineScreenShots
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.DirList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Settings = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.PicList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.DirList);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.PicList);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel2MinSize = 500;
            this.splitContainer1.Size = new System.Drawing.Size(1578, 939);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Controls.Add(this.Add);
            this.flowLayoutPanel1.Controls.Add(this.Remove);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 899);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 40);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add.Enabled = false;
            this.Add.Location = new System.Drawing.Point(3, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(148, 34);
            this.Add.TabIndex = 3;
            this.Add.Text = "添加截图路径";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Remove
            // 
            this.Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Remove.Enabled = false;
            this.Remove.Location = new System.Drawing.Point(157, 3);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(112, 34);
            this.Remove.TabIndex = 4;
            this.Remove.Text = "移除路径";
            this.Remove.UseVisualStyleBackColor = true;
            // 
            // DirList
            // 
            this.DirList.AllowDrop = true;
            this.DirList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DirList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.DirList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DirList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.DirList.Location = new System.Drawing.Point(0, 0);
            this.DirList.MultiSelect = false;
            this.DirList.Name = "DirList";
            this.DirList.Size = new System.Drawing.Size(300, 939);
            this.DirList.TabIndex = 2;
            this.DirList.TileSize = new System.Drawing.Size(348, 30);
            this.DirList.UseCompatibleStateImageBehavior = false;
            this.DirList.View = System.Windows.Forms.View.List;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel2.Controls.Add(this.Settings);
            this.flowLayoutPanel2.Controls.Add(this.Copy);
            this.flowLayoutPanel2.Controls.Add(this.Delete);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 899);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1276, 40);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // Settings
            // 
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings.Location = new System.Drawing.Point(1161, 3);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(112, 34);
            this.Settings.TabIndex = 6;
            this.Settings.Text = "功能设置";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Copy
            // 
            this.Copy.Enabled = false;
            this.Copy.Location = new System.Drawing.Point(1043, 3);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(112, 34);
            this.Copy.TabIndex = 8;
            this.Copy.Text = "复制图片";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.Enabled = false;
            this.Delete.Location = new System.Drawing.Point(925, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(112, 34);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "删除图片";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // PicList
            // 
            this.PicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.PicList.Cursor = System.Windows.Forms.Cursors.Default;
            this.PicList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicList.LabelEdit = true;
            this.PicList.Location = new System.Drawing.Point(0, 0);
            this.PicList.Margin = new System.Windows.Forms.Padding(0);
            this.PicList.Name = "PicList";
            this.PicList.Size = new System.Drawing.Size(1276, 939);
            this.PicList.TabIndex = 2;
            this.PicList.UseCompatibleStateImageBehavior = false;
            this.PicList.SelectedIndexChanged += new System.EventHandler(this.PicList_SelectedIndexChanged);
            this.PicList.DoubleClick += new System.EventHandler(this.PicList_DoubleClick);
            this.PicList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PicList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1578, 944);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(830, 500);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Text = "MineScreenShots";
            this.Load += new System.EventHandler(this.MineScreenShots_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer splitContainer1;
        private ListView DirList;
        private ColumnHeader columnHeader2;
        private ListView PicList;
        private ColumnHeader columnHeader1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Add;
        private Button Remove;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button Settings;
        private Button Delete;
        private Button Copy;
    }
}