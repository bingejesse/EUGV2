namespace SC.View2
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.panelBLeft = new System.Windows.Forms.Panel();
            this.labelScenesMessage = new System.Windows.Forms.Label();
            this.labelCountdown = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelBR = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.timerSceneInfo = new System.Windows.Forms.Timer(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.panel_count = new System.Windows.Forms.Panel();
            this.ad1 = new GBY.ad();
            this.panelButtom.SuspendLayout();
            this.panelBLeft.SuspendLayout();
            this.panelBR.SuspendLayout();
            this.panel_count.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtom
            // 
            this.panelButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelButtom.BackgroundImage = global::SC.View2.Properties.Resources.background_bottom;
            this.panelButtom.Controls.Add(this.panel_count);
            this.panelButtom.Controls.Add(this.panelBLeft);
            this.panelButtom.Controls.Add(this.panelBR);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(0, 648);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(1024, 120);
            this.panelButtom.TabIndex = 0;
            // 
            // panelBLeft
            // 
            this.panelBLeft.BackgroundImage = global::SC.View2.Properties.Resources.background_panel_left_big;
            this.panelBLeft.Controls.Add(this.labelScenesMessage);
            this.panelBLeft.Controls.Add(this.labelMessage);
            this.panelBLeft.Location = new System.Drawing.Point(12, 6);
            this.panelBLeft.Name = "panelBLeft";
            this.panelBLeft.Size = new System.Drawing.Size(545, 108);
            this.panelBLeft.TabIndex = 0;
            // 
            // labelScenesMessage
            // 
            this.labelScenesMessage.Font = new System.Drawing.Font("方正中倩简体", 24F);
            this.labelScenesMessage.ForeColor = System.Drawing.Color.Red;
            this.labelScenesMessage.Location = new System.Drawing.Point(3, 1);
            this.labelScenesMessage.Name = "labelScenesMessage";
            this.labelScenesMessage.Size = new System.Drawing.Size(435, 38);
            this.labelScenesMessage.TabIndex = 3;
            this.labelScenesMessage.Text = "<<系统提示信息>>";
            this.labelScenesMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCountdown
            // 
            this.labelCountdown.BackColor = System.Drawing.Color.Transparent;
            this.labelCountdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCountdown.Font = new System.Drawing.Font("方正中倩简体", 42F);
            this.labelCountdown.Location = new System.Drawing.Point(0, 0);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(132, 108);
            this.labelCountdown.TabIndex = 1;
            this.labelCountdown.Text = "60";
            this.labelCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("方正中倩简体", 24F);
            this.labelMessage.Location = new System.Drawing.Point(0, 39);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1041, 38);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "天气预报。。。。天气预报。。。。天气预报。。。。天气预报。。。。";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBR
            // 
            this.panelBR.BackgroundImage = global::SC.View2.Properties.Resources.background_panel_right;
            this.panelBR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBR.Controls.Add(this.ad1);
            this.panelBR.Location = new System.Drawing.Point(705, 6);
            this.panelBR.Name = "panelBR";
            this.panelBR.Size = new System.Drawing.Size(307, 108);
            this.panelBR.TabIndex = 4;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.BackgroundImage = global::SC.View2.Properties.Resources.bg;
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1024, 648);
            this.panelCenter.TabIndex = 1;
            // 
            // timerSceneInfo
            // 
            this.timerSceneInfo.Interval = 500;
            this.timerSceneInfo.Tick += new System.EventHandler(this.timerSceneInfo_Tick);
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // panel_count
            // 
            this.panel_count.BackgroundImage = global::SC.View2.Properties.Resources.background_panel;
            this.panel_count.Controls.Add(this.labelCountdown);
            this.panel_count.Location = new System.Drawing.Point(565, 6);
            this.panel_count.Name = "panel_count";
            this.panel_count.Size = new System.Drawing.Size(132, 108);
            this.panel_count.TabIndex = 5;
            // 
            // ad1
            // 
            this.ad1.BackColor = System.Drawing.Color.Transparent;
            this.ad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ad1.Location = new System.Drawing.Point(0, 0);
            this.ad1.Name = "ad1";
            this.ad1.Size = new System.Drawing.Size(307, 108);
            this.ad1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelButtom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主页";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelButtom.ResumeLayout(false);
            this.panelBLeft.ResumeLayout(false);
            this.panelBLeft.PerformLayout();
            this.panelBR.ResumeLayout(false);
            this.panel_count.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelCountdown;
        private System.Windows.Forms.Timer timerSceneInfo;
        private System.Windows.Forms.Label labelScenesMessage;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Panel panelBR;
        private System.Windows.Forms.Panel panelBLeft;
        private System.Windows.Forms.Panel panel_count;
        private GBY.ad ad1;
    }
}

