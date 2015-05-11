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
    public partial class PostmanEntryPGInfo : UCSceneWithKeyboadBasic
    {
        public PostmanEntryPGInfo()
        {
            InitializeComponent();
        }

        public PostmanEntryPGInfo(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private Courier courier;
        private Box checkedBox;
        private string sn = "";
        private string telNum = "";
        private string telNumConfirm = "";

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击寄件，进入输快递单号和手机号界面");
            frmMain.voiceService.BroadcastOnce("请输入快递单号和收件人手机号码");

            base.Start();
            base.labelMessage.Text = "提示信息：请输入快递单号和收件人手机号码";

            this.textPGID.Text = "";
            this.textBoxTelNum.Text = "";
            this.textBoxTelNumConfim.Text = "";
            this.textPGID.Focus();

            if (args.Length > 0)
            {
                courier = (Courier)args[0];
                checkedBox = (Box)args[1];
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (PGInfoVerify())
            {
                this.frmMain.SceneTransit(Roster.P_D_PGVerify, courier, checkedBox, sn, telNum);
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private bool PGInfoVerify()
        {
            sn = this.textPGID.Text.Trim();
            telNum = this.textBoxTelNum.Text.Trim();
            telNumConfirm = this.textBoxTelNumConfim.Text.Trim();

            if (sn == "" || telNum == "" || telNumConfirm == "")
            {
                frmMain.ShowSystemPromptMessage("不能为空");
                return false;
            }
            else
            {
                bool telNum1 = System.Text.RegularExpressions.Regex.IsMatch(telNum, @"^[1]+[3,5,7,8]+\d{9}");
                bool telNum2 = System.Text.RegularExpressions.Regex.IsMatch(telNumConfirm, @"^[1]+[3,5,7,8]+\d{9}");
                if (telNum1 && telNum2)
                {
                    if (telNum == telNumConfirm)
                    {
                        return true;
                    }
                    else
                    {
                        //不同显示错误信息
                        frmMain.voiceService.BroadcastOnce("两次输入的手机号不同，请重新输入");
                        frmMain.ShowSystemPromptMessage("两次输入的手机号不同，请重新输入");
                        CLog4net.LogInfo("两次输入的手机号不同");

                        return false;
                    }
                }
                else
                {
                    CLog4net.LogInfo("手机号码格式不对");
                    frmMain.voiceService.BroadcastOnce("号码格式不对，请重新输入");
                    frmMain.ShowSystemPromptMessage("手机号码格式不对");

                    return false;
                }
            }
        }

    }
}
