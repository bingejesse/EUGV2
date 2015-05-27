using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain;

namespace SC.View2
{
    public partial class CustomerPGSearched : UCSceneBasicWithTitle
    {
        public CustomerPGSearched()
        {
            InitializeComponent();
        }

        private string pgInfo = "";
        public CustomerPGSearched(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            pgInfo = (string)args[0];

            RefreshWebBrowser();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.C_S_EntryPGInfo);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }


        private int pageNum = 1;
        private int totalPageNum = 1;
        private string GetRequestUrl()
        {
            string result = "";
            if (pageNum < 1)
            {
                pageNum = 1;
            }

            result = frmMain.serverService.GetRceiverSearchPGUrl(frmMain.about, pgInfo, pageNum);

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
            this.wb.Refresh();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            GetTotalPageNum();
            if (totalPageNum > pageNum)
            {
                pageNum += 1;
                RefreshWebBrowser();
            }
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            pageNum -= 1;
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            RefreshWebBrowser();
        }

        private void GetTotalPageNum()
        {
            try
            {
                string value = this.wb.Document.GetElementById("totPageCnt").GetAttribute("value").ToString();
                totalPageNum = Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetTotalPageNum:" + e);
            }
        }
    }
}
