using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PersonalFolder {
    class MenuFileItem : ToolStripMenuItem {
        public readonly string path;
        public MenuFileItem (string path) {
            this.path = path;
            Image = ExtractFileIcon(path);
            Text = Path.GetFileNameWithoutExtension(path);
        }

        private static Dictionary<string, Bitmap> extensions = new Dictionary<string, Bitmap>();
        private static Bitmap ExtractFileIcon (string path) {
            var extension = Path.GetExtension(path);
            if (extensions.ContainsKey(extension))
                return extensions[extension];

			Win32.SHFILEINFO shellInfo = new Win32.SHFILEINFO();
			Win32.SHGetFileInfo(
                path,
				Win32.FILE_ATTRIBUTE_NORMAL,
				ref shellInfo,
				(uint) System.Runtime.InteropServices.Marshal.SizeOf(shellInfo),
                Win32.SHGFI_ICON | Win32.SHGFI_USEFILEATTRIBUTES | Win32.SHGFI_SMALLICON
            );

			var icon = (Icon) Icon.FromHandle(shellInfo.hIcon).Clone();
			Win32.DestroyIcon(shellInfo.hIcon);

            var bitmap = icon.ToBitmap();
            extensions.Add(extension, bitmap);
			return bitmap;
		}
    }
}
