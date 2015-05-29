namespace SC.View2
{
    partial class CustomerTBVerify
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
            this.labelPass = new System.Windows.Forms.Label();
            this.qr = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl();
            this.textBoxPassword = new GBY.GBYTextBox();
            this.buttonNext = new GBY.GBYButton();
            this.buttonHome = new GBY.GBYButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // virtualNumKeyboard
            // 
            this.virtualNumKeyboard.BackgroundImage = global::SC.View2.Properties.Resources.back_keyboard;
            this.virtualNumKeyboard.IsTopBarVisible = false;
            this.virtualNumKeyboard.Location = new System.Drawing.Point(596, 189);
            this.virtualNumKeyboard.Size = new System.Drawing.Size(373, 399);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("方正中倩简体", 24F, System.Drawing.FontStyle.Bold);
            this.labelPass.ForeColor = System.Drawing.Color.White;
            this.labelPass.Location = new System.Drawing.Point(43, 213);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(116, 38);
            this.labelPass.TabIndex = 9;
            this.labelPass.Text = "验证码";
            // 
            // qr
            // 
            this.qr.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qr.Location = new System.Drawing.Point(392, 281);
            this.qr.Name = "qr";
            this.qr.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two;
            this.qr.Size = new System.Drawing.Size(175, 175);
            this.qr.TabIndex = 15;
            this.qr.Visible = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPassword.BackgroundImage = global::SC.View2.Properties.Resources.inputBg_348x93;
            this.textBoxPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxPassword.EnterBackImage = global::SC.View2.Properties.Resources.inputBg_348x93_focus;
            this.textBoxPassword.Location = new System.Drawing.Point(192, 192);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(20);
            this.textBoxPassword.MaxLength = 12;
            this.textBoxPassword.MultiLine = false;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.NormalBackImage = global::SC.View2.Properties.Resources.inputBg_348x93;
            this.textBoxPassword.PFont = new System.Drawing.Font("方正中倩简体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPassword.PForeColor = System.Drawing.Color.White;
            this.textBoxPassword.PText = "";
            this.textBoxPassword.Size = new System.Drawing.Size(375, 80);
            this.textBoxPassword.TabIndex = 21;
            this.textBoxPassword.Text = "gbyTextBox1";
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.Checked = false;
            this.buttonNext.Del_X = 0F;
            this.buttonNext.Del_Y = 1F;
            this.buttonNext.DownImg = global::SC.View2.Properties.Resources.back_next_226x132_down;
            this.buttonNext.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonNext.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonNext.HoverImg = null;
            this.buttonNext.Location = new System.Drawing.Point(327, 473);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.NormalImg = global::SC.View2.Properties.Resources.back_next_226x132_normal;
            this.buttonNext.Size = new System.Drawing.Size(234, 138);
            this.buttonNext.TabIndex = 23;
            this.buttonNext.Text = "下一步";
            this.buttonNext.TextColor = System.Drawing.Color.White;
            this.buttonNext.TextLeft = 0F;
            this.buttonNext.TextTop = 10F;
            this.buttonNext.Toogle = false;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Checked = false;
            this.buttonHome.Del_X = 0F;
            this.buttonHome.Del_Y = 1F;
            this.buttonHome.DownImg = global::SC.View2.Properties.Resources.back_main_226x132_down;
            this.buttonHome.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonHome.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonHome.HoverImg = null;
            this.buttonHome.Location = new System.Drawing.Point(81, 473);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.NormalImg = global::SC.View2.Properties.Resources.back_main_226x132_normal;
            this.buttonHome.Size = new System.Drawing.Size(234, 138);
            this.buttonHome.TabIndex = 22;
            this.buttonHome.Text = "返回首页";
            this.buttonHome.TextColor = System.Drawing.Color.White;
            this.buttonHome.TextLeft = 0F;
            this.buttonHome.TextTop = 10F;
            this.buttonHome.Toogle = false;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // CustomerTBVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.qr);
            this.Controls.Add(this.labelPass);
            this.Name = "CustomerTBVerify";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.virtualNumKeyboard, 0);
            this.Controls.SetChildIndex(this.labelPass, 0);
            this.Controls.SetChildIndex(this.qr, 0);
            this.Controls.SetChildIndex(this.textBoxPassword, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPass;
        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl qr;
        private GBY.GBYTextBox textBoxPassword;
        private GBY.GBYButton buttonNext;
        private GBY.GBYButton buttonHome;
    }
}
