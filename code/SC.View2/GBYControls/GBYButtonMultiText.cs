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

namespace GBY
{
    public partial class GBYButtonMultiText : GBYButton
    {
        public GBYButtonMultiText():base()
        {
            InitializeComponent();
        }

        private string multiText = "";
        [Category("自定义属性"), Description("多行文字内容")]
        public string MultiText
        {
            get { return multiText; }
            set { multiText = value; base.Invalidate(); }
        }

        private Font mutiFont = new Font("宋体", 9);
        [Category("自定义属性"), Description("多行文字字体")]
        public Font MutiFont
        {
            get { return mutiFont; }
            set { mutiFont = value; base.Invalidate(); }
        }

        private float _multitextTop = 0;
        [Category("自定义属性"), Description("文字居中向上偏移量")]
        public float MultiTextTop
        {
            get { return _multitextTop; }
            set { _multitextTop = value; base.Invalidate(); }
        }
        private float _multitextLeft = 0;
        [Category("自定义属性"), Description("文字居中向左偏移量")]
        public float MultiTextLeft
        {
            get { return _multitextLeft; }
            set { _multitextLeft = value; base.Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            Rectangle bounds = base.ClientRectangle;
            PointF textPoint = new PointF();
            SizeF textSize = TextRenderer.MeasureText(this.multiText, this.mutiFont);

            textPoint.X
                = bounds.X + (bounds.Width - textSize.Width) / 2 - _multitextLeft;
            textPoint.Y
                = (bounds.Bottom - textSize.Height) / 2 - _multitextTop;

            // Draw highlights  
            float highlight_x = textPoint.X + Del_X;
            float highlight_y = textPoint.Y + Del_Y;
            //g.DrawString(
            //    this.multiText,
            //    this.mutiFont,
            //    new SolidBrush(HighLight),    // 高光颜色  
            //    highlight_x,
            //    highlight_y);

            TextShadow tShadow = new TextShadow();
            tShadow.Draw(g, this.multiText, this.mutiFont, new PointF(textPoint.X, textPoint.Y));//文字阴影

            // 绘制正常文字  
            //textPoint.X -= _del_X;
            //textPoint.Y -= _del_Y;
            g.DrawString(
                this.multiText,
                this.mutiFont,
                new SolidBrush(TextColor),    // 正常颜色  
                textPoint.X,
                textPoint.Y);
        }
    }
}
