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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelButtom = new System.Windows.Forms.Panel();
            this.panelQR = new System.Windows.Forms.Panel();
            this.labelCountdown = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.timerSceneInfo = new System.Windows.Forms.Timer(this.components);
            this.labelScenesMessage = new System.Windows.Forms.Label();
            this.panelButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtom
            // 
            this.panelButtom.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelButtom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtom.Controls.Add(this.labelScenesMessage);
            this.panelButtom.Controls.Add(this.panelQR);
            this.panelButtom.Controls.Add(this.labelCountdown);
            this.panelButtom.Controls.Add(this.labelMessage);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(0, 668);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(1024, 100);
            this.panelButtom.TabIndex = 0;
            // 
            // panelQR
            // 
            this.panelQR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelQR.BackgroundImage")));
            this.panelQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelQR.Location = new System.Drawing.Point(939, 9);
            this.panelQR.Name = "panelQR";
            this.panelQR.Size = new System.Drawing.Size(80, 80);
            this.panelQR.TabIndex = 2;
            this.panelQR.Click += new System.EventHandler(this.panelQR_Click);
            // 
            // labelCountdown
            // 
            this.labelCountdown.BackColor = System.Drawing.Color.LightGray;
            this.labelCountdown.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCountdown.Location = new System.Drawing.Point(486, 24);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(50, 50);
            this.labelCountdown.TabIndex = 1;
            this.labelCountdown.Text = "60";
            this.labelCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCountdown.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMessage.Location = new System.Drawing.Point(3, 37);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1018, 38);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "天气预报。。。。";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1024, 668);
            this.panelCenter.TabIndex = 1;
            // 
            // timerSceneInfo
            // 
            this.timerSceneInfo.Interval = 500;
            this.timerSceneInfo.Tick += new System.EventHandler(this.timerSceneInfo_Tick);
            // 
            // labelScenesMessage
            // 
            this.labelScenesMessage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScenesMessage.ForeColor = System.Drawing.Color.Red;
            this.labelScenesMessage.Location = new System.Drawing.Point(22, 30);
            this.labelScenesMessage.Name = "labelScenesMessage";
            this.labelScenesMessage.Size = new System.Drawing.Size(435, 38);
            this.labelScenesMessage.TabIndex = 3;
            this.labelScenesMessage.Text = "<<系统提示信息>>";
            this.labelScenesMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelCountdown;
        private System.Windows.Forms.Timer timerSceneInfo;
        private System.Windows.Forms.Panel panelQR;
        private System.Windows.Forms.Label labelScenesMessage;
    }
}

