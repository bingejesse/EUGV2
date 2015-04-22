using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Keyboard;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient.Controller;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Tools;
using System.Runtime.InteropServices;
using Domain;

namespace IEC.UI
{
    public partial class InputPwdPanel : UserControl
    {
        public InputPwdPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }

        private VGuangQR vguangQR;

        public void ShowCurrentModle(About a)
        {
            switch (a.Model)
            {
                case "a":
                    this.qrCodeGraphicControl1.Visible = false;
                    ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("请输入取件密码");
                    this.labelX3.Text = "请输入取件密码";
                    break;
                case "b":
                    this.qrCodeGraphicControl1.Visible = true;
                    this.qrCodeGraphicControl1.Text = a.CabinetCode;
                    ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("请扫描二维码或输入取件密码");
                    this.labelX3.Text = "请扫描二维码或输入取件密码";
                    break;
                case "c":
                    this.qrCodeGraphicControl1.Visible = false;
                    ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("请扫描二维码或输入取件密码");
                    this.labelX3.Text = "请扫描二维码或输入取件密码";
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
                    this.qrCodeGraphicControl1.Visible = false;
                    ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("请输入取件密码");
                    this.labelX3.Text = "请输入取件密码";
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

        public delegate void UpdateTextBox(string str);
        private void InputTextBox(string str)
        {
            this.packagePwd.Focus();
            this.packagePwd.Text = str;
            KeyEventArgs ek = new KeyEventArgs(Keys.Enter);
            this.packagePwd_KeyUp(this.packagePwd, ek);
        }

        public void DisposeQR()
        {
            this.packagePwd.Text = "";
            if (this.vguangQR != null)
            {
                this.vguangQR.Dispose();
            }
        }
        #endregion

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }
        public string getPwd()
        {
            return packagePwd.Text;
        }
        public void inputFocus()
        {
            packagePwd.Clear();
            packagePwd.Focus();
        }

        //添加事件代理
        public event EventHandler confirmEvent;

        private void confirm_Click(object sender, EventArgs e)
        {
            if (confirmEvent != null)
            {
                confirmEvent(this, e);
            }
        }

        private void packagePwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (packagePwd.Text!=""&&confirmEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    confirmEvent(this, e);
                }
            }
        }
    }
}
