using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class ImportForm : Form {
        public ImportForm () {
            InitializeComponent();
            minClassInput_TextChanged();
        }

        private async void CopyCode (object sender, EventArgs e) {
            Clipboard.SetText(codeBox.Text);
            copyBtn.Text = "Скопировано!";
            await Task.Delay(750);
            copyBtn.Text = "Скопировать";
        }

        private void Cancel (object sender, EventArgs e) {
            Close();
        }

        private void Continue (object sender, EventArgs e) {
            var closeDialog = Utils.OpenProgressDialog(this, "Выполняется импорт пользователей...");
            Enabled = false;

            new Thread((ThreadStart) delegate {
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
                Invoke((Action) delegate {
                    closeDialog();
                    Close();
                });
            }).Start();
        }

        private void minClassInput_TextChanged (object sender = null, EventArgs e = null) {
            try {
                var minClass = int.Parse(minClassInput.Text);
                var resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
                codeBox.Text = resources.GetString("codeBox.Text").Replace("{{ minClass }}", minClass.ToString());
            } catch {
            }
        }
    }
}
