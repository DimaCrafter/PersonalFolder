using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class ExplorerForm : Form {
        private string basePath;
        private string group;
        public ExplorerForm (string basePath, string group) {
            this.basePath = basePath;
            this.group = group;
            InitializeComponent();

            Icon = Icons.GetSystemIcon("explorer.exe", 0, true);
            OpenCurrentPath();
        }

        private void webBrowser1_Navigated (object sender, WebBrowserNavigatedEventArgs e) {
            Text = webBrowser1.DocumentTitle;
            backBtn.Enabled = webBrowser1.CanGoBack;
            nextBtn.Enabled = webBrowser1.CanGoForward;
            SetPath();
        }

        private void SetPath () {
            pathInput.Text = webBrowser1.Url.LocalPath.Substring(basePath.Length);
            if (pathInput.Text.Length == 0) {
                pathInput.Text = "\\";
            }
        }

        private void backBtn_Click (object sender, EventArgs e) {
            webBrowser1.GoBack();
        }

        private void nextBtn_Click (object sender, EventArgs e) {
            webBrowser1.GoForward();
        }

        private void systemIconButton1_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.List);
        }

        private void systemIconButton3_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.SmallIcons);
        }

        private void systemIconButton5_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.Details);
        }

        private void systemIconButton6_Click (object sender, EventArgs e) {
            OpenCurrentPath();
        }

        private void pathInput_TextUpdate (object sender, EventArgs e) {
            pathInput.DroppedDown = true;
            var path = basePath + pathInput.Text;
            var parentPath = Path.GetDirectoryName(path);

            pathInput.BeginUpdate();
            for (var i = 0; i < pathInput.Items.Count; i++) {
                pathInput.Items.RemoveAt(i);
            }

            //pathInput.Items.Add(pathInput.Text);

            try {
                foreach (var entry in Directory.GetDirectories(parentPath)) {
                    if (entry.StartsWith(path)) {
                        pathInput.Items.Add(entry.Substring(basePath.Length));
                    }
                }
            } catch {
            }

            pathInput.EndUpdate();
        }

        private void pathInput_SelectedIndexChanged (object sender, EventArgs e) {

        }

        private void pathInput_Click (object sender, EventArgs e) {
            pathInput.Select(pathInput.Text.Length, 0);
        }

        private void pathInput_SelectionChangeCommitted (object sender, EventArgs e) {
            if (pathInput.SelectedIndex == -1) return;

            var value = pathInput.SelectedItem.ToString();
            pathInput.Items.Clear();

            // Doesn't work without task
            Task.Run(() => {
                pathInput.Invoke((Action) delegate {
                    pathInput.Text = value;
                });

                OpenCurrentPath();
            });
        }

        private void pathInput_KeyPress (object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r') {
                OpenCurrentPath();
                e.Handled = true;
            }
        }

        private void OpenCurrentPath () {
            var path = Path.GetFullPath(basePath + pathInput.Text);
            if (!path.StartsWith(basePath)) {
                path = basePath;
                pathInput.Text = "\\";
            }

            if (Directory.Exists(path)) {
                try { webBrowser1.Navigate(path); }
                catch (System.Runtime.InteropServices.COMException) { }
            } else {
                MessageBox.Show(null, "Указанная директория не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void systemIconButton7_Click (object sender, EventArgs e) {
            var templatesDir = SettingsForm.data.remoteTemplatesPath;
            if (!Utils.DirectoryExists(templatesDir)) {
                templatesDir = SettingsForm.data.localTemplatesPath;
            }

            var templateDirs = Directory.GetDirectories(templatesDir);

            var items = new List<ToolStripItem>();
            foreach (var dir in templateDirs) {
                var namePattern = Path.GetFileName(dir).Replace('#', '.');
                if (Regex.IsMatch(group, "^" + namePattern + "$")) {
                    foreach (var templateFile in Directory.GetFiles(dir)) {
                        var item = new MenuFileItem(templateFile);
                        item.Click += onTemplateSelect;
                        items.Add(item);
                    }
                }
            }

            templatesMenu.Items.Clear();
            templatesMenu.Items.AddRange(items.ToArray());
            if (items.Count == 0) {
                templatesMenu.Items.AddRange(new ToolStripItem[] { new ToolStripMenuItem { Text = "Пусто", Enabled = false } });
            }

            templatesMenu.Show(templatesBtn, Point.Empty);
        }

        private void onTemplateSelect (object sender, EventArgs e) {
            var item = (MenuFileItem) sender;
            var dest = basePath + "\\" + Path.GetFileName(item.path);

            if (File.Exists(dest)) {
                var result = MessageBox.Show(
                    "Файл \"" + Path.GetFileNameWithoutExtension(item.path) + "\" уже существет.\nПерезаписать?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;
                File.Delete(dest);
            }

            File.Copy(item.path, dest);
            Process.Start(dest);
        }
    }
}
