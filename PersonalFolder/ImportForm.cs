using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class ImportForm : Form {
        public ImportForm () {
            InitializeComponent();
        }

        private async void CopyCode (object sender, EventArgs e) {
            Clipboard.SetText(codeBox.Text);
            copyBtn.Text = "Скопировано!";
            await Task.Delay(250);
            copyBtn.Text = "Скопировать";
        }

        private void Cancel (object sender, EventArgs e) {
            Close();
        }

        private void Continue (object sender, EventArgs e) {
            var group = "<default>";
            foreach (var line in importInput.Lines) {
                switch (line[0]) {
                    case '>':
                        group = line.Substring(1);
                        Directory.CreateDirectory(SettingsForm.data.remotePath + "\\" + group);
                        if (!SettingsForm.data.cache.ContainsKey(group)) {
                            SettingsForm.data.cache.Add(group, new List<string>());
                        }
                        break;
                    case '-':
                        var user = line.Substring(1);
                        Directory.CreateDirectory(SettingsForm.data.remotePath + "\\" + group + "\\" + user);
                        if (!SettingsForm.data.cache[group].Contains(user)) {
                            SettingsForm.data.cache[group].Add(user);
                        }
                        break;
                }
            }

            SettingsForm.WriteData();
            Close();
        }
    }
}
