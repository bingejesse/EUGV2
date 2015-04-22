using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEC.UI
{
    public partial class FrmMessagebox : Form
    {
        public FrmMessagebox()
        {
            InitializeComponent();
        }

        private int seconds;

        public void SetMessageInfo(string title, string info)
        {
            this.labelXTitle.Text = title;
            this.labelXInfo.Text = info;

            this.seconds = 10;
            this.timerMain.Enabled = true;
            this.timerMain.Start();
        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            this.timerMain.Stop();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            this.timerMain.Stop();
            this.DialogResult = DialogResult.Cancel;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            this.seconds -= 1;
            if (this.seconds < 1)
            {
                this.timerMain.Stop();
                this.DialogResult = DialogResult.Cancel;
                //this.Close();
            }
        }
    }
}
