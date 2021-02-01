using System;
using System.IO;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class MainForm : Form {
        public MainForm () {
            InitializeComponent();
            if (!SettingsForm.data.inited) {
                OpenSettings();
            }

            Sync();
            RefreshList();
        }

        private void Sync () {
            if (!Directory.Exists(SettingsForm.data.remotePath) || !Directory.Exists(SettingsForm.data.localPath)) {
                return;
            }

            Utils.MoveMerge(SettingsForm.data.localPath, SettingsForm.data.remotePath);
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

            var explorer = new ExplorerForm(path);
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
