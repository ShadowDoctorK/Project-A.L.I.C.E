using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALICE_Actions;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;
using ALICE_Settings;
using System.Diagnostics;
using ALICE_Debug;

namespace ALICE_Interface
{
    public static class IScreenshot
    {
        private static bool Enabled = false;

        /// <summary>
        /// Saves a screenshot to "\...\A.L.I.C.E User Data\Screenshots\"
        /// </summary>
        public static void Save()
        {
            string MethodName = "Screenshot";            
            
            if (Enabled == false)
            {
                Logger.Log(MethodName, "This Feature Is Disabled While Development Is In Progress. Try Again Next Update", Logger.Purple);
                return;
            }

            try
            {
                //Screenshot The Active Window
                //Call.Key.Press(Call.Key.ActiveScreenshot, 100);

                //Prepair The File Name & Path
                string FileName = GetFileName();
                string FilePath = Paths.ALICE_Screenshots + FileName;

                IntPtr Temp = EliteHandle(); if (Temp != IntPtr.Zero)
                {
                    ScreenCapture Cap = new ScreenCapture();
                    Image I = Cap.CaptureWindow(Temp);

                    I.Save(FilePath, ImageFormat.Png);

                    //Log File Name & Location
                    Logger.Log(MethodName, "Image Saved: " + FileName, Logger.Yellow);
                    Logger.Log(MethodName, "Image Location: " + Paths.ALICE_Screenshots, Logger.Yellow);
                }
            }
            catch (ThreadStateException ex)
            {
                Logger.Exception(MethodName, "Thread State Exception: " + ex);
                Logger.Log(MethodName, "Failed To Take Screenshot Try Again...", Logger.Yellow);
            }
            catch (ExternalException ex)
            {
                Logger.Exception(MethodName, "External Exception: " + ex);
                Logger.Log(MethodName, "Failed To Take Screenshot Try Again...", Logger.Yellow);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Log(MethodName, "Failed To Take Screenshot Try Again...", Logger.Yellow);
            }
        }

        /// <summary>
        /// Creates the Virtual Keys to capture the Active Window.
        /// </summary>
        public static AliceKeys.Bind ActiveScreenCap()
        {
            AliceKeys.Bind Temp = new AliceKeys.Bind()
            {
                Name = "ActiveScreenCap",
                Key1 = "Key_LeftAlt",
                Key2 = "Key_SYSRQ",
                Key3 = null,
                Key4 = null
            };

            return Temp;
        }

        public static IntPtr EliteHandle()
        {
            string MethodName = "Screenshot";

            Process[] Processes = Process.GetProcesses();

            foreach (var Item in Processes)
            {
                if (Item.MainWindowTitle != "")
                {

                }

                if (Item.MainWindowTitle == "Elite - Dangerous (CLIENT)")
                { return Item.MainWindowHandle; }
            }
            Logger.Log(MethodName, "Unable To Find The Elite Dangerous Window", Logger.Red);
            return IntPtr.Zero;         
        }

        private static string GetFileName()
        {
            string MethodName = "Screenshot (Get File Name)";

            //Check If We Are Exploring A Planet or Ring
            string Mod = ""; if (
                ICheck.SupercruiseExit.BodyType(MethodName, true, IEnums.Planet) ||
                ICheck.SupercruiseExit.BodyType(MethodName, true, IEnums.PlanetaryRing))
            {
                Mod = "-" + ICheck.SupercruiseExit.Body(MethodName);
            }

            string Time = DateTime.UtcNow.ToString("s").Replace(":", ".").Replace("-", ".");

            //Return Generated File Name
            return ISettings.Commander + "-" + IObjects.SystemCurrent.Name + Mod + "-" + Time + ".png";
        }

        /// <summary>
        /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
        /// </summary>
        public class ScreenCapture
        {
            /// <summary>
            /// Creates an Image object containing a screen shot of the entire desktop
            /// </summary>
            /// <returns></returns>
            public Image CaptureScreen()
            {
                return CaptureWindow(User32.GetDesktopWindow());
            }
            /// <summary>
            /// Creates an Image object containing a screen shot of a specific window
            /// </summary>
            /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
            /// <returns></returns>
            public Image CaptureWindow(IntPtr handle)
            {
                // get te hDC of the target window
                IntPtr hdcSrc = User32.GetWindowDC(handle);
                // get the size
                User32.RECT windowRect = new User32.RECT();
                User32.GetWindowRect(handle, ref windowRect);
                int width = windowRect.right - windowRect.left;
                int height = windowRect.bottom - windowRect.top;
                // create a device context we can copy to
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                // bitblt over
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                // restore selection
                GDI32.SelectObject(hdcDest, hOld);
                // clean up 
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);
                // get a .NET image object for it
                Image img = Image.FromHbitmap(hBitmap);
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);
                return img;
            }
            /// <summary>
            /// Captures a screen shot of a specific window, and saves it to a file
            /// </summary>
            /// <param name="handle"></param>
            /// <param name="filename"></param>
            /// <param name="format"></param>
            public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
            {
                Image img = CaptureWindow(handle);
                img.Save(filename, format);
            }
            /// <summary>
            /// Captures a screen shot of the entire desktop, and saves it to a file
            /// </summary>
            /// <param name="filename"></param>
            /// <param name="format"></param>
            public void CaptureScreenToFile(string filename, ImageFormat format)
            {
                Image img = CaptureScreen();
                img.Save(filename, format);
            }

            /// <summary>
            /// Helper class containing Gdi32 API functions
            /// </summary>
            private class GDI32
            {
                public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
                [DllImport("gdi32.dll")]
                public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                    int nWidth, int nHeight, IntPtr hObjectSource,
                    int nXSrc, int nYSrc, int dwRop);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                    int nHeight);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteObject(IntPtr hObject);
                [DllImport("gdi32.dll")]
                public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
            }

            /// <summary>
            /// Helper class containing User32 API functions
            /// </summary>
            private class User32
            {
                [StructLayout(LayoutKind.Sequential)]
                public struct RECT
                {
                    public int left;
                    public int top;
                    public int right;
                    public int bottom;
                }
                [DllImport("user32.dll")]
                public static extern IntPtr GetDesktopWindow();
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowDC(IntPtr hWnd);
                [DllImport("user32.dll")]
                public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            }
        }
    }
}
