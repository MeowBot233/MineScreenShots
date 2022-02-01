#pragma warning disable CS8618
using LitJson;
using Microsoft.WindowsAPICodePack.Shell;
using System.Diagnostics;

namespace MineScreenShots
{
    public partial class MainForm : Form
    {
        private Settings _Settings;
        private static readonly string dataPath = string.Format("{0}/MineScreenShots/", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        private static readonly string settingsPath = dataPath + "config.json";
        private readonly Dictionary<string, FileSystemWatcher> watchers = new();
        private readonly Dictionary<string, ListViewGroup> groups = new();
        public MainForm()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Directory.CreateDirectory(dataPath);
            CheckForIllegalCrossThreadCalls = false;
            PicList.LargeImageList = imageList;
            if (File.Exists(settingsPath)) _Settings = JsonMapper.ToObject<Settings>(File.ReadAllText(settingsPath));
            else _Settings = new Settings
            {
                WatchAndCopy = false,
                HideWhenStart = false
            };
            if (_Settings.HideWhenStart) WindowState = FormWindowState.Minimized;
        }
        public ImageList imageList = new()
        {
            ImageSize = new Size(384, 256),
            ColorDepth = ColorDepth.Depth32Bit
        };
        private void MineScreenShots_Load(object sender, EventArgs e)
        {
            string minecraft =
                _Settings.CustomMinecraftDir ?
                _Settings.MinecraftDir :
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\";
            string screenshots = minecraft + @"screenshots\";
            var defaultGroup = DirList.Groups.Add("default", "默认路径");
            var mainPath = new ScreenshotsPath
            {
                Name = "根目录",
                Path = new DirectoryInfo(screenshots),
                Removable = false
            };
            AddPath(mainPath, defaultGroup);
            DirectoryInfo versionsDir = new(minecraft + @"\versions\");
            DirectoryInfo[] versions = versionsDir.Exists ? versionsDir.GetDirectories() : new DirectoryInfo[0];
            foreach (var version in versions)
            {
                AddPath(new ScreenshotsPath
                {
                    Path = new DirectoryInfo(version.FullName + @"\screenshots\"),
                    Name = version.Name,
                    Removable = false
                }, defaultGroup);
            }
        }

        private void AddPath(ScreenshotsPath path, ListViewGroup group)
        {
            if (!path.Path.Exists) return;
            FileSystemWatcher watcher = new(path.Path.FullName);
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watchers.Add(path.Path.FullName, watcher);
            DirList.Items.Add(path).Group = group;
            var picGroup = PicList.Groups.Add(path.Path.FullName, path.Name);
            groups.Add(path.Path.FullName, picGroup);
            if (!path.Path.Exists) return;
            var pics = path.Path.GetFiles();
            foreach (var pic in pics)
            {
                AddFile(pic, picGroup);
            }
        }

        private void AddFile(FileInfo pic, ListViewGroup picGroup)
        {
            var item = new Screenshot
            {
                File = pic,
                Name = pic.Name,
                Group = picGroup,
                ImageKey = pic.FullName
            };
            ShellFile file = ShellFile.FromFilePath(pic.FullName);
            Icon img = file.Thumbnail.ExtraLargeIcon;
            imageList.Images.Add(pic.FullName, img);
            PicList.Items.Add(item);
        }

        private static void CopyScreenshot(Screenshot screenshot, bool silent = false)
        {
            try
            {
                Clipboard.SetImage(Image.FromFile(screenshot.File.FullName));
                if (!silent) MessageBox.Show("复制成功！");
            }
            catch (Exception ex)
            {
                if (!silent) MessageBox.Show(ex.Message, "发生错误！");
            }
        }

        private void DeleteScreenshots()
        {
            if (PicList.SelectedItems.Count == 0) return;
            var result = MessageBox.Show(string.Format("要删除这{0}张图片吗？", PicList.SelectedItems.Count), "删除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (Screenshot item in PicList.SelectedItems)
                {
                    try
                    {
                        item.File.Delete();
                        PicList.Items.Remove(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除失败！", ex.Message);
                    }
                }
            }
        }

        private static void OpenScreenshot(Screenshot screenshot)
        {
            Process.Start(new ProcessStartInfo
            {
                WorkingDirectory = screenshot.File.DirectoryName,
                FileName = "explorer.exe",
                Arguments = screenshot.File.FullName
            });
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            var file = new FileInfo(e.FullPath);
            if (file.Exists)
                PicList.Items[file.FullName].Remove();
            imageList.Images[file.FullName].Dispose();
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(2000); // 等待文件写入完成
            var file = new FileInfo(e.FullPath);
            string path = file.FullName.Remove(file.FullName.IndexOf(file.Name));
            AddFile(file, groups[path]);
            if (_Settings.WatchAndCopy)
            {
                Thread thread = new(new ThreadStart(() =>
                {
                    CopyScreenshot(new Screenshot
                    {
                        File = file,
                    }, true);
                }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

        }

        private void DirList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DirList.SelectedItems.Count == 0)
            {
                Remove.Enabled = false;
                return;
            }
            ScreenshotsPath item = (ScreenshotsPath)DirList.SelectedItems[0];
            Remove.Enabled = item.Removable;
        }

        private void PicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PicList.SelectedItems.Count == 0)
            {
                Delete.Enabled = false;
                Copy.Enabled = false;
                return;
            }
            Delete.Enabled = true;
            if (PicList.SelectedItems.Count == 1) Copy.Enabled = true;
            else Copy.Enabled = false;
        }

        private void PicList_DoubleClick(object sender, EventArgs e)
        {
            if (PicList.SelectedItems.Count != 1) return;
            Screenshot item = (Screenshot)PicList.SelectedItems[0];
            OpenScreenshot(item);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteScreenshots();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (PicList.SelectedItems.Count != 1) return;
            Screenshot screenshot = (Screenshot)PicList.SelectedItems[0];
            CopyScreenshot(screenshot);
        }


        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new(_Settings);
            var result = form.ShowDialog();
            if (result == DialogResult.OK) _Settings = form.Settings;
            File.WriteAllText(settingsPath, JsonMapper.ToJson(_Settings));
        }

        private void PicList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) DeleteScreenshots();
            else if (e.KeyCode == Keys.Enter)
            {
                foreach (Screenshot item in PicList.SelectedItems)
                    OpenScreenshot(item);
            }
        }
    }


    public class Screenshot : ListViewItem
    {
        public new string Name { get => Text; set => Text = value; }
        public FileInfo File { get; set; }
    }

    public class ScreenshotsPath : ListViewItem
    {
        public new string Name { get => Text; set => Text = value; }
        public DirectoryInfo Path { get; init; }
        public bool Removable { get; set; }
    }

    public struct Settings
    {
        public bool HideWhenStart = false;
        public bool WatchAndCopy = false;
        public bool CustomMinecraftDir = false;
        public string MinecraftDir = ".";
    }
}