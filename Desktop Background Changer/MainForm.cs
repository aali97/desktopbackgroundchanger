using System;
using System.Windows.Forms;

namespace Desktop_Background_Changer
{
    public partial class MainForm : Form
    {
        string currWallpaperPath;

        public MainForm()
        {
            InitializeComponent();
            ReduceToTaskbar();
            this.Shown += HideForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            pictureBox.Size = this.Size;
            stretchImageBtn.Checked = Properties.Settings.Default.Stretch;
            resetOnExitBtn.Checked = Properties.Settings.Default.ResetOnExit;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (resetOnExitBtn.Checked) ResetWallpaper(true);
            Properties.Settings.Default.Stretch = stretchImageBtn.Checked;
            Properties.Settings.Default.ResetOnExit = resetOnExitBtn.Checked;
            Properties.Settings.Default.Save();
        }

        private void changeWPToImageBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (currWallpaperPath != null && currWallpaperPath.EndsWith(".exe")) KillProc();
                ChangeWPToImage(openFileDialog.FileName);
            }
        }

        private void changeWPToAppBtn_Click(object sender, EventArgs e)
        {
            ProcessSelector selector = new ProcessSelector();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                ChangeWPToProc(selector.SelectedPID);
            }
        }

        private void stretchImageBtn_Click(object sender, EventArgs e)
        {
            if (currWallpaperPath != null)
            {
                if (stretchImageBtn.Checked) pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                else pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                if (currWallpaperPath.EndsWith(".exe"))
                {
                    int pid = Convert.ToInt32(currWallpaperPath.Substring(0, currWallpaperPath.Length - 4));
                    ChangeWPToProc(pid);
                }
                else ChangeWPToImage(currWallpaperPath);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetWallpaperBtn_Click(object sender, EventArgs e)
        {
            ResetWallpaper();
        }
    }
}
