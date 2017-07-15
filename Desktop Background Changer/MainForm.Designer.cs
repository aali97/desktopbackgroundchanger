namespace Desktop_Background_Changer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem changeWallpaperBtn;
            this.changeWPToImageBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWPToAppBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stretchImageBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.resetWallpaperBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resetOnExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            changeWallpaperBtn = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.notifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // changeWallpaperBtn
            // 
            changeWallpaperBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeWPToImageBtn,
            this.changeWPToAppBtn});
            changeWallpaperBtn.Name = "changeWallpaperBtn";
            changeWallpaperBtn.Size = new System.Drawing.Size(171, 22);
            changeWallpaperBtn.Text = "Change Wallpaper";
            // 
            // changeWPToImageBtn
            // 
            this.changeWPToImageBtn.Name = "changeWPToImageBtn";
            this.changeWPToImageBtn.Size = new System.Drawing.Size(152, 22);
            this.changeWPToImageBtn.Text = "To Image";
            this.changeWPToImageBtn.Click += new System.EventHandler(this.changeWPToImageBtn_Click);
            // 
            // changeWPToAppBtn
            // 
            this.changeWPToAppBtn.Name = "changeWPToAppBtn";
            this.changeWPToAppBtn.Size = new System.Drawing.Size(152, 22);
            this.changeWPToAppBtn.Text = "To Application";
            this.changeWPToAppBtn.Click += new System.EventHandler(this.changeWPToAppBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(284, 261);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Live Wallpaper is now running";
            this.notifyIcon.BalloonTipTitle = "Live Wallpaper";
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = global::Desktop_Background_Changer.Properties.Resources.Icon;
            this.notifyIcon.Text = "Live Wallpaper";
            this.notifyIcon.Visible = true;
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            changeWallpaperBtn,
            this.stretchImageBtn,
            this.resetWallpaperBtn,
            this.resetOnExitBtn,
            this.exitBtn});
            this.notifyIconMenu.Name = "contextMenuStrip1";
            this.notifyIconMenu.Size = new System.Drawing.Size(172, 136);
            // 
            // stretchImageBtn
            // 
            this.stretchImageBtn.Checked = true;
            this.stretchImageBtn.CheckOnClick = true;
            this.stretchImageBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stretchImageBtn.Name = "stretchImageBtn";
            this.stretchImageBtn.Size = new System.Drawing.Size(171, 22);
            this.stretchImageBtn.Text = "Stretch Image";
            this.stretchImageBtn.Click += new System.EventHandler(this.stretchImageBtn_Click);
            // 
            // resetWallpaperBtn
            // 
            this.resetWallpaperBtn.Name = "resetWallpaperBtn";
            this.resetWallpaperBtn.Size = new System.Drawing.Size(171, 22);
            this.resetWallpaperBtn.Text = "Reset Wallpaper";
            this.resetWallpaperBtn.Click += new System.EventHandler(this.resetWallpaperBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(171, 22);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.gif";
            this.openFileDialog.Filter = "Animated images|*.gif";
            this.openFileDialog.Title = "Pick a wallpaper";
            // 
            // resetOnExitBtn
            // 
            this.resetOnExitBtn.Checked = true;
            this.resetOnExitBtn.CheckOnClick = true;
            this.resetOnExitBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resetOnExitBtn.Name = "resetOnExitBtn";
            this.resetOnExitBtn.Size = new System.Drawing.Size(171, 22);
            this.resetOnExitBtn.Text = "Reset On Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBox);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.notifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem resetWallpaperBtn;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem changeWPToImageBtn;
        private System.Windows.Forms.ToolStripMenuItem changeWPToAppBtn;
        private System.Windows.Forms.ToolStripMenuItem stretchImageBtn;
        private System.Windows.Forms.ToolStripMenuItem resetOnExitBtn;
    }
}

