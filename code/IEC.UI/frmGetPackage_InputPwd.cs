using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar.Keyboard;
namespace IEC.UI
{
    public partial class frmGetPackage_InputPwd : Form
    {
        frmMain mainfrm;
        int sec = 60;
        public frmGetPackage_InputPwd(frmMain fm)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            this.SetVisibleCore(false);
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);

            mainfrm = fm;
            virtualNumKeyboard.Keyboard = CreateNumericKeyboard();
            virtualNumKeyboard.Renderer = new vKeyboardRenderer();
            virtualNumKeyboard.Invalidate();
            sec = 60;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private Keyboard CreateNumericKeyboard()
        {
            Keyboard keyboard = new Keyboard();

            LinearKeyboardLayout keyboardlayout = new LinearKeyboardLayout();

            keyboardlayout.AddKey("7");
            keyboardlayout.AddKey("8");
            keyboardlayout.AddKey("9");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("4");
            keyboardlayout.AddKey("5");
            keyboardlayout.AddKey("6");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("1");
            keyboardlayout.AddKey("2");
            keyboardlayout.AddKey("3");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("0");
            keyboardlayout.AddKey("退格", "{BACKSPACE}");
            keyboardlayout.AddKey("清除", "^{a}{BACKSPACE}");

            keyboard.Layouts.Add(keyboardlayout);

            return keyboard;
        }

        
        private void frmGetPackage_InputPwd_Activated(object sender, EventArgs e)
        {
            packagePwd.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec < 0)
            {

            }
            else
            {
                sec--;
                Countdown.Text = sec.ToString();
            }
            
            
        }

        private void returnToMainfrm_Click(object sender, EventArgs e)
        {
            mainfrm.Show();
            this.Close();
        }

        private void frmGetPackage_InputPwd_Paint(object sender, PaintEventArgs e)
        {
            //Image image = Properties.Resources.bj_small;
            //TextureBrush brush = new TextureBrush(image);
            //Graphics g = e.Graphics;
            //brush.WrapMode = WrapMode.Clamp;

            //g.FillRectangle(brush,new Rectangle(0,0,this.Width,this.Height));
            ////g.Restore(state);  
            //g.Dispose();
        }



    }
}
