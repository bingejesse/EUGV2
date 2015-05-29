namespace SC.View2
{
    partial class CustomerPGSearched
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
            this.buttonNext = new GBY.GBYButton();
            this.buttonRefresh = new GBY.GBYButton();
            this.buttonHome = new GBY.GBYButton();
            this.buttonNextPage = new GBY.GBYButton();
            this.buttonPreviousPage = new GBY.GBYButton();
            this.panelWB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWB
            // 
            this.panelWB.Controls.Add(this.wb);
            this.panelWB.Location = new System.Drawing.Point(55, 45);
            this.panelWB.Name = "panelWB";
            this.panelWB.Size = new System.Drawing.Size(917, 379);
            this.panelWB.TabIndex = 3;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(917, 379);
            this.wb.TabIndex = 0;
            this.wb.TabStop = false;
            this.wb.Url = new System.Uri("", System.UriKind.Relative);
            this.wb.WebBrowserShortcutsEnabled = false;
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.Checked = false;
            this.buttonNext.Del_X = 0F;
            this.buttonNext.Del_Y = 1F;
            this.buttonNext.DownImg = global::SC.View2.Properties.Resources.button_custom_getpackage_down;
            this.buttonNext.Font = new System.Drawing.Font("方正中倩简体", 22F);
            this.buttonNext.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonNext.HoverImg = null;
            this.buttonNext.Location = new System.Drawing.Point(51, 470);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.NormalImg = global::SC.View2.Properties.Resources.button_182x108_blue_normal;
            this.buttonNext.Size = new System.Drawing.Size(181, 108);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "继续查询";
            this.buttonNext.TextColor = System.Drawing.Color.White;
            this.buttonNext.TextLeft = 0F;
            this.buttonNext.TextTop = 10F;
            this.buttonNext.Toogle = false;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.Checked = false;
            this.buttonRefresh.Del_X = 0F;
            this.buttonRefresh.Del_Y = 1F;
            this.buttonRefresh.DownImg = global::SC.View2.Properties.Resources.button_custom_getpackage_down;
            this.buttonRefresh.Font = new System.Drawing.Font("方正中倩简体", 22F);
            this.buttonRefresh.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonRefresh.HoverImg = null;
            this.buttonRefresh.Location = new System.Drawing.Point(238, 470);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.NormalImg = global::SC.View2.Properties.Resources.button_182x108_blue_normal;
            this.buttonRefresh.Size = new System.Drawing.Size(181, 108);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.TextColor = System.Drawing.Color.White;
            this.buttonRefresh.TextLeft = 0F;
            this.buttonRefresh.TextTop = 10F;
            this.buttonRefresh.Toogle = false;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Checked = false;
            this.buttonHome.Del_X = 0F;
            this.buttonHome.Del_Y = 1F;
            this.buttonHome.DownImg = global::SC.View2.Properties.Resources.button_182x108_yellow_down;
            this.buttonHome.Font = new System.Drawing.Font("方正中倩简体", 22F);
            this.buttonHome.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonHome.HoverImg = null;
            this.buttonHome.Location = new System.Drawing.Point(425, 470);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.NormalImg = global::SC.View2.Properties.Resources.button_182x108_yellow_normal;
            this.buttonHome.Size = new System.Drawing.Size(181, 108);
            this.buttonHome.TabIndex = 3;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.TextColor = System.Drawing.Color.White;
            this.buttonHome.TextLeft = 0F;
            this.buttonHome.TextTop = 10F;
            this.buttonHome.Toogle = false;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextPage.Checked = false;
            this.buttonNextPage.Del_X = 0F;
            this.buttonNextPage.Del_Y = 1F;
            this.buttonNextPage.DownImg = global::SC.View2.Properties.Resources.button_custom_getpackage_down;
            this.buttonNextPage.Font = new System.Drawing.Font("方正中倩简体", 22F);
            this.buttonNextPage.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonNextPage.HoverImg = null;
            this.buttonNextPage.Location = new System.Drawing.Point(612, 474);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.NormalImg = global::SC.View2.Properties.Resources.button_182x108_blue_normal;
            this.buttonNextPage.Size = new System.Drawing.Size(181, 108);
            this.buttonNextPage.TabIndex = 3;
            this.buttonNextPage.Text = "下一页";
            this.buttonNextPage.TextColor = System.Drawing.Color.White;
            this.buttonNextPage.TextLeft = 0F;
            this.buttonNextPage.TextTop = 10F;
            this.buttonNextPage.Toogle = false;
            this.buttonNextPage.UseVisualStyleBackColor = false;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.BackColor = System.Drawing.Color.Transparent;
            this.buttonPreviousPage.Checked = false;
            this.buttonPreviousPage.Del_X = 0F;
            this.buttonPreviousPage.Del_Y = 1F;
            this.buttonPreviousPage.DownImg = global::SC.View2.Properties.Resources.button_custom_getpackage_down;
            this.buttonPreviousPage.Font = new System.Drawing.Font("方正中倩简体", 22F);
            this.buttonPreviousPage.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonPreviousPage.HoverImg = null;
            this.buttonPreviousPage.Location = new System.Drawing.Point(799, 474);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.NormalImg = global::SC.View2.Properties.Resources.button_182x108_blue_normal;
            this.buttonPreviousPage.Size = new System.Drawing.Size(181, 108);
            this.buttonPreviousPage.TabIndex = 3;
            this.buttonPreviousPage.Text = "上一页";
            this.buttonPreviousPage.TextColor = System.Drawing.Color.White;
            this.buttonPreviousPage.TextLeft = 0F;
            this.buttonPreviousPage.TextTop = 10F;
            this.buttonPreviousPage.Toogle = false;
            this.buttonPreviousPage.UseVisualStyleBackColor = false;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // CustomerPGSearched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.panelWB);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "CustomerPGSearched";
            this.panelWB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWB;
        private System.Windows.Forms.WebBrowser wb;
        private GBY.GBYButton buttonNext;
        private GBY.GBYButton buttonRefresh;
        private GBY.GBYButton buttonHome;
        private GBY.GBYButton buttonNextPage;
        private GBY.GBYButton buttonPreviousPage;
    }
}
