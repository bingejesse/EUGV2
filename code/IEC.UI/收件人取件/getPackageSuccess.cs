using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEC.UI
{
    public partial class getPackageSuccess : UserControl
    {
        public getPackageSuccess()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void setInfo(string str)
        {
            packageAdress.Text = str;
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }
        //添加事件代理
        public event EventHandler reopenEvent;

        private void reopen_Click(object sender, EventArgs e)
        {
            if (reopenEvent != null)
            {
                reopenEvent(this, e);
            }
        }


    }
}
