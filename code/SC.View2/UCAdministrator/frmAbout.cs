using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient.Tools;
using System.Diagnostics;
using Domain;

namespace SC.View2
{
    public partial class frmAbout : Form
    {
        private About about;

        public frmAbout()
        {
            InitializeComponent();
            about = AboutConfig.GetInstance().GetAbout();
            
            this.TopMost = true;
            RefreshFrm();
        }

        private void RefreshFrm()
        {
            try
            {
                //About about = AboutConfig.GetInstance().GetAbout();
                //this.managerName.Text = about.ManagerName;
                //this.ManagerPwd.Text = about.ManagerPassword;
                this.name.Text = about.Name;
                this.companyName.Text = about.CompanyName;
                this.serverUrl.Text = about.ServerUrl;
                this.adress.Text = about.Address;
                this.telNum.Text = about.TelNum;
                this.remark.Text = about.Remark;
                this.modeltype.Text = about.Model;
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
            }
        }

        private void cabinetCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void telNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            DatabaseService service = ServicesFactory.GetInstance().GetDatabaseService();
            //About about = new About();
            about.CabinetCode = AboutConfig.GetInstance().GetCabinetCode();
            about.Name = this.name.Text;
            about.CompanyName = this.companyName.Text;
            about.ServerUrl = this.serverUrl.Text;
            about.Address = this.adress.Text;
            about.TelNum = this.telNum.Text;
            about.Remark = this.remark.Text;
            about.Model = this.modeltype.Text;

            service.UpdateAbout(about);

            RefreshFrm();
            MessageBox.Show("修改成功");
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
