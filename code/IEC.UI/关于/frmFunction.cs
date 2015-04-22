using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Controller;
using DareneExpressCabinetClient.Tools;
using System.Threading;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace IEC.UI
{
    public partial class frmFunction : Form
    {
        public frmFunction()
        {
            InitializeComponent();
            this.circularProgressUpdate.Visible = false;
            Init();
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
        private bool isUpdateing = false;
        public void CheckUpdate()
        {
            if (this.isUpdateing == true)
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
                        this.isUpdateing = true;
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
            this.isUpdateing = false;
            MessageBox.Show("更新包已下载到程序安装目录，请退出系统并手动运行更新包！", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void password_Click(object sender, EventArgs e)
        {
            CLog4net.LogInfo("点击修改密码");
            new FrmPassword().ShowDialog();
        }

    }
}
