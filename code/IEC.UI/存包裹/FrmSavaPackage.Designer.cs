namespace IEC.UI
{
    partial class FrmSavaPackage
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
            this.components = new System.ComponentModel.Container();
            this.buttonXYes = new DevComponents.DotNetBar.ButtonX();
            this.buttonXNo = new DevComponents.DotNetBar.ButtonX();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelXInfo = new DevComponents.DotNetBar.LabelX();
            this.Countdown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonXYes
            // 
            this.buttonXYes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXYes.BackColor = System.Drawing.Color.Orange;
            this.buttonXYes.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXYes.Location = new System.Drawing.Point(223, 123);
            this.buttonXYes.Name = "buttonXYes";
            this.buttonXYes.Size = new System.Drawing.Size(571, 127);
            this.buttonXYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXYes.Symbol = "";
            this.buttonXYes.SymbolSize = 30F;
            this.buttonXYes.TabIndex = 0;
            this.buttonXYes.Text = "扫描快递号";
            this.buttonXYes.Click += new System.EventHandler(this.buttonXYes_Click);
            // 
            // buttonXNo
            // 
            this.buttonXNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXNo.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXNo.Location = new System.Drawing.Point(223, 281);
            this.buttonXNo.Name = "buttonXNo";
            this.buttonXNo.Size = new System.Drawing.Size(571, 127);
            this.buttonXNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXNo.Symbol = "";
            this.buttonXNo.SymbolSize = 30F;
            this.buttonXNo.TabIndex = 1;
            this.buttonXNo.Text = "取消存件";
            this.buttonXNo.Click += new System.EventHandler(this.buttonXNo_Click);
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.BackColor = System.Drawing.Color.Orange;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXCancel.Location = new System.Drawing.Point(223, 439);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Size = new System.Drawing.Size(571, 127);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXCancel.Symbol = "";
            this.buttonXCancel.SymbolSize = 30F;
            this.buttonXCancel.TabIndex = 2;
            this.buttonXCancel.Text = "重选柜子";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // labelXInfo
            // 
            this.labelXInfo.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.labelXInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelXInfo.Font = new System.Drawing.Font("宋体", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInfo.Location = new System.Drawing.Point(0, 616);
            this.labelXInfo.Name = "labelXInfo";
            this.labelXInfo.Size = new System.Drawing.Size(1024, 144);
            this.labelXInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelXInfo.TabIndex = 1;
            this.labelXInfo.Text = "<div align=\"center\">您选的柜门是<b><font size=\"+15\" color=\"red\">11</font></b>号，还有3次重选机会" +
                "</div>";
            this.labelXInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Countdown
            // 
            this.Countdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Countdown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Countdown.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Countdown.ForeColor = System.Drawing.Color.White;
            this.Countdown.Location = new System.Drawing.Point(864, 37);
            this.Countdown.Name = "Countdown";
            this.Countdown.Size = new System.Drawing.Size(90, 75);
            this.Countdown.TabIndex = 4;
            this.Countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSavaPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 760);
            this.Controls.Add(this.Countdown);
            this.Controls.Add(this.labelXInfo);
            this.Controls.Add(this.buttonXCancel);
            this.Controls.Add(this.buttonXNo);
            this.Controls.Add(this.buttonXYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSavaPackage";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSavaPackage";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonXYes;
        private DevComponents.DotNetBar.ButtonX buttonXNo;
        private System.Windows.Forms.Timer timerMain;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.DotNetBar.LabelX labelXInfo;
        private System.Windows.Forms.Label Countdown;

    }
}