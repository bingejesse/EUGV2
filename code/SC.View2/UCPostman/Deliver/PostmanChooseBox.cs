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
using DareneExpressCabinetClient;

namespace SC.View2
{
    public partial class PostmanChooseBox : UCSceneWithInfoBasic
    {
        public PostmanChooseBox()
        {
            InitializeComponent();
        }

        public PostmanChooseBox(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private int Tick = 0;
        private Courier courier;
        private Box checkedBox;
        private Box.Size checkedInfo;

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("进入选择智能柜界面");
            frmMain.voiceService.BroadcastOnce("请选择合适大小的箱子");
            base.Start();
            base.labelMessage.Text = "提示信息：请选择合适大小的箱子";
            Tick = (int)args[0];
            courier = (Courier)args[1];
            checkedBox = (Box)args[2];

            int[] boxCount = frmMain.boxsManager.GetAvailableBoxCount();
            //更新页面的box数量
            updateBoxNum(boxCount[2], boxCount[1], boxCount[0]);
        }

        private void updateBoxNum(int bigBoxNum, int mediumBoxNum, int smallBoxNum)
        {
            this.buttonLBox.Text = "大箱子\r可用数量：" + bigBoxNum.ToString();
            this.buttonMBox.Text = "中箱子\r可用数量：" + mediumBoxNum.ToString();
            this.buttonSBox.Text = "小箱子\r可用数量：" + smallBoxNum.ToString();

            this.buttonLBox.Enabled = true ? bigBoxNum > 0 : false;
            this.buttonMBox.Enabled = true ? mediumBoxNum > 0 : false;
            this.buttonSBox.Enabled = true ? smallBoxNum > 0 : false;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (ChooseBox())
            {
                this.frmMain.SceneTransit(Roster.P_D_DeliverPG, Tick, courier,checkedBox);
            }
        }

        //选择box确认后的事件实现
        private bool ChooseBox()
        {
            Box box = checkedBox;
            if (box == null)
            {
                frmMain.ShowSystemPromptMessage("获取箱子失败,请重新选择");
                CLog4net.LogInfo("获取箱子失败:" + checkedInfo);
                return false;
            }

            string boxCode = box.ToString();

            //开柜成功
            if (box.Open() == false)
            {
                frmMain.ShowSystemPromptMessage("打开箱子:" + boxCode + "失败,请重新选择");
                CLog4net.LogInfo("打开箱子:" + boxCode + " 失败，可能是can无回应");
                return false;
            }

            return true;
        }

        private void buttonLBox_Click(object sender, EventArgs e)
        {
            FindBox(Box.Size.L);
        }

        private void buttonMBox_Click(object sender, EventArgs e)
        {
            FindBox(Box.Size.M);
        }

        private void buttonSBox_Click(object sender, EventArgs e)
        {
            FindBox(Box.Size.S);
        }

        private void FindBox(Box.Size size)
        {
            this.checkedBox = frmMain.boxsManager.Find(size);
            if (this.checkedBox == null)
            {
                frmMain.ShowSystemPromptMessage("找不到合适的箱子");
                return;
            }
            checkedInfo = Box.Size.L;
            labelMessage.Text = "提示信息: " + checkedBox.ToString() + "号箱子";
            CLog4net.LogInfo("选取箱子：" + checkedBox.Code);
        }
    }
}
