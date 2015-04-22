using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Keyboard;
using DareneExpressCabinetClient;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Controller;
using System.Runtime.InteropServices;
using DareneExpressCabinetClient.Service.Factory;
using System.Drawing;
using Domain;

namespace IEC.UI
{
    public partial class FrmMain : Form
    {
        #region 属性列表
        /// <summary>
        /// 允许选择柜门剩余次数
        /// </summary>
        private int chooseBoxNum = 2;
        VoiceService voiceService;// = DareneExpressCabinetClient.Service.Factory.ServicesFactory.GetInstance().GetVoicService();
        ServerService serverService;
        BoxsManager boxsManager;
        PackageManager packageManager;
        SystemController systemController = null;
        CameraService cameraService;
        InfoCenterLister infoCenterLister;

        //重新开箱使用
        Package tempPackage;
        //快递员工号
        string CourierID = "";
        //快递员工密码
        string CourierPwd = "";
        //快递公司名
        Courier courier;
        About about;
        public enum panelName { mainPanel, InputPwdPanel, getPackageSuccess, inputCourierID, inputCourierPwd, scanTrackingNum, chooseBox, inputConsigneeTel, confirmConsigneeTel, savePackageSuccess, returnICID, returnIDPwd, returnScanTN, returnSuccess, getHelp,getHelpInfo, superManager };
        public static panelName currentPanel;
        int cdSec = 60;
        //收件人手机号
        string ConsigneeTel = "";
        //快递单号
        string TrackingNum = "";
        //智能柜号
        string courierNum = "";
        #endregion

        #region 构造函数及初始化
        public FrmMain()
        {
            CLog4net.LogInfo("System starting！");
            InitializeComponent();

            //读取配置文件和Logo图片
            try
            {
                CLog4net.LogInfo("读取配置文件和Logo图片");
                string imagepath = Environment.CurrentDirectory + "\\configInfo\\logo.png";
                Image image = Image.FromFile(imagepath);
                Size size = new Size(logoPic.Width, logoPic.Height);
                Bitmap b = new Bitmap(image, size);
                this.logoPic.BackgroundImage = b;

                IniConfigManager iniConfig = new IniConfigManager();
                tel.Text = iniConfig.GetAboutTel();
                url.Text = iniConfig.GetAboutUrl();
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
            }
            this.systemController = new SystemController();
            FrmLoading frmLoading = new FrmLoading(this.systemController);
            frmLoading.ShowDialog();

            if (frmLoading.DialogResult == DialogResult.OK)
            {
                frmLoading.Hide();
                frmLoading.Close();
            }

            this.boxsManager = BoxsManager.GetInstance();
            this.packageManager = PackageManager.GetInstance();
            this.voiceService = ServicesFactory.GetInstance().GetVoicService();
            this.serverService = ServicesFactory.GetInstance().GetServerService();
            this.cameraService = ServicesFactory.GetInstance().GetCameraService();
            this.about = AboutConfig.GetInstance().GetAbout();
            this.infoCenterLister = InfoCenterLister.GetInsatnce();

            timerNav.Interval = 1000;
            timerNav.Stop();

            this.timerMain.Enabled = true;
            this.timerMain.Start();

            currentPanel = panelName.mainPanel;
            mainPanel1.BringToFront();
            CLog4net.LogInfo("启动完成");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.RunOnce();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);

            #region 事件绑定

            //主界面我要取件事件
            mainPanel1.gpcEvent += new EventHandler(getPackageEvent);
            //取件时输入密码事件
            inputPwdPanel1.confirmEvent += new EventHandler(inputPwdPanel1_confirmEvent);
            //取件成功后重新开箱事件
            getPackageSuccess1.reopenEvent += new EventHandler(getPackageSuccess1_reopenEvent);

            //主界面快递员寄件事件
            mainPanel1.spEvent += new EventHandler(mainPanel1_spEvent);
            //寄件时输入快递员工号事件
            inputCourierID1.courierConfirmEvent += new EventHandler(inputCourierID1_ccfEvent);
            //寄件时输入快递员工密码事件
            inputCourierPwd1.confirmCpEvent += new EventHandler(inputCourierPwd1_confirmCpEvent);
            //寄件时扫描快递单号事件
            scanTrackingNum1.scanTNEvent += new EventHandler(scanTrackingNum1_scanTNEvent);
            //寄件时选择智能柜事件
            chooseBox1.confirmEvent += new EventHandler(chooseBox1_confirmEvent);
            //寄件时输入收件人手机号事件
            inputConsigneeTel1.inputTelEvent += new EventHandler(inputConsigneeTel1_inputTelEvent);
            //寄件时确认收件人手机号事件
            confirmConsigneeTel1.confirmEvent += new EventHandler(confirmConsigneeTel1_confirmEvent);

            //主界面快递员取回事件
            mainPanel1.gbEvent += new EventHandler(mainPanel1_gbEvent);
            //取回时输入快递员工号事件
            returnICID1.getBackIDEvent += new EventHandler(returnICID1_getBackIDEvent);
            //取回时输入快递员密码事件
            returnIDPwd1.getBackPwdEvent += new EventHandler(returnIDPwd1_getBackPwdEvent);
            //取回时输入快递单号事件
            returnScanTN1.ReturnScanTNEvent += new EventHandler(returnScanTN1_ReturnScanTNEvent);

            //主界面帮助事件
            mainPanel1.helpEvent += new EventHandler(mainPanel1_helpEvent);
            getHelp1.getSuperEvent += new EventHandler(getHelp1_getSuperEvent);
            getHelpInfo1.getSuperEvent += new EventHandler(getHelpInfo_getSuperEvent);
            superManager1.superEvent += new EventHandler(superManager1_superEvent);
            #endregion


            //先把图片加载到内存，减少第一次读取时的闪烁
            Image backgroundPic = Properties.Resources.bj_small;
            //this.BackgroundImage = backgroundPic;
            //BackgroundImageLayout = ImageLayout.Tile;
        }


        private void RunOnce()
        {
            string moduleName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            string processName = System.IO.Path.GetFileNameWithoutExtension(moduleName);
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(processName);
            if (process.Length > 1)
            {
                MessageBox.Show("本程序已经运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CLog4net.LogInfo("程序重复启动");
                Application.Exit();
            }
        }
        #endregion

        #region 事件代理的实现

        #region 取件事件
        //点击我要取件后的事件实现
        private void getPackageEvent(object sender, EventArgs e)
        {
            NavInputPwdPanelState();
        }
        //取件时点击确定后的事件实现
        private void inputPwdPanel1_confirmEvent(object sender, EventArgs e)
        {
            //验证密码
            string password = inputPwdPanel1.getPwd().Trim();
            //校验不能为空
            if (password.Equals(""))
            {
                inputPwdPanel1.errorMessage("密码不能为空");
            }
            else
            {
               ServerCallback3 serviceShakeHand = serverService.ServiceShakeHand(this.about, null);
               if (serviceShakeHand.Success == false)
               {
                   inputPwdPanel1.errorMessage("网络或者服务器连接失败，请稍后再试");
                   voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                   CLog4net.LogInfo("网络或者服务器连接异常");
                   return;
               }

                ServerCallback callback = serverService.RceiverLogin(password,this.about);
                if (callback.Success)
                {
                    bool issuccess = cameraService.TakePicture();
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
                    Box box = boxsManager.Find(tempcode);
                    if (box.Open())
                    {
                        boxsManager.ClearBox(tempcode);
                        //柜子地址
                        courierNum = box.CoordinateInfo.X.ToString() + box.CoordinateInfo.Y.ToString();
                        //跳转下一页
                        NavGetPackageSuccessState();
                        //设置信息
                        getPackageSuccess1.setInfo(courierNum);
                        string s = String.Format("取件成功，您的包裹在{0}号箱，请关闭柜门，谢谢", courierNum);
                        voiceService.BroadcastOnce(s);
                        CLog4net.LogInfo("取件成功");

                        Package package = packageManager.TakePackage(callback);
                        if (package != null)
                        {
                            //拍照
                            tempPackage = package;

                            if (package.Place.Code != box.Code)
                            {
                                CLog4net.LogError("服务器与客户端查询箱子不一致，服务器boxcode：" + callback.BoxCode + " 客户端boxcode：" + package.Place.Code + " 快递号：" + package.SN);
                            }
                        }
                        else
                        {
                            CLog4net.LogInfo("服务器与客户端查询箱子不一致:" + callback.BoxCode);
                        }
                    }
                    else
                    {
                        voiceService.BroadcastOnce("开柜失败");
                        returnSuccess1.errorMessage("如果储物柜无法打开，请联系管理员");
                        CLog4net.LogInfo("如果储物柜无法打开，请联系管理员:" + tempcode);
                    }
                }
                else
                {
                    if (callback.Message == null)
                    {
                        inputPwdPanel1.errorMessage("网络或者服务器连接失败，请稍后再试");
                        voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                        CLog4net.LogInfo("网络或者服务器连接异常");
                    }
                    else
                    {
                        if (callback.Message != "")
                        {
                            inputPwdPanel1.errorMessage(callback.Message);
                            voiceService.BroadcastOnce(callback.Message);
                            CLog4net.LogInfo(callback.Message);
                        }
                        else
                        {
                            inputPwdPanel1.errorMessage("取件密码错误");
                            voiceService.BroadcastOnce("密码错误");
                            CLog4net.LogInfo("取件密码错误");
                        }
                    }
                }
            }
        }

        //取件成功后重新开箱事件
        private void getPackageSuccess1_reopenEvent(object sender, EventArgs e)
        {
            if (tempPackage == null)
            {
                return;
            }
            //重新开箱
            bool issuccess = tempPackage.Place.Open();
            //判断是否成功
            if (!issuccess)
            {
                getPackageSuccess1.errorMessage("如果无法开柜门，请联系管理员");
            }
        }
        #endregion

        #region 寄件事件
        //点击快递员寄件后的事件实现
        private void mainPanel1_spEvent(object sender, EventArgs e)
        {
            this.cameraService.Open();
            NavInputCourierIDState(true,"");
        }

        
        //快递员寄件输入员工号后的事件实现
        private void inputCourierID1_ccfEvent(object sender, EventArgs e)
        {
            //获取员工号
            string cid = inputCourierID1.getCourierID().Trim();
            //不能为空
            if (cid.Equals(""))
            {
                inputCourierID1.errorMessage("账号不能为空");
            }
            else 
            {
                try
                {
                    CourierID =cid;
                    //跳转下一页
                    NavInputCourierPwdState();
                }
                catch (Exception ex)
                {
                    inputCourierID1.errorMessage("快递员ID输入错误");
                    CLog4net.LogError(ex.ToString());
                }
            }
            
        }

        //快递员寄件输入员工密码后的事件实现
        private void inputCourierPwd1_confirmCpEvent(object sender, EventArgs e)
        {
            //获取密码进行匹配
            try
            {
                CourierPwd = inputCourierPwd1.getCourierPwd().Trim();
                //不能为空
                if (CourierPwd.Equals(""))
                {
                    inputCourierPwd1.errorMessage("密码不能为空");
                }
                else 
                {
                    courier = new Courier(CourierID, CourierPwd);
                    ServerCallback sc = serverService.CourierLogin(courier, about);
                    if (sc.Success)//new Courier(CourierID, CourierPwd).IsRegister())
                    {
                        courier.CompanyName = sc.CompanyName;
                        //跳转下一页
                        this.NavChooseBoxState();
                        //log4net记录用户名和公司名
                    }
                    else
                    {
                        string errorMessage = "";
                        if (sc.Message == null)
                        {
                            voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                            inputCourierPwd1.errorMessage("网络或者服务器连接失败，请稍后再试");
                            errorMessage = "网络或者服务器连接失败，请稍后再试";
                            CLog4net.LogInfo("服务器连接异常");
                        }
                        else
                        {
                            if (sc.Message != "")
                            {
                                voiceService.BroadcastOnce(sc.Message);
                                inputCourierPwd1.errorMessage(sc.Message);
                                errorMessage = sc.Message;
                                CLog4net.LogInfo(sc.Message);
                            }
                            else
                            {
                                voiceService.BroadcastOnce("用户名或密码错误，请重新输入");
                                inputCourierPwd1.errorMessage("用户名或密码错误");
                                errorMessage = "用户名或密码错误";
                                CLog4net.LogInfo("用户名或密码错误");
                            }
                        }

                        //快递员寄件返回输入用户名阶段
                        NavInputCourierIDState(false,errorMessage);
                    }
                }
                
            }
            catch (Exception ex)
            {
                //回到输入用户名阶段
                inputCourierPwd1.errorMessage("密码格式错误");
                CLog4net.LogError(ex.ToString());
            }
            
        }

        /// <summary>
        /// 临时变量，存储寄件时选择的柜子
        /// </summary>
        private Box tempChooseBox;
        //选择box确认后的事件实现
        private void chooseBox1_confirmEvent(object sender, EventArgs e)
        {
            Box box = (Box)sender;
            this.tempChooseBox = box;
            if (box == null)
            {
                //失败则返回选柜子界面
                NavChooseBoxState();
                chooseBox1.errorMessage("获取柜子失败,请重新选择");
                CLog4net.LogInfo("获取柜子失败:" + chooseBox1.checkedInfo);
                return;
            }

            string boxCode = box.CoordinateInfo.X.ToString() + box.CoordinateInfo.Y.ToString();

            //开柜成功
            if (box.Open()==false)
            {
                //失败则返回选柜子界面
                NavChooseBoxState();
                chooseBox1.errorMessage("打开柜门:" + boxCode + "失败,请重新选择");
                CLog4net.LogInfo("打开柜门:" + boxCode + "，可能是can无回应");
                return;
            }

            FrmSavaPackage sp = new FrmSavaPackage(cdSec, boxCode, chooseBoxNum);
            sp.ShowDialog();
            CLog4net.LogInfo("进入选取快递柜确认界面");
            if (sp.DialogResult == DialogResult.Yes)
            {
                sp.Close();
                this.chooseBoxNum -= 1;
                this.NavScanTrackingNumState(true);
                CLog4net.LogInfo("点击继续存件");
            }
            else if (sp.DialogResult == DialogResult.No)
            {
                sp.Close();
                this.NavMainPanelState();
                box.Open();//本次操作流程为快递员取回放错包裹
                voiceService.BroadcastOnce("请取回包裹，并关闭柜门，谢谢！");
                CLog4net.LogInfo("点击取消存件");
            }
            else if (sp.DialogResult == DialogResult.Retry)
            {
                sp.Close();
                this.chooseBoxNum -= 1;
                this.NavChooseBoxState();
                CLog4net.LogInfo("点击重新选柜子");
            }
        }

        //扫描快递单号确认后的事件实现
        private void scanTrackingNum1_scanTNEvent(object sender, EventArgs e)
        {
            scanTrackingNum1.errorMessage("");
            TrackingNum = scanTrackingNum1.getTrackingNum().Trim();
            //bool istel = System.Text.RegularExpressions.Regex.Match(TrackingNum, "^\\d+$").Success;
            //if (istel==false)
            //{
            //    scanTrackingNum1.errorMessage("请重新扫描单号或手动输入");
            //    voiceService.BroadcastOnce("请重新扫描单号");
            //    CLog4net.LogInfo("快递单号不全为数字");

            //    return;
            //}

            if (TrackingNum.Equals(""))
            {
                scanTrackingNum1.errorMessage("快递单号不能为空");
                CLog4net.LogInfo("快递单号不能为空");
            }
            else 
            {
                //跳转下一页
                this.NavInputConsigneeTelState(true,"");
            }
            
        }

        //点击确认收件人手机号的事件实现
        private void inputConsigneeTel1_inputTelEvent(object sender, EventArgs e)
        {
            //保存手机号，以便来匹配
            ConsigneeTel = inputConsigneeTel1.getTel().Trim();

            ////电信手机号码正则        
            //string dianxin = @"^1[3578][01379]\d{8}$";        
            //System.Text.RegularExpressions.Regex dReg = new System.Text.RegularExpressions.Regex(dianxin);        
            ////联通手机号正则        
            //string liantong = @"^1[34578][01256]\d{8}$";
            //System.Text.RegularExpressions.Regex tReg = new System.Text.RegularExpressions.Regex(liantong);        
            ////移动手机号正则        
            //string yidong = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";
            //System.Text.RegularExpressions.Regex yReg = new System.Text.RegularExpressions.Regex(yidong);

            bool istel = System.Text.RegularExpressions.Regex.IsMatch(ConsigneeTel, @"^[1]+[3,5,7,8]+\d{9}");
            if (istel)
            {
                //跳转下一页
                NavConfirmConsigneeTelState();
            }
            else
            {
                CLog4net.LogInfo("手机号码格式不对");
                voiceService.BroadcastOnce("号码格式不对，请重新输入");
                inputConsigneeTel1.errorMessage("手机号码格式不对");
            }
 
        }

        //点击再次确认收件人手机号的事件实现
        private void confirmConsigneeTel1_confirmEvent(object sender, EventArgs e)
        {
            //两次输入要匹配
            if (ConsigneeTel.Equals(confirmConsigneeTel1.getTel().Trim()))
            {
                CLog4net.LogInfo("再次输入手机号确认成功");
                //两次手机号相同

                ServerCallback3 serviceShakeHand = serverService.ServiceShakeHand(this.about, null);
                if (serviceShakeHand.Success == false)
                {
                    inputPwdPanel1.errorMessage("网络或者服务器连接失败，请稍后再试");
                    voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                    CLog4net.LogInfo("网络或者服务器连接异常");
                    return;
                }

                //创建包裹
                Package p = packageManager.CreatePackage(CourierID, courier.CompanyName, TrackingNum, ConsigneeTel, this.tempChooseBox);

                ServerCallback serverConnect = serverService.PackageCreate(p, about);

                if (serverConnect.Success)
                {
                    //拍照
                    bool issuccess = cameraService.TakePicture();
                    CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());

                    boxsManager.UserBox(this.tempChooseBox.Code);

                    //x,y为智能柜坐标
                    courierNum = p.Place.CoordinateInfo.X.ToString() + p.Place.CoordinateInfo.Y.ToString();

                    //跳转下一页
                    NavSavePackageSuccessState(ConsigneeTel, TrackingNum, courierNum);

                    packageManager.CreatePackageSuccess(p);
                    CLog4net.LogInfo("创建包裹成功");
                }
                else
                {
                    /**
                     * 包裹发送到服务器失败，该次操作不成功
                     * */
                    this.NavScanTrackingNumState(false);

                    if (serverConnect.Message!=null&&serverConnect.Message != "")
                    {
                        voiceService.BroadcastOnce(serverConnect.Message);
                        savePackageSuccess1.errorMessage(serverConnect.Message);
                        scanTrackingNum1.errorMessage(serverConnect.Message);
                        CLog4net.LogInfo(serverConnect.Message);
                    }
                    else
                    {
                        voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                        savePackageSuccess1.errorMessage("网络或者服务器连接失败，请稍后再试");
                        scanTrackingNum1.errorMessage("网络或者服务器连接失败，请稍后再试");
                        CLog4net.LogInfo("包裹发送到服务器失败");
                    }
                }
            }
            else
            {
                //不同显示错误信息
                voiceService.BroadcastOnce("两次输入的手机号不同，请重新输入");
                confirmConsigneeTel1.errorMessage("两次输入的手机号不同，请重新输入");
                CLog4net.LogInfo("两次输入的手机号不同");

                //返回输入手机号
                NavInputConsigneeTelState(false, "两次输入的手机号不同，请重新输入");
            }
        }
        
        #endregion

        #region 取回事件
        //点击快递员取回后的事件
        private void mainPanel1_gbEvent(object sender, EventArgs e)
        {
            this.cameraService.Open();
            NavReturnICIDState(true,"");
        }
        //输入员工号后的事件
        private void returnICID1_getBackIDEvent(object sender, EventArgs e)
        {
            //获取员工号
            string cid = returnICID1.getCourierID().Trim();
            //判断为空
            if (cid.Equals(""))
            {
                returnICID1.errorMessage("账号不能为空");
            }
            else
            {
                try
                {
                    CourierID = cid;
                    //跳转下一页
                    NavReturnIDPwdState();
                }
                catch (Exception ex)
                {
                    returnICID1.errorMessage("快递员ID输入错误");
                    CLog4net.LogError(ex.ToString());
                }
            }
            
        }

        private Courier tempCourier;
        //输入员工密码后的事件
        private void returnIDPwd1_getBackPwdEvent(object sender, EventArgs e)
        {
            //获取密码进行匹配
            try
            {
                CourierPwd = returnIDPwd1.getCourierPwd().Trim();
                //是否为空
                if (CourierPwd.Equals(""))
                {
                    returnIDPwd1.errorMessage("密码不能为空");
                }
                else
                {
                    courier = new Courier(CourierID, CourierPwd);
                    ServerCallback sc = serverService.CourierLogin(courier, about);

                    if (sc.Success)
                    {
                        courier.CompanyName = sc.CompanyName;
                        tempCourier = courier;
                        //跳转下一页
                        NavReturnScanTNState();
                    }
                    else
                    {
                        string errorMessage = "";

                        if (sc.Message == null) {
                            voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                            returnICID1.errorMessage("网络或者服务器连接失败，请稍后再试");
                            errorMessage = "网络或者服务器连接失败，请稍后再试";
                            CLog4net.LogInfo("网络或服务器连接异常");
                        }
                        else
                        {
                            if (sc.Message != "")
                            {
                                voiceService.BroadcastOnce(sc.Message);
                                returnIDPwd1.errorMessage(sc.Message);
                                errorMessage = sc.Message;
                                CLog4net.LogInfo(sc.Message);
                            }
                            else
                            {
                                voiceService.BroadcastOnce("用户名或密码错误");
                                returnICID1.errorMessage("用户名或密码错误，请重新输入");
                                errorMessage = "用户名或密码错误，请重新输入";
                                CLog4net.LogInfo("用户名或密码错误");
                            }
                        }
                        //快递员取回，返回输入用户名
                        NavReturnICIDState(false, errorMessage);
                    }
                }            
            }
            catch (Exception ex)
            {
                voiceService.BroadcastOnce("网络连接异常，请稍后再试或联系管理员，谢谢！");
                returnIDPwd1.errorMessage("网络异常");
                CLog4net.LogError(ex.ToString());

                //回到输入用户名阶段
                NavReturnICIDState(false, "网络异常");
            }
        }
        //输入快递单号后的事件
        private void returnScanTN1_ReturnScanTNEvent(object sender, EventArgs e)
        {
            //快递单号存入数据库（要不要进行检查？）
            TrackingNum = returnScanTN1.getTrackingNum().Trim();
            if (TrackingNum.Equals(""))
            {
                returnScanTN1.errorMessage("快递单号不能为空");
                CLog4net.LogInfo("快递单号不能为空");
            }
            else
            {
                //与服务器握手检测当前连接状态
                ServerCallback3 serviceShakeHand = serverService.ServiceShakeHand(this.about, null);
                if (serviceShakeHand.Success == false)
                {
                    inputPwdPanel1.errorMessage("网络或者服务器连接失败，请稍后再试");
                    voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                    CLog4net.LogInfo("网络或者服务器连接异常");
                    return;
                }

                ServerCallback sc = serverService.CourierTackBack(TrackingNum, tempCourier, about);

                if (sc.Success)
                {
                    //拍照
                    bool issuccess = cameraService.TakePicture();
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

                    Box box = boxsManager.Find(boxcode);

                    if (box.Open())
                    {
                        packageManager.TakePackage(boxcode, 1);
                        courierNum = box.CoordinateInfo.X.ToString() + box.CoordinateInfo.Y.ToString();

                        boxsManager.ClearBox(boxcode);
                    }
                    else
                    {
                        voiceService.BroadcastOnce("开柜失败");
                        returnSuccess1.errorMessage("如果储物柜无法打开，请联系管理员");
                        CLog4net.LogInfo("如果储物柜无法打开，请联系管理员");
                    }

                    //int sn = Convert.ToInt32(TrackingNum);
                    //查找到包裹
                    Package p = packageManager.FindPackageBySN(TrackingNum);
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
                    NavReturnSuccessState(courierNum);
                }
                else
                {
                    if (sc.Message == null)
                    {
                        voiceService.BroadcastOnce("网络或者服务器连接失败，请稍后再试");
                        returnScanTN1.errorMessage("网络或者服务器连接失败，请稍后再试");
                        CLog4net.LogInfo("服务器连接异常");
                    }
                    else
                    {

                        if (sc.Message != "")
                        {
                            voiceService.BroadcastOnce(sc.Message);
                            returnScanTN1.errorMessage(sc.Message);
                            CLog4net.LogInfo(sc.Message);
                        }
                        else
                        {
                            voiceService.BroadcastOnce("未找到此包裹，请联系管理员");
                            returnScanTN1.errorMessage("没有这个包裹，请联系管理员");
                            CLog4net.LogInfo("没有这个包裹，请联系管理员");
                        }
                    }
                }

            }

        }

        #endregion

        #region 帮助事件
        
        private void mainPanel1_helpEvent(object sender, EventArgs e)
        {
            //about = AboutConfig.GetInstance().GetAbout();
            //about.CabinetCode = "1234";
            //getHelp1.setInfo(this.about);
            NavGetHelpState();
        }

        private void getHelp1_getSuperEvent(object sender, EventArgs e)
        {
            this.cameraService.Open();
            NavGetSuperState();
        }

        private void superManager1_superEvent(object sender, EventArgs e)
        {
            bool issuccess = cameraService.TakePicture();
            CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());

            CLog4net.LogInfo("管理员登录");
            string superNum = superManager1.getSuperNum().Trim();
            superNum = superNum.ToLower();
            string superPwd = superManager1.getSuperPwd().Trim();
            superPwd = superPwd.ToLower();
            superManager1.ClearTexbox();
            //超级管理员登录
            if (superNum.Equals(about.ManagerName) && superPwd.Equals(about.ManagerPassword))
            {

                CLog4net.LogInfo("管理员登录成功");
                new frmFunction().ShowDialog();
            }
            else
            {
                superManager1.errorMessage("用户名或密码错误");
                CLog4net.LogInfo("管理员登录失败");
            }
        }
        #endregion
        #endregion

        #region 页面导航
        /// <summary>
        /// 选择返回的页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToMainfrm_Click(object sender, EventArgs e)
        {
            switch (currentPanel)
            {
                case panelName.InputPwdPanel:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.getPackageSuccess:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.inputCourierID:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.inputCourierPwd:
                    {
                        NavInputCourierIDState(true,"");
                        break;
                    }
                case panelName.scanTrackingNum:
                    {
                        NavChooseBoxState();
                        break;
                    }
                case panelName.chooseBox:
                    {
                        NavInputCourierPwdState();
                        break;
                    }
                case panelName.inputConsigneeTel:
                    {
                        NavScanTrackingNumState(true);
                        break;
                    }
                case panelName.confirmConsigneeTel:
                    {
                        NavInputConsigneeTelState(true,"");
                        break;
                    }
                case panelName.savePackageSuccess:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.returnICID:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.returnIDPwd:
                    {
                        NavReturnICIDState(true,"");
                        break;
                    }
                case panelName.returnScanTN:
                    {
                        NavReturnIDPwdState();
                        break;
                    }
                case panelName.returnSuccess:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.getHelp:
                    {
                        NavMainPanelState();
                        break;
                    }
                case panelName.getHelpInfo:
                    NavMainPanelState();
                    break;
                case panelName.superManager:
                    {
                        NavGetHelpState();
                        break;
                    }
            }
        }

        /// <summary>
        /// 设置主页底部两个导航按钮状态
        /// </summary>
        /// <param name="homeVisible"></param>
        /// <param name="homeEnable"></param>
        /// <param name="returnVisible"></param>
        /// <param name="returnEnable"></param>
        private void SetButtomButton(bool homeVisible, bool homeEnable, bool returnVisible, bool returnEnable)
        {
            buttonXHome.Enabled = homeEnable;
            returnToMainfrm.Enabled = returnEnable;

            returnToMainfrm.Visible = returnVisible;
            buttonXHome.Visible = homeVisible;
            if (currentPanel == panelName.scanTrackingNum
                || currentPanel == panelName.inputConsigneeTel
                || currentPanel == panelName.confirmConsigneeTel)
            {
                Font font = new Font("微软雅黑", 14, FontStyle.Bold);
                buttonXHome.Font = font;
                buttonXHome.Text = "取消存件";
            }
            else
            {
                Font font = new Font("微软雅黑", 15.75f, FontStyle.Bold);
                buttonXHome.Font = font;
                buttonXHome.Text = "主页";
            }
        }

        /// <summary>
        /// 设置回退系统
        /// </summary>
        /// <param name="time">自动返回时间，单位S</param>
        /// <param name="homeEnable">home键是否可用</param>
        /// <param name="retunbuttonEnable">返回键是否可用</param>
        private void resetCountdownAndBack(int time, bool homeEnable,bool retunbuttonEnable)
        {
            SetButtomButton(true, homeEnable, true, retunbuttonEnable);
            //returnToMainfrm.Visible = true;
            //returnToMainfrm.Enabled = retunbuttonEnable;

            timerNav.Start();
            cdSec = time;
            Countdown.Text = time.ToString();
            this.labelXInfo.Visible = false;
            //this.buttonXHome.Visible = true;
            //this.buttonXHome.Enabled = homeEnable;
            this.Countdown.Visible = true;
        }

        /// <summary>
        /// 返回主页
        /// </summary>
        private void NavMainPanelState()
        {
            currentPanel = panelName.mainPanel;
            mainPanel1.BringToFront();
            timerNav.Stop();
            //returnToMainfrm.Visible = false;
            //this.buttonXHome.Visible = false;
            this.Countdown.Visible = false;
            this.labelXInfo.Visible = true;
            ConsigneeTel = "";
            TrackingNum = "";
            courierNum = "";
            CourierID = "";
            CourierPwd = "";
            this.tempPackage = null;
            this.chooseBoxNum = 2;
            this.tempChooseBox = null;
            this.tempCourier = null;

            this.SetButtomButton(false, false, false, false);

            this.cameraService.Close();
            inputPwdPanel1.DisposeQR();
            if (RemoteOpenLogic.GetInstance().IsEnable
                && RemoteOpenLogic.GetInstance().IsWorking)
            {
                RemoteOpenLogic.GetInstance().StopRemoteOpenListen();
                RemoteOpenLogic.GetInstance().RemoteOpenBoxEvent -= new RemoteOpenLogic.RemoteOpenBoxDelegate(frmMain_RemoteOpenBoxEvent);
            }

            mainPanel1.Focus();//防止后面界面获取焦点
        }
        #endregion

        #region 切换页面实现
        private void NavInputPwdPanelState()
        {
            CLog4net.LogInfo("点击我要取件");
            inputPwdPanel1.BringToFront();
            inputPwdPanel1.inputFocus();
            inputPwdPanel1.errorMessage("");
            currentPanel = panelName.InputPwdPanel;
            resetCountdownAndBack(60,true,true);
            this.inputPwdPanel1.ShowCurrentModle(this.about);
            if (RemoteOpenLogic.GetInstance().IsEnable
                && RemoteOpenLogic.GetInstance().IsWorking == false)
            {
                RemoteOpenLogic.GetInstance().StartRemoteOpenListen();
                RemoteOpenLogic.GetInstance().RemoteOpenBoxEvent += new RemoteOpenLogic.RemoteOpenBoxDelegate(frmMain_RemoteOpenBoxEvent);
            }

            this.cameraService.Open();
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
            }

            bool issuccess = cameraService.TakePicture();
            CLog4net.LogInfo("拍照是否成功：" + issuccess.ToString());
            //开箱
            Box box = boxsManager.Find(boxcode);
            if (box.Open())
            {
                //柜子地址
                courierNum = box.CoordinateInfo.X.ToString() + box.CoordinateInfo.Y.ToString();
                //跳转下一页
                NavGetPackageSuccessState();
                string s = String.Format("取件成功，您的包裹在{0}号箱，请关闭柜门，谢谢", courierNum);
                voiceService.BroadcastOnce(s);
                RemoteOpenLogic.GetInstance().Response(sc.Code, true, this.about);
                CLog4net.LogInfo("取件成功");

                boxsManager.ClearBox(boxcode);
            }
            else
            {
                voiceService.BroadcastOnce("开柜失败");
                returnSuccess1.errorMessage("如果储物柜无法打开，请联系管理员");
                CLog4net.LogInfo("如果储物柜无法打开，请联系管理员");
                RemoteOpenLogic.GetInstance().Response(sc.Code, false, this.about);
            }

            Package package = packageManager.TakePackage(boxcode);
            if (package != null)
            {
                ////拍照
                tempPackage = package;
                if (package.Place.Code != box.Code)
                {
                    CLog4net.LogError("服务器与客户端查询箱子不一致，服务器boxcode：" + sc.Boxnumber + " 客户端boxcode：" + package.Place.Code + " 快递号：" + package.SN);
                }
            }
            else
            {
                CLog4net.LogInfo("未找到您的包裹:" + boxcode);
            }
        }


        public delegate void updateUserControlDelegate(UserControl uc, string type);
        private void NavUpdateUserControl(UserControl uc, string type)
        {
            switch (type)
            {
                case "取件成功":
                    {
                        uc.BringToFront();
                        currentPanel = panelName.getPackageSuccess;
                        resetCountdownAndBack(10,true,true);
                        //设置信息
                        ((getPackageSuccess)uc).setInfo(courierNum);
                    }
                    break;
                case "取件失败":
                    ((InputPwdPanel)uc).errorMessage("未找到您的包裹");
                    break;
                default:
                    break;
            }
        }
        private void NavGetPackageSuccessState()
        {
            if (InvokeRequired)
            {
                Invoke(new updateUserControlDelegate(NavUpdateUserControl), getPackageSuccess1,"取件成功");
            }
            else
            {
                getPackageSuccess1.BringToFront();
                currentPanel = panelName.getPackageSuccess;
                resetCountdownAndBack(10,true,true);
                //设置信息
                getPackageSuccess1.setInfo(courierNum);
            }
        }

        /// <summary>
        /// 点击寄件,进入输入员工号码界面
        /// </summary>
        /// <param name="voiceEnable"></param>
        /// <param name="errorMessage"></param>
        private void NavInputCourierIDState(bool voiceEnable,string errorMessage)
        {
            CLog4net.LogInfo("点击寄件，进入输入账号界面");
            if (voiceEnable)
            {
                voiceService.BroadcastOnce("请刷卡或输入账号");
            }
            inputCourierID1.BringToFront();
            inputCourierID1.errorMessage(errorMessage);
            inputCourierID1.inputFocus();
            currentPanel = panelName.inputCourierID;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 进入输入员工密码界面
        /// </summary>
        private void NavInputCourierPwdState()
        {
            CLog4net.LogInfo("进入输入密码界面");
            voiceService.BroadcastOnce("请输入密码");
            inputCourierPwd1.BringToFront();
            inputCourierPwd1.inputFocus();
            inputCourierPwd1.errorMessage("");
            currentPanel = panelName.inputCourierPwd;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 进入扫描快递界面
        /// </summary>
        /// <param name="voiceEnable"></param>
        private void NavScanTrackingNumState(bool voiceEnable)
        {
            CLog4net.LogInfo("进入扫描快递界面");
            if (voiceEnable)
            {
                voiceService.BroadcastOnce("请扫描快递单号");
            }
            scanTrackingNum1.BringToFront();
            scanTrackingNum1.inputFocus();
            scanTrackingNum1.errorMessage("");
            currentPanel = panelName.scanTrackingNum;
            resetCountdownAndBack(60,true,false);
        }
        /// <summary>
        /// 进入选择智能柜界面
        /// </summary>
        private void NavChooseBoxState()
        {
            CLog4net.LogInfo("进入选择智能柜界面");
            voiceService.BroadcastOnce("请选择智能柜");
            this.tempChooseBox = null;

            int[] boxCount = boxsManager.GetAvailableBoxCount();
            //更新页面的box数量
            chooseBox1.updateBoxNum(boxCount[2], boxCount[1], boxCount[0]);
            chooseBox1.BringToFront();
            chooseBox1.clearCheckedInfo();
            chooseBox1.errorMessage("");
            currentPanel = panelName.chooseBox;
            resetCountdownAndBack(120,true,true);
        }
        /// <summary>
        /// 进入输入取件人手机号码界面
        /// </summary>
        /// <param name="voiceEnable"></param>
        /// <param name="errorMessage"></param>
        private void NavInputConsigneeTelState(bool voiceEnable,string errorMessage)
        {
            CLog4net.LogInfo("进入输入取件人手机号码界面");
            if (voiceEnable)
            {
                voiceService.BroadcastOnce("请输入取件人手机号码");
            }
            inputConsigneeTel1.BringToFront();
            inputConsigneeTel1.inputFocus();
            inputConsigneeTel1.errorMessage(errorMessage);
            currentPanel = panelName.inputConsigneeTel;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 进入再次输入手机号码界面
        /// </summary>
        private void NavConfirmConsigneeTelState()
        {
            CLog4net.LogInfo("进入再次输入手机号码界面");
            voiceService.BroadcastOnce("请再次输入手机号码");
            confirmConsigneeTel1.BringToFront();
            confirmConsigneeTel1.inputFocus();
            confirmConsigneeTel1.errorMessage("");
            currentPanel = panelName.confirmConsigneeTel;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 进入创建包裹结束界面
        /// </summary>
        /// <param name="ConsigneeTel"></param>
        /// <param name="TrackingNum"></param>
        /// <param name="courierNum"></param>
        private void NavSavePackageSuccessState(string ConsigneeTel, string TrackingNum, string courierNum)
        {
            CLog4net.LogInfo("进入创建包裹结束界面");
            //显示寄存信息
            savePackageSuccess1.setInfo(ConsigneeTel, TrackingNum, courierNum);
            string voiceString = string.Format("存件成功，您的包裹在{0}号箱，请确认柜门关闭，谢谢", courierNum);
            voiceService.BroadcastOnce(voiceString);

            savePackageSuccess1.BringToFront();
            currentPanel = panelName.savePackageSuccess;
            savePackageSuccess1.errorMessage("");
            resetCountdownAndBack(10,true,true);
        }
        /// <summary>
        /// 点击快递员取回，进入输入卡号界面
        /// </summary>
        /// <param name="voiceEnable"></param>
        /// <param name="errorMessage"></param>
        private void NavReturnICIDState(bool voiceEnable,string errorMessage)
        {
            CLog4net.LogInfo("点击快递员取回，进入输入账号界面");
            if (voiceEnable)
            {
                voiceService.BroadcastOnce("请刷卡或输入账号");
            }
            returnICID1.BringToFront();
            returnICID1.inputFocus();
            returnICID1.errorMessage(errorMessage);
            currentPanel = panelName.returnICID;
            resetCountdownAndBack(60,true,true);

        }
        /// <summary>
        /// 进入输入员工号码界面
        /// </summary>
        private void NavReturnIDPwdState()
        {
            CLog4net.LogInfo("进入输入账号界面");
            voiceService.BroadcastOnce("请输入密码");
            returnIDPwd1.BringToFront();
            returnIDPwd1.inputFocus();
            returnIDPwd1.errorMessage("");
            currentPanel = panelName.returnIDPwd;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 用进入扫描快递单号界面
        /// </summary>
        private void NavReturnScanTNState()
        {
            CLog4net.LogInfo("用进入扫描快递单号界面");
            voiceService.BroadcastOnce("请扫描快递单号");

            returnScanTN1.BringToFront();
            returnScanTN1.inputFocus();
            returnScanTN1.errorMessage("");
            currentPanel = panelName.returnScanTN;
            resetCountdownAndBack(60,true,true);
        }
        /// <summary>
        /// 进入快递员取回成功界面
        /// </summary>
        /// <param name="courierNum"></param>
        private void NavReturnSuccessState(string courierNum)
        {
            CLog4net.LogInfo("进入快递员取回成功界面");
            string s = String.Format("您的包裹在{0}号箱,请取回包裹并关闭柜门,谢谢", courierNum);
            voiceService.BroadcastOnce(s);
            returnSuccess1.setInfo(courierNum);

            returnSuccess1.BringToFront();
            currentPanel = panelName.returnSuccess;
            resetCountdownAndBack(10,true,true);
        }
        /// <summary>
        /// 点击帮助，进入帮助界面
        /// </summary>
        private void NavGetHelpState()
        {
            CLog4net.LogInfo("点击帮助，进入帮助界面");
            getHelp1.BringToFront();
            getHelp1.Loading();
            currentPanel = panelName.getHelp;
            //getHelpInfo1.BringToFront();
            //currentPanel = panelName.getHelpInfo;
            resetCountdownAndBack(20,true,true);
        }
        /// <summary>
        /// 点击管理员，进入管理员密码输入界面
        /// </summary>
        private void NavGetSuperState()
        {
            CLog4net.LogInfo("点击管理员，进入管理员密码输入界面");
            superManager1.BringToFront();
            superManager1.inputFocus();
            superManager1.errorMessage("");
            currentPanel = panelName.superManager;
            //timer1.Stop();
            //returnToMainfrm.Visible = true;
            Countdown.Visible = false;

            resetCountdownAndBack(20,true,true);
        }

        /// <summary>
        /// 点击管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getHelpInfo_getSuperEvent(object sender, EventArgs e)
        {
            this.cameraService.Open();
            NavGetSuperState();
        }
#endregion

        #region 界面刷新时钟
        //倒计时结束回到主界面
        private void timerNav_Tick(object sender, EventArgs e)
        {
            if (cdSec > 0)
            {
                cdSec--;
                Countdown.Text = cdSec.ToString();
            }
            else
            {
                NavMainPanelState();
            }
        }
        
        private void timerMain_Tick(object sender, EventArgs e)
        {
            ServerCallback3 sc = this.infoCenterLister.State;

            string info = "欢迎使用德瑞纳智能快递柜，祝您今天生活愉快！";
            if (sc == null)
            {
                this.labelXInfo.Text = info;
                labelXInfo.Left = 106;
            }
            else
            {
                if (sc.Success)
                {
                    this.labelXInfo.Text = sc.Message;

                    if (labelXInfo.Left > -this.labelXInfo.Width)
                    {
                        labelXInfo.Left = labelXInfo.Left - 3;
                    }
                    else
                    {
                        labelXInfo.Left = this.Width;
                    }
                }
                else
                {
                    this.labelXInfo.Text = info;
                    labelXInfo.Left = 106;
                }
            }
        }

        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.systemController.Dispose();
            this.cameraService.Close();
        }

        private void buttonXHome_Click(object sender, EventArgs e)
        {
            if (currentPanel == panelName.scanTrackingNum
                || currentPanel == panelName.inputConsigneeTel
                || currentPanel == panelName.confirmConsigneeTel)
            {
                FrmMessagebox messagebox = new FrmMessagebox();
                messagebox.SetMessageInfo("系统提示", "请注意：确认操作将返回主界面！");
                DialogResult dr = messagebox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (this.tempChooseBox != null)
                    {
                        this.tempChooseBox.Open();
                    }
                    voiceService.BroadcastOnce("请取回包裹，并关闭柜门，谢谢！");
                }
                else
                {
                    return;
                }
            }

            this.NavMainPanelState();
        }
    }
}
