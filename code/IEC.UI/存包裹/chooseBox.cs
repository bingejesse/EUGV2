using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Tools;
using Domain;
using DareneExpressCabinetClient.Service.Factory;

namespace IEC.UI
{
    public partial class chooseBox : UserControl
    {
        private BoxsManager boxsManager;
        private Box checkedBox;
        public chooseBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.boxsManager = BoxsManager.GetInstance();
        }
        public Box.Size checkedInfo;
        //添加事件代理
        public event EventHandler confirmEvent;

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }

        public void clearCheckedInfo()
        {
            bigbox.Checked = false;
            mediumbox.Checked = false;
            smallbox.Checked = false;
            errMsg.Text = "";
            boxChose.Text = "";
            checkedBox = null;
        }
        public void updateBoxNum(int bigBoxNum, int mediumBoxNum, int smallBoxNum)
        {
            bigboxNumL.Text = "剩余："+bigBoxNum.ToString();
            mediumboxNumL.Text = "剩余：" + mediumBoxNum.ToString();
            smallboxNumL.Text = "剩余："+smallBoxNum.ToString();

            this.bigbox.Enabled = true ? bigBoxNum > 0 : false;
            this.mediumbox.Enabled = true ? mediumBoxNum > 0 : false;
            this.smallbox.Enabled = true ? smallBoxNum > 0 : false;

        }

        private void confirmChooseBox_Click(object sender, EventArgs e)
        {
            if (this.checkedBox != null)
            {
                if (confirmEvent != null)
                {
                    confirmEvent(checkedBox, e);
                }
            }
            else
            {
                errMsg.Text = "请先选取合适柜子";
                ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("请先选取合适柜子");
            }
        }

        private void bigbox_Click(object sender, EventArgs e)
        {
            this.checkedBox= boxsManager.Find(Box.Size.L);
            if (this.checkedBox == null)
            {
                errMsg.Text = "找不到合适的柜子";
                return;
            }
            checkedInfo = Box.Size.L;
            this.boxChose.Text = checkedBox.CoordinateInfo.X.ToString() + checkedBox.CoordinateInfo.Y.ToString() + "号大柜";
            CLog4net.LogInfo("选取柜门："+checkedBox.Code);
        }

        private void mediumbox_Click(object sender, EventArgs e)
        {
            this.checkedBox = boxsManager.Find(Box.Size.M);
            if (this.checkedBox == null)
            {
                errMsg.Text = "找不到合适的柜子";
                return;
            }
            checkedInfo = Box.Size.M;
            this.boxChose.Text = checkedBox.CoordinateInfo.X.ToString() + checkedBox.CoordinateInfo.Y.ToString() + "号中柜";
            CLog4net.LogInfo("选取柜门：" + checkedBox.Code);
        }

        private void smallbox_Click(object sender, EventArgs e)
        {
            this.checkedBox = boxsManager.Find(Box.Size.S);
            if (this.checkedBox == null)
            {
                errMsg.Text = "找不到合适的柜子";
                return;
            }
            checkedInfo = Box.Size.S;
            this.boxChose.Text = checkedBox.CoordinateInfo.X.ToString() + checkedBox.CoordinateInfo.Y.ToString() + "号小柜";
            CLog4net.LogInfo("选取柜门：" + checkedBox.Code);
        }
    }
}
