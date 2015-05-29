using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Keyboard;
using System.Drawing;
using GBY;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SC.View2
{
    public class vKeyboardRenderer : Renderer
    {
        private Font _Font = new Font("微软雅黑", 18, FontStyle.Bold);
        private StringFormat _Format;

        public vKeyboardRenderer()
        {
            _Format = (StringFormat)StringFormat.GenericDefault.Clone();
            _Format.LineAlignment = StringAlignment.Center;
            _Format.Alignment = StringAlignment.Center;

        }

        public override void DrawBackground(BackgroundRendererEventArgs args)
        {
            //args.Graphics.DrawImage((Image)Properties.Resources.back_keyboard, args.Bounds, new Rectangle(0, 0, Properties.Resources.back_keyboard.Width, Properties.Resources.back_keyboard.Height), GraphicsUnit.Pixel);
        }

        public override void DrawCloseButton(CloseButtonRendererEventArgs args)
        {
            if (args.IsDown)
                Draw3DBorder(args.Graphics, args.Bounds, ColorTable.DarkKeysBrush, ColorTable.LightKeysBrush);
            else
                Draw3DBorder(args.Graphics, args.Bounds, ColorTable.LightKeysBrush, ColorTable.DarkKeysBrush);

            Rectangle rect = args.Bounds;
            rect.Inflate(-5, -5);

            using (Pen p = new Pen(ColorTable.TextBrush, 2))
            {
                args.Graphics.DrawLine(p, rect.Left, rect.Top, rect.Right, rect.Bottom);
                args.Graphics.DrawLine(p, rect.Left, rect.Bottom, rect.Right, rect.Top);
            }
        }

        TextShadow tShadow = new TextShadow();
        public override void DrawKey(KeyRendererEventArgs args)
        {
            tShadow.Radius = 1;
            tShadow.Distance = 2;
            tShadow.Alpha = 146;
            Graphics g = args.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.White);
            //Rectangle keyBackBounds = args.Bounds;
            //Rectangle keyBackBounds = new Rectangle(args.Bounds.X, args.Bounds.Y, args.Bounds.Width + 4, args.Bounds.Height + 4);
            Rectangle keyBackBounds = (args.Key.Info != "{BACKSPACE}") ? new Rectangle(args.Bounds.X, args.Bounds.Y, args.Bounds.Width + 4, args.Bounds.Height + 4) : new Rectangle(args.Bounds.X, args.Bounds.Y, args.Bounds.Width + 4, args.Bounds.Height + 4);
            //keyBackBounds.Inflate(2, 2);
            Rectangle keyTextBounds = args.Bounds;
            keyTextBounds.Inflate(2, 2);
            keyTextBounds.Offset(-3, 0);

            if (args.Key.Info != "{BACKSPACE}")
            {
                if (args.IsDown || args.Key.Style == KeyStyle.Pressed || args.Key.Style == KeyStyle.Toggled)
                {
                    g.DrawImage(Properties.Resources.back_keyboard_number_down, keyBackBounds, new Rectangle(0, 0, Properties.Resources.back_keyboard_number_down.Width, Properties.Resources.back_keyboard_number_down.Height), GraphicsUnit.Pixel);
                    if (args.Key.Style == KeyStyle.Toggled)
                    {
                        tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                        g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                    }
                    else
                    {
                        keyTextBounds.Offset(1, 1);
                        tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                        g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                    }
                }
                else
                {
                    g.DrawImage(Properties.Resources.back_keyboard_number, keyBackBounds, new Rectangle(0, 0, Properties.Resources.back_keyboard_number.Width, Properties.Resources.back_keyboard_number.Height), GraphicsUnit.Pixel);
                    tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                    g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                }
            }
            else
            {
                keyTextBounds.Offset(10, 0);
                if (args.IsDown || args.Key.Style == KeyStyle.Pressed || args.Key.Style == KeyStyle.Toggled)
                {
                    g.DrawImage(Properties.Resources.back_keyboard_delate_down, keyBackBounds, new Rectangle(0, 0, Properties.Resources.back_keyboard_delate_down.Width, Properties.Resources.back_keyboard_delate_down.Height), GraphicsUnit.Pixel);
                    if (args.Key.Style == KeyStyle.Toggled)
                    {
                        tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                        g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                    }
                    else
                    {
                        keyTextBounds.Offset(1, 1);
                        tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                        g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                    }
                }
                else
                {
                    g.DrawImage(Properties.Resources.back_keyboard_delate, keyBackBounds, new Rectangle(0, 0, Properties.Resources.back_keyboard_delate.Width, Properties.Resources.back_keyboard_delate.Height), GraphicsUnit.Pixel);
                    tShadow.Draw(g, args.Key.Caption, _Font, keyTextBounds, _Format);
                    g.DrawString(args.Key.Caption, _Font, brush2, keyTextBounds, _Format);
                }

            }

            brush.Dispose();
            brush2.Dispose();
        }

        public override void DrawTopBar(TopBarRendererEventArgs args)
        {
            args.Graphics.DrawString(args.Text, _Font, ColorTable.TopBarTextBrush, args.Bounds);
        }

        private static void Draw3DBorder(Graphics g, Rectangle bounds, Brush light, Brush dark)
        {
            int borderSize = 1;
            Pen lpen = new Pen(light, borderSize);
            Pen dpen = new Pen(dark, borderSize * 2);
            g.DrawRectangle(lpen, bounds);
            g.DrawLine(lpen, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
            g.DrawLine(lpen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
            g.DrawLine(dpen, bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom);
            g.DrawLine(dpen, bounds.Right, bounds.Bottom, bounds.Right, bounds.Top);
        }
    }
}
