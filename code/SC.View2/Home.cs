using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC.View2
{
    public partial class Home :UCSceneBasic
    {
        public Home()
        {
            InitializeComponent();
        }

        public Home(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.C_ControlPanel);
        }

        private void buttonPostman_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_ControlPanel);
        }
    }
}
