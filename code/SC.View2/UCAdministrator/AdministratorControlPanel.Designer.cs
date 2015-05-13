namespace SC.View2
{
    partial class AdministratorControlPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.password = new DevComponents.DotNetBar.ButtonX();
            this.labelXServer = new DevComponents.DotNetBar.LabelX();
            this.labelXCamare = new DevComponents.DotNetBar.LabelX();
            this.labelXCan = new DevComponents.DotNetBar.LabelX();
            this.buttonExit = new DevComponents.DotNetBar.ButtonX();
            this.buttonUpdate = new DevComponents.DotNetBar.ButtonX();
            this.buttonXReboot = new DevComponents.DotNetBar.ButtonX();
            this.manager = new DevComponents.DotNetBar.ButtonX();
            this.config = new DevComponents.DotNetBar.ButtonX();
            this.circularProgressUpdate = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.createdTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.password.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.password.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(287, 393);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(133, 74);
            this.password.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.password.TabIndex = 14;
            this.password.Text = "修改密码";
            this.password.Click += new System.EventHandler(this.password_Click);
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
            this.labelXServer.Location = new System.Drawing.Point(591, 251);
            this.labelXServer.Name = "labelXServer";
            this.labelXServer.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXServer.Size = new System.Drawing.Size(158, 27);
            this.labelXServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXServer.TabIndex = 19;
            this.labelXServer.Text = "服务器连接：异常";
            this.labelXServer.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.labelXCamare.Location = new System.Drawing.Point(431, 251);
            this.labelXCamare.Name = "labelXCamare";
            this.labelXCamare.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXCamare.Size = new System.Drawing.Size(158, 27);
            this.labelXCamare.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXCamare.TabIndex = 18;
            this.labelXCamare.Text = "监控摄像头：正常";
            this.labelXCamare.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.labelXCan.Location = new System.Drawing.Point(271, 251);
            this.labelXCan.Name = "labelXCan";
            this.labelXCan.SingleLineColor = System.Drawing.Color.Black;
            this.labelXCan.Size = new System.Drawing.Size(158, 27);
            this.labelXCan.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelXCan.TabIndex = 17;
            this.labelXCan.Text = "Can控制器：异常";
            this.labelXCan.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonExit
            // 
            this.buttonExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExit.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(440, 393);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(133, 74);
            this.buttonExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonExit.TabIndex = 15;
            this.buttonExit.Text = "退出系统";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUpdate.Location = new System.Drawing.Point(590, 296);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(133, 74);
            this.buttonUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "检测更新";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonXReboot
            // 
            this.buttonXReboot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXReboot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXReboot.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXReboot.Location = new System.Drawing.Point(590, 393);
            this.buttonXReboot.Name = "buttonXReboot";
            this.buttonXReboot.Size = new System.Drawing.Size(133, 74);
            this.buttonXReboot.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXReboot.TabIndex = 16;
            this.buttonXReboot.Text = "重启";
            this.buttonXReboot.Click += new System.EventHandler(this.buttonXReboot_Click);
            // 
            // manager
            // 
            this.manager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.manager.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.manager.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manager.Location = new System.Drawing.Point(440, 296);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(133, 74);
            this.manager.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.manager.TabIndex = 12;
            this.manager.Text = "管理智能柜";
            this.manager.Click += new System.EventHandler(this.manager_Click);
            // 
            // config
            // 
            this.config.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.config.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.config.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.config.Location = new System.Drawing.Point(287, 296);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(133, 74);
            this.config.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.config.TabIndex = 11;
            this.config.Text = "配置智能柜";
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // circularProgressUpdate
            // 
            this.circularProgressUpdate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgressUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressUpdate.FocusCuesEnabled = false;
            this.circularProgressUpdate.Location = new System.Drawing.Point(472, 498);
            this.circularProgressUpdate.Name = "circularProgressUpdate";
            this.circularProgressUpdate.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgressUpdate.ProgressColor = System.Drawing.Color.Salmon;
            this.circularProgressUpdate.Size = new System.Drawing.Size(50, 50);
            this.circularProgressUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressUpdate.TabIndex = 21;
            this.circularProgressUpdate.Value = 100;
            // 
            // createdTime
            // 
            this.createdTime.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.createdTime.Border.Class = "TextBoxBorder";
            this.createdTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.createdTime.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.createdTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createdTime.Location = new System.Drawing.Point(678, 605);
            this.createdTime.Name = "createdTime";
            this.createdTime.PreventEnterBeep = true;
            this.createdTime.ReadOnly = true;
            this.createdTime.Size = new System.Drawing.Size(232, 35);
            this.createdTime.TabIndex = 35;
            this.createdTime.TabStop = false;
            this.createdTime.Text = "2014.7.25";
            // 
            // code
            // 
            this.code.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.code.Border.Class = "TextBoxBorder";
            this.code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.code.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.code.Location = new System.Drawing.Point(256, 603);
            this.code.Name = "code";
            this.code.PreventEnterBeep = true;
            this.code.ReadOnly = true;
            this.code.ShortcutsEnabled = false;
            this.code.Size = new System.Drawing.Size(232, 35);
            this.code.TabIndex = 34;
            this.code.TabStop = false;
            this.code.Text = "A0001";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(533, 603);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(118, 35);
            this.labelX6.TabIndex = 33;
            this.labelX6.Text = "启用时间：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(111, 603);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(139, 35);
            this.labelX1.TabIndex = 32;
            this.labelX1.Text = "快递柜编号：";
            // 
            // AdministratorControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createdTime);
            this.Controls.Add(this.code);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.circularProgressUpdate);
            this.Controls.Add(this.password);
            this.Controls.Add(this.labelXServer);
            this.Controls.Add(this.labelXCamare);
            this.Controls.Add(this.labelXCan);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonXReboot);
            this.Controls.Add(this.manager);
            this.Controls.Add(this.config);
            this.Name = "AdministratorControlPanel";
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.config, 0);
            this.Controls.SetChildIndex(this.manager, 0);
            this.Controls.SetChildIndex(this.buttonXReboot, 0);
            this.Controls.SetChildIndex(this.buttonUpdate, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.labelXCan, 0);
            this.Controls.SetChildIndex(this.labelXCamare, 0);
            this.Controls.SetChildIndex(this.labelXServer, 0);
            this.Controls.SetChildIndex(this.password, 0);
            this.Controls.SetChildIndex(this.circularProgressUpdate, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.code, 0);
            this.Controls.SetChildIndex(this.createdTime, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX password;
        private DevComponents.DotNetBar.LabelX labelXServer;
        private DevComponents.DotNetBar.LabelX labelXCamare;
        private DevComponents.DotNetBar.LabelX labelXCan;
        private DevComponents.DotNetBar.ButtonX buttonExit;
        private DevComponents.DotNetBar.ButtonX buttonUpdate;
        private DevComponents.DotNetBar.ButtonX buttonXReboot;
        private DevComponents.DotNetBar.ButtonX manager;
        private DevComponents.DotNetBar.ButtonX config;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private DevComponents.DotNetBar.Controls.TextBoxX createdTime;
        private DevComponents.DotNetBar.Controls.TextBoxX code;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}
