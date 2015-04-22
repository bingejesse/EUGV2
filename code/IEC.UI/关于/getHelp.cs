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
    public partial class getHelp : UserControl
    {
        public getHelp()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private About about;
        public event EventHandler getSuperEvent;
        private void getSuper_Click(object sender, EventArgs e)
        {
            if (getSuperEvent != null)
            {
                getSuperEvent(this, e);
            }
        }

        public void Loading()
        {
            this.about = AboutConfig.GetInstance().GetAbout();
            this.adress.Text = about.Address;
            this.companyName.Text = about.CompanyName;
            this.name.Text = about.Name;
            this.code.Text = about.CabinetCode;
            this.telNum.Text = about.TelNum;

            IniConfigManager iniConfig = new IniConfigManager();
            this.labelVersion.Text = "客户端版本号：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.createdTime.Text = iniConfig.GetAboutCommissioningData();
        }
    }
}
