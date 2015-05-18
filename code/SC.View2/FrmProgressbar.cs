using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Service.Factory;

namespace SC.View2
{
    public partial class FrmProgressbar : Form
    {
        public FrmProgressbar()
        {
            InitializeComponent();
        }

        Form frmMain;
        public FrmProgressbar(Form frmMain):this()
        {
            this.frmMain = frmMain;
            this.Size = this.frmMain.Size;
            this.circularProgress.IsRunning = true;
        }
    }
}
