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
    public partial class mainPanel : UserControl
    {
        public string clickmessage;

        public mainPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        #region 事件代理
        //取件事件
        public event EventHandler gpcEvent;
        //寄件事件
        public event EventHandler spEvent;
        //取回事件
        public event EventHandler gbEvent;
        //帮助事件
        public event EventHandler helpEvent;
        #endregion

        private void getPackage_Click(object sender, EventArgs e)
        {
            if (gpcEvent != null)
            {
                gpcEvent(this, e);

            }
        }

        private void savePackage_Click(object sender, EventArgs e)
        {
            if (spEvent != null)
            {
                spEvent(this, e);
            }
        }

        private void returnPackage_Click(object sender, EventArgs e)
        {
            if (gbEvent != null)
            {
                gbEvent(this, e);
            }
        }

        private void forHelp_Click(object sender, EventArgs e)
        {
            if (helpEvent != null)
            {
                helpEvent(this, e);
            }
        }

    }
}
