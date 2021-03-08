using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        internal static bool DirectoryExists (string path, int timeout = 100) {
            var task = new Task<bool>(() => {
                var info = new DirectoryInfo(path);
                return info.Exists;
            });

            task.Start();
            return task.Wait(timeout) && task.Result;
        }

        internal static Action OpenProgressDialog (Form parent, string text) {
            var dialog = new Form();
            dialog.Size = new Size(250, 120);
            dialog.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            dialog.Text = "Выполнение...";
            dialog.StartPosition = FormStartPosition.CenterParent;

            var label = new Label();
            label.Location = new Point(5, 5);
            label.Text = "Пожалуйста, подождите...\n" + text;
            label.AutoSize = false;
            label.Size = new Size(225, 32);
            label.TextAlign = ContentAlignment.MiddleCenter;
            dialog.Controls.Add(label);

            var progress = new ProgressBar();
            progress.Style = ProgressBarStyle.Marquee;
            progress.Step = 1;
            progress.Value = 100;
            progress.MarqueeAnimationSpeed = 75;
            progress.Location = new Point(5, 45);
            progress.Size = new Size(225, 32);
            dialog.Controls.Add(progress);

            var canClose = false;
            dialog.FormClosing += (sender, e) => {
                e.Cancel = !canClose;
            };

            dialog.Show(parent);
            return delegate {
                //dialog.Invoke
                canClose = true;
                dialog.Close();
            };
        }

        internal static void HashedContentsCopy (HashAlgorithm crypto, string from, string to) {
            foreach (var src in Directory.GetFiles(from)) {
                var srcBuffer = File.ReadAllBytes(src);
                var srcHash = crypto.ComputeHash(srcBuffer);

                var dest = to + "\\" + Path.GetFileName(src);
                FileStream destStream;
                try {
                    destStream = File.OpenRead(dest);
                } catch (FileNotFoundException) {
                    File.WriteAllBytes(dest, srcBuffer);
                    continue;
                }

                var destHash = crypto.ComputeHash(destStream);
                destStream.Dispose();

                for (var i = 0; i < crypto.HashSize >> 3; i++) {
                    if (srcHash[i] != destHash[i]) {
                        File.WriteAllBytes(dest, srcBuffer);
                        break;
                    }
                }
            }

            foreach (var src in Directory.GetDirectories(from)) {
                var dest = to + "\\" + Path.GetFileName(src);
                if (!Directory.Exists(dest)) {
                    Directory.CreateDirectory(dest);
                }

                HashedContentsCopy(crypto, src, dest);
            }
        }

        internal static bool IsFilesEquals (HashAlgorithm crypto, string fileA, string fileB) {
            var streamA = File.OpenRead(fileA);
            var hashA = crypto.ComputeHash(streamA);
            streamA.Dispose();

            var streamB = File.OpenRead(fileB);
            var hashB = crypto.ComputeHash(streamB);
            streamB.Dispose();

            for (var i = 0; i < crypto.HashSize; i++) {
                if (hashA[i] != hashB[i])
                    return false;
            }

            return true;
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
