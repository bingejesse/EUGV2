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
    public partial class savePackageSuccess : UserControl
    {
        public savePackageSuccess()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        public void setInfo(string tel, string tNum, string cNum)
        {
            consigneeTel.Text = tel;
            trackingNum.Text = tNum;
            courierNum.Text = cNum;
        }

        public void errorMessage(string str)
        {
        }
    }
}
