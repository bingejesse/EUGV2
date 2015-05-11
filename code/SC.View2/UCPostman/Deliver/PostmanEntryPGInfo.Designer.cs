namespace SC.View2
{
    partial class PostmanEntryPGInfo
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
            this.textPGID = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.labelPGID = new System.Windows.Forms.Label();
            this.labelConfimTel = new System.Windows.Forms.Label();
            this.textBoxTelNum = new System.Windows.Forms.TextBox();
            this.textBoxTelNumConfim = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(302, 483);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(139, 483);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(135, 67);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textPGID
            // 
            this.textPGID.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPGID.Location = new System.Drawing.Point(233, 230);
            this.textPGID.MaxLength = 15;
            this.textPGID.Name = "textPGID";
            this.textPGID.Size = new System.Drawing.Size(246, 41);
            this.textPGID.TabIndex = 0;
            this.textPGID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTel.Location = new System.Drawing.Point(67, 301);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(160, 24);
            this.labelTel.TabIndex = 10;
            this.labelTel.Text = "收件人手机号";
            this.labelTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPGID
            // 
            this.labelPGID.AutoSize = true;
            this.labelPGID.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPGID.Location = new System.Drawing.Point(117, 237);
            this.labelPGID.Name = "labelPGID";
            this.labelPGID.Size = new System.Drawing.Size(110, 24);
            this.labelPGID.TabIndex = 9;
            this.labelPGID.Text = "快递单号";
            this.labelPGID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelConfimTel
            // 
            this.labelConfimTel.AutoSize = true;
            this.labelConfimTel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelConfimTel.Location = new System.Drawing.Point(85, 363);
            this.labelConfimTel.Name = "labelConfimTel";
            this.labelConfimTel.Size = new System.Drawing.Size(135, 24);
            this.labelConfimTel.TabIndex = 15;
            this.labelConfimTel.Text = "确认手机号";
            this.labelConfimTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTelNum
            // 
            this.textBoxTelNum.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTelNum.Location = new System.Drawing.Point(233, 294);
            this.textBoxTelNum.MaxLength = 15;
            this.textBoxTelNum.Name = "textBoxTelNum";
            this.textBoxTelNum.Size = new System.Drawing.Size(246, 41);
            this.textBoxTelNum.TabIndex = 16;
            this.textBoxTelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTelNumConfim
            // 
            this.textBoxTelNumConfim.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTelNumConfim.Location = new System.Drawing.Point(233, 356);
            this.textBoxTelNumConfim.MaxLength = 15;
            this.textBoxTelNumConfim.Name = "textBoxTelNumConfim";
            this.textBoxTelNumConfim.Size = new System.Drawing.Size(246, 41);
            this.textBoxTelNumConfim.TabIndex = 17;
            this.textBoxTelNumConfim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PostmanEntryPGInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxTelNumConfim);
            this.Controls.Add(this.textBoxTelNum);
            this.Controls.Add(this.labelConfimTel);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textPGID);
            this.Controls.Add(this.labelTel);
            this.Controls.Add(this.labelPGID);
            this.Name = "PostmanEntryPGInfo";
            this.Controls.SetChildIndex(this.labelPGID, 0);
            this.Controls.SetChildIndex(this.labelTel, 0);
            this.Controls.SetChildIndex(this.textPGID, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.virtualNumKeyboard, 0);
            this.Controls.SetChildIndex(this.labelConfimTel, 0);
            this.Controls.SetChildIndex(this.textBoxTelNum, 0);
            this.Controls.SetChildIndex(this.textBoxTelNumConfim, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textPGID;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.Label labelPGID;
        private System.Windows.Forms.Label labelConfimTel;
        private System.Windows.Forms.TextBox textBoxTelNum;
        private System.Windows.Forms.TextBox textBoxTelNumConfim;

    }
}
