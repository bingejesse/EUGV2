using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient;

namespace SC.View2
{
    public partial class PostmanTBEntryPGInfo : UCSceneWithKeyboadBasic
    {
        public PostmanTBEntryPGInfo()
        {
            InitializeComponent();
        }

        public PostmanTBEntryPGInfo(FrmMain frmMain, int time)
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
            CLog4net.LogInfo("点击快递员取回，进入输入单号界面");
            frmMain.voiceService.BroadcastOnce("请输入要取回的快递单号");

            base.Start();
            base.labelMessage.Text = "提示信息：请输入要取回的快递单号";
            this.textPGCode.Text = "";
            this.textPGCode.Focus();

            courier = (Courier)args[0];
            box = null;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (PGTakeback())
            {
                this.frmMain.SceneTransit(Roster.P_T_FinishWork,courier,box);
            }
        }

        private bool PGTakeback()
        {
            //快递单号存入数据库（要不要进行检查？）
            string TrackingNum = this.textPGCode.Text.Trim();
            if (TrackingNum.Equals(""))
            {
                frmMain.ShowSystemPromptMessage("快递单号不能为空");
                CLog4net.LogInfo("快递单号不能为空");

                return false;
            }
            else
            {
                //与服务器握手检测当前连接状态
                ServerCallback3 serviceShakeHand = frmMain.serverService.ServiceShakeHand(frmMain.about, null);
                if (serviceShakeHand.Success == false)
                {
                    frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                    frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                    CLog4net.LogInfo("网络或者服务器连接异常");
                    return false;
                }

                ServerCallback sc = frmMain.serverService.CourierTackBack(TrackingNum, courier, frmMain.about);

                if (sc.Success)
                {
                    //拍照
                    bool issuccess = frmMain.cameraService.TakePicture();
                    CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());

                    int boxcode = -1;
                    try
                    {
                        boxcode = Convert.ToInt32(sc.BoxCode);
                    }
                    catch (Exception err)
                    {
                        CLog4net.LogError("输入快递单号后的事件" + sc.BoxCode + err);
                    }

                    this.box =frmMain.boxsManager.Find(boxcode);

                    if (box.Open())
                    {
                        frmMain.packageManager.TakePackage(boxcode, 1);

                        frmMain.boxsManager.ClearBox(boxcode);
                    }
                    else
                    {
                        frmMain.voiceService.BroadcastOnce("开柜失败");
                        frmMain.ShowSystemPromptMessage("如果储物柜无法打开，请联系管理员");
                        CLog4net.LogInfo("如果储物柜无法打开，请联系管理员");

                        return false;
                    }

                    //int sn = Convert.ToInt32(TrackingNum);
                    //查找到包裹
                    Package p = frmMain.packageManager.FindPackageBySN(TrackingNum);
                    if (p == null)
                    {
                        CLog4net.LogInfo("没有这个包裹，请联系管理员:" + TrackingNum);
                    }
                    else
                    {
                        if (p.Place.Code != box.Code)
                        {
                            CLog4net.LogError("单号" + TrackingNum + ",服务器与客户端查询箱子不一致，服务器boxcode：" + sc.BoxCode + " 客户端boxcode：" + p.Place.Code + " 快递号：" + p.SN);
                        }
                    }

                    //跳转下一页
                    return true;
                }
                else
                {
                    if (sc.Message == null)
                    {
                        frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                        frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                        CLog4net.LogInfo("服务器连接异常");
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
                            frmMain.voiceService.BroadcastOnce("未找到此包裹，请联系管理员");
                            frmMain.ShowSystemPromptMessage("没有这个包裹，请联系管理员");
                            CLog4net.LogInfo("没有这个包裹，请联系管理员");
                        }
                    }

                    return false;
                }

            }
        }
    }
}
