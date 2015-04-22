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
    public partial class inputConsigneeTel : UserControl
    {
        public inputConsigneeTel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            virtualNumKeyboard.Keyboard = KeyboardInstance.CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
        }
        public event EventHandler inputTelEvent;
        public string getTel()
        {
            return consigneeTel.Text;
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }

        public void inputFocus()
        {
            consigneeTel.Clear();
            consigneeTel.Focus();
        }

        private void confirmConsigneeTel_Click(object sender, EventArgs e)
        {
            if (inputTelEvent != null)
            {
                inputTelEvent(this, e);
            }
        }

        private void consigneeTel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (consigneeTel.Text!=""&&inputTelEvent != null)
                {
                    ((TextBox)(sender)).SelectAll();
                    inputTelEvent(this, e);
                }
            }
        }
    }
}
