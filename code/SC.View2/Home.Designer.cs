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
            this.components = new System.ComponentModel.Container();
            this.buttonPostman = new System.Windows.Forms.Button();
            this.buttonCustomer = new System.Windows.Forms.Button();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.ad = new System.Windows.Forms.PictureBox();
            this.timerAD = new System.Windows.Forms.Timer(this.components);
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ad)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPostman
            // 
            this.buttonPostman.Location = new System.Drawing.Point(585, 513);
            this.buttonPostman.Name = "buttonPostman";
            this.buttonPostman.Size = new System.Drawing.Size(214, 105);
            this.buttonPostman.TabIndex = 1;
            this.buttonPostman.Text = "我是快递员";
            this.buttonPostman.UseVisualStyleBackColor = true;
            this.buttonPostman.Click += new System.EventHandler(this.buttonPostman_Click);
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.Location = new System.Drawing.Point(226, 513);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.Size = new System.Drawing.Size(214, 105);
            this.buttonCustomer.TabIndex = 0;
            this.buttonCustomer.Text = "我是业主";
            this.buttonCustomer.UseVisualStyleBackColor = true;
            this.buttonCustomer.Click += new System.EventHandler(this.buttonCustomer_Click);
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.ad);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPicture.Location = new System.Drawing.Point(0, 0);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(1024, 480);
            this.panelPicture.TabIndex = 2;
            // 
            // ad
            // 
            this.ad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ad.Location = new System.Drawing.Point(0, 0);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(1024, 480);
            this.ad.TabIndex = 0;
            this.ad.TabStop = false;
            // 
            // timerAD
            // 
            this.timerAD.Interval = 2000;
            this.timerAD.Tick += new System.EventHandler(this.timerAD_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.buttonPostman);
            this.Controls.Add(this.buttonCustomer);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1024, 668);
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPostman;
        private System.Windows.Forms.Button buttonCustomer;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox ad;
        private System.Windows.Forms.Timer timerAD;
    }
}
