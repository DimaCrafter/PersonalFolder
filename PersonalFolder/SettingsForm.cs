using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PersonalFolder {
    public partial class SettingsForm : Form {
        public static SettingsData data = new SettingsData();
        private static string settingsPath = Environment.CurrentDirectory + "\\settings.bin";
        static SettingsForm () {
            data.cache = new Dictionary<string, List<string>>();

            if (File.Exists(settingsPath)) {
                var reader = new BinaryReader(File.OpenRead(settingsPath));
                try {
                    data.localPath = reader.ReadString();
                    data.remotePath = reader.ReadString();

                    var cachedCount = reader.ReadByte();
                    for (var i = 0; i < cachedCount; i++) {
                        var group = reader.ReadString();
                        var list = new List<string>();

                        var listCount = reader.ReadByte();
                        for (var j = 0; j < listCount; j++) {
                            list.Add(reader.ReadString());
                        }

                        data.cache.Add(group, list);
                    }

                    data.inited = true;
                } catch (Exception err) {
                    MessageBox.Show("Невозможно прочитать файл настроек\n" + err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Dispose();
            }
        }

        public SettingsForm () {
            InitializeComponent();

            if (data.inited) {
                localPathInput.Text = data.localPath;
                remotePathInput.Text = data.remotePath;
            }
        }

        private void Cancel (object sender, EventArgs e) {
            Close();
        }

        private void Save (object sender, EventArgs e) {
            data.localPath = localPathInput.Text;
            data.remotePath = remotePathInput.Text;
            WriteData();
            Close();
        }

        public static void WriteData () {
            var writer = new BinaryWriter(File.OpenWrite(settingsPath));
            writer.Write(data.localPath);
            writer.Write(data.remotePath);

            writer.Write((byte) data.cache.Count);
            foreach (var pair in data.cache) {
                writer.Write(pair.Key);
                writer.Write((byte) pair.Value.Count);
                foreach (var user in pair.Value) {
                    writer.Write(user);
                }
            }

            writer.Dispose();
        }

        private void SelectLocalPath (object sender, EventArgs e) {
            localPathInput.Text = OpenPathSelector(localPathInput.Text);
        }

        private void SelectRemotePath (object sender, EventArgs e) {
            remotePathInput.Text = OpenPathSelector(remotePathInput.Text);
        }

        private string OpenPathSelector (string start) {
            folderDialog.SelectedPath = start;
            if (folderDialog.ShowDialog(this) == DialogResult.OK) {
                return folderDialog.SelectedPath;
            } else {
                return start;
            }
        }

        private void Import (object sender, EventArgs e) {
            new ImportForm().ShowDialog(this);
        }
    }

    public struct SettingsData {
        public bool inited;
        public string localPath;
        public string remotePath;
        public Dictionary<string, List<string>> cache;
    }
}
