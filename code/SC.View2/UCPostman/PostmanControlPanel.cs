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
    public partial class PostmanControlPanel : UCSceneBasic
    {
        public PostmanControlPanel()
        {
            InitializeComponent();
        }

        public PostmanControlPanel(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_D_Verify, "deliver");
        }

        private void buttonTakeBack_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_T_Verify, "takeback");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_S_Verify, "search");
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_R_PGRegister);
        }
    }
}
