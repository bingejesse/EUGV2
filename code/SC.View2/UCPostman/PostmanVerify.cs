using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Service;
using Domain;

namespace SC.View2
{
    public partial class PostmanVerify : UCSceneWithKeyboadBasic
    {
        public PostmanVerify()
        {
            InitializeComponent();
        }

        private string actionKey = "";

        public PostmanVerify(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击寄件，进入输入账号界面");
            frmMain.voiceService.BroadcastOnce("请刷卡或输入卡号密码");

            base.Start();
            base.labelMessage.Text = "提示信息：刷卡或输入卡号密码";
            this.textBoxCode.Text = "";
            this.textBoxPassword.Text = "";
            this.textBoxCode.Focus();

            this.actionKey = Convert.ToString(args[0]);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

            if (Verify())
            {
                if (actionKey == "deliver")
                {
                    this.frmMain.SceneTransit(Roster.P_D_ChooseBox, 0, courier, null);
                }
                else if (actionKey == "takeback")
                {
                    this.frmMain.SceneTransit(Roster.P_T_EntryPGInfo, courier);
                }
                else
                {
                    this.frmMain.SceneTransit(Roster.P_S_PGDelivered, courier);
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        /// <summary>
        /// 快递员
        /// </summary>
        private Courier courier;
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            //获取员工号
            string user = this.textBoxCode.Text.Trim();
            string password = this.textBoxPassword.Text.Trim();
            //不能为空
            if (user.Equals("") || password.Equals(""))
            {
                this.frmMain.ShowSystemPromptMessage("账号或密码不能为空");
                return false;
            }
            else
            {
                try
                {
                    courier = new Courier(user, password);
                    ServerCallback sc =frmMain.serverService.CourierLogin(courier, frmMain.about);

                    if (sc.Success)
                    {
                        courier.CompanyName = sc.CompanyName;
                    }
                    else
                    {

                        if (sc.Message == null)
                        {
                            frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                            frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                            CLog4net.LogInfo("网络或服务器连接异常");
                        }
                        else
                        {
                            if (sc.Message != "")
                            {
                                frmMain.voiceService.BroadcastOnce(sc.Message);
                                frmMain.ShowSystemPromptMessage(sc.Message);
                                CLog4net.LogInfo(sc.Message);
                            }
                            else
                            {
                                frmMain.voiceService.BroadcastOnce("用户名或密码错误");
                                frmMain.ShowSystemPromptMessage("用户名或密码错误，请重新输入");
                                CLog4net.LogInfo("用户名或密码错误");
                            }
                        }

                        return false;
                    }

                }
                catch (Exception ex)
                {
                    frmMain.ShowSystemPromptMessage("快递员ID输入错误");
                    CLog4net.LogError(ex.ToString());
                    return false;
                }
            }

            return true;
        }
    }
}
