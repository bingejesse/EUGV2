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
using System.Diagnostics;

namespace SC.View2
{
    public partial class AdministratorControlPanel : UCSceneWithInfoBasic
    {
        public AdministratorControlPanel()
        {
            InitializeComponent();
        }

        public AdministratorControlPanel(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            CLog4net.LogInfo("点击后台，进入超级管理员控制面板");
            base.Start();
            base.labelMessage.Text = "提示信息：修改参数后请重启系统";

            IniConfigManager iniConfig = new IniConfigManager();

            Init();
            this.circularProgressUpdate.Visible = false;
            this.code.Text = frmMain.about.CabinetCode;
            this.createdTime.Text = iniConfig.GetAboutCommissioningData();
        }

        private void Init()
        {
            if (CemmberData.Instance.IsCanConnectFail)
            {
                this.labelXCan.Text = "控制器连接：失败";
                this.labelXCan.BackColor = Color.Red;
            }
            else
            {
                this.labelXCan.Text = "控制器连接：成功";
                this.labelXCan.BackColor = Color.Green;
            }

            if (CemmberData.Instance.IsCameraConnectFail)
            {
                this.labelXCamare.Text = "监控摄像头连接：失败";
                this.labelXCamare.BackColor = Color.Red;
            }
            else
            {
                this.labelXCamare.Text = "监控摄像头连接：成功";
                this.labelXCamare.BackColor = Color.Green;
            }

            if (CemmberData.Instance.IsServerConnectFail)
            {
                this.labelXServer.Text = "服务器连接：失败";
                this.labelXServer.BackColor = Color.Red;
            }
            else
            {
                this.labelXServer.Text = "服务器连接：成功";
                this.labelXServer.BackColor = Color.Green;
            }
        }

        private void config_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击信息配置");
            new frmAbout().ShowDialog();
        }

        private void manager_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击快递柜管理器");
            new frmManager().ShowDialog();
        }

        private void buttonXReboot_Click(object sender, EventArgs e)
        {

            CLog4net.LogInfo("点击重启");
            if (MessageBox.Show("确认重启", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CLog4net.LogInfo("确认重启");
                this.Dispose();
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                CLog4net.LogInfo("取消重启");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击退出系统");
            if (MessageBox.Show("确认退出系统", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CLog4net.LogInfo("退出系统");
                this.Dispose();
                Application.Exit();
            }
            else
            {
                CLog4net.LogInfo("取消退出系统");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.CheckUpdate();
        }

        #region 更新
        public void CheckUpdate()
        {
            if (backgroundWorkerUpdate.IsBusy)
            {
                return;
            }

            SoftUpdateManager app = new SoftUpdateManager(Application.ExecutablePath, "SCSystem");
            try
            {
                if (app.IsUpdate)
                {
                    if (MessageBox.Show("检查到新版本，是否下载更新包？", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.circularProgressUpdate.Visible = true;
                        this.circularProgressUpdate.IsRunning = true;

                        backgroundWorkerUpdate.WorkerSupportsCancellation = true; // 设置可以取消
                        backgroundWorkerUpdate.RunWorkerAsync(app);
                    }
                }
                else
                {
                    MessageBox.Show("未找到合适更新包");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CLog4net.LogError("CheckUpdate" + ex);
            }
        }

        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            SoftUpdateManager sum = e.Argument as SoftUpdateManager;
            sum.Update();
        }

        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.circularProgressUpdate.Visible = false;
            this.circularProgressUpdate.IsRunning = false;
            MessageBox.Show("更新包已下载到程序安装目录，请退出系统并手动运行更新包！", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (MessageBox.Show("更新包已下载到程序安装目录，请退出系统并手动运行更新包！", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    RunUpdate();
            //}
        }

        private void RunUpdate()
        {
            try
            {
                IniConfigManager ini = new IniConfigManager();
                string updatePath = ini.GetUpdateAppPath();
                string parm = updatePath +"/"+AboutConfig.appName+".txt"+ ";SC.View2";
                string updateApp = ini.GetUpdateAppName();

                StartApp(updatePath, "SC.Update", parm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.frmMain.Close();
            }
        }

        private void StartApp(string appPath,string appName,string parm)
        {
            try
            {
                Console.WriteLine("cmd start");
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd";
                cmd.StartInfo.Arguments = parm;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.Start();
                cmd.StandardInput.WriteLine("cd " + appPath);
                cmd.StandardInput.WriteLine(appName);

                cmd.Close();
                Console.WriteLine("cmd close");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

        private void password_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击修改密码");
            new FrmPassword().ShowDialog();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }
    }
}
