namespace SC.View2
{
    partial class Home
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
            this.buttonPostman = new System.Windows.Forms.Button();
            this.buttonCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPostman
            // 
            this.buttonPostman.Location = new System.Drawing.Point(579, 471);
            this.buttonPostman.Name = "buttonPostman";
            this.buttonPostman.Size = new System.Drawing.Size(214, 105);
            this.buttonPostman.TabIndex = 3;
            this.buttonPostman.Text = "我是快递员";
            this.buttonPostman.UseVisualStyleBackColor = true;
            this.buttonPostman.Click += new System.EventHandler(this.buttonPostman_Click);
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.Location = new System.Drawing.Point(232, 471);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.Size = new System.Drawing.Size(214, 105);
            this.buttonCustomer.TabIndex = 2;
            this.buttonCustomer.Text = "我是业主";
            this.buttonCustomer.UseVisualStyleBackColor = true;
            this.buttonCustomer.Click += new System.EventHandler(this.buttonCustomer_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPostman);
            this.Controls.Add(this.buttonCustomer);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1024, 668);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPostman;
        private System.Windows.Forms.Button buttonCustomer;
    }
}
