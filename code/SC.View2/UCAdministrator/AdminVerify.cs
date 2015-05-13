using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;
using Domain;

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

        private enum identity{NotPass,AdminProxy,Administrator};

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击后台，进入身份验证界面");

            base.Start();
            base.labelMessage.Text = "提示信息：刷卡或输入卡号密码";
            this.textBoxUser.Text = "";
            this.textBoxPassword.Text = "";
            this.textBoxUser.Focus();

            IniConfigManager iniConfig = new IniConfigManager();
            this.labelVersion.Text = "客户端版本号：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            identity user = IdentityVerify();

            if (user == identity.AdminProxy)
            {
                this.frmMain.SceneTransit(Roster.A_P_EntryBoxCode);
            }
            else if (user == identity.Administrator)
            {
                this.frmMain.SceneTransit(Roster.A_ControlPanel);
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private identity IdentityVerify()
        {
            string name = this.textBoxUser.Text.Trim();
            string pass = this.textBoxPassword.Text.Trim();
            

            if (name == "1" && pass == "1")
            {
                return identity.Administrator;
            }
            else if (name == "2" && pass == "1")
            {
                return identity.AdminProxy;
            }
            else
            {
                return identity.NotPass;
            }
        }
    }
}
