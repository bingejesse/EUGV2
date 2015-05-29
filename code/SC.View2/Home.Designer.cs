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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panelPicture = new System.Windows.Forms.Panel();
            this.ad = new System.Windows.Forms.PictureBox();
            this.timerAD = new System.Windows.Forms.Timer(this.components);
            this.buttonPostman = new GBY.GBYButton();
            this.buttonCustomer = new GBY.GBYButton();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ad)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.ad);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPicture.Location = new System.Drawing.Point(0, 0);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(1024, 440);
            this.panelPicture.TabIndex = 2;
            // 
            // ad
            // 
            this.ad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ad.Location = new System.Drawing.Point(0, 0);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(1024, 440);
            this.ad.TabIndex = 0;
            this.ad.TabStop = false;
            // 
            // timerAD
            // 
            this.timerAD.Interval = 2000;
            this.timerAD.Tick += new System.EventHandler(this.timerAD_Tick);
            // 
            // buttonPostman
            // 
            this.buttonPostman.BackColor = System.Drawing.Color.Transparent;
            this.buttonPostman.Checked = false;
            this.buttonPostman.Del_X = 0F;
            this.buttonPostman.Del_Y = 1F;
            this.buttonPostman.DownImg = ((System.Drawing.Image)(resources.GetObject("buttonPostman.DownImg")));
            this.buttonPostman.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonPostman.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonPostman.HoverImg = null;
            this.buttonPostman.Location = new System.Drawing.Point(523, 472);
            this.buttonPostman.Name = "buttonPostman";
            this.buttonPostman.NormalImg = ((System.Drawing.Image)(resources.GetObject("buttonPostman.NormalImg")));
            this.buttonPostman.Size = new System.Drawing.Size(398, 177);
            this.buttonPostman.TabIndex = 4;
            this.buttonPostman.Text = "我是快递员";
            this.buttonPostman.TextColor = System.Drawing.Color.White;
            this.buttonPostman.TextLeft = 0F;
            this.buttonPostman.TextTop = 10F;
            this.buttonPostman.Toogle = false;
            this.buttonPostman.UseVisualStyleBackColor = false;
            this.buttonPostman.Click += new System.EventHandler(this.buttonPostman_Click);
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.BackColor = System.Drawing.Color.Transparent;
            this.buttonCustomer.Checked = false;
            this.buttonCustomer.Del_X = 0F;
            this.buttonCustomer.Del_Y = 1F;
            this.buttonCustomer.DownImg = ((System.Drawing.Image)(resources.GetObject("buttonCustomer.DownImg")));
            this.buttonCustomer.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonCustomer.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonCustomer.HoverImg = null;
            this.buttonCustomer.Location = new System.Drawing.Point(100, 472);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.NormalImg = ((System.Drawing.Image)(resources.GetObject("buttonCustomer.NormalImg")));
            this.buttonCustomer.Size = new System.Drawing.Size(398, 177);
            this.buttonCustomer.TabIndex = 3;
            this.buttonCustomer.Text = "我是业主";
            this.buttonCustomer.TextColor = System.Drawing.Color.White;
            this.buttonCustomer.TextLeft = 0F;
            this.buttonCustomer.TextTop = 10F;
            this.buttonCustomer.Toogle = false;
            this.buttonCustomer.UseVisualStyleBackColor = false;
            this.buttonCustomer.Click += new System.EventHandler(this.buttonCustomer_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPostman);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.buttonCustomer);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1024, 668);
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox ad;
        private System.Windows.Forms.Timer timerAD;
        private GBY.GBYButton buttonPostman;
        private GBY.GBYButton buttonCustomer;
    }
}
