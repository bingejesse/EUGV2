using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;

namespace GBY
{
    public partial class GBYButton : Button
    {
        public GBYButton()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.AllPaintingInWmPaint , true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer , true);
            base.SetStyle(ControlStyles.ResizeRedraw , true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor , true);
            base.SetStyle(ControlStyles.UserPaint , true);
            base.SetStyle(ControlStyles.Opaque, false);
            base.UpdateStyles();
        }

        private Image _normalImg;
        [Category("自定义属性"), Description("正常样式")]
        public Image NormalImg
        {
            get { return _normalImg; }
            set { _normalImg = value; base.Invalidate(); }
        }
        private Image _downImg;
        [Category("自定义属性"), Description("鼠标按下样式")]
        public Image DownImg
        {
            get { return _downImg; }
            set { _downImg = value; base.Invalidate(); }
        }
        private Image _hoverImg;
        [Category("自定义属性"), Description("鼠标悬浮样式")]
        public Image HoverImg
        {
            get { return _hoverImg; }
            set { _hoverImg = value; base.Invalidate(); }
        }
        private Color _highLight = Color.FromArgb(207, 207, 207);
        [Category("自定义属性"), Description("文字高光色")]
        public Color HighLight
        {
            get { return _highLight; }
            set { _highLight = value; base.Invalidate(); }
        }
        private Color _textColor = Color.Black;
        [Category("自定义属性"), Description("文字颜色")]
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; base.Invalidate(); }
        }
        private float _del_X = 0;
        [Category("自定义属性"), Description("文字高光X偏移")]
        public float Del_X
        {
            get { return _del_X; }
            set { _del_X = value; base.Invalidate(); }
        }

        private float _del_Y = 1;
        [Category("自定义属性"), Description("文字高光Y偏移")]
        public float Del_Y
        {
            get { return _del_Y; }
            set { _del_Y = value; base.Invalidate(); }
        }

        private float _textTop = 0;
        [Category("自定义属性"), Description("文字居中向上偏移量")]
        public float TextTop
        {
            get { return _textTop; }
            set { _textTop = value; base.Invalidate(); }
        }
        private float _textLeft = 0;
        [Category("自定义属性"), Description("文字居中向左偏移量")]
        public float TextLeft
        {
            get { return _textLeft; }
            set { _textLeft = value; base.Invalidate(); }
        }

        private PushButtonState _state = PushButtonState.Default;

        private PushButtonState State
        {
            get { return _state; }
            set { _state = value; base.Invalidate(); }
        }

        private bool _toogle = false;

        public bool Toogle
        {
            get { return _toogle; }
            set { _toogle = value; base.Invalidate(); }
        }

        private bool _checked = false;

        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value)
                {
                    if (base.Parent != null)
                        foreach (Control c in base.Parent.Controls)
                        {
                            if (c is GBYButton)
                            {
                                if (((GBYButton)c).Toogle)
                                    ((GBYButton)c).Checked = false;
                            }
                        }
                }
                _checked = value;
                base.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //g.Clear(base.BackColor);

            switch (State)
            {
                case PushButtonState.Default:
                    if (_normalImg != null)
                    {
                        if (_toogle && _checked)
                        {
                            if (_downImg != null)
                                g.DrawImage(_downImg, base.ClientRectangle, new Rectangle(0, 0, _downImg.Width, _downImg.Height), GraphicsUnit.Pixel);
                        }
                        else
                            g.DrawImage(_normalImg, base.ClientRectangle, new Rectangle(0, 0, _normalImg.Width, _normalImg.Height), GraphicsUnit.Pixel);
                    }
                    break;
                case PushButtonState.Normal:
                    if (_hoverImg != null)
                    {
                        if (_toogle && _checked)
                        {
                            if (_downImg != null)
                                g.DrawImage(_downImg, base.ClientRectangle, new Rectangle(0, 0, _downImg.Width, _downImg.Height), GraphicsUnit.Pixel);
                        }
                        else
                            g.DrawImage(_hoverImg, base.ClientRectangle, new Rectangle(0, 0, _hoverImg.Width, _hoverImg.Height), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        if (_normalImg != null)
                            if (_toogle && _checked)
                            {
                                if (_downImg != null)
                                    g.DrawImage(_downImg, base.ClientRectangle, new Rectangle(0, 0, _downImg.Width, _downImg.Height), GraphicsUnit.Pixel);
                            }
                            else
                                g.DrawImage(_normalImg, base.ClientRectangle, new Rectangle(0, 0, _normalImg.Width, _normalImg.Height), GraphicsUnit.Pixel);
                    }
                    break;
                case PushButtonState.Pressed:
                    if (_downImg != null)
                    {
                        g.DrawImage(_downImg, base.ClientRectangle, new Rectangle(0, 0, _downImg.Width, _downImg.Height), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        if (_normalImg != null)
                            g.DrawImage(_normalImg, base.ClientRectangle, new Rectangle(0, 0, _normalImg.Width, _normalImg.Height), GraphicsUnit.Pixel);
                    }
                    break;
            }

            Rectangle bounds = base.ClientRectangle;
            PointF textPoint = new PointF();
            SizeF textSize = TextRenderer.MeasureText(this.Text, this.Font);

            textPoint.X
                = bounds.X + (bounds.Width - textSize.Width) / 2 - _textLeft;
            textPoint.Y
                = (bounds.Bottom - textSize.Height) / 2 - _textTop;

            // Draw highlights  
            float highlight_x = textPoint.X + _del_X ;
            float highlight_y = textPoint.Y + _del_Y ;
            //g.DrawString(
            //    this.Text,
            //    this.Font,
            //    new SolidBrush(_highLight),    // 高光颜色  
            //    highlight_x,
            //    highlight_y);
            TextShadow tShadow = new TextShadow();
            tShadow.Draw(g, this.Text, this.Font, new PointF(textPoint.X, textPoint.Y));//文字阴影

            // 绘制正常文字  
            //textPoint.X -= _del_X;
            //textPoint.Y -= _del_Y;
            g.DrawString(
                this.Text,
                this.Font,
                new SolidBrush(_textColor),    // 正常颜色  
                textPoint.X,
                textPoint.Y);

        }

        private void GBYButton_MouseDown(object sender, MouseEventArgs e)
        {
            State = PushButtonState.Pressed;

            if (_toogle)
            {
                Checked = true;
            }
            else
            {
                SetPressedStyle(true);
            }
            //base.OnMouseDown(e);
        }

        private void GBYButton_MouseEnter(object sender, EventArgs e)
        {
            State = PushButtonState.Normal;
            //base.OnMouseEnter(e);
        }

        private void GBYButton_MouseLeave(object sender, EventArgs e)
        {
            State = PushButtonState.Default;
            //base.OnMouseLeave(e);
        }

        private void GBYButton_MouseUp(object sender, MouseEventArgs e)
        {
            State = PushButtonState.Normal;
            if (!_toogle)
                SetPressedStyle(false);
        }

        private void SetPressedStyle(bool down)
        {
            if (down)
            {
                this.TextTop--;
                this.TextLeft--;
            }
            else
            {
                this.TextTop++;
                this.TextLeft++;
            }
        }
    }
}
