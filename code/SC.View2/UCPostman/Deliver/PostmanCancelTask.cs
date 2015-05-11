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
    public partial class PostmanCancelTask : UCSceneWithInfoBasic
    {
        public PostmanCancelTask()
        {
            InitializeComponent();
        }

        private string previousKey = "";

        public PostmanCancelTask(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private Box checkedBox;

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("进入取消存件确认界面");
            frmMain.voiceService.BroadcastOnce("请确认是否取消本次存件，确认后将弹出箱门，注意取回快递");

            base.Start();
            base.labelMessage.Text = "提示信息：请确认是否取消本次存件，确认后将弹出箱门，注意取回快递！";

            previousKey = Convert.ToString(args[0]);
            checkedBox = (Box)args[1];
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(previousKey);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.checkedBox == null)
            {
                return;
            }

            if (checkedBox.Open())
            {
                frmMain.voiceService.BroadcastOnce("请取回包裹，并关闭柜门，谢谢！");
                this.frmMain.SceneTransit(Roster.Home);
            }
        }
    }
}
