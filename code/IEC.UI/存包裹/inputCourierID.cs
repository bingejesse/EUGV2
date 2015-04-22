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
    public partial class inputCourierID : UserControl
    {
        public inputCourierID()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);  //  禁止擦除背景. 
            SetStyle(ControlStyles.DoubleBuffer, true);  //  双缓冲 

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }

        public event EventHandler courierConfirmEvent;

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
            if (courierConfirmEvent != null)
            {
                courierConfirmEvent(this, e);
            }
        }

        private void courierNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (courierNum.Text!=""&&courierConfirmEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    courierConfirmEvent(this, e);
                }
            }
        }

    }
}
