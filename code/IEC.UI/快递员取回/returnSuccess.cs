using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEC.UI
{
    public partial class returnSuccess : UserControl
    {
        public returnSuccess()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
        }
        public void setInfo(string str)
        {
            packageAdress.Text = str;
        }

        public void errorMessage(string str)
        {
            errMsg.Text = str;
        }
    }
}
