using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DareneExpressCabinetClient.Controller;
using DareneExpressCabinetClient.Tools;
using Domain;

namespace SC.View2
{
    public partial class FrmLoading : Form
    {
        public FrmLoading(SystemController systemController)
        {
            InitializeComponent();
            this.labelSystemInfo.Text = "";
            this.DoubleBuffered = true;
            backgroundWorkerLoading.WorkerReportsProgress = true; // 设置可以通告进度
            backgroundWorkerLoading.WorkerSupportsCancellation = true; // 设置可以取消
            backgroundWorkerLoading.RunWorkerAsync(this);

            this.systemController = systemController;
        }
        //关闭自身 
        public void KillMe(object o, EventArgs e)
        {
            this.Close();
        }

        private SystemController systemController;
        private int sytemNum=0;
        private void LoadingSystem()
        {
            try
            {
                sytemNum=this.systemController.Load(backgroundWorkerLoading);
            }
            catch (Exception e)
            {
                CLog4net.LogError("LoadingSystem:"+e);
            }
        }

        private void backgroundWorkerLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LoadingSystem();
        }

        private void backgroundWorkerLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void backgroundWorkerLoading_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage * 100 / 9;
            this.labelSystemInfo.Text = e.UserState.ToString();
            this.labelSystemInfo.Left = (this.Width - this.labelSystemInfo.Width) / 2;
        }
    }
}
