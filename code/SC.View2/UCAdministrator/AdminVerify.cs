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
    public partial class AdminVerify : UCSceneWithInfoBasic
    {
        public AdminVerify()
        {
            InitializeComponent();
        }

        public AdminVerify(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            base.labelMessage.Text = "提示信息：刷卡或输入卡号密码";
            this.textBoxUser.Text = "";
            this.textBoxPassword.Text = "";
            this.textBoxUser.Focus();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.A_P_EntryBoxCode);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }
    }
}
