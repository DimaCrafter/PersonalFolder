using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class MainForm : Form {
        public MainForm () {
            var closeDialog = Utils.OpenProgressDialog(this, "Выполняется синхронизация...");
            InitializeComponent();

            if (!SettingsForm.data.inited) {
                OpenSettings();
            }

            new Thread((ThreadStart) delegate {
                Sync();

                Invoke((Action) delegate {
                    RefreshList();
                    closeDialog();
                });
            }).Start();
        }

        public static void Sync () {
            if (!Directory.Exists(SettingsForm.data.localTemplatesPath)) {
                Directory.CreateDirectory(SettingsForm.data.localTemplatesPath);
            }

            if (Utils.DirectoryExists(SettingsForm.data.remotePath)) {
                SettingsForm.data.cache.Clear();
                foreach (var groupPath in Directory.GetDirectories(SettingsForm.data.remotePath)) {
                    var group = Path.GetFileName(groupPath);
                    var list = new List<string>();
                    foreach (var userPath in Directory.GetDirectories(groupPath)) {
                        list.Add(Path.GetFileName(userPath));
                    }

                    SettingsForm.data.cache.Add(group, list);
                }

                if (Directory.Exists(SettingsForm.data.localPath)) {
                    new Thread((ThreadStart) delegate {
                        Utils.MoveMerge(SettingsForm.data.localPath, SettingsForm.data.remotePath);
                    });
                }

                var today = (ushort) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds / 60 / 60 / 24);
                if (SettingsForm.data.lastSync < today) {
                    var md5 = MD5.Create();
                    Utils.HashedContentsCopy(md5, SettingsForm.data.remoteTemplatesPath, SettingsForm.data.localTemplatesPath);

                    md5.Dispose();
                    SettingsForm.data.lastSync = today;
                }

                SettingsForm.WriteData();
            }
        }

        private void OpenSettings (object sender = null, EventArgs e = null) {
            new SettingsForm().ShowDialog(this);
            RefreshList();
        }

        private void RefreshList () {
            groupsSelect.BeginUpdate();
            groupsSelect.Items.Clear();
            foreach (var group in SettingsForm.data.cache.Keys) {
                groupsSelect.Items.Add(group);
            }

            groupsSelect.EndUpdate();
            DisableUsersSelect();
        }

        private void DisableUsersSelect () {
            usersSelect.Enabled = false;
            usersSelect.Items.Clear();
            usersSelect.Items.Add("Выберите группу");
        }

        private void onGroupSelect (object sender, EventArgs e) {
            if (groupsSelect.SelectedIndex == -1) {
                DisableUsersSelect();
                return;
            }

            usersSelect.Enabled = true;
            usersSelect.BeginUpdate();
            usersSelect.Items.Clear();
            foreach (var user in SettingsForm.data.cache[(string) groupsSelect.SelectedItem]) {
                usersSelect.Items.Add(user);
            }

            usersSelect.EndUpdate();
        }

        private void OpenSelectedUser (object sender, EventArgs e) {
            if (groupsSelect.SelectedIndex == -1 || usersSelect.SelectedIndex == -1) {
                return;
            }

            Hide();
            var path = SettingsForm.data.remotePath + "\\" + groupsSelect.SelectedItem + "\\" + usersSelect.SelectedItem;
            var isOffline = false;
            if (!Directory.Exists(path)) {
                path = SettingsForm.data.localPath + "\\" + groupsSelect.SelectedItem + "\\" + usersSelect.SelectedItem;
                Directory.CreateDirectory(path);
                isOffline = true;
            }

            var explorer = new ExplorerForm(path, (string) groupsSelect.SelectedItem);
            explorer.FormClosed += (_e, _sender) => {
                Close();

                if (isOffline) {
                    var remotePath = SettingsForm.data.remotePath + "\\" + groupsSelect.SelectedItem + "\\" + usersSelect.SelectedItem;
                    if (Directory.Exists(remotePath)) {
                        Utils.MoveMerge(path, remotePath);
                    }
                }
            };

            explorer.Show();
        }
    }
}
