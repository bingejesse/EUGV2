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
    public partial class superManager : UserControl
    {
        public superManager()
        {
            InitializeComponent();
            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNormalKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }
        public event EventHandler superEvent;
        public void inputFocus()
        {
            superNum.Clear();
            superPwd.Clear();
            superNum.Focus();
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }
        public string getSuperNum()
        {
            return superNum.Text;
        }
        public string getSuperPwd()
        {
            return superPwd.Text;
        }

        public void ClearTexbox()
        {
            superNum.Clear();
            superPwd.Clear();
        }

        private void superLogin_Click(object sender, EventArgs e)
        {
            if (superNum.Text != "" && superPwd.Text != "" && superEvent != null)
            {
                superEvent(this, e);
            }
        }

        private void superPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (superNum.Text != "" && superPwd.Text != "" && superEvent != null)
                {
                    superEvent(this, e);
                }
            }
        }

    }
}
