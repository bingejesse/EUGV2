using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Keyboard;
using System.Runtime.InteropServices;

namespace IEC.UI
{
    public partial class confirmConsigneeTel : UserControl
    {
        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        public static extern int ShowCursor(bool bShow);

        public confirmConsigneeTel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }
        //添加事件代理
        public event EventHandler confirmEvent;
        public void inputFocus()
        {
            confirmTel.Clear();
            confirmTel.Focus();
            errMsg.Text = "";
        }
        public string getTel()
        {
            return confirmTel.Text;
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }

        private void confirmTelBtn_Click(object sender, EventArgs e)
        {
            if (confirmEvent != null)
            {
                confirmEvent(this, e);
            }
        }

        private void confirmTel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (confirmTel.Text!=""&&confirmEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    confirmEvent(this, e);
                }
            }
        }
    }
}
