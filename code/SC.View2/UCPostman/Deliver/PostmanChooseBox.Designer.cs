namespace SC.View2
{
    partial class PostmanChooseBox
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
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonMBox = new GBY.GBYButtonMultiText();
            this.buttonLBox = new GBY.GBYButtonMultiText();
            this.buttonSBox = new GBY.GBYButtonMultiText();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(784, 504);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(545, 504);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(135, 67);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonMBox
            // 
            this.buttonMBox.Checked = true;
            this.buttonMBox.Del_X = 0F;
            this.buttonMBox.Del_Y = 1F;
            this.buttonMBox.DownImg = global::SC.View2.Properties.Resources.middlebox_checked;
            this.buttonMBox.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonMBox.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonMBox.HoverImg = null;
            this.buttonMBox.Location = new System.Drawing.Point(363, 180);
            this.buttonMBox.MultiText = "可用数量：10";
            this.buttonMBox.MultiTextLeft = 0F;
            this.buttonMBox.MultiTextTop = 50F;
            this.buttonMBox.MutiFont = new System.Drawing.Font("方正中倩简体", 25F);
            this.buttonMBox.Name = "buttonMBox";
            this.buttonMBox.NormalImg = global::SC.View2.Properties.Resources.middlebox_normal;
            this.buttonMBox.Size = new System.Drawing.Size(288, 300);
            this.buttonMBox.TabIndex = 24;
            this.buttonMBox.Text = "中箱子";
            this.buttonMBox.TextColor = System.Drawing.Color.White;
            this.buttonMBox.TextLeft = 0F;
            this.buttonMBox.TextTop = 100F;
            this.buttonMBox.Toogle = true;
            this.buttonMBox.UseVisualStyleBackColor = true;
            this.buttonMBox.Click += new System.EventHandler(this.buttonMBox_Click);
            // 
            // buttonLBox
            // 
            this.buttonLBox.Checked = false;
            this.buttonLBox.Del_X = 0F;
            this.buttonLBox.Del_Y = 1F;
            this.buttonLBox.DownImg = global::SC.View2.Properties.Resources.bigbox_checked;
            this.buttonLBox.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonLBox.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonLBox.HoverImg = null;
            this.buttonLBox.Location = new System.Drawing.Point(50, 180);
            this.buttonLBox.MultiText = "可用数量：10";
            this.buttonLBox.MultiTextLeft = 0F;
            this.buttonLBox.MultiTextTop = 50F;
            this.buttonLBox.MutiFont = new System.Drawing.Font("方正中倩简体", 25F);
            this.buttonLBox.Name = "buttonLBox";
            this.buttonLBox.NormalImg = global::SC.View2.Properties.Resources.bigbox_normal;
            this.buttonLBox.Size = new System.Drawing.Size(288, 300);
            this.buttonLBox.TabIndex = 24;
            this.buttonLBox.Text = "大箱子";
            this.buttonLBox.TextColor = System.Drawing.Color.White;
            this.buttonLBox.TextLeft = 0F;
            this.buttonLBox.TextTop = 100F;
            this.buttonLBox.Toogle = true;
            this.buttonLBox.UseVisualStyleBackColor = true;
            this.buttonLBox.Click += new System.EventHandler(this.buttonLBox_Click);
            // 
            // buttonSBox
            // 
            this.buttonSBox.Checked = false;
            this.buttonSBox.Del_X = 0F;
            this.buttonSBox.Del_Y = 1F;
            this.buttonSBox.DownImg = global::SC.View2.Properties.Resources.smallbox_checked;
            this.buttonSBox.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonSBox.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonSBox.HoverImg = null;
            this.buttonSBox.Location = new System.Drawing.Point(657, 180);
            this.buttonSBox.MultiText = "可用数量：10";
            this.buttonSBox.MultiTextLeft = 0F;
            this.buttonSBox.MultiTextTop = 50F;
            this.buttonSBox.MutiFont = new System.Drawing.Font("方正中倩简体", 25F);
            this.buttonSBox.Name = "buttonSBox";
            this.buttonSBox.NormalImg = global::SC.View2.Properties.Resources.smallbox_normal;
            this.buttonSBox.Size = new System.Drawing.Size(288, 300);
            this.buttonSBox.TabIndex = 24;
            this.buttonSBox.Text = "小箱子";
            this.buttonSBox.TextColor = System.Drawing.Color.White;
            this.buttonSBox.TextLeft = 0F;
            this.buttonSBox.TextTop = 100F;
            this.buttonSBox.Toogle = true;
            this.buttonSBox.UseVisualStyleBackColor = true;
            this.buttonSBox.Click += new System.EventHandler(this.buttonSBox_Click);
            // 
            // PostmanChooseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonLBox);
            this.Controls.Add(this.buttonSBox);
            this.Controls.Add(this.buttonMBox);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Name = "PostmanChooseBox";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.buttonMBox, 0);
            this.Controls.SetChildIndex(this.buttonSBox, 0);
            this.Controls.SetChildIndex(this.buttonLBox, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonNext;
        private GBY.GBYButtonMultiText buttonMBox;
        private GBY.GBYButtonMultiText buttonLBox;
        private GBY.GBYButtonMultiText buttonSBox;
    }
}
