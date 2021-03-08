using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFolder {
    class CLI {
        private static Func<string, bool> matchContext;
        private static Action closeContext;
        public static void Init (string[] args) {
            foreach (var arg in args) {
                if (matchContext != null) {
                    if (matchContext(arg)) continue;
                    else DisposeMatcher();
                }

                switch (arg) {
                    case "--clear-cache":
                        ClearCache();
                        break;
                    case "--sync":
                        MainForm.Sync();
                        break;
                    case "--update-settings":
                        closeContext = () => SettingsForm.WriteData();
                        matchContext = MatchSettingsUpdate;
                        break;
                }
            }

            DisposeMatcher();
        }

        private static void DisposeMatcher () {
            if (closeContext != null)
                closeContext();

            closeContext = null;
            matchContext = null;
        }

        private static void ClearCache () {
            if (SettingsForm.data.inited) {
                SettingsForm.data.cache.Clear();
                SettingsForm.data.lastSync = 0;
            }

            SettingsForm.WriteData();
        }

        private static string paramName;
        private static bool MatchSettingsUpdate (string arg) {
            if (paramName != null) {
                UpdateSettings(arg);
                return true;
            }

            switch (arg) {
                case "--local-path":
                    paramName = "localPath";
                    break;
                case "--remove-path":
                    paramName = "remotePath";
                    break;
                default:
                    return false;
            }

            return true;
        }

        private static void UpdateSettings (string value) {
            switch (paramName) {
                case "localPath":
                    SettingsForm.data.localPath = value;
                    break;
                case "remotePath":
                    SettingsForm.data.remotePath = value;
                    break;
            }

            paramName = null;
        }
    }
}
