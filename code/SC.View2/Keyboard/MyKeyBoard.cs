using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC.View2
{
    public partial class MyKeyBoard : DevComponents.DotNetBar.Keyboard.KeyboardControl
    {
        public MyKeyBoard()
        {
            InitializeComponent();
            //base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.Opaque, false);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

    }
}
