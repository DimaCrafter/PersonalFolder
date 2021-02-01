using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFolder {
    class Win32 {
        public enum ViewType {
            Icons,
            Details,
            SmallIcons,
            List,
            Tiles
        }

        private const int EM_HIDEBALLOONTIP = 0x1504;
        private const int LVM_SETVIEW = 0x108E;
        private const string ListViewClassName = "SysListView32";



        private static readonly HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern bool EnumChildWindows (HandleRef hwndParent, EnumChildrenCallback lpEnumFunc, HandleRef lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage (HandleRef hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint RealGetWindowClass (IntPtr hwnd, [Out] StringBuilder pszType, uint cchType);

        private delegate bool EnumChildrenCallback (IntPtr hwnd, IntPtr lParam);


        public static void ChangeViewType (HandleRef viewHandle, ViewType type) {
            if (viewHandle.Handle != IntPtr.Zero) {
                SendMessage(viewHandle, LVM_SETVIEW, (int) type, 0);
            }
        }

        public static HandleRef GetViewHandle (WebBrowser browser) {
            var result = NullHandleRef;
            var lpEnumFunc = new EnumChildrenCallback((handle, lparam) => {
                StringBuilder sb = new StringBuilder(100);
                RealGetWindowClass(handle, sb, 100);

                if (sb.ToString() == ListViewClassName) {
                    result = new HandleRef (null, handle);
                    return false;
                }

                return true;
            });

            EnumChildWindows(new HandleRef(browser, browser.Handle), lpEnumFunc, NullHandleRef);
            return result;
        }
    }
}
