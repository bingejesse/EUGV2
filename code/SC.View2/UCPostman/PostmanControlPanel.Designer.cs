namespace SC.View2
{
    partial class PostmanControlPanel
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
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonTakeBack = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(245, 304);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(222, 83);
            this.buttonPost.TabIndex = 0;
            this.buttonPost.Text = "存快递";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(554, 304);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(222, 83);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "查询快递";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonTakeBack
            // 
            this.buttonTakeBack.Location = new System.Drawing.Point(245, 432);
            this.buttonTakeBack.Name = "buttonTakeBack";
            this.buttonTakeBack.Size = new System.Drawing.Size(222, 83);
            this.buttonTakeBack.TabIndex = 2;
            this.buttonTakeBack.Text = "取回快递";
            this.buttonTakeBack.UseVisualStyleBackColor = true;
            this.buttonTakeBack.Click += new System.EventHandler(this.buttonTakeBack_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(554, 432);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(222, 83);
            this.buttonRegister.TabIndex = 3;
            this.buttonRegister.Text = "快递员注册";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // PostmanControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonTakeBack);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonPost);
            this.Name = "PostmanControlPanel";
            this.Controls.SetChildIndex(this.buttonPost, 0);
            this.Controls.SetChildIndex(this.buttonSearch, 0);
            this.Controls.SetChildIndex(this.buttonTakeBack, 0);
            this.Controls.SetChildIndex(this.buttonRegister, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonTakeBack;
        private System.Windows.Forms.Button buttonRegister;
    }
}
