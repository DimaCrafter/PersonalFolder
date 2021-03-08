using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PersonalFolder {
    class Updater {
        public const string REPO_NAME = "JsOS-Team/JsOS";
        private const string VERSION_START = "\"tag_name\":\"";
        private const string LINK_START = "\"browser_download_url\":\"";
        public static void Check () {
            var client = new WebClient();
            
            client.Headers.Add(HttpRequestHeader.UserAgent, "PersonalFolderUpdater/" + Application.ProductVersion);
            var res = client.DownloadString("https://api.github.com/repos/" + REPO_NAME + "/releases");

            var startIndex = res.IndexOf(VERSION_START);
            if (startIndex == -1) return;

            startIndex += VERSION_START.Length;
            var version = res.Substring(startIndex, res.IndexOf('"', startIndex) - startIndex);

            if (!IsNewerVersion(version)) return;
            startIndex = res.IndexOf(LINK_START, startIndex);
            if (startIndex == -1) return;

            startIndex += LINK_START.Length;
            var link = res.Substring(startIndex, res.IndexOf('"', startIndex) - startIndex);
            Install(client, link);
        }

        public static bool IsNewerVersion (string version) {
            var partsOld = Application.ProductVersion.Split('.');
            var partsNew = version.Split('.');
            for (var i = 0; i < partsOld.Length; i++) {
                var partOld = int.Parse(partsOld[i]);
                var partNew = int.Parse(partsNew[i]);
                if (partNew > partOld) {
                    return true;
                } else if (partNew < partOld) {
                    return false;
                }
            }

            return false;
        }

        public static void Install (WebClient client, string link) {
            var buffer = client.DownloadData(link);
            var exe = Application.ExecutablePath.Replace('/', '\\');

            File.WriteAllBytes(exe + ".dwl", buffer);
            File.WriteAllLines(exe + "_install.bat", new string[] {
                 "@echo off",
                 "timeout /T 1",
                $"DEL \"{exe}\"",
                $"MOVE \"{exe}.dwl\" \"{exe}\"",
                $"DEL \"{exe}_install.bat\"",
                $"\"{exe}\""
            });

            Process.Start(new ProcessStartInfo {
                FileName = exe + "_install.bat",
                UseShellExecute = true,
                CreateNoWindow = true,
                
            });

            Process.GetCurrentProcess().Kill();
        }
    }
}
