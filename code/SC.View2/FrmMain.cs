using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Tools;
using Domain;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Controller;
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient;

namespace SC.View2
{
    public partial class FrmMain : Form
    {

        internal VoiceService voiceService;// = DareneExpressCabinetClient.Service.Factory.ServicesFactory.GetInstance().GetVoicService();
        internal ServerService serverService;
        internal BoxsManager boxsManager;
        internal PackageManager packageManager;
        internal SystemController systemController = null;
        internal CameraService cameraService;
        internal InfoCenterLister infoCenterLister;
        internal About about;
        internal ADManager adManager;

        public FrmMain()
        {
            CLog4net.LogInfo("System starting！");

            InitializeComponent();
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
            this.adManager = ADManager.GetInstance();

            this.AddUCScene(Roster.Home, new Home(this,0));
            this.AddUCScene(Roster.P_ControlPanel, new PostmanControlPanel(this, 5));
            this.AddUCScene(Roster.P_D_Verify, new PostmanVerify(this, 60));
            this.AddUCScene(Roster.P_D_ChooseBox, new PostmanChooseBox(this, 60));
            this.AddUCScene(Roster.P_D_DeliverPG, new PostmanDeliverPG(this, 120));
            this.AddUCScene(Roster.P_D_EntryPGInfo, new PostmanEntryPGInfo(this, 60));
            this.AddUCScene(Roster.P_D_PGVerify, new PostmanPGVerify(this, 60));
            this.AddUCScene(Roster.P_D_FinishWork, new PostmanFinishWork(this, 10));
            this.AddUCScene(Roster.P_D_Cancel, new PostmanCancelTask(this, 60));
            this.AddUCScene(Roster.P_D_CancelTask,new PostmanCancelTask(this,60));
            this.AddUCScene(Roster.P_T_EntryPGInfo, new PostmanTBEntryPGInfo(this, 60));
            this.AddUCScene(Roster.P_T_FinishWork, new PostmanTBFinishWork(this, 60));
            this.AddUCScene(Roster.P_S_PGDelivered, new PostmanSPGDelivered(this, 60));
            this.AddUCScene(Roster.P_R_PGRegister, new PostmanRegister(this, 180));

            this.AddUCScene(Roster.C_ControlPanel, new CustomerControlPanel(this, 5));
            this.AddUCScene(Roster.C_T_Verify, new CustomerTBVerify(this, 60));
            this.AddUCScene(Roster.C_T_FinishWork, new CustomerTBFinishWork(this, 60));
            this.AddUCScene(Roster.C_S_EntryPGInfo, new CustomerSEntryPGInfo(this, 60));
            this.AddUCScene(Roster.C_S_PGSearched, new CustomerPGSearched(this, 60));

            this.AddUCScene(Roster.A_Verify, new AdminVerify(this, 60));
            this.AddUCScene(Roster.A_P_EntryBoxCode, new AdminProxyEntryBoxCode(this, 60));
            this.AddUCScene(Roster.A_P_FinishWork, new AdminProxyFinishWork(this, 60));
            this.AddUCScene(Roster.A_ControlPanel, new AdministratorControlPanel(this,360));

            this.SceneTransit(Roster.Home);
            this.timerSceneInfo.Enabled = true;
            this.timerMain.Enabled = true;

            CLog4net.LogInfo("启动完成");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;//Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region 导航
        private string scenesKey = "";

        /// <summary>
        /// 场景库
        /// </summary>
        private Dictionary<string, UCSceneBasic> scenesLib = new Dictionary<string, UCSceneBasic>();
        /// <summary>
        /// 添加控件场景
        /// </summary>
        /// <param name="key"></param>
        /// <param name="uc"></param>
        private void AddUCScene(string key, UCSceneBasic uc)
        {
            if (!scenesLib.ContainsValue(uc))
            {
                scenesLib.Add(key, uc);
            }
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="key"></param>
        public void SceneTransit(string key, params object[] args)
        {
            if (this.scenesLib.ContainsKey(key)&&this.scenesKey!=key)
            {
                if (scenesKey != "")
                {
                    this.scenesLib[scenesKey].Stop();
                }
                this.panelCenter.Controls.Clear();
                this.panelCenter.Controls.Add(this.scenesLib[key]);
                this.panelCenter.Controls[key].Dock = System.Windows.Forms.DockStyle.Fill;
                this.panelCenter.Controls[key].BringToFront();
                this.scenesKey = key;
                this.scenesLib[key].Start(args);
                this.ShowSystemPromptMessage("");

                this.SceneEvent();
            }
        }

        /// <summary>
        /// 切换界面是控件事件
        /// </summary>
        private void SceneEvent()
        {
            if (this.scenesKey != Roster.Home)
            {
                labelCountdown.Visible = true;
                labelScenesMessage.Visible = true;
                labelMessage.Visible = false;
            }
            else
            {
                labelMessage.Visible = true;
                labelCountdown.Visible = false;
                labelScenesMessage.Visible = false;

                this.cameraService.Close();
            }

            if (this.scenesKey == Roster.P_ControlPanel 
                || this.scenesKey == Roster.C_ControlPanel 
                || this.scenesKey == Roster.A_Verify)
            {
                this.cameraService.Open();
            }
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.RunOnce();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);

            IniConfigManager ini = new IniConfigManager();
            this.labelTel.Text = ini.GetAboutTel();
            this.labelUrl.Text = ini.GetAboutUrl();
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

        private void timerSceneInfo_Tick(object sender, EventArgs e)
        {
            if (this.scenesKey != Roster.Home)
            {
                labelCountdown.Text = this.scenesLib[scenesKey].RemainTime.ToString();
            }
        }

        private void panelQR_Click(object sender, EventArgs e)
        {
            if (this.scenesKey == Roster.Home)
            {
                this.SceneTransit(Roster.A_Verify, "adminstrator");
            }
        }

        internal void ShowSystemPromptMessage(string message)
        {
            this.labelScenesMessage.Visible = true;
            this.labelScenesMessage.Text = message;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            InfromationShow();
        }

        private void InfromationShow()
        {
            ServerCallback3 sc = this.infoCenterLister.State;

            string info = "欢迎使用德瑞纳智能快递柜，祝您今天生活愉快！";
            if (sc == null)
            {
                this.labelMessage.Text = info;
                labelMessage.Left = 106;
            }
            else
            {
                if (sc.Success)
                {
                    this.labelMessage.Text = sc.Message;

                    if (labelMessage.Left > -this.labelMessage.Width)
                    {
                        labelMessage.Left = labelMessage.Left - 3;
                    }
                    else
                    {
                        labelMessage.Left = this.Width;
                    }
                }
                else
                {
                    this.labelMessage.Text = info;
                    labelMessage.Left = 106;
                }
            }
        }
    }
}
