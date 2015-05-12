using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient;
using Domain;

namespace SC.View2
{
    public partial class PostmanTBFinishWork : UCSceneWithInfoBasic
    {
        public PostmanTBFinishWork()
        {
            InitializeComponent();
        }

        public PostmanTBFinishWork(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        /// <summary>
        /// 快递员
        /// </summary>
        private Courier courier;

        /// <summary>
        /// 找到的箱子
        /// </summary>
        private Box box;

        public override void Start(params object[] args)
        {
            base.Start();

            courier = (Courier)args[0];
            box = (Box)args[1];
            string message = string.Format("请注意{0}号箱门已经弹开，请取回快件并关闭箱门",box.ToString());

            base.labelMessage.Text = message;

            CLog4net.LogInfo("点击快递员取回，进入完成取回界面");
            frmMain.voiceService.BroadcastOnce(message);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_T_EntryPGInfo,courier);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }
    }
}
