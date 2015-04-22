using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;

namespace IEC.UI
{
    public partial class getHelpInfo : UserControl
    {
        public getHelpInfo()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            IniConfigManager iniConfig = new IniConfigManager();

            this.labelVersion.Text = "客户端版本号：" + iniConfig.GetAboutVersion();
        }
        public event EventHandler getSuperEvent;

        private void getSuper_Click(object sender, EventArgs e)
        {
            if (getSuperEvent != null)
            {
                getSuperEvent(this, e);
            }
        }
    }
}
