using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Keyboard;
using System.Drawing;

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
            using (Brush brush = new SolidBrush(Color.White))
            {
                //brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                args.Graphics.FillRectangle(brush, args.Bounds);
                Draw3DBorder(args.Graphics, args.Bounds, ColorTable.DarkKeysBrush, ColorTable.LightKeysBrush);
            }
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

        public override void DrawKey(KeyRendererEventArgs args)
        {
            /**
             * 调背景色和字体颜色
             * */
            SolidBrush brush = new SolidBrush(SystemColors.Control);
            SolidBrush brush2 = new SolidBrush(Color.Black);
            SolidBrush brush3 = new SolidBrush(Color.Orange);
            Rectangle keyBounds = args.Bounds;
            args.Graphics.FillRectangle(brush, keyBounds);

            if (args.IsDown || args.Key.Style == KeyStyle.Pressed || args.Key.Style == KeyStyle.Toggled)
            {
                Draw3DBorder(args.Graphics, keyBounds, ColorTable.DarkKeysBrush, ColorTable.LightKeysBrush);
                keyBounds.Offset(1, 1);
                args.Graphics.FillRectangle(brush3, keyBounds);
                if (args.Key.Style == KeyStyle.Toggled)
                    args.Graphics.DrawString(args.Key.Caption, _Font, brush2, keyBounds, _Format);
                else
                    args.Graphics.DrawString(args.Key.Caption, _Font, brush2, keyBounds, _Format);
            }
            else
            {
                args.Graphics.FillRectangle(brush, keyBounds);
                Draw3DBorder(args.Graphics, keyBounds, ColorTable.LightKeysBrush, ColorTable.DarkKeysBrush);
                args.Graphics.DrawString(args.Key.Caption, _Font, brush2, keyBounds, _Format);
            }

            brush.Dispose();
            brush2.Dispose();
            brush3.Dispose();
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
