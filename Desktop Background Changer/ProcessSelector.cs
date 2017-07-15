using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Desktop_Background_Changer
{
    public partial class ProcessSelector : Form
    {
        public ProcessSelector()
        {
            InitializeComponent();
        }

        private void ProcessSelector_Load(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcesses();
            for (int i = 0; i < procs.Length; i++)
            {
                string item = procs[i].ProcessName + " (" + procs[i].Id + ")";
                procsList.Items.Add(item);
            }
        }

        public int SelectedPID
        {
            get
            {
                if (procsList.SelectedIndex == -1) return -1;
                else
                {
                    string item = (string)procsList.SelectedItem;
                    int startIndex = item.IndexOf('('), endIndex = item.IndexOf(')');
                    string pidStr = item.Substring(startIndex + 1, endIndex - startIndex - 1);
                    return Convert.ToInt32(pidStr);
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (procsList.SelectedIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
