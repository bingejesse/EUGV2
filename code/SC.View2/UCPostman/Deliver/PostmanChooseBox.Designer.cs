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
            this.buttonLBox = new System.Windows.Forms.Button();
            this.buttonMBox = new System.Windows.Forms.Button();
            this.buttonSBox = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLBox
            // 
            this.buttonLBox.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.buttonLBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonLBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonLBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLBox.Location = new System.Drawing.Point(63, 203);
            this.buttonLBox.Name = "buttonLBox";
            this.buttonLBox.Size = new System.Drawing.Size(236, 172);
            this.buttonLBox.TabIndex = 0;
            this.buttonLBox.Text = "大箱子\r\n可用数量10";
            this.buttonLBox.UseVisualStyleBackColor = true;
            this.buttonLBox.Click += new System.EventHandler(this.buttonLBox_Click);
            // 
            // buttonMBox
            // 
            this.buttonMBox.Location = new System.Drawing.Point(392, 203);
            this.buttonMBox.Name = "buttonMBox";
            this.buttonMBox.Size = new System.Drawing.Size(236, 172);
            this.buttonMBox.TabIndex = 1;
            this.buttonMBox.Text = "中箱子\r\n可用数量10";
            this.buttonMBox.UseVisualStyleBackColor = true;
            this.buttonMBox.Click += new System.EventHandler(this.buttonMBox_Click);
            // 
            // buttonSBox
            // 
            this.buttonSBox.Location = new System.Drawing.Point(721, 203);
            this.buttonSBox.Name = "buttonSBox";
            this.buttonSBox.Size = new System.Drawing.Size(236, 172);
            this.buttonSBox.TabIndex = 2;
            this.buttonSBox.Text = "小箱子\r\n可用数量10";
            this.buttonSBox.UseVisualStyleBackColor = true;
            this.buttonSBox.Click += new System.EventHandler(this.buttonSBox_Click);
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
            // PostmanChooseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonSBox);
            this.Controls.Add(this.buttonMBox);
            this.Controls.Add(this.buttonLBox);
            this.Name = "PostmanChooseBox";
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.buttonLBox, 0);
            this.Controls.SetChildIndex(this.buttonMBox, 0);
            this.Controls.SetChildIndex(this.buttonSBox, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLBox;
        private System.Windows.Forms.Button buttonMBox;
        private System.Windows.Forms.Button buttonSBox;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonNext;
    }
}
