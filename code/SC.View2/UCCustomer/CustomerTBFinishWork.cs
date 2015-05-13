using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain;
using DareneExpressCabinetClient;

namespace SC.View2
{
    public partial class CustomerTBFinishWork : UCSceneWithInfoBasic
    {
        public CustomerTBFinishWork()
        {
            InitializeComponent();
        }

        public CustomerTBFinishWork(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private Box box;

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击取件，进入完成取件界面");
            //box = frmMain.boxsManager.Find(Convert.ToInt32(args[0]));
            box = (Box)args[0];
            string message = string.Format("请注意{0}号箱门已弹出，请取走快件并关闭箱门",box.ToString());

            frmMain.voiceService.BroadcastOnce(message);

            base.Start();
            base.labelMessage.Text = "提示信息："+message;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.C_T_Verify);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonOpenAgain_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击重新开箱");
            box.Open();
        }
    }
}
