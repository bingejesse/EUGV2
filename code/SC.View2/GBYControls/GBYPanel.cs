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
using System.Drawing.Imaging;
using System.Threading;

namespace GBY
{
    public enum AnimationDirection
    {
        UP_TO_DOWN,
        DOWN_TO_UP,
        LEFT_TO_RIGHT,
        RIGHT_TO_LEFT,
    };

    public enum AnimationCategory
    {
        Load,
        Scale,
        Move,
    };

    public partial class GBYPanel : Panel
    {
        public delegate void EventHandler(object sender, AnimationCategory ani);
        public event EventHandler AnimationEnd;
        public GBYPanel()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.UpdateStyles();

            if (backImg != null)
                backImg.Dispose(); backImg = null;
            backImg = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);

            base.DrawToBitmap(backImg, base.ClientRectangle);
        }

        private Bitmap backImg;//控件截图
        private Bitmap alphaback;//透明抓图
        private Bitmap backgroundTemp;//临时背景
        private Color backcolorTemp = Color.Transparent;//临时背景色
        Graphics gbackImg;
        uPictureBox picbox;
        private AnimationCategory aniCategory = AnimationCategory.Load;
        private AnimationDirection showDirection = AnimationDirection.DOWN_TO_UP;

        public AnimationDirection ShowDirection
        {
            get { return showDirection; }
            set { showDirection = value; }
        }

        private AnimationDirection hideDirection = AnimationDirection.UP_TO_DOWN;

        public AnimationDirection HideDirection
        {
            get { return hideDirection; }
            set { hideDirection = value; }
        }

        private float loadSpeed = 1f;

        public float LoadSpeed
        {
            get { return loadSpeed; }
            set { loadSpeed = value; }
        }

        private bool isShow = false;
        private bool shown = false;
        private bool isfirst = false;
        public bool Shown
        {
            get { return shown; }   
        }

        public void Play(bool show)
        {
            isShow = !show;
            aniCategory = AnimationCategory.Load;
            animate();
        }

        private int scaledue = 0;
        private int scaleX = 0;
        private int scaleY = 0;
        private int scalecount = 0;
        public void Play(int delX, int delY, int duration)
        {
            this.scaledue = duration;
            this.scalecount = duration / timer1.Interval;
            this.scaleX = base.Width + delX;
            this.scaleY = base.Height + delY;
            aniCategory = AnimationCategory.Scale;
            if(!timer1.Enabled)
                this.timer1.Start();
        }

        /// <summary>
        /// 显示和消失动画
        /// </summary>
        private void animate()
        {
            if (!timer1.Enabled)
            {
                if (backImg != null)
                    backImg.Dispose(); backImg = null;
                backImg = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);
 
                base.DrawToBitmap(backImg, base.ClientRectangle);

                if (alphaback != null)
                    alphaback.Dispose(); alphaback = null;
                alphaback = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);

                if (base.BackgroundImage != null)
                {
                    backgroundTemp = (Bitmap)base.BackgroundImage;
                    base.BackgroundImage = null;
                }
                if (base.BackColor != Color.Transparent)
                {
                    backcolorTemp = base.BackColor;
                    base.BackColor = Color.Transparent;
                }

                WIN32.CaptureWindow(this, ref alphaback);

                if (picbox != null)
                    picbox.Dispose(); picbox = null;
                picbox = new uPictureBox();
                this.Controls.Add(picbox);
                picbox.Dock = DockStyle.Fill;

                if (!shown)
                    picbox.Image = alphaback;
                else
                    picbox.Image = backImg;
                picbox.BringToFront();
                base.Visible = true;

                if (!shown)
                {
                    if (gbackImg != null)
                        gbackImg.Dispose(); gbackImg = null;
                    gbackImg = Graphics.FromImage(alphaback);
                    gbackImg.SmoothingMode = SmoothingMode.HighQuality;
                }
                else
                {
                    if (gbackImg != null)
                        gbackImg.Dispose(); gbackImg = null;
                    gbackImg = Graphics.FromImage(backImg);
                    gbackImg.SmoothingMode = SmoothingMode.HighQuality;
                }
                isfirst = true;
                this.timer1.Start();
            }
        }

        private void DrawBack(Graphics g,AnimationDirection direction,bool show)
        {
            switch (direction)
            {
                case AnimationDirection.DOWN_TO_UP:
                    if(show)
                        g.DrawImage(backImg, new RectangleF(0, base.ClientRectangle.Height - drawH, base.ClientRectangle.Width, drawH), new RectangleF(0, backImg.Height - drawH, backImg.Width, drawH), GraphicsUnit.Pixel);
                    else
                        g.DrawImage(alphaback, new RectangleF(0, base.ClientRectangle.Height - drawH, base.ClientRectangle.Width, drawH), new RectangleF(0, alphaback.Height - drawH, alphaback.Width, drawH), GraphicsUnit.Pixel);
                    break;
                case AnimationDirection.UP_TO_DOWN:
                    if (show)
                        g.DrawImage(backImg, 0, 0, new RectangleF(0, 0, backImg.Width, drawH), GraphicsUnit.Pixel);
                    else
                        g.DrawImage(alphaback, 0, 0, new RectangleF(0, 0, alphaback.Width, drawH), GraphicsUnit.Pixel);
                    break;
                case AnimationDirection.LEFT_TO_RIGHT:
                    if (show)
                        g.DrawImage(backImg, 0, 0, new RectangleF(0, 0, drawH, backImg.Height), GraphicsUnit.Pixel);
                    else
                        g.DrawImage(alphaback, 0, 0, new RectangleF(0, 0, drawH, alphaback.Height), GraphicsUnit.Pixel);
                    break;
                case AnimationDirection.RIGHT_TO_LEFT:
                    if (show)
                        g.DrawImage(backImg, new RectangleF(base.ClientRectangle.Width - drawH, 0, drawH, base.ClientRectangle.Height), new RectangleF(backImg.Width - drawH, 0, drawH,backImg.Height ), GraphicsUnit.Pixel);
                    else
                        g.DrawImage(alphaback, new RectangleF(base.ClientRectangle.Width - drawH, 0, drawH, base.ClientRectangle.Height), new RectangleF(alphaback.Width - drawH, 0, drawH, alphaback.Height), GraphicsUnit.Pixel);
                    break;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (aniCategory)
            {
                case AnimationCategory.Load:
                    LoadAnimation();
                    break;
                case AnimationCategory.Scale:
                    ScaleAnimation();
                    break;
            }

        }

        private int scalespeedX = 4;
        private int scalespeedY = 5;
        private void ScaleAnimation()
        {
            if (base.Width == scaleX && base.Height == scaleY)
            {
                timer1.Stop();
                this.AnimationEnd(this, aniCategory);
            }
            else
            {
                if (base.Width > scaleX)
                {
                    if( base.Width - scalespeedX>scaleX)
                        base.Width -= scalespeedX;
                    else
                        base.Width = scaleX;
                }
                else if (base.Width < scaleX)
                {
                    if (base.Width + scalespeedX < scaleX)
                        base.Width += scalespeedX;
                    else
                        base.Width = scaleX;
                }

                if (base.Height > scaleY)
                {
                    if (base.Height - scalespeedY > scaleY)
                        base.Height -= scalespeedY;
                    else
                        base.Height = scaleY;

                }
                else if (base.Height < scaleY)
                {
                    if (base.Height + scalespeedY < scaleY)
                        base.Height += scalespeedY;
                    else
                        base.Height = scaleY;
                }
            }
        }

        private float tick = 0;
        private float drawH = 0;
        private float tempH = 0;

        private void LoadAnimation()
        {
            AnimationDirection direc;
            Image img;
            if (isShow)
            {
                direc = showDirection;
                img = (Image)alphaback.Clone();
            }
            else
            {
                direc = hideDirection;
                img = (Image)backImg.Clone();
            }

            if (isfirst)
            {
                drawH = 0;
                isfirst = false;
            }
            tempH = (direc == AnimationDirection.DOWN_TO_UP || showDirection == AnimationDirection.UP_TO_DOWN) ? base.ClientRectangle.Height : base.ClientRectangle.Width;
            drawH += loadSpeed;
            if (drawH < tempH)
            {
                DrawBack(gbackImg, direc, isShow);
                picbox.Image = (Image)img.Clone();
                tick++;
            }
            else
            {
                drawH = tempH;
                DrawBack(gbackImg, direc, isShow);
                picbox.Image = (Image)img.Clone();
                shown = isShow;
                ResetState();
                if (!isShow)
                    base.Visible = false;
            }
            img.Dispose();
        }

        private void ResetState()
        {
            if (backgroundTemp != null)
                base.BackgroundImage = backgroundTemp;
            if (backcolorTemp != Color.Transparent)
                base.BackColor = backcolorTemp;
            base.Controls.Remove(picbox);
            picbox.Dispose();
            picbox = null;
            
            tick = 0;
            drawH = 0;
            timer1.Stop();
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
        }     
    }
}
