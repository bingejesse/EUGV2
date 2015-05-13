using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient;

namespace SC.View2
{
    public partial class Home : UCSceneBasic
    {
        public Home()
        {
            InitializeComponent();
        }

        public Home(FrmMain frmMain, int time)
            : this()
        {
            base.frmMain = frmMain;
            base.Countdown = time;
            base.key = this.Name;
        }

        private List<Image> adImages;

        public override void Start(params object[] args)
        {
            base.Start(args);

            adImages = ADManager.GetADImages();

            this.timerAD.Enabled = true;
        }

        public override void Stop()
        {
            base.Stop();
            this.timerAD.Enabled = false;
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.C_ControlPanel);
        }

        private void buttonPostman_Click(object sender, EventArgs e)
        {
            frmMain.SceneTransit(Roster.P_ControlPanel);
        }

        int index = 0;

        private void timerAD_Tick(object sender, EventArgs e)
        {
            int tempIndex = adImages.Count;

            if (tempIndex == 0)
            {
                return;
            }

            this.ad.BackgroundImage = this.adImages[index%tempIndex];

            index++;
        }
    }
}
