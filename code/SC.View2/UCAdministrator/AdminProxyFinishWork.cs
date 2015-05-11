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
    public partial class AdminProxyFinishWork : UCSceneWithInfoBasic
    {
        public AdminProxyFinishWork()
        {
            InitializeComponent();
        }

        public AdminProxyFinishWork(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        public override void Start(params object[] args)
        {
            base.Start();
            base.labelMessage.Text = "提示信息：请注意XX箱门已弹出，请取回快件并关闭箱门";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.A_P_EntryBoxCode);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.frmMain.SceneTransit(Roster.Home);
        }
    }
}
