using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PersonalFolder {
    class Utils {
        public static unsafe Bitmap GrayscaleImage (Image _img, float lightness) {
            var img = (Bitmap) _img.Clone();
            var imgData = img.LockBits(new Rectangle(Point.Empty, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            for (var y = 0; y < img.Height; y++) {
                for (var x = 0; x < img.Width; x++) {
                    var i = (byte*) imgData.Scan0 + imgData.Stride * y + x * 4;
                    i[2] = i[1] = i[0] = (byte) ((i[2] + i[1] + i[0]) * lightness / 3);
                }
            }

            img.UnlockBits(imgData);
            return img;
        }

        internal static bool MoveMerge (string localPath, string remotePath) {
            var isRemove = true;
            foreach (var localDir in Directory.GetDirectories(localPath)) {
                var dirName = Path.GetFileName(localDir);
                if (!MoveMerge(localDir, remotePath + "\\" + dirName)) {
                    isRemove = false;
                }
            }

            foreach (var localFile in Directory.GetFiles(localPath)) {
                var fileName = Path.GetFileName(localFile);
                try {
                    File.Move(localFile, remotePath + "\\" + fileName);
                } catch {
                    isRemove = false;
                }
            }

            try {
                if (isRemove) Directory.Delete(localPath, true);
            } catch {
                isRemove = false;
            }

            return isRemove;
        }
    }
}
