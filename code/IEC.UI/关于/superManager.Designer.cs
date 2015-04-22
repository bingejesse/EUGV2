namespace IEC.UI
{
    partial class superManager
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
            DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable virtualKeyboardColorTable1 = new DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable();
            DevComponents.DotNetBar.Keyboard.FlatStyleRenderer flatStyleRenderer1 = new DevComponents.DotNetBar.Keyboard.FlatStyleRenderer();
            this.errMsg = new DevComponents.DotNetBar.LabelX();
            this.superLogin = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.superNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.virtualNumKeyboard = new DevComponents.DotNetBar.Keyboard.KeyboardControl();
            this.SuspendLayout();
            // 
            // errMsg
            // 
            this.errMsg.AutoSize = true;
            // 
            // 
            // 
            this.errMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.errMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errMsg.ForeColor = System.Drawing.Color.Red;
            this.errMsg.Location = new System.Drawing.Point(91, 231);
            this.errMsg.Name = "errMsg";
            this.errMsg.Size = new System.Drawing.Size(0, 0);
            this.errMsg.TabIndex = 8;
            // 
            // superLogin
            // 
            this.superLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.superLogin.BackColor = System.Drawing.Color.White;
            this.superLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.superLogin.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superLogin.Location = new System.Drawing.Point(811, 217);
            this.superLogin.Name = "superLogin";
            this.superLogin.Size = new System.Drawing.Size(121, 48);
            this.superLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.superLogin.Symbol = "";
            this.superLogin.TabIndex = 7;
            this.superLogin.Text = "确定";
            this.superLogin.Click += new System.EventHandler(this.superLogin_Click);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.ForeColor = System.Drawing.Color.White;
            this.labelX6.Location = new System.Drawing.Point(91, 72);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(281, 46);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "请输入管理员账号：";
            // 
            // superNum
            // 
            // 
            // 
            // 
            this.superNum.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superNum.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superNum.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superNum.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superNum.Border.Class = "TextBoxBorder";
            this.superNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superNum.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superNum.Location = new System.Drawing.Point(378, 68);
            this.superNum.MaxLength = 13;
            this.superNum.Name = "superNum";
            this.superNum.PreventEnterBeep = true;
            this.superNum.Size = new System.Drawing.Size(360, 50);
            this.superNum.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(91, 157);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(281, 46);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "请输入管理员密码：";
            // 
            // superPwd
            // 
            // 
            // 
            // 
            this.superPwd.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superPwd.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superPwd.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superPwd.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Etched;
            this.superPwd.Border.Class = "TextBoxBorder";
            this.superPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superPwd.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superPwd.Location = new System.Drawing.Point(378, 153);
            this.superPwd.MaxLength = 13;
            this.superPwd.Name = "superPwd";
            this.superPwd.PasswordChar = '*';
            this.superPwd.PreventEnterBeep = true;
            this.superPwd.Size = new System.Drawing.Size(360, 50);
            this.superPwd.TabIndex = 6;
            this.superPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.superPwd_KeyUp);
            // 
            // virtualNumKeyboard
            // 
            this.virtualNumKeyboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            virtualKeyboardColorTable1.BackgroundColor = System.Drawing.Color.Black;
            virtualKeyboardColorTable1.DarkKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            virtualKeyboardColorTable1.DownKeysColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.DownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            virtualKeyboardColorTable1.KeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            virtualKeyboardColorTable1.LightKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            virtualKeyboardColorTable1.PressedKeysColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(81)))));
            virtualKeyboardColorTable1.TextColor = System.Drawing.Color.White;
            virtualKeyboardColorTable1.ToggleTextColor = System.Drawing.Color.Green;
            virtualKeyboardColorTable1.TopBarTextColor = System.Drawing.Color.White;
            this.virtualNumKeyboard.ColorTable = virtualKeyboardColorTable1;
            this.virtualNumKeyboard.IsTopBarVisible = false;
            this.virtualNumKeyboard.Location = new System.Drawing.Point(91, 285);
            this.virtualNumKeyboard.Name = "virtualNumKeyboard";
            flatStyleRenderer1.ColorTable = virtualKeyboardColorTable1;
            flatStyleRenderer1.ForceAntiAlias = false;
            this.virtualNumKeyboard.Renderer = flatStyleRenderer1;
            this.virtualNumKeyboard.Size = new System.Drawing.Size(841, 230);
            this.virtualNumKeyboard.TabIndex = 12;
            this.virtualNumKeyboard.Text = "keyboardControl1";
            // 
            // superManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.virtualNumKeyboard);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.superPwd);
            this.Controls.Add(this.errMsg);
            this.Controls.Add(this.superLogin);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.superNum);
            this.Name = "superManager";
            this.Size = new System.Drawing.Size(1024, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX errMsg;
        private DevComponents.DotNetBar.ButtonX superLogin;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX superNum;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX superPwd;
        private DevComponents.DotNetBar.Keyboard.KeyboardControl virtualNumKeyboard;
    }
}
