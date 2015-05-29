using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC.View2.GBYControls
{
    public partial class GBYLabel : Label
    {
        public GBYLabel()
        {
            InitializeComponent();
            textBox1.MouseDown += new MouseEventHandler(GBYLabel_MouseDown);
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            //textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            textBox1.KeyUp += new KeyEventHandler(textBox1_KeyUp);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            base.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            textBox1.Focus();
            base.Image = (Image)Properties.Resources.inputBg_348x93_focus;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.Image = (Image)Properties.Resources.inputBg_348x93;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void GBYLabel_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            base.Text = textBox1.Text;
           
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
