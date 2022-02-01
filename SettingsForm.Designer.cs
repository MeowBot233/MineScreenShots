namespace MineScreenShots
{
    partial class SettingsForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.HideWhenStart = new System.Windows.Forms.CheckBox();
            this.WatchAndCopy = new System.Windows.Forms.CheckBox();
            this.CustomMinecraftDir = new System.Windows.Forms.CheckBox();
            this.ChooseDir = new System.Windows.Forms.Button();
            this.MinecraftDir = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Save);
            this.flowLayoutPanel1.Controls.Add(this.Cancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 294);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 40);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(643, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(112, 34);
            this.Save.TabIndex = 0;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(525, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 34);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // HideWhenStart
            // 
            this.HideWhenStart.AutoSize = true;
            this.HideWhenStart.Location = new System.Drawing.Point(13, 13);
            this.HideWhenStart.Name = "HideWhenStart";
            this.HideWhenStart.Size = new System.Drawing.Size(144, 28);
            this.HideWhenStart.TabIndex = 1;
            this.HideWhenStart.Text = "启动时最小化";
            this.HideWhenStart.UseVisualStyleBackColor = true;
            // 
            // WatchAndCopy
            // 
            this.WatchAndCopy.AutoSize = true;
            this.WatchAndCopy.Location = new System.Drawing.Point(13, 47);
            this.WatchAndCopy.Name = "WatchAndCopy";
            this.WatchAndCopy.Size = new System.Drawing.Size(180, 28);
            this.WatchAndCopy.TabIndex = 2;
            this.WatchAndCopy.Text = "自动复制最新截图";
            this.WatchAndCopy.UseVisualStyleBackColor = true;
            // 
            // CustomMinecraftDir
            // 
            this.CustomMinecraftDir.AutoSize = true;
            this.CustomMinecraftDir.Location = new System.Drawing.Point(13, 81);
            this.CustomMinecraftDir.Name = "CustomMinecraftDir";
            this.CustomMinecraftDir.Size = new System.Drawing.Size(335, 28);
            this.CustomMinecraftDir.TabIndex = 3;
            this.CustomMinecraftDir.Text = "自定义Minecraft文件夹（重启生效）";
            this.CustomMinecraftDir.UseVisualStyleBackColor = true;
            // 
            // ChooseDir
            // 
            this.ChooseDir.Location = new System.Drawing.Point(13, 115);
            this.ChooseDir.Name = "ChooseDir";
            this.ChooseDir.Size = new System.Drawing.Size(112, 34);
            this.ChooseDir.TabIndex = 4;
            this.ChooseDir.Text = "选择文件夹";
            this.ChooseDir.UseVisualStyleBackColor = true;
            this.ChooseDir.Click += new System.EventHandler(this.ChooseDir_Click);
            // 
            // MinecraftDir
            // 
            this.MinecraftDir.AutoEllipsis = true;
            this.MinecraftDir.AutoSize = true;
            this.MinecraftDir.Location = new System.Drawing.Point(131, 120);
            this.MinecraftDir.Name = "MinecraftDir";
            this.MinecraftDir.Size = new System.Drawing.Size(100, 24);
            this.MinecraftDir.TabIndex = 5;
            this.MinecraftDir.TabStop = true;
            this.MinecraftDir.Text = "选择文件夹";
            this.MinecraftDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MinecraftDir_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(778, 344);
            this.Controls.Add(this.MinecraftDir);
            this.Controls.Add(this.ChooseDir);
            this.Controls.Add(this.CustomMinecraftDir);
            this.Controls.Add(this.WatchAndCopy);
            this.Controls.Add(this.HideWhenStart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button Save;
        private Button Cancel;
        private CheckBox HideWhenStart;
        private CheckBox WatchAndCopy;
        private CheckBox CustomMinecraftDir;
        private Button ChooseDir;
        private LinkLabel MinecraftDir;
    }
}