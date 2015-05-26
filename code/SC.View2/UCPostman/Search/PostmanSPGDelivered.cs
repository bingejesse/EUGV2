using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;

namespace SC.View2
{
    public partial class PostmanSPGDelivered : UCSceneBasicWithTitle
    {
        public PostmanSPGDelivered()
        {
            InitializeComponent();
        }

        private Courier courier;
        public PostmanSPGDelivered(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            courier = (Courier)args[0];

            RefreshWebBrowser();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }

        int pageNum = 0;
        private string GetRequestUrl()
        {
            string result = "";
            if (pageNum < 0)
            {
                pageNum = 0;
            }

            result = frmMain.serverService.GetCourierSearchPGUrl(frmMain.about, courier, pageNum);

            return result;
        }

        /// <summary>
        /// 重定向网页
        /// </summary>
        private void RefreshWebBrowser()
        {
            string url = this.GetRequestUrl();
            this.wb.Url = new Uri(url);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //RefreshWebBrowser();
            this.wb.Refresh();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            pageNum += 1;
            RefreshWebBrowser();
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            pageNum -= 1;
            if (pageNum < 0)
            {
                pageNum = 0;
            }
            RefreshWebBrowser();
        }
        
    }
}
