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
    public partial class UCSceneBasic : UserControl
    {
        protected string key = "";

        protected FrmMain frmMain;

        public int RemainTime{get;set;}

        /// <summary>
        /// 本页最长停留时间
        /// </summary>
        public int Countdown{get;set;}

        public UCSceneBasic()
        {
            InitializeComponent();
        }

        public UCSceneBasic(FrmMain frmMain)
            : this()
        {
            this.frmMain = frmMain;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= ~0x02000000;//Turn off WS_EX_CLIPCHILDREN
                return cp;
            }
        }

        public virtual void Start(params object[] args)
        {
            this.RemainTime = Countdown;
            this.timerCountdown.Enabled = true;
            this.timerCountdown.Start();
        }

        public virtual void Stop()
        {
            this.timerCountdown.Enabled = false;
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            RemainTime -= 1;
            if (RemainTime <= 0)
            {
                RemainTime = 0;
                this.timerCountdown.Enabled = false;
                this.frmMain.SceneTransit("Home");
            }

        }
    }
}
