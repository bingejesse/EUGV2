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
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textPGCode = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(293, 397);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(104, 397);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(135, 67);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textPGCode
            // 
            this.textPGCode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPGCode.Location = new System.Drawing.Point(234, 264);
            this.textPGCode.MaxLength = 15;
            this.textPGCode.Name = "textPGCode";
            this.textPGCode.Size = new System.Drawing.Size(246, 41);
            this.textPGCode.TabIndex = 0;
            this.textPGCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCode.Location = new System.Drawing.Point(95, 267);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(133, 29);
            this.labelCode.TabIndex = 9;
            this.labelCode.Text = "快递单号";
            // 
            // PostmanTBEntryPGInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textPGCode);
            this.Controls.Add(this.labelCode);
            this.Name = "PostmanTBEntryPGInfo";
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.virtualNumKeyboard, 0);
            this.Controls.SetChildIndex(this.labelCode, 0);
            this.Controls.SetChildIndex(this.textPGCode, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textPGCode;
        private System.Windows.Forms.Label labelCode;
    }
}
