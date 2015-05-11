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
    public partial class PostmanFinishWork : UCSceneWithInfoBasic
    {
        public PostmanFinishWork()
        {
            InitializeComponent();
        }

        public PostmanFinishWork(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private Courier courier;

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击寄件，进入完成工作界面");
            frmMain.voiceService.BroadcastOnce("存件成功");
            base.Start();
            if (args.Length > 0)
            {
                courier = (Courier)args[0];
            }

            base.Start();
            base.labelMessage.Text = "提示信息：存件成功";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_ChooseBox, 0,courier,null);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }
    }
}
