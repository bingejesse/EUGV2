using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace GBY
{
    public partial class GBYAlphaTextBox : System.Windows.Forms.TextBox
    {
        #region 变量

        private uPictureBox myPictureBox;
        private bool myUpToDate = false;
        private bool myCaretUpToDate = false;
        private Bitmap myBitmap;
        private Bitmap myAlphaBitmap;

        private int myFontHeight = 10;

        private System.Windows.Forms.Timer myTimer1;

        private bool myCaretState = true;

        private bool myPaintedFirstTime = false;

        private Color myBackColor = Color.White;
        private int myBackAlpha = 10;

        #endregion

        #region 方法和重写

        public GBYAlphaTextBox()
        {
            InitializeComponent();

            this.BackColor = myBackColor;

            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);


            myPictureBox = new uPictureBox();
            this.Controls.Add(myPictureBox);
            myPictureBox.Dock = DockStyle.Fill;
        }


        protected override void OnResize(EventArgs e)
        {
            if (base.Width < 1)
            {
                base.Width = 1;
            }
            base.OnResize(e);
            this.myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            this.myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            myUpToDate = false;
            this.Invalidate();

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Invalidate();
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
            myUpToDate = false;
            this.Invalidate();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            Point ptCursor = Cursor.Position;

            Form f = this.FindForm();
            ptCursor = f.PointToClient(ptCursor);
            if (!this.Bounds.Contains(ptCursor))
                base.OnMouseLeave(e);
        }


        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();


            myTimer1 = new System.Windows.Forms.Timer();
            myTimer1.Interval = (int)WIN32.GetCaretBlinkTime(); //  usually around 500;

            myTimer1.Tick += new EventHandler(myTimer1_Tick);
            //myTimer1.Enabled = true;

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();

            myTimer1.Dispose();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, false);

            base.OnFontChanged(e);

            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, true);


            myFontHeight = GetFontHeight();


            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            myUpToDate = false;
            this.Invalidate();
        }


        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);

            if (m.Msg == WIN32.WM_PAINT)
            {
                myPaintedFirstTime = true;

                if (!myUpToDate || !myCaretUpToDate)
                    GetBitmaps();
                myUpToDate = true;
                myCaretUpToDate = true;

                if (myPictureBox.Image != null) myPictureBox.Image.Dispose();
                myPictureBox.Image = (Image)myAlphaBitmap.Clone();

            }

            else if (m.Msg == WIN32.WM_HSCROLL || m.Msg == WIN32.WM_VSCROLL)
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == WIN32.WM_LBUTTONDOWN
                || m.Msg == WIN32.WM_RBUTTONDOWN
                || m.Msg == WIN32.WM_LBUTTONDBLCLK
                )
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == WIN32.WM_MOUSEMOVE)
            {
                if (m.WParam.ToInt32() != 0)
                {
                    myUpToDate = false;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region 属性

        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.BorderStyle = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }

        public new Color BackColor
        {
            get
            {
                return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
            }
            set
            {
                myBackColor = value;
                base.BackColor = value;
                myUpToDate = false;
            }
        }
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.Multiline = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }


        #endregion

        #region 私有方法和私有类

        private int GetFontHeight()
        {
            Graphics g = this.CreateGraphics();
            SizeF sf_font = g.MeasureString("X", this.Font);
            g.Dispose();
            return (int)sf_font.Height;
        }


        private void GetBitmaps()
        {

            if (myBitmap == null
                || myAlphaBitmap == null
                || myBitmap.Width != Width
                || myBitmap.Height != Height
                || myAlphaBitmap.Width != Width
                || myAlphaBitmap.Height != Height)
            {
                myBitmap = null;
                myAlphaBitmap = null;
            }



            if (myBitmap == null)
            {
                myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);
                myUpToDate = false;
            }


            if (!myUpToDate)
            {
                this.SetStyle(ControlStyles.UserPaint, false);

                WIN32.CaptureWindow(this, ref myBitmap);

                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.FromArgb(myBackAlpha, myBackColor);

            }

            Rectangle r2 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            ImageAttributes tempImageAttr = new ImageAttributes();

            ColorMap[] tempColorMap = new ColorMap[1];
            tempColorMap[0] = new ColorMap();
            tempColorMap[0].OldColor = Color.FromArgb(255, myBackColor);
            tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha, myBackColor);

            tempImageAttr.SetRemapTable(tempColorMap);

            if (myAlphaBitmap != null)
                myAlphaBitmap.Dispose();


            myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);

            Graphics tempGraphics1 = Graphics.FromImage(myAlphaBitmap);

            //tempGraphics1.DrawImage(myBitmap, r2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);
            tempGraphics1.DrawImage(myBitmap, r2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);

            tempGraphics1.Dispose();

            //if (this.Focused && (this.SelectionLength == 0))
            //{
            //    Graphics tempGraphics2 = Graphics.FromImage(myAlphaBitmap);
            //    if (myCaretState)
            //    {
            //        Point caret = this.findCaret();
            //        Pen p = new Pen(this.ForeColor, 3);
            //        tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + myFontHeight);
            //        tempGraphics2.Dispose();
            //    }

            //}
        }

        private Point findCaret()
        {

            Point pointCaret = new Point(0);
            int i_char_loc = this.SelectionStart;
            IntPtr pi_char_loc = new IntPtr(i_char_loc);

            int i_point = WIN32.SendMessage(this.Handle, WIN32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
            pointCaret = new Point(i_point);

            if (i_char_loc == 0)
            {
                pointCaret = new Point(0);
            }
            else if (i_char_loc >= this.Text.Length)
            {
                pi_char_loc = new IntPtr(i_char_loc - 1);
                i_point = WIN32.SendMessage(this.Handle, WIN32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
                pointCaret = new Point(i_point);

                Graphics g = this.CreateGraphics();
                String t1 = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                SizeF sizet1 = g.MeasureString(t1, this.Font);
                SizeF sizex = g.MeasureString("X", this.Font);
                g.Dispose();
                int xoffset = (int)(sizet1.Width - sizex.Width);
                pointCaret.X = pointCaret.X + xoffset;

                if (i_char_loc == this.Text.Length)
                {
                    String slast = this.Text.Substring(Text.Length - 1, 1);
                    if (slast == "\n")
                    {
                        pointCaret.X = 1;
                        pointCaret.Y = pointCaret.Y + myFontHeight;
                    }
                }

            }
            return pointCaret;
        }


        private void myTimer1_Tick(object sender, EventArgs e)
        {
            myCaretState = !myCaretState;
            myCaretUpToDate = false;
            this.Invalidate();
        }


        private class uPictureBox : PictureBox
        {
            public uPictureBox()
            {
                this.SetStyle(ControlStyles.Selectable, false);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);

                this.Cursor = null;
                this.Enabled = true;
                this.SizeMode = PictureBoxSizeMode.Normal;

            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WIN32.WM_LBUTTONDOWN
                    || m.Msg == WIN32.WM_RBUTTONDOWN
                    || m.Msg == WIN32.WM_LBUTTONDBLCLK
                    || m.Msg == WIN32.WM_MOUSELEAVE
                    || m.Msg == WIN32.WM_MOUSEMOVE)
                {
                    WIN32.PostMessage(this.Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);
                }

                else if (m.Msg == WIN32.WM_LBUTTONUP)
                {
                    this.Parent.Invalidate();
                }


                base.WndProc(ref m);
            }
        }
        #endregion

        #region 新属性

        [
        Category("Appearance"),
        Description("The alpha value used to blend the control's background. Valid values are 0 through 255."),
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)

        ]
        public int BackAlpha
        {
            get { return myBackAlpha; }
            set
            {
                int v = value;
                if (v > 255)
                    v = 255;
                myBackAlpha = v;
                myUpToDate = false;
                Invalidate();
            }
        }
        #endregion
    }
}