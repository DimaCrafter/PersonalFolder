//using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace PersonalFolder {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main (string[] args) {
            if (args.Length != 0) {
                CLI.Init(args);
                return;
            }

            //Updater.Install(new System.Net.WebClient(), "http://localhost:5000/PersonalFolder.exe");
            //Updater.Check();
            //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1", "CurrentLevel", 0x10000);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
