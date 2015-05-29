using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GBY
{
    public partial class GBYTextBox : Control
    {
        public GBYTextBox()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.FixedHeight, false);
            base.UpdateStyles();
            Init();
        }

        private RichTextBoxEX alphaTB;
        private Bitmap normalBackImage = null;

        public Bitmap NormalBackImage
        {
            get { return normalBackImage; }
            set { normalBackImage = value; }
        }
        private Bitmap enterBackImage = null;

        public Bitmap EnterBackImage
        {
            get { return enterBackImage; }
            set { enterBackImage = value; }
        }

        private void Init()
        {
            this.BackColor = Color.Transparent;
            alphaTB = new RichTextBoxEX();
            this.Controls.Add(alphaTB);

            base.Size = new Size(alphaTB.Size.Width + Margin.Left + Margin.Right, alphaTB.Size.Height + Margin.Top + Margin.Bottom);

            base.GotFocus += new EventHandler(GBYTextBox_GotFocus);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (!MultiLine)
            {
                base.Height = this.PFont.Height + Margin.Top + Margin.Bottom;
            }
            if (base.Width < Margin.Left + Margin.Right)
            {
                base.Width = Margin.Left + Margin.Right;
            }
            alphaTB.Location = new Point(Margin.Left, Margin.Top);
            alphaTB.Width = base.Width - Margin.Left - Margin.Right;
        }

        public new Padding Margin
        {
            get { return base.Margin; }
            set
            {
                base.Margin = value;
                if(!MultiLine)
                base.Height = PFont.Height + value.Top + value.Bottom;
            }
        }

        public int MaxLength
        {
            get { return alphaTB.MaxLength; }
            set { alphaTB.MaxLength = value; }
        }

        public string PText
        {
            get { return alphaTB.Text; }
            set { this.alphaTB.Text = value; }
        }

        public Font PFont
        {
            get { return alphaTB.Font; }
            set
            {
                if (alphaTB.Font != value)
                {
                    alphaTB.Font = value;
                    if (!MultiLine)
                    {
                        base.Height = PFont.Height + 10;
                    }
                }
            }
        }

        public Color PForeColor
        {
            get { return alphaTB.ForeColor; }
            set { alphaTB.ForeColor = value; }
        }

        public bool MultiLine
        {
            get { return alphaTB.Multiline; }
            set
            {
                alphaTB.Multiline = value;
            }
        }

        private void GBYTextBox_Enter(object sender, EventArgs e)
        {
            if (enterBackImage != null)
            {
                base.BackgroundImage = (Image)enterBackImage;
            }
        }

        private void GBYTextBox_Leave(object sender, EventArgs e)
        {
            if (normalBackImage != null)
            {
                base.BackgroundImage = (Image)normalBackImage;
            }
        }

        private void GBYTextBox_GotFocus(object sender, EventArgs e)
        {
            alphaTB.Focus();
        }

        private class RichTextBoxEX : RichTextBox
        {
            public RichTextBoxEX()
            {
                Init();
            }

            private void Init()
            {
                base.BorderStyle = BorderStyle.None;
                base.Multiline = false;
            }

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr LoadLibrary(string lpFileName);

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams prams = base.CreateParams;
                    if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                    {
                        prams.ExStyle |= 0x020; // transparent 
                        prams.ClassName = "RICHEDIT50W";
                    }
                    return prams;
                }
            }    
        }
    }
}