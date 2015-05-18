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
            this.buttonHome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.password.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.password.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(256, 133);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(170, 74);
            this.password.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.password.TabIndex = 3;
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
            this.labelXServer.Location = new System.Drawing.Point(42, 149);
            this.labelXServer.Name = "labelXServer";
            this.labelXServer.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXServer.Size = new System.Drawing.Size(185, 45);
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
            this.labelXCamare.Location = new System.Drawing.Point(42, 91);
            this.labelXCamare.Name = "labelXCamare";
            this.labelXCamare.SingleLineColor = System.Drawing.Color.MidnightBlue;
            this.labelXCamare.Size = new System.Drawing.Size(185, 45);
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
            this.labelXCan.Location = new System.Drawing.Point(42, 33);
            this.labelXCan.Name = "labelXCan";
            this.labelXCan.SingleLineColor = System.Drawing.Color.Black;
            this.labelXCan.Size = new System.Drawing.Size(185, 45);
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
            this.buttonExit.Location = new System.Drawing.Point(57, 231);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(170, 74);
            this.buttonExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "退出系统";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUpdate.Location = new System.Drawing.Point(57, 133);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(170, 74);
            this.buttonUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "检测更新";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonXReboot
            // 
            this.buttonXReboot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXReboot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXReboot.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXReboot.Location = new System.Drawing.Point(256, 231);
            this.buttonXReboot.Name = "buttonXReboot";
            this.buttonXReboot.Size = new System.Drawing.Size(170, 74);
            this.buttonXReboot.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXReboot.TabIndex = 5;
            this.buttonXReboot.Text = "重启";
            this.buttonXReboot.Click += new System.EventHandler(this.buttonXReboot_Click);
            // 
            // manager
            // 
            this.manager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.manager.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.manager.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manager.Location = new System.Drawing.Point(256, 30);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(170, 74);
            this.manager.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.manager.TabIndex = 1;
            this.manager.Text = "管理智能柜";
            this.manager.Click += new System.EventHandler(this.manager_Click);
            // 
            // config
            // 
            this.config.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.config.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.config.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.config.Location = new System.Drawing.Point(57, 30);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(170, 74);
            this.config.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.config.TabIndex = 0;
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
            this.circularProgressUpdate.Location = new System.Drawing.Point(114, 360);
            this.circularProgressUpdate.Name = "circularProgressUpdate";
            this.circularProgressUpdate.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgressUpdate.ProgressColor = System.Drawing.Color.Salmon;
            this.circularProgressUpdate.Size = new System.Drawing.Size(50, 50);
            this.circularProgressUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressUpdate.TabIndex = 21;
            this.circularProgressUpdate.Value = 100;
            // 
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdate_RunWorkerCompleted);
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
            this.createdTime.Location = new System.Drawing.Point(42, 153);
            this.createdTime.Name = "createdTime";
            this.createdTime.PreventEnterBeep = true;
            this.createdTime.ReadOnly = true;
            this.createdTime.Size = new System.Drawing.Size(185, 35);
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
            this.code.Location = new System.Drawing.Point(42, 71);
            this.code.Name = "code";
            this.code.PreventEnterBeep = true;
            this.code.ReadOnly = true;
            this.code.ShortcutsEnabled = false;
            this.code.Size = new System.Drawing.Size(185, 35);
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
            this.labelX6.Location = new System.Drawing.Point(42, 112);
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
            this.labelX1.Location = new System.Drawing.Point(42, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(139, 35);
            this.labelX1.TabIndex = 32;
            this.labelX1.Text = "快递柜编号：";
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(256, 343);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(170, 67);
            this.buttonHome.TabIndex = 6;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelXCan);
            this.groupBox1.Controls.Add(this.labelXCamare);
            this.groupBox1.Controls.Add(this.labelXServer);
            this.groupBox1.Location = new System.Drawing.Point(97, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 217);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统状态";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.config);
            this.groupBox2.Controls.Add(this.buttonHome);
            this.groupBox2.Controls.Add(this.manager);
            this.groupBox2.Controls.Add(this.buttonXReboot);
            this.groupBox2.Controls.Add(this.buttonUpdate);
            this.groupBox2.Controls.Add(this.circularProgressUpdate);
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Location = new System.Drawing.Point(454, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 460);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能项";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelX1);
            this.groupBox3.Controls.Add(this.labelX6);
            this.groupBox3.Controls.Add(this.code);
            this.groupBox3.Controls.Add(this.createdTime);
            this.groupBox3.Location = new System.Drawing.Point(97, 405);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 231);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "系统信息";
            // 
            // AdministratorControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdministratorControlPanel";
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
