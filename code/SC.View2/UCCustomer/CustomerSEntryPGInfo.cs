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
    public partial class CustomerSEntryPGInfo : UCSceneWithKeyboadBasic
    {
        public CustomerSEntryPGInfo()
        {
            InitializeComponent();
        }

        public CustomerSEntryPGInfo(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;

            pgInfo = "";
        }

        public override void Start(params object[] args)
        {
            base.Start();
            base.labelMessage.Text = "提示信息：输入快递单号或手机号";
            this.textBoxPGInfo.Text = "";
            this.textBoxPGInfo.Focus();
        }

        string pgInfo = "";

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (VerifyEntryInfo())
            {
                this.frmMain.SceneTransit(Roster.C_S_PGSearched,pgInfo);
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private bool VerifyEntryInfo()
        {
            pgInfo = this.textBoxPGInfo.Text.Trim();
            if (pgInfo != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
