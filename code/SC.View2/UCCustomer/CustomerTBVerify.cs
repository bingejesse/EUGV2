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
    public partial class CustomerTBVerify : UCSceneWithKeyboadBasic
    {
        public CustomerTBVerify()
        {
            InitializeComponent();
        }

        public CustomerTBVerify(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            base.labelMessage.Text = "提示信息：用微信扫描屏幕二维码或输入取件验证码";
            this.textBoxPassword.Text = "";
            this.textBoxPassword.Focus();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.C_T_FinishWork);
        }
    }
}
