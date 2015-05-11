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
    public partial class PostmanTBEntryPGInfo : UCSceneWithKeyboadBasic
    {
        public PostmanTBEntryPGInfo()
        {
            InitializeComponent();
        }

        public PostmanTBEntryPGInfo(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            base.labelMessage.Text = "提示信息：请输入要取回的快递单号";
            this.textPGCode.Text = "";
            this.textPGCode.Focus();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_T_FinishWork);
        }
    }
}
