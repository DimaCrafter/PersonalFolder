using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class ExplorerForm : Form {
        private string basePath;
        public ExplorerForm (string basePath) {
            this.basePath = basePath;
            InitializeComponent();

            Icon = Icons.GetSystemIcon("explorer.exe", 0, true);
            OpenCurrentPath();
        }

        private void button1_Click (object sender, EventArgs e) {
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

        private void systemIconButton2_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.Icons);
        }

        private void systemIconButton3_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.SmallIcons);
        }

        private void systemIconButton4_Click (object sender, EventArgs e) {
            var view = Win32.GetViewHandle(webBrowser1);
            Win32.ChangeViewType(view, Win32.ViewType.Tiles);
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
    }
}
