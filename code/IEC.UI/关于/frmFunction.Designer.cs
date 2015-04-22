namespace IEC.UI
{
    partial class frmFunction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.config = new DevComponents.DotNetBar.ButtonX();
            this.manager = new DevComponents.DotNetBar.ButtonX();
            this.labelXInfo = new DevComponents.DotNetBar.LabelX();
            this.buttonXReboot = new DevComponents.DotNetBar.ButtonX();
            this.buttonUpdate = new DevComponents.DotNetBar.ButtonX();
            this.buttonExit = new DevComponents.DotNetBar.ButtonX();
            this.circularProgressUpdate = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.labelXCan = new DevComponents.DotNetBar.LabelX();
            this.labelXCamare = new DevComponents.DotNetBar.LabelX();
            this.labelXServer = new DevComponents.DotNetBar.LabelX();
            this.password = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // config
            // 
            this.config.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.config.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.config.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.config.Location = new System.Drawing.Point(16, 45);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(133, 74);
            this.config.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.config.TabIndex = 0;
            this.config.Text = "配置智能柜";
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // manager
            // 
            this.manager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.manager.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.manager.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manager.Location = new System.Drawing.Point(169, 45);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(133, 74);
            this.manager.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.manager.TabIndex = 1;
            this.manager.Text = "管理智能柜";
            this.manager.Click += new System.EventHandler(this.manager_Click);
            // 
            // labelXInfo
            // 
            this.labelXInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // 
            // 
            this.labelXInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelXInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInfo.Location = new System.Drawing.Point(0, 249);
            this.labelXInfo.Name = "labelXInfo";
            this.labelXInfo.Size = new System.Drawing.Size(470, 47);
            this.labelXInfo.TabIndex = 7;
            this.labelXInfo.Text = "修改参数后请重启系统";
            this.labelXInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonXReboot
            // 
            this.buttonXReboot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXReboot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXReboot.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXReboot.Location = new System.Drawing.Point(319, 142);
            this.buttonXReboot.Name = "buttonXReboot";
            this.buttonXReboot.Size = new System.Drawing.Size(133, 74);
            this.buttonXReboot.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXReboot.TabIndex = 5;
            this.buttonXReboot.Text = "重启";
            this.buttonXReboot.Click += new System.EventHandler(this.buttonXReboot_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUpdate.Location = new System.Drawing.Point(319, 45);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(133, 74);
            this.buttonUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "检测更新";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExit.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(169, 142);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(133, 74);
            this.buttonExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "退出系统";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // circularProgressUpdate
            // 
            this.circularProgressUpdate.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // 
            // 
            this.circularProgressUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressUpdate.FocusCuesEnabled = false;
            this.circularProgressUpdate.Location = new System.Drawing.Point(414, 249);
            this.circularProgressUpdate.Name = "circularProgressUpdate";
            this.circularProgressUpdate.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgressUpdate.ProgressColor = System.Drawing.Color.White;
            this.circularProgressUpdate.Size = new System.Drawing.Size(38, 47);
            this.circularProgressUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressUpdate.TabIndex = 6;
            this.circularProgressUpdate.Value = 100;
            // 
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdate_RunWorkerCompleted);
            // 
            // labelXCan
            // 
            this.labelXCan.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.labelXCan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXCan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXCan.ForeColor = System.Drawing.Color.White;
            this.labelXCan.Location = new System.Drawing.Point(0, 0);
            this.labelXCan.Name = "labelXCan";
            this.labelXCan.SingleLineColor = System.Drawing.Color.Black;
            this.labelXCan.Size = new System.Drawing.Size(158, 27);
            this.labelXCan.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXCan.TabIndex = 8;
            this.labelXCan.Text = "Can控制器：异常";
            this.labelXCan.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelXCamare
            // 
            this.labelXCamare.BackColor = System.Drawing.Color.Green;
            // 
            // 
            // 
            this.labelXCamare.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXCamare.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXCamare.ForeColor = System.Drawing.Color.White;
            this.labelXCamare.Location = new System.Drawing.Point(160, 0);
            this.labelXCamare.Name = "labelXCamare";
            this.labelXCamare.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXCamare.Size = new System.Drawing.Size(158, 27);
            this.labelXCamare.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXCamare.TabIndex = 9;
            this.labelXCamare.Text = "监控摄像头：正常";
            this.labelXCamare.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelXServer
            // 
            this.labelXServer.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.labelXServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXServer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXServer.ForeColor = System.Drawing.Color.White;
            this.labelXServer.Location = new System.Drawing.Point(320, 0);
            this.labelXServer.Name = "labelXServer";
            this.labelXServer.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXServer.Size = new System.Drawing.Size(158, 27);
            this.labelXServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXServer.TabIndex = 10;
            this.labelXServer.Text = "服务器连接：异常";
            this.labelXServer.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // password
            // 
            this.password.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.password.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.password.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(16, 142);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(133, 74);
            this.password.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.password.TabIndex = 3;
            this.password.Text = "修改密码";
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // frmFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 296);
            this.Controls.Add(this.password);
            this.Controls.Add(this.labelXServer);
            this.Controls.Add(this.labelXCamare);
            this.Controls.Add(this.labelXCan);
            this.Controls.Add(this.circularProgressUpdate);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonXReboot);
            this.Controls.Add(this.labelXInfo);
            this.Controls.Add(this.manager);
            this.Controls.Add(this.config);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFunction";
            this.ShowIcon = false;
            this.Text = "管理员入口";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX config;
        private DevComponents.DotNetBar.ButtonX manager;
        private DevComponents.DotNetBar.LabelX labelXInfo;
        private DevComponents.DotNetBar.ButtonX buttonXReboot;
        private DevComponents.DotNetBar.ButtonX buttonUpdate;
        private DevComponents.DotNetBar.ButtonX buttonExit;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private DevComponents.DotNetBar.LabelX labelXCan;
        private DevComponents.DotNetBar.LabelX labelXCamare;
        private DevComponents.DotNetBar.LabelX labelXServer;
        private DevComponents.DotNetBar.ButtonX password;
    }
}