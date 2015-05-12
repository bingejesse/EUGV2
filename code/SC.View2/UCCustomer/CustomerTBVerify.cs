using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Resource;
using Domain;
using System.Runtime.InteropServices;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient;
using DareneExpressCabinetClient.Controller;

namespace SC.View2
{
    public partial class CustomerTBVerify : UCSceneWithKeyboadBasic
    {
        public CustomerTBVerify()
        {
            InitializeComponent();
        }

        public CustomerTBVerify(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击取件，进入输入验证码界面");

            base.Start();
            base.labelMessage.Text = "提示信息：用微信扫描屏幕二维码或输入取件验证码";
            this.textBoxPassword.Text = "";
            this.textBoxPassword.Focus();

            ShowCurrentModle(frmMain.about);
            this.StratLogic();
        }

        public override void Stop()
        {
            base.Stop();
            this.StopLogic();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (PasswordVerify())
            {
                this.frmMain.SceneTransit(Roster.C_T_FinishWork, box.Code);
            }
        }


        private VGuangQR vguangQR;
        private Box box;

        private void ShowCurrentModle(About a)
        {
            switch (a.Model)
            {
                case "a":
                    this.qr.Visible = false;
                    frmMain.voiceService.BroadcastOnce("请输入取件密码");
                    break;
                case "b":
                    this.qr.Visible = true;
                    this.qr.Text = a.CabinetCode;
                    frmMain.voiceService.BroadcastOnce("请扫描二维码或输入取件密码");
                    break;
                case "c":
                    this.qr.Visible = false;
                    frmMain.voiceService.BroadcastOnce("请扫描二维码或输入取件密码");
                    if (this.vguangQR == null)
                    {
                        this.vguangQR = new VGuangQR();
                        this.vguangQR.Load();
                        try
                        {
                            //设置扫码成功时的回调
                            VGuangQR.decodeCall = new VGuangQR.DecodeCallBack(decodeCallBackStr);
                            VGuangQR.setDecodeCallBack(VGuangQR.decodeCall);
                            //设置设备状态变化时回调
                            VGuangQR.deviceStatusCall = new VGuangQR.DeviceStatusCallBack(deviceStatusCallBack);
                            VGuangQR.setDeviceStatusCallBack(VGuangQR.deviceStatusCall);
                        }
                        catch (Exception e)
                        {
                            CLog4net.LogError(e);
                        }
                    }
                    else
                    {
                        this.vguangQR.OpenDevice();
                    }
                    break;
                default:
                    this.qr.Visible = false;
                    frmMain.voiceService.BroadcastOnce("请输入取件密码");
                    break;
            }
        }

        #region 二维码扫描器
        //扫码成功时的回调函数
        int decodeCallBackStr(IntPtr str, int length)
        {
            //得到解码结果字符串
            string result = Marshal.PtrToStringAnsi(str);
            UpdateTextBox utb = new UpdateTextBox(InputTextBox);
            BeginInvoke(utb, result);

            return 0;
        }

        //设备状态变化时的回调函数
        void deviceStatusCallBack(int istatus)
        {
            if (istatus == VGuangQR.DEVICE_VALID)
            {
                CLog4net.LogInfo("微光二维码扫描器启动成功");
            }
            else if (istatus == VGuangQR.DEVICE_VALID)
            {
                CLog4net.LogInfo("微光二维码扫描器启动失败");
            }
        }

        private delegate void UpdateTextBox(string str);
        private void InputTextBox(string str)
        {
            this.textBoxPassword.Focus();
            this.textBoxPassword.Text = str;
            KeyEventArgs ek = new KeyEventArgs(Keys.Enter);
            //this.packagePwd_KeyUp(this.packagePwd, ek);
        }

        private void DisposeQR()
        {
            if (this.vguangQR != null)
            {
                this.vguangQR.Dispose();
            }
        }
        #endregion


        private bool PasswordVerify()
        {
            //验证密码
            string password = this.textBoxPassword.Text.Trim();
            //校验不能为空
            if (password.Equals(""))
            {
                frmMain.ShowSystemPromptMessage("密码不能为空");
            }
            else
            {
                ServerCallback3 serviceShakeHand = frmMain.serverService.ServiceShakeHand(frmMain.about, null);
                if (serviceShakeHand.Success == false)
                {
                    frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                    frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                    CLog4net.LogInfo("网络或者服务器连接异常");
                }

                ServerCallback callback = frmMain.serverService.RceiverLogin(password, frmMain.about);
                if (callback.Success)
                {
                    bool issuccess = frmMain.cameraService.TakePicture();
                    CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());
                    int tempcode = 0;
                    try
                    {
                        tempcode = Convert.ToInt32(callback.BoxCode);
                    }
                    catch (Exception err)
                    {
                        CLog4net.LogError("inputPwdPanel1_confirmEvent callback.BoxCode" + callback.BoxCode + " " + err);
                    }

                    //开箱
                    this.box = frmMain.boxsManager.Find(tempcode);
                    if (box.Open())
                    {
                        frmMain.boxsManager.ClearBox(tempcode);

                        CLog4net.LogInfo("取件成功");

                        Package package = frmMain.packageManager.TakePackage(callback);
                        if (package != null)
                        {
                            //拍照
                            if (package.Place.Code != box.Code)
                            {
                                CLog4net.LogError("服务器与客户端查询箱子不一致，服务器boxcode：" + callback.BoxCode + " 客户端boxcode：" + package.Place.Code + " 快递号：" + package.SN);
                            }
                        }
                        else
                        {
                            CLog4net.LogInfo("服务器与客户端查询箱子不一致:" + callback.BoxCode);
                        }

                        return true;
                    }
                    else
                    {
                        frmMain.voiceService.BroadcastOnce("开柜失败");
                        frmMain.ShowSystemPromptMessage("如果储物柜无法打开，请联系管理员");
                        CLog4net.LogInfo("如果储物柜无法打开，请联系管理员:" + tempcode);
                    }
                }
                else
                {
                    if (callback.Message == null)
                    {
                        frmMain.ShowSystemPromptMessage("网络或者服务器连接失败，请稍后再试");
                        frmMain.voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                        CLog4net.LogInfo("网络或者服务器连接异常");
                    }
                    else
                    {
                        if (callback.Message != "")
                        {
                            frmMain.ShowSystemPromptMessage(callback.Message);
                            frmMain.voiceService.BroadcastOnce(callback.Message);
                            CLog4net.LogInfo(callback.Message);
                        }
                        else
                        {
                            frmMain.ShowSystemPromptMessage("取件密码错误");
                            frmMain.voiceService.BroadcastOnce("密码错误");
                            CLog4net.LogInfo("取件密码错误");
                        }
                    }
                }
            }

            return false;
        }


        private void StratLogic()
        {
            if (RemoteOpenLogic.GetInstance().IsEnable
                && RemoteOpenLogic.GetInstance().IsWorking == false)
            {
                RemoteOpenLogic.GetInstance().StartRemoteOpenListen();
                RemoteOpenLogic.GetInstance().RemoteOpenBoxEvent += new RemoteOpenLogic.RemoteOpenBoxDelegate(frmMain_RemoteOpenBoxEvent);
            }
        }

        private void StopLogic()
        {
            if (RemoteOpenLogic.GetInstance().IsEnable&& RemoteOpenLogic.GetInstance().IsWorking)
            {
                RemoteOpenLogic.GetInstance().StopRemoteOpenListen();
                RemoteOpenLogic.GetInstance().RemoteOpenBoxEvent -= new RemoteOpenLogic.RemoteOpenBoxDelegate(frmMain_RemoteOpenBoxEvent);
            }
            this.DisposeQR();
        }

        delegate void myUserControlDelegate(UserControl control, object sender);
        void frmMain_RemoteOpenBoxEvent(ServerCallback2 sc)
        {
            int boxcode = -1;
            try
            {
                boxcode = Convert.ToInt32(sc.Boxnumber);
            }
            catch (Exception err)
            {
                CLog4net.LogError("frmMain_RemoteOpenBoxEvent " + sc.Boxnumber + " :" + err);

                return;
            }

            bool issuccess = frmMain.cameraService.TakePicture();
            CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());
            //开箱
            this.box = frmMain.boxsManager.Find(boxcode);
            if (box.Open())
            {
                RemoteOpenLogic.GetInstance().Response(sc.Code, true, frmMain.about);
                CLog4net.LogInfo("取件成功");

                frmMain.boxsManager.ClearBox(boxcode);
            }
            else
            {
                frmMain.voiceService.BroadcastOnce("开柜失败");
                frmMain.ShowSystemPromptMessage("如果储物柜无法打开，请联系管理员");
                CLog4net.LogInfo("如果储物柜无法打开，请联系管理员");
                RemoteOpenLogic.GetInstance().Response(sc.Code, false, frmMain.about);

                return;
            }

            Package package = frmMain.packageManager.TakePackage(boxcode);
            if (package != null)
            {
                if (package.Place.Code != box.Code)
                {
                    CLog4net.LogError("服务器与客户端查询箱子不一致，服务器boxcode：" + sc.Boxnumber + " 客户端boxcode：" + package.Place.Code + " 快递号：" + package.SN);
                }
            }
            else
            {
                CLog4net.LogInfo("未找到您的包裹:" + boxcode);
            }

            SceneTransitEvent();

        }

        delegate void SceneTransitDelegate(string key, params object[] args);
        private void SceneTransitEvent()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new SceneTransitDelegate(frmMain.SceneTransit), Roster.C_T_FinishWork, box.Code);
                }

            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }
        }
    }
}
