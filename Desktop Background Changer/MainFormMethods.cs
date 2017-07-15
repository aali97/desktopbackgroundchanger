using Microsoft.Win32;
using SHDocVw;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Desktop_Background_Changer
{
    public partial class MainForm
    {
        IntPtr GetWorkerWHandle()
        {
                IntPtr progman = Global.FindWindow("Progman", null);
                IntPtr result = IntPtr.Zero;
                Global.SendMessageTimeout(progman, 0x052C, new IntPtr(0), IntPtr.Zero,
                    Global.SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out result);
                IntPtr workerW = IntPtr.Zero;
                Global.EnumWindows(new Global.EnumWindowsProc((tophandle, topparamhandle) =>
                {
                    IntPtr p = Global.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", "");

                    if (p != IntPtr.Zero)
                    {
                        // Gets the WorkerW Window after the current one.
                        workerW = Global.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", "");
                    }

                    return true;
                }), IntPtr.Zero);
            return workerW;
        }

        void HideForm(object sender, EventArgs e)
        {
            this.Hide();
            this.Shown -= HideForm;
        }

        void ReduceToTaskbar()
        {
            notifyIcon.ShowBalloonTip(1000);
            this.ShowInTaskbar = false;
        }

        #region Image wallpaper methods

        void ChangeWPToImage(string path)
        {
            try
            {
                Image newWallpaper = Image.FromFile(path);
                pictureBox.Image = newWallpaper;
                AdjustPictureBox();
                if (!this.Visible) this.Show();
                if (!pictureBox.Visible) pictureBox.Show();
                Global.SetParent(this.Handle, GetWorkerWHandle());
                currWallpaperPath = path;
            } catch (Exception) { MessageBox.Show("An error occurred"); }
        }

        void AdjustPictureBox()
        {
            if ((pictureBox.Image.Size.Height > Screen.PrimaryScreen.Bounds.Size.Height ||
                pictureBox.Image.Size.Width > Screen.PrimaryScreen.Bounds.Size.Width) || (stretchImageBtn.Checked))
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            else pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        void ResetWallpaper(bool complete = false)
        {
            if (complete)
            {
                var explorers = Process.GetProcessesByName("explorer");
                foreach (var thisExplorer in explorers)
                {
                    thisExplorer.Kill();
                }
                Process.Start("explorer.exe");
                ShellWindows windows;
                while ((windows = new SHDocVw.ShellWindows()).Count == 0)
                {
                    Thread.Sleep(10);
                }
                foreach (InternetExplorer p in windows)
                {
                    // Close explorer window
                    if (Path.GetFileNameWithoutExtension(p.FullName.ToLower()) == "explorer") p.Quit();
                }
                if (currWallpaperPath != null && currWallpaperPath.EndsWith(".exe")) KillProc();
            }
            else ChangeWPToImage(GetCurrentWallpaperPath());
        }

        string GetCurrentWallpaperPath()
        {
            RegistryKey wallPaper = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
            string WallpaperPath = wallPaper.GetValue("WallPaper").ToString();
            wallPaper.Close();
            return WallpaperPath;
        }

        #endregion

        #region Application wallpaper methods

        void ChangeWPToProc(int pid)
        {
            try
            {
                Process proc = Process.GetProcessById(pid);
                if (proc.HasExited) return;
                Process p = proc.Parent();
                //RemoveHandleMenu(proc.MainWindowHandle);

                if (!this.Visible) this.Show();
                if (pictureBox.Visible) pictureBox.Hide();

                AdoptProc(proc.MainWindowHandle);

                Global.SetParent(this.Handle, GetWorkerWHandle());
                currWallpaperPath = pid + ".exe";
            } catch (Exception) { MessageBox.Show("An error occurred"); }
        }

        void RemoveHandleMenu(IntPtr hWnd)
        {
            long style = Global.GetWindowLong(hWnd, Global.GWL_STYLE);
            style |= 0xc00000L;
            style &= -12582913L;
            Global.SetWindowLong(hWnd, Global.GWL_STYLE, (int)style);
            Global.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, (Global.SetWindowPosFlags)0x27);
        }

        void AdoptProc(IntPtr hWnd)
        {
            Global.SetParent(hWnd, this.Handle);
            Size size = stretchImageBtn.Checked ? Screen.PrimaryScreen.Bounds.Size : GetHWNDSize(hWnd);
            Global.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, size.Width, size.Height, 0);
            if (stretchImageBtn.Checked) ; //TODO: center
        }

        Size GetHWNDSize(IntPtr hWnd)
        {
            Global.RECT pRect;
            Size cSize = new Size();
            // get coordinates relative to window
            Global.GetWindowRect(hWnd, out pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;

            return cSize;
        }

        void KillProc()
        {
            if (currWallpaperPath.EndsWith(".exe"))
            {
                int pid = Convert.ToInt32(currWallpaperPath.Substring(0, currWallpaperPath.Length - 4));
                Process child = Process.GetProcessById(pid);
                child.Kill();
            }
        }

        #endregion
    }
}
