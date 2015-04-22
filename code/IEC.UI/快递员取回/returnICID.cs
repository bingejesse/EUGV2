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
    public partial class returnICID : UserControl
    {
        public returnICID()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }
        public event EventHandler getBackIDEvent;

        public void inputFocus()
        {
            courierNum.Clear();
            courierNum.Focus();
        }
        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }
        public string getCourierID()
        {
            return courierNum.Text;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (getBackIDEvent != null)
            {
                getBackIDEvent(this, e);
            }
        }

        private void courierNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (courierNum.Text!=""&&getBackIDEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    getBackIDEvent(this, e);
                }
            }
        }
    }
}
