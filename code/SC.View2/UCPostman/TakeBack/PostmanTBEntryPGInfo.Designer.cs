namespace SC.View2
{
    partial class PostmanTBEntryPGInfo
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
            this.textPGCode = new GBY.GBYTextBox();
            this.labelPGInfo = new System.Windows.Forms.Label();
            this.buttonNext = new GBY.GBYButton();
            this.buttonHome = new GBY.GBYButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // virtualNumKeyboard
            // 
            this.virtualNumKeyboard.IsTopBarVisible = false;
            this.virtualNumKeyboard.Location = new System.Drawing.Point(596, 189);
            this.virtualNumKeyboard.Size = new System.Drawing.Size(373, 399);
            // 
            // textPGCode
            // 
            this.textPGCode.BackColor = System.Drawing.Color.Transparent;
            this.textPGCode.BackgroundImage = global::SC.View2.Properties.Resources.inputBg_348x93;
            this.textPGCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textPGCode.EnterBackImage = global::SC.View2.Properties.Resources.inputBg_348x93_focus;
            this.textPGCode.Location = new System.Drawing.Point(192, 192);
            this.textPGCode.Margin = new System.Windows.Forms.Padding(20);
            this.textPGCode.MaxLength = 12;
            this.textPGCode.MultiLine = false;
            this.textPGCode.Name = "textPGCode";
            this.textPGCode.NormalBackImage = global::SC.View2.Properties.Resources.inputBg_348x93;
            this.textPGCode.PFont = new System.Drawing.Font("方正中倩简体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPGCode.PForeColor = System.Drawing.Color.White;
            this.textPGCode.PText = "";
            this.textPGCode.Size = new System.Drawing.Size(375, 80);
            this.textPGCode.TabIndex = 21;
            this.textPGCode.Text = "gbyTextBox1";
            // 
            // labelPGInfo
            // 
            this.labelPGInfo.AutoSize = true;
            this.labelPGInfo.Font = new System.Drawing.Font("方正中倩简体", 24F, System.Drawing.FontStyle.Bold);
            this.labelPGInfo.ForeColor = System.Drawing.Color.White;
            this.labelPGInfo.Location = new System.Drawing.Point(43, 213);
            this.labelPGInfo.Name = "labelPGInfo";
            this.labelPGInfo.Size = new System.Drawing.Size(149, 38);
            this.labelPGInfo.TabIndex = 22;
            this.labelPGInfo.Text = "快递单号";
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.Checked = false;
            this.buttonNext.Del_X = 0F;
            this.buttonNext.Del_Y = 1F;
            this.buttonNext.DownImg = global::SC.View2.Properties.Resources.back_next_226x132_down;
            this.buttonNext.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonNext.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonNext.HoverImg = null;
            this.buttonNext.Location = new System.Drawing.Point(327, 473);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.NormalImg = global::SC.View2.Properties.Resources.back_next_226x132_normal;
            this.buttonNext.Size = new System.Drawing.Size(234, 138);
            this.buttonNext.TabIndex = 24;
            this.buttonNext.Text = "下一步";
            this.buttonNext.TextColor = System.Drawing.Color.White;
            this.buttonNext.TextLeft = 0F;
            this.buttonNext.TextTop = 10F;
            this.buttonNext.Toogle = false;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Checked = false;
            this.buttonHome.Del_X = 0F;
            this.buttonHome.Del_Y = 1F;
            this.buttonHome.DownImg = global::SC.View2.Properties.Resources.back_main_226x132_down;
            this.buttonHome.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonHome.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonHome.HoverImg = null;
            this.buttonHome.Location = new System.Drawing.Point(81, 473);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.NormalImg = global::SC.View2.Properties.Resources.back_main_226x132_normal;
            this.buttonHome.Size = new System.Drawing.Size(234, 138);
            this.buttonHome.TabIndex = 23;
            this.buttonHome.Text = "返回首页";
            this.buttonHome.TextColor = System.Drawing.Color.White;
            this.buttonHome.TextLeft = 0F;
            this.buttonHome.TextTop = 10F;
            this.buttonHome.Toogle = false;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // PostmanTBEntryPGInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.labelPGInfo);
            this.Controls.Add(this.textPGCode);
            this.Name = "PostmanTBEntryPGInfo";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.virtualNumKeyboard, 0);
            this.Controls.SetChildIndex(this.textPGCode, 0);
            this.Controls.SetChildIndex(this.labelPGInfo, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GBY.GBYTextBox textPGCode;
        private System.Windows.Forms.Label labelPGInfo;
        private GBY.GBYButton buttonNext;
        private GBY.GBYButton buttonHome;
    }
}
