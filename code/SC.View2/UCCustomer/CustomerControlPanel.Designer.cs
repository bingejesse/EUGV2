namespace SC.View2
{
    partial class CustomerControlPanel
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonTakePG = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(554, 318);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(222, 83);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "查询快递";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonTakePG
            // 
            this.buttonTakePG.Location = new System.Drawing.Point(245, 318);
            this.buttonTakePG.Name = "buttonTakePG";
            this.buttonTakePG.Size = new System.Drawing.Size(222, 83);
            this.buttonTakePG.TabIndex = 0;
            this.buttonTakePG.Text = "取快递";
            this.buttonTakePG.UseVisualStyleBackColor = true;
            this.buttonTakePG.Click += new System.EventHandler(this.buttonTakePG_Click);
            // 
            // CustomerControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonTakePG);
            this.Name = "CustomerControlPanel";
            this.Controls.SetChildIndex(this.buttonTakePG, 0);
            this.Controls.SetChildIndex(this.buttonSearch, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonTakePG;
    }
}
