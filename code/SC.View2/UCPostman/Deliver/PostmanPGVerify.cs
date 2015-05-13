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
using DareneExpressCabinetClient.Service;

namespace SC.View2
{
    public partial class PostmanPGVerify : UCSceneBasicWithTitle
    {
        public PostmanPGVerify()
        {
            InitializeComponent();
        }

        public PostmanPGVerify(FrmMain frmMain, int time)
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

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击寄件，进入确认快递信息界面");
            frmMain.voiceService.BroadcastOnce("请确认快递信息");
            base.Start();
            if (args.Length > 0)
            {
                courier = (Courier)args[0];
                checkedBox = (Box)args[1];
                sn = (string)args[2];
                telNum = (string)args[3];
            }

            this.labelMessage.Text = string.Format("您存如的快递信息如下：\r\r快递单号：{0}\r收件人手机号码：{1}",sn,telNum);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_EntryPGInfo);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.P_D_CancelTask, key);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (CreatePG())
            {
                this.frmMain.SceneTransit(Roster.P_D_FinishWork, courier);
            }
        }

        private bool CreatePG()
        {
            ServerCallback3 serviceShakeHand =frmMain.serverService.ServiceShakeHand(frmMain.about, null);
            if (serviceShakeHand.Success == false)
            {
                frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                CLog4net.LogInfo("网络或者服务器连接异常");
                return false;
            }

            //创建包裹
            Package p = frmMain.packageManager.CreatePackage(courier.Code, courier.CompanyName, sn, telNum, checkedBox);

            ServerCallback serverConnect = frmMain.serverService.PackageCreate(p, frmMain.about);

            if (serverConnect.Success)
            {
                //拍照
                bool issuccess = frmMain.cameraService.TakePicture();
                CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());
                frmMain.boxsManager.UserBox(checkedBox.Code);
                frmMain.packageManager.CreatePackageSuccess(p);
                CLog4net.LogInfo("创建包裹成功");

                return true;
            }
            else
            {
                /**
                 * 包裹发送到服务器失败，该次操作不成功
                 * */

                if (serverConnect.Message != null && serverConnect.Message != "")
                {
                    frmMain.ShowSystemPromptMessage(serverConnect.Message);
                    frmMain.voiceService.BroadcastOnce(serverConnect.Message);
                    CLog4net.LogInfo(serverConnect.Message);
                }
                else
                {
                    frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                    frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                    CLog4net.LogInfo("包裹发送到服务器失败");
                }

                return false;
            }
        }
    }
}
