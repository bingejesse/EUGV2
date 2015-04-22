namespace IEC.UI
{
    partial class mainPanel
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
            this.forHelp = new DevComponents.DotNetBar.ButtonX();
            this.savePackage = new DevComponents.DotNetBar.ButtonX();
            this.returnPackage = new DevComponents.DotNetBar.ButtonX();
            this.getPackage = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // forHelp
            // 
            this.forHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.forHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forHelp.BackColor = System.Drawing.Color.Gold;
            this.forHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.forHelp.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forHelp.Location = new System.Drawing.Point(550, 288);
            this.forHelp.Name = "forHelp";
            this.forHelp.Size = new System.Drawing.Size(330, 160);
            this.forHelp.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.forHelp.Symbol = "";
            this.forHelp.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.forHelp.SymbolSize = 50F;
            this.forHelp.TabIndex = 3;
            this.forHelp.TabStop = false;
            this.forHelp.Text = "<font size=\"+2\"><b>关于智能柜</b></font><br/><font size=\"-3\">GO POST智能柜为您服务</font>";
            this.forHelp.Click += new System.EventHandler(this.forHelp_Click);
            // 
            // savePackage
            // 
            this.savePackage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.savePackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savePackage.BackColor = System.Drawing.Color.Gold;
            this.savePackage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.savePackage.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.savePackage.Location = new System.Drawing.Point(550, 76);
            this.savePackage.Name = "savePackage";
            this.savePackage.Size = new System.Drawing.Size(330, 160);
            this.savePackage.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.savePackage.Symbol = "";
            this.savePackage.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.savePackage.SymbolSize = 50F;
            this.savePackage.TabIndex = 1;
            this.savePackage.TabStop = false;
            this.savePackage.Text = "<font size=\"+2\"><b>快递员存件</b></font><br/><font size=\"-3\">投递您的邮包，方便，快捷</font>";
            this.savePackage.Click += new System.EventHandler(this.savePackage_Click);
            // 
            // returnPackage
            // 
            this.returnPackage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.returnPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnPackage.BackColor = System.Drawing.Color.Gold;
            this.returnPackage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.returnPackage.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnPackage.Location = new System.Drawing.Point(135, 288);
            this.returnPackage.Name = "returnPackage";
            this.returnPackage.Size = new System.Drawing.Size(330, 160);
            this.returnPackage.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.returnPackage.Symbol = "";
            this.returnPackage.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.returnPackage.SymbolSize = 50F;
            this.returnPackage.TabIndex = 2;
            this.returnPackage.TabStop = false;
            this.returnPackage.Text = "<font size=\"+2\"><b>快递员取回</b></font><br/><font size=\"-3\">取回您的邮包，方便，快捷</font>";
            this.returnPackage.Click += new System.EventHandler(this.returnPackage_Click);
            // 
            // getPackage
            // 
            this.getPackage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.getPackage.BackColor = System.Drawing.Color.Gold;
            this.getPackage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.getPackage.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.getPackage.Location = new System.Drawing.Point(135, 76);
            this.getPackage.Name = "getPackage";
            this.getPackage.Size = new System.Drawing.Size(330, 160);
            this.getPackage.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.getPackage.Symbol = "";
            this.getPackage.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.getPackage.SymbolSize = 50F;
            this.getPackage.TabIndex = 0;
            this.getPackage.TabStop = false;
            this.getPackage.Text = "<font size=\"+2\"><b>我要取件</b></font><br/><font size=\"-3\">取回您的邮包，方便，快捷</font>";
            this.getPackage.Click += new System.EventHandler(this.getPackage_Click);
            // 
            // mainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.forHelp);
            this.Controls.Add(this.savePackage);
            this.Controls.Add(this.returnPackage);
            this.Controls.Add(this.getPackage);
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(1024, 530);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX forHelp;
        private DevComponents.DotNetBar.ButtonX savePackage;
        private DevComponents.DotNetBar.ButtonX returnPackage;
        private DevComponents.DotNetBar.ButtonX getPackage;

    }
}
