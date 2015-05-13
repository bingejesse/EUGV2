namespace SC.View2
{
    partial class PostmanPGVerify
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.Yellow;
            this.labelMessage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMessage.Location = new System.Drawing.Point(248, 137);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(524, 278);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "您存如的快递信息如下：\r\n\r\n快递单号：123456789\r\n收件人手机号码：13344556655";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(654, 497);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "取消存件";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(427, 497);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(161, 67);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "确定";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(206, 497);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(161, 67);
            this.buttonPrevious.TabIndex = 0;
            this.buttonPrevious.Text = "上一步";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // PostmanPGVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelMessage);
            this.Name = "PostmanPGVerify";
            this.Controls.SetChildIndex(this.labelMessage, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.buttonPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
    }
}
