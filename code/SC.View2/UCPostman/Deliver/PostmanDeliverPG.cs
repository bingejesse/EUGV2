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
    public partial class PostmanDeliverPG : UCSceneWithInfoBasic
    {
        public PostmanDeliverPG()
        {
            InitializeComponent();
        }

        public PostmanDeliverPG(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        /// <summary>
        /// 最多允许返回重新选箱子次数
        /// </summary>
        private const int maxAllowGobackNum = 3;
        private int tick;
        private Courier courier;
        private Box checkedBox;

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("进入确认智能柜界面");

            base.Start();
            if (args.Length > 0)
            {
                tick = (int)args[0];
                courier = (Courier)args[1];
                checkedBox = (Box)args[2];
            }

            string message = string.Format("请将快递存入{0}号箱子，并关闭箱门", checkedBox.ToString());
            frmMain.voiceService.BroadcastOnce(message);
            base.labelMessage.Text = string.Format("提示信息：{0}，关闭后输入快递单号和收件人手机号码", message);

            if (tick >= maxAllowGobackNum)
            {
                this.buttonPrevious.Enabled = false;
            }
            else
            {
                this.buttonPrevious.Enabled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_CancelTask, key, checkedBox);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_ChooseBox, tick + 1,courier,null);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_EntryPGInfo, courier, checkedBox);
        }
    }
}
