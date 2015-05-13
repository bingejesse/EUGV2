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

namespace SC.View2
{
    public partial class FrmPassword : Form
    {
        private About about;

        public FrmPassword()
        {
            InitializeComponent();
            about = AboutConfig.GetInstance().GetAbout();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string oldpassword = txtoldPassWord.Text;
            string newpassword = txtnewPassWord.Text;
            string repeatpassword = txtrepeatPassWord.Text;
            if (oldpassword != about.ManagerPassword)
            {
                MessageBox.Show("旧密码错误");
                return;
            }
            if (newpassword != repeatpassword)
            {
                MessageBox.Show("密码不一致");
                return;
            }
            if (newpassword.Length < 6)
            {
                MessageBox.Show("密码长度必须大于5个字符");
                return;
            }
            if (newpassword == oldpassword)
            {
                MessageBox.Show("新旧密码不能一样");
                return;
            }
            else
            {
                DatabaseService service = ServicesFactory.GetInstance().GetDatabaseService();
                bool success = service.UpdateAboutPassword(repeatpassword);
                if (success)
                {
                    about.ManagerPassword = repeatpassword;
                    MessageBox.Show("密码修改成功");
                }
                else
                {
                    MessageBox.Show("密码修改失败");
                }

                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
