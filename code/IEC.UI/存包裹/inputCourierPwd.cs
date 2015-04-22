using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Keyboard;

namespace IEC.UI
{
    public partial class inputCourierPwd : UserControl
    {
        public inputCourierPwd()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }

        public void inputFocus()
        {
            courierPwd.Clear();
            courierPwd.Focus();
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }

        public string getCourierPwd()
        {
            return courierPwd.Text;
        }

        //添加事件代理
        public event EventHandler confirmCpEvent;
        private void confirmCourierPwd_Click(object sender, EventArgs e)
        {
            if (confirmCpEvent != null)
            {
                confirmCpEvent(this, e);
            }
        }

        private void courierPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (courierPwd.Text!=""&&confirmCpEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    confirmCpEvent(this, e);
                }
            }
        }

    }
}
