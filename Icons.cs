using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PersonalFolder {
    internal class Icons {
        [DllImport("shell32", CharSet = CharSet.Unicode)]
        private static extern int ExtractIconEx (
          string lpszFile,
          int nIconIndex,
          IntPtr[] phIconLarge,
          IntPtr[] phIconSmall,
          int nIcons);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon (IntPtr hIcon);

        private static IntPtr GetHandle (string file, int index, bool isLarge) {
            IntPtr[] phIconLarge = new IntPtr[1];
            IntPtr[] phIconSmall = new IntPtr[1];
            ExtractIconEx(file, index, phIconLarge, phIconSmall, 1);
            return isLarge ? phIconLarge[0] : phIconSmall[0];
        }

        public static Icon GetSystemIcon (string file, int index, bool isLarge) {
            try {
                return Icon.FromHandle(GetHandle(file, index, isLarge));
            } catch {
                return null;
            }
        }

        public static Bitmap GetSystemBitmap (string file, int index, bool isLarge) {
            try {
                return Bitmap.FromHicon(GetHandle(file, index, isLarge));
            } catch {
                return null;
            }
        }
    }
}
