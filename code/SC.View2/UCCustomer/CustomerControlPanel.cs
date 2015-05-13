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
    public partial class CustomerControlPanel : UCSceneBasicWithTitle
    {
        public CustomerControlPanel()
        {
            InitializeComponent();
        }

        public CustomerControlPanel(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private void buttonTakePG_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.C_T_Verify);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.C_S_EntryPGInfo);
        }
    }
}
