namespace IEC.UI
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.url = new DevComponents.DotNetBar.LabelX();
            this.tel = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.Countdown = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonXHome = new DevComponents.DotNetBar.ButtonX();
            this.returnToMainfrm = new DevComponents.DotNetBar.ButtonX();
            this.labelXInfo = new DevComponents.DotNetBar.LabelX();
            this.timerNav = new System.Windows.Forms.Timer(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.savePackageSuccess1 = new IEC.UI.savePackageSuccess();
            this.getHelpInfo1 = new IEC.UI.getHelpInfo();
            this.superManager1 = new IEC.UI.superManager();
            this.getHelp1 = new IEC.UI.getHelp();
            this.returnSuccess1 = new IEC.UI.returnSuccess();
            this.returnScanTN1 = new IEC.UI.returnScanTN();
            this.returnIDPwd1 = new IEC.UI.returnIDPwd();
            this.returnICID1 = new IEC.UI.returnICID();
            this.confirmConsigneeTel1 = new IEC.UI.confirmConsigneeTel();
            this.inputConsigneeTel1 = new IEC.UI.inputConsigneeTel();
            this.chooseBox1 = new IEC.UI.chooseBox();
            this.scanTrackingNum1 = new IEC.UI.scanTrackingNum();
            this.inputCourierPwd1 = new IEC.UI.inputCourierPwd();
            this.inputCourierID1 = new IEC.UI.inputCourierID();
            this.getPackageSuccess1 = new IEC.UI.getPackageSuccess();
            this.inputPwdPanel1 = new IEC.UI.InputPwdPanel();
            this.mainPanel1 = new IEC.UI.mainPanel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.labelX3);
            this.topPanel.Controls.Add(this.url);
            this.topPanel.Controls.Add(this.tel);
            this.topPanel.Controls.Add(this.labelX2);
            this.topPanel.Controls.Add(this.labelX1);
            this.topPanel.Controls.Add(this.logoPic);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1024, 100);
            this.topPanel.TabIndex = 0;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(218, 21);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(184, 32);
            this.labelX3.TabIndex = 109;
            this.labelX3.Text = "德瑞纳智能快递柜";
            // 
            // url
            // 
            this.url.AutoSize = true;
            // 
            // 
            // 
            this.url.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.url.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.url.ForeColor = System.Drawing.Color.White;
            this.url.Location = new System.Drawing.Point(790, 58);
            this.url.MaximumSize = new System.Drawing.Size(500, 0);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(148, 32);
            this.url.TabIndex = 108;
            this.url.Text = "www.163.com";
            // 
            // tel
            // 
            this.tel.AutoSize = true;
            // 
            // 
            // 
            this.tel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tel.ForeColor = System.Drawing.Color.White;
            this.tel.Location = new System.Drawing.Point(832, 20);
            this.tel.MaximumSize = new System.Drawing.Size(500, 0);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(147, 32);
            this.tel.TabIndex = 107;
            this.tel.Text = "400-881-6878";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(718, 59);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 32);
            this.labelX2.TabIndex = 106;
            this.labelX2.Text = "网址：";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(718, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(108, 32);
            this.labelX1.TabIndex = 105;
            this.labelX1.Text = "客服热线：";
            // 
            // logoPic
            // 
            this.logoPic.Location = new System.Drawing.Point(12, 12);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(200, 50);
            this.logoPic.TabIndex = 4;
            this.logoPic.TabStop = false;
            // 
            // Countdown
            // 
            this.Countdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Countdown.AutoSize = true;
            this.Countdown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Countdown.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Countdown.ForeColor = System.Drawing.Color.White;
            this.Countdown.Location = new System.Drawing.Point(504, 33);
            this.Countdown.Name = "Countdown";
            this.Countdown.Size = new System.Drawing.Size(66, 48);
            this.Countdown.TabIndex = 3;
            this.Countdown.Text = "60";
            this.Countdown.Visible = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.bottomPanel.Controls.Add(this.buttonXHome);
            this.bottomPanel.Controls.Add(this.Countdown);
            this.bottomPanel.Controls.Add(this.returnToMainfrm);
            this.bottomPanel.Controls.Add(this.labelXInfo);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 668);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1024, 100);
            this.bottomPanel.TabIndex = 1;
            // 
            // buttonXHome
            // 
            this.buttonXHome.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXHome.BackColor = System.Drawing.Color.Gold;
            this.buttonXHome.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonXHome.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXHome.Location = new System.Drawing.Point(66, 33);
            this.buttonXHome.Name = "buttonXHome";
            this.buttonXHome.Size = new System.Drawing.Size(121, 48);
            this.buttonXHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.buttonXHome.Symbol = "";
            this.buttonXHome.TabIndex = 111;
            this.buttonXHome.Text = "主页";
            this.buttonXHome.Visible = false;
            this.buttonXHome.Click += new System.EventHandler(this.buttonXHome_Click);
            // 
            // returnToMainfrm
            // 
            this.returnToMainfrm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.returnToMainfrm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.returnToMainfrm.BackColor = System.Drawing.Color.Gold;
            this.returnToMainfrm.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.returnToMainfrm.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnToMainfrm.Location = new System.Drawing.Point(853, 33);
            this.returnToMainfrm.Name = "returnToMainfrm";
            this.returnToMainfrm.Size = new System.Drawing.Size(121, 48);
            this.returnToMainfrm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.returnToMainfrm.Symbol = "";
            this.returnToMainfrm.TabIndex = 102;
            this.returnToMainfrm.Text = "返回";
            this.returnToMainfrm.Visible = false;
            this.returnToMainfrm.Click += new System.EventHandler(this.returnToMainfrm_Click);
            // 
            // labelXInfo
            // 
            this.labelXInfo.AutoSize = true;
            // 
            // 
            // 
            this.labelXInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInfo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInfo.ForeColor = System.Drawing.Color.White;
            this.labelXInfo.Location = new System.Drawing.Point(106, 32);
            this.labelXInfo.Name = "labelXInfo";
            this.labelXInfo.Size = new System.Drawing.Size(485, 35);
            this.labelXInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.labelXInfo.TabIndex = 110;
            this.labelXInfo.Text = "欢迎使用德瑞纳智能快递柜，祝您今天生活愉快！";
            // 
            // timerNav
            // 
            this.timerNav.Tick += new System.EventHandler(this.timerNav_Tick);
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // savePackageSuccess1
            // 
            this.savePackageSuccess1.BackColor = System.Drawing.Color.Transparent;
            this.savePackageSuccess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savePackageSuccess1.Location = new System.Drawing.Point(0, 100);
            this.savePackageSuccess1.Name = "savePackageSuccess1";
            this.savePackageSuccess1.Size = new System.Drawing.Size(1024, 568);
            this.savePackageSuccess1.TabIndex = 11;
            // 
            // getHelpInfo1
            // 
            this.getHelpInfo1.BackColor = System.Drawing.Color.Transparent;
            this.getHelpInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getHelpInfo1.Location = new System.Drawing.Point(0, 100);
            this.getHelpInfo1.Name = "getHelpInfo1";
            this.getHelpInfo1.Size = new System.Drawing.Size(1024, 568);
            this.getHelpInfo1.TabIndex = 18;
            // 
            // superManager1
            // 
            this.superManager1.BackColor = System.Drawing.Color.Transparent;
            this.superManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superManager1.Location = new System.Drawing.Point(0, 100);
            this.superManager1.Name = "superManager1";
            this.superManager1.Size = new System.Drawing.Size(1024, 568);
            this.superManager1.TabIndex = 17;
            // 
            // getHelp1
            // 
            this.getHelp1.BackColor = System.Drawing.Color.Transparent;
            this.getHelp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getHelp1.Location = new System.Drawing.Point(0, 100);
            this.getHelp1.Name = "getHelp1";
            this.getHelp1.Size = new System.Drawing.Size(1024, 568);
            this.getHelp1.TabIndex = 16;
            // 
            // returnSuccess1
            // 
            this.returnSuccess1.BackColor = System.Drawing.Color.Transparent;
            this.returnSuccess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnSuccess1.Location = new System.Drawing.Point(0, 100);
            this.returnSuccess1.Name = "returnSuccess1";
            this.returnSuccess1.Size = new System.Drawing.Size(1024, 568);
            this.returnSuccess1.TabIndex = 15;
            // 
            // returnScanTN1
            // 
            this.returnScanTN1.BackColor = System.Drawing.Color.Transparent;
            this.returnScanTN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnScanTN1.Location = new System.Drawing.Point(0, 100);
            this.returnScanTN1.Name = "returnScanTN1";
            this.returnScanTN1.Size = new System.Drawing.Size(1024, 568);
            this.returnScanTN1.TabIndex = 14;
            // 
            // returnIDPwd1
            // 
            this.returnIDPwd1.BackColor = System.Drawing.Color.Transparent;
            this.returnIDPwd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnIDPwd1.Location = new System.Drawing.Point(0, 100);
            this.returnIDPwd1.Name = "returnIDPwd1";
            this.returnIDPwd1.Size = new System.Drawing.Size(1024, 568);
            this.returnIDPwd1.TabIndex = 13;
            // 
            // returnICID1
            // 
            this.returnICID1.BackColor = System.Drawing.Color.Transparent;
            this.returnICID1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnICID1.Location = new System.Drawing.Point(0, 100);
            this.returnICID1.Name = "returnICID1";
            this.returnICID1.Size = new System.Drawing.Size(1024, 568);
            this.returnICID1.TabIndex = 12;
            // 
            // confirmConsigneeTel1
            // 
            this.confirmConsigneeTel1.BackColor = System.Drawing.Color.Transparent;
            this.confirmConsigneeTel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmConsigneeTel1.Location = new System.Drawing.Point(0, 100);
            this.confirmConsigneeTel1.Name = "confirmConsigneeTel1";
            this.confirmConsigneeTel1.Size = new System.Drawing.Size(1024, 568);
            this.confirmConsigneeTel1.TabIndex = 10;
            // 
            // inputConsigneeTel1
            // 
            this.inputConsigneeTel1.BackColor = System.Drawing.Color.Transparent;
            this.inputConsigneeTel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputConsigneeTel1.Location = new System.Drawing.Point(0, 100);
            this.inputConsigneeTel1.Name = "inputConsigneeTel1";
            this.inputConsigneeTel1.Size = new System.Drawing.Size(1024, 568);
            this.inputConsigneeTel1.TabIndex = 9;
            // 
            // chooseBox1
            // 
            this.chooseBox1.BackColor = System.Drawing.Color.Transparent;
            this.chooseBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseBox1.Location = new System.Drawing.Point(0, 100);
            this.chooseBox1.Name = "chooseBox1";
            this.chooseBox1.Size = new System.Drawing.Size(1024, 568);
            this.chooseBox1.TabIndex = 8;
            // 
            // scanTrackingNum1
            // 
            this.scanTrackingNum1.BackColor = System.Drawing.Color.Transparent;
            this.scanTrackingNum1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scanTrackingNum1.Location = new System.Drawing.Point(0, 100);
            this.scanTrackingNum1.Name = "scanTrackingNum1";
            this.scanTrackingNum1.Size = new System.Drawing.Size(1024, 568);
            this.scanTrackingNum1.TabIndex = 7;
            // 
            // inputCourierPwd1
            // 
            this.inputCourierPwd1.BackColor = System.Drawing.Color.Transparent;
            this.inputCourierPwd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputCourierPwd1.Location = new System.Drawing.Point(0, 100);
            this.inputCourierPwd1.Name = "inputCourierPwd1";
            this.inputCourierPwd1.Size = new System.Drawing.Size(1024, 568);
            this.inputCourierPwd1.TabIndex = 6;
            // 
            // inputCourierID1
            // 
            this.inputCourierID1.BackColor = System.Drawing.Color.Transparent;
            this.inputCourierID1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputCourierID1.Location = new System.Drawing.Point(0, 100);
            this.inputCourierID1.Name = "inputCourierID1";
            this.inputCourierID1.Size = new System.Drawing.Size(1024, 568);
            this.inputCourierID1.TabIndex = 5;
            // 
            // getPackageSuccess1
            // 
            this.getPackageSuccess1.BackColor = System.Drawing.Color.Transparent;
            this.getPackageSuccess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getPackageSuccess1.Location = new System.Drawing.Point(0, 100);
            this.getPackageSuccess1.Name = "getPackageSuccess1";
            this.getPackageSuccess1.Size = new System.Drawing.Size(1024, 568);
            this.getPackageSuccess1.TabIndex = 4;
            // 
            // inputPwdPanel1
            // 
            this.inputPwdPanel1.BackColor = System.Drawing.Color.Transparent;
            this.inputPwdPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPwdPanel1.Location = new System.Drawing.Point(0, 100);
            this.inputPwdPanel1.Name = "inputPwdPanel1";
            this.inputPwdPanel1.Size = new System.Drawing.Size(1024, 568);
            this.inputPwdPanel1.TabIndex = 3;
            // 
            // mainPanel1
            // 
            this.mainPanel1.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel1.Location = new System.Drawing.Point(0, 100);
            this.mainPanel1.Name = "mainPanel1";
            this.mainPanel1.Size = new System.Drawing.Size(1024, 568);
            this.mainPanel1.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.savePackageSuccess1);
            this.Controls.Add(this.getHelpInfo1);
            this.Controls.Add(this.superManager1);
            this.Controls.Add(this.getHelp1);
            this.Controls.Add(this.returnSuccess1);
            this.Controls.Add(this.returnScanTN1);
            this.Controls.Add(this.returnIDPwd1);
            this.Controls.Add(this.returnICID1);
            this.Controls.Add(this.confirmConsigneeTel1);
            this.Controls.Add(this.inputConsigneeTel1);
            this.Controls.Add(this.chooseBox1);
            this.Controls.Add(this.scanTrackingNum1);
            this.Controls.Add(this.inputCourierPwd1);
            this.Controls.Add(this.inputCourierID1);
            this.Controls.Add(this.getPackageSuccess1);
            this.Controls.Add(this.inputPwdPanel1);
            this.Controls.Add(this.mainPanel1);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能快递柜";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label Countdown;
        private DevComponents.DotNetBar.ButtonX returnToMainfrm;
        private mainPanel mainPanel1;
        private InputPwdPanel inputPwdPanel1;
        private System.Windows.Forms.Timer timerNav;
        private getPackageSuccess getPackageSuccess1;
        private inputCourierID inputCourierID1;
        private inputCourierPwd inputCourierPwd1;
        private scanTrackingNum scanTrackingNum1;
        private chooseBox chooseBox1;
        private inputConsigneeTel inputConsigneeTel1;
        private confirmConsigneeTel confirmConsigneeTel1;
        private savePackageSuccess savePackageSuccess1;
        private returnICID returnICID1;
        private returnIDPwd returnIDPwd1;
        private returnScanTN returnScanTN1;
        private returnSuccess returnSuccess1;
        private getHelp getHelp1;
        private superManager superManager1;
        private System.Windows.Forms.PictureBox logoPic;
        private getHelpInfo getHelpInfo1;
        private DevComponents.DotNetBar.LabelX url;
        private DevComponents.DotNetBar.LabelX tel;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelXInfo;
        private DevComponents.DotNetBar.ButtonX buttonXHome;
        private System.Windows.Forms.Timer timerMain;



    }
}

