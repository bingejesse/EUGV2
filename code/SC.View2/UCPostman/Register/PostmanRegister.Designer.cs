namespace SC.View2
{
    partial class PostmanRegister
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
            this.panelWB = new System.Windows.Forms.Panel();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelWB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWB
            // 
            this.panelWB.Controls.Add(this.wb);
            this.panelWB.Location = new System.Drawing.Point(29, 122);
            this.panelWB.Name = "panelWB";
            this.panelWB.Size = new System.Drawing.Size(949, 422);
            this.panelWB.TabIndex = 1;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(949, 422);
            this.wb.TabIndex = 0;
            this.wb.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(588, 570);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(271, 570);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(161, 67);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // PostmanRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.panelWB);
            this.Name = "PostmanRegister";
            this.Controls.SetChildIndex(this.panelWB, 0);
            this.Controls.SetChildIndex(this.buttonRefresh, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.panelWB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWB;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.WebBrowser wb;


    }
}
