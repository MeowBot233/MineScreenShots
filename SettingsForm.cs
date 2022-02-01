using System.ComponentModel;
using System.Diagnostics;

namespace MineScreenShots
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            Settings = settings;
            WatchAndCopy.Checked = settings.WatchAndCopy;
            HideWhenStart.Checked = settings.HideWhenStart;
            CustomMinecraftDir.Checked = settings.CustomMinecraftDir;
            ChooseDir.Enabled = CustomMinecraftDir.Checked;
            MinecraftDir.Enabled = CustomMinecraftDir.Checked;
            MinecraftDir.Text = settings.MinecraftDir;
            WatchAndCopy.CheckedChanged += WatchAndCopy_CheckedChanged;
            HideWhenStart.CheckedChanged += HideWhenStart_CheckedChanged;
            CustomMinecraftDir.CheckedChanged += CustomMinecraftDir_CheckedChanged;
        }

        private bool SettingsModified = false;
        private bool Saved = false;
        public Settings Settings;

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (Settings.CustomMinecraftDir && !Directory.Exists(Settings.MinecraftDir))
            {
                e.Cancel = true;
                MessageBox.Show("Minecraft文件夹不存在！", "错误！");
                return;
            }

            if (SettingsModified)
            {
                if (!Saved && MessageBox.Show("不保存更改？", "更改未保存", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                DialogResult = DialogResult.OK;
            }
            else DialogResult = DialogResult.Cancel;
        }

        private void HideWhenStart_CheckedChanged(object? sender, EventArgs e)
        {
            SettingsModified = true;
            Settings.HideWhenStart = HideWhenStart.Checked;
        }

        private void WatchAndCopy_CheckedChanged(object? sender, EventArgs e)
        {
            SettingsModified = true;
            Settings.WatchAndCopy = WatchAndCopy.Checked;
        }

        private void CustomMinecraftDir_CheckedChanged(object? sender, EventArgs e)
        {
            ChooseDir.Enabled = CustomMinecraftDir.Checked;
            MinecraftDir.Enabled = CustomMinecraftDir.Checked;
            SettingsModified = true;
            Settings.CustomMinecraftDir = CustomMinecraftDir.Checked;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SettingsModified = false;
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Saved = true;
            Close();
        }

        private void MinecraftDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Settings.MinecraftDir))
                Process.Start("explorer.exe", Settings.MinecraftDir);
            else MessageBox.Show("文件夹不存在！", "错误！");
        }

        private void ChooseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                Description = "选择.minecraft文件夹",
                UseDescriptionForTitle = true
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                Settings.MinecraftDir = dialog.SelectedPath;
                MinecraftDir.Text = dialog.SelectedPath;
            }
        }
    }
}
