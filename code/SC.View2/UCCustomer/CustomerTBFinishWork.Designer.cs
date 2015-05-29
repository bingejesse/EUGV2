namespace SC.View2
{
    partial class CustomerTBFinishWork
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
            this.buttonNext = new GBY.GBYButton();
            this.buttonOpenAgain = new GBY.GBYButton();
            this.buttonHome = new GBY.GBYButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.Checked = false;
            this.buttonNext.Del_X = 0F;
            this.buttonNext.Del_Y = 1F;
            this.buttonNext.DownImg = global::SC.View2.Properties.Resources.button_247x177_blue_down;
            this.buttonNext.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonNext.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonNext.HoverImg = null;
            this.buttonNext.Location = new System.Drawing.Point(110, 260);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.NormalImg = global::SC.View2.Properties.Resources.button_247x177_blue_normal;
            this.buttonNext.Size = new System.Drawing.Size(247, 177);
            this.buttonNext.TabIndex = 24;
            this.buttonNext.Text = "继续存件";
            this.buttonNext.TextColor = System.Drawing.Color.White;
            this.buttonNext.TextLeft = 0F;
            this.buttonNext.TextTop = 10F;
            this.buttonNext.Toogle = false;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonOpenAgain
            // 
            this.buttonOpenAgain.BackColor = System.Drawing.Color.Transparent;
            this.buttonOpenAgain.Checked = false;
            this.buttonOpenAgain.Del_X = 0F;
            this.buttonOpenAgain.Del_Y = 1F;
            this.buttonOpenAgain.DownImg = global::SC.View2.Properties.Resources.button_247x177_yellow_down;
            this.buttonOpenAgain.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonOpenAgain.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonOpenAgain.HoverImg = null;
            this.buttonOpenAgain.Location = new System.Drawing.Point(391, 260);
            this.buttonOpenAgain.Name = "buttonOpenAgain";
            this.buttonOpenAgain.NormalImg = global::SC.View2.Properties.Resources.button_247x177_yellow_normal;
            this.buttonOpenAgain.Size = new System.Drawing.Size(247, 177);
            this.buttonOpenAgain.TabIndex = 24;
            this.buttonOpenAgain.Text = "重新开箱";
            this.buttonOpenAgain.TextColor = System.Drawing.Color.White;
            this.buttonOpenAgain.TextLeft = 0F;
            this.buttonOpenAgain.TextTop = 10F;
            this.buttonOpenAgain.Toogle = false;
            this.buttonOpenAgain.UseVisualStyleBackColor = false;
            this.buttonOpenAgain.Click += new System.EventHandler(this.buttonOpenAgain_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Checked = false;
            this.buttonHome.Del_X = 0F;
            this.buttonHome.Del_Y = 1F;
            this.buttonHome.DownImg = global::SC.View2.Properties.Resources.button_247x177_yellow_down;
            this.buttonHome.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonHome.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonHome.HoverImg = null;
            this.buttonHome.Location = new System.Drawing.Point(670, 260);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.NormalImg = global::SC.View2.Properties.Resources.button_247x177_yellow_normal;
            this.buttonHome.Size = new System.Drawing.Size(247, 177);
            this.buttonHome.TabIndex = 24;
            this.buttonHome.Text = "返回首页";
            this.buttonHome.TextColor = System.Drawing.Color.White;
            this.buttonHome.TextLeft = 0F;
            this.buttonHome.TextTop = 10F;
            this.buttonHome.Toogle = false;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("方正中倩简体", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(231, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 39);
            this.label1.TabIndex = 25;
            this.label1.Text = "如果箱门没有打开，请点击重新开箱";
            // 
            // CustomerTBFinishWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonOpenAgain);
            this.Controls.Add(this.buttonNext);
            this.Name = "CustomerTBFinishWork";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonOpenAgain, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GBY.GBYButton buttonNext;
        private GBY.GBYButton buttonOpenAgain;
        private GBY.GBYButton buttonHome;
        private System.Windows.Forms.Label label1;
    }
}
