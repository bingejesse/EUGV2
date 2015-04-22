using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Service.Factory;

namespace IEC.UI
{
    public partial class FrmSavaPackage : Form
    {
        public FrmSavaPackage()
        {
            InitializeComponent();
        }

        
        private int seconds;
        public FrmSavaPackage(int seconds,string num,int count):this()
        {
            ServicesFactory.GetInstance().GetVoicService().BroadcastOnce("您选择的柜子是" + num + "号，请放入包裹并关闭柜门，谢谢！");
            this.labelXInfo.Text = string.Format("<div align='center'>您选择的柜子是<b><font size='+15' color='red'>{0}</font></b>号，还有<font size='+15' color='orange'>{1}</font>次重选机会</div>", num, count);
            //您选的柜门是<b><font size="+15" color="red">11</font></b>号，还有3次重选机会
            this.buttonXCancel.Enabled = true ? count > 0 : false;
            this.seconds = seconds;
            this.timerMain.Interval = 1000;
            this.timerMain.Enabled = true;
            this.timerMain.Start();
        }

        private void buttonXYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private FrmMessagebox messagebox;
        private void buttonXNo_Click(object sender, EventArgs e)
        {
            if (messagebox == null)
            {
                messagebox = new FrmMessagebox();
            }
            messagebox.SetMessageInfo("系统提示", "请注意：确认操作将返回主界面！");
            DialogResult dr = messagebox.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            this.seconds -= 1;
            if (this.seconds < 1)
            {
                //ServicesFactory.GetInstance().GetVoicService().StopBroadcast();

                if (this.messagebox != null)
                {
                    this.messagebox.Close();
                }

                this.Close();
            }
            else
            {
                this.Countdown.Text = this.seconds.ToString();
            }

        }
    }
}
