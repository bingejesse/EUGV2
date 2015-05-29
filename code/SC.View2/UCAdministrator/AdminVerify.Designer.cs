namespace SC.View2
{
    partial class AdminVerify
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable2 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer2 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.virtualNumKeyboard = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUser.Location = new System.Drawing.Point(143, 190);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(73, 29);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "卡号";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPass.Location = new System.Drawing.Point(558, 190);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(73, 29);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "密码";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUser.Location = new System.Drawing.Point(225, 183);
            this.textBoxUser.MaxLength = 15;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(246, 41);
            this.textBoxUser.TabIndex = 0;
            this.textBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPassword.Location = new System.Drawing.Point(641, 187);
            this.textBoxPassword.MaxLength = 15;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(246, 41);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(292, 509);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(169, 67);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "下一步";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(560, 509);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(169, 67);
            this.buttonHome.TabIndex = 3;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // virtualNumKeyboard
            // 
            this.virtualNumKeyboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            virtualKeyboardColorTable2.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable2.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable2.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable2.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable2.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable2.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable2.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable2.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable2.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable2.TopBarTextColor = System.Drawing.Color.White;
            this.virtualNumKeyboard.ColorTable = virtualKeyboardColorTable2;
            this.virtualNumKeyboard.IsTopBarVisible = false;
            this.virtualNumKeyboard.Location = new System.Drawing.Point(134, 250);
            this.virtualNumKeyboard.Name = "virtualNumKeyboard";
            flatStyleRenderer2.ColorTable = virtualKeyboardColorTable2;
            flatStyleRenderer2.ForceAntiAlias = false;
            this.virtualNumKeyboard.Renderer = flatStyleRenderer2;
            this.virtualNumKeyboard.Size = new System.Drawing.Size(753, 230);
            this.virtualNumKeyboard.TabIndex = 13;
            this.virtualNumKeyboard.Text = "keyboardControl1";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVersion.Location = new System.Drawing.Point(547, 635);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(470, 29);
            this.labelVersion.TabIndex = 14;
            this.labelVersion.Text = "客户端版本号：1.1.100";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdminVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.virtualNumKeyboard);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.Name = "AdminVerify";
            this.Controls.SetChildIndex(this.labelUser, 0);
            this.Controls.SetChildIndex(this.labelPass, 0);
            this.Controls.SetChildIndex(this.textBoxUser, 0);
            this.Controls.SetChildIndex(this.textBoxPassword, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.virtualNumKeyboard, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonHome;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl virtualNumKeyboard;
        private System.Windows.Forms.Label labelVersion;
    }
}
