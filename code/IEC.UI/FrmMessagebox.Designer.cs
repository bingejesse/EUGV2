namespace IEC.UI
{
    partial class FrmMessagebox
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonXCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonXOK = new DevComponents.DotNetBar.ButtonX();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.labelXTitle = new DevComponents.DotNetBar.LabelX();
            this.labelXInfo = new DevComponents.DotNetBar.LabelX();
            this.panelMain = new System.Windows.Forms.Panel();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.buttonXCancel);
            this.panelBottom.Controls.Add(this.buttonXOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
            this.panelBottom.Location = new System.Drawing.Point(0, 173);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(532, 89);
            this.panelBottom.TabIndex = 0;
            // 
            // buttonXCancel
            // 
            this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXCancel.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXCancel.Location = new System.Drawing.Point(296, 19);
            this.buttonXCancel.Name = "buttonXCancel";
            this.buttonXCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.buttonXCancel.Size = new System.Drawing.Size(139, 52);
            this.buttonXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXCancel.TabIndex = 0;
            this.buttonXCancel.Text = "取消";
            this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
            // 
            // buttonXOK
            // 
            this.buttonXOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXOK.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXOK.Location = new System.Drawing.Point(97, 19);
            this.buttonXOK.Name = "buttonXOK";
            this.buttonXOK.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.buttonXOK.Size = new System.Drawing.Size(139, 52);
            this.buttonXOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonXOK.TabIndex = 0;
            this.buttonXOK.Text = "确认";
            this.buttonXOK.Click += new System.EventHandler(this.buttonXOK_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.SystemColors.Control;
            this.panelCenter.Controls.Add(this.labelXTitle);
            this.panelCenter.Controls.Add(this.labelXInfo);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(532, 173);
            this.panelCenter.TabIndex = 1;
            // 
            // labelXTitle
            // 
            this.labelXTitle.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.labelXTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXTitle.ForeColor = System.Drawing.Color.Black;
            this.labelXTitle.Location = new System.Drawing.Point(3, 3);
            this.labelXTitle.Name = "labelXTitle";
            this.labelXTitle.Size = new System.Drawing.Size(526, 58);
            this.labelXTitle.TabIndex = 1;
            this.labelXTitle.Text = "系统提示";
            this.labelXTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelXInfo
            // 
            // 
            // 
            // 
            this.labelXInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelXInfo.Location = new System.Drawing.Point(3, 93);
            this.labelXInfo.Name = "labelXInfo";
            this.labelXInfo.Size = new System.Drawing.Size(526, 58);
            this.labelXInfo.TabIndex = 0;
            this.labelXInfo.Text = "请注意，本次操作将返回主页！";
            this.labelXInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.panelCenter);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(536, 266);
            this.panelMain.TabIndex = 2;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FrmMessagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 266);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMessagebox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMessagebox";
            this.panelBottom.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private DevComponents.DotNetBar.ButtonX buttonXCancel;
        private DevComponents.DotNetBar.ButtonX buttonXOK;
        private DevComponents.DotNetBar.LabelX labelXInfo;
        private System.Windows.Forms.Panel panelMain;
        private DevComponents.DotNetBar.LabelX labelXTitle;
        private System.Windows.Forms.Timer timerMain;
    }
}