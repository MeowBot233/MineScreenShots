#pragma warning disable CS8618
using LitJson;
using Microsoft.WindowsAPICodePack.Shell;
using System.Diagnostics;

namespace MineScreenShots
{
    public partial class MainForm : Form
    {
        private Settings _settings;
        private static readonly string DataPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/MineScreenShots/";
        private static readonly string SettingsPath = DataPath + "config.json";
        private readonly Dictionary<string, FileSystemWatcher> _watchers = new();
        private readonly Dictionary<string, ListViewGroup> _groups = new();
        public MainForm()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Directory.CreateDirectory(DataPath);
            CheckForIllegalCrossThreadCalls = false;
            PicList.LargeImageList = imageList;
            if (File.Exists(SettingsPath)) _settings = JsonMapper.ToObject<Settings>(File.ReadAllText(SettingsPath));
            else _settings = new Settings
            {
                WatchAndCopy = false, 
                HideWhenStart = false
            };
            if (_settings.HideWhenStart) WindowState = FormWindowState.Minimized;
        }
        private ImageList imageList = new()
        {
            ImageSize = new Size(256, 144),
            ColorDepth = ColorDepth.Depth32Bit
        };
        private void MineScreenShots_Load(object sender, EventArgs e)
        {
            var minecraft =
                _settings.CustomMinecraftDir ?
                _settings.MinecraftDir :
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\";
            var screenshots = minecraft + @"screenshots\";
            var defaultGroup = DirList.Groups.Add("default", "默认路径");
            var mainPath = new ScreenshotsPath
            {
                Name = "根目录",
                Path = new DirectoryInfo(screenshots),
                Removable = false
            };
            AddPath(mainPath, defaultGroup);
            DirectoryInfo versionsDir = new(minecraft + @"\versions\");
            var versions = versionsDir.Exists ? versionsDir.GetDirectories() : Array.Empty<DirectoryInfo>();
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
            _watchers.Add(path.Path.FullName, watcher);
            DirList.Items.Add(path).Group = group;
            var picGroup = PicList.Groups.Add(path.Path.FullName, path.Name);
            _groups.Add(path.Path.FullName, picGroup);
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
            var result = MessageBox.Show($"要删除这{PicList.SelectedItems.Count}张图片吗？", "删除", MessageBoxButtons.YesNo);
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
            imageList.Images[file.FullName]?.Dispose();
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(2000); // 等待文件写入完成
            var file = new FileInfo(e.FullPath);
            var path = file.FullName.Remove(file.FullName.IndexOf(file.Name, StringComparison.Ordinal));
            AddFile(file, _groups[path]);
            if (!_settings.WatchAndCopy) return;
            Thread thread = new(() =>
            {
                CopyScreenshot(new Screenshot
                {
                    File = file,
                }, true);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

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
            SettingsForm form = new(_settings);
            var result = form.ShowDialog();
            if (result == DialogResult.OK) _settings = form.Settings;
            File.WriteAllText(SettingsPath, JsonMapper.ToJson(_settings));
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
        public FileInfo File { get; init; }
    }

    public class ScreenshotsPath : ListViewItem
    {
        public new string Name { get => Text; init => Text = value; }
        public DirectoryInfo Path { get; init; }
        public bool Removable { get; init; }
    }

    public struct Settings
    {
        public bool HideWhenStart = false;
        public bool WatchAndCopy = false;
        public bool CustomMinecraftDir = false;
        public string MinecraftDir = ".";
    }
}