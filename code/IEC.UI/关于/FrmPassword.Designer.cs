namespace IEC.UI
{
    partial class FrmPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtnewPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtrepeatPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.labelXInfo = new DevComponents.DotNetBar.LabelX();
            this.txtoldPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // txtnewPassWord
            // 
            // 
            // 
            // 
            this.txtnewPassWord.Border.Class = "TextBoxBorder";
            this.txtnewPassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnewPassWord.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtnewPassWord.Location = new System.Drawing.Point(189, 62);
            this.txtnewPassWord.MaxLength = 13;
            this.txtnewPassWord.Name = "txtnewPassWord";
            this.txtnewPassWord.PasswordChar = '*';
            this.txtnewPassWord.PreventEnterBeep = true;
            this.txtnewPassWord.Size = new System.Drawing.Size(284, 33);
            this.txtnewPassWord.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(96, 63);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 32);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "新密码：";
            // 
            // txtrepeatPassWord
            // 
            // 
            // 
            // 
            this.txtrepeatPassWord.Border.Class = "TextBoxBorder";
            this.txtrepeatPassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtrepeatPassWord.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtrepeatPassWord.Location = new System.Drawing.Point(191, 112);
            this.txtrepeatPassWord.MaxLength = 13;
            this.txtrepeatPassWord.Name = "txtrepeatPassWord";
            this.txtrepeatPassWord.PasswordChar = '*';
            this.txtrepeatPassWord.PreventEnterBeep = true;
            this.txtrepeatPassWord.Size = new System.Drawing.Size(284, 33);
            this.txtrepeatPassWord.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(39, 113);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(146, 32);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "再次确认密码：";
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.ForeColor = System.Drawing.Color.Firebrick;
            this.cancel.Location = new System.Drawing.Point(275, 166);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(132, 52);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.ForeColor = System.Drawing.Color.Firebrick;
            this.confirm.Location = new System.Drawing.Point(108, 166);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(132, 52);
            this.confirm.TabIndex = 3;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // labelXInfo
            // 
            this.labelXInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // 
            // 
            this.labelXInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelXInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXInfo.Location = new System.Drawing.Point(0, 237);
            this.labelXInfo.Name = "labelXInfo";
            this.labelXInfo.Size = new System.Drawing.Size(515, 47);
            this.labelXInfo.TabIndex = 8;
            this.labelXInfo.Text = "密码不得少于7位";
            this.labelXInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtoldPassWord
            // 
            // 
            // 
            // 
            this.txtoldPassWord.Border.Class = "TextBoxBorder";
            this.txtoldPassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtoldPassWord.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtoldPassWord.Location = new System.Drawing.Point(191, 12);
            this.txtoldPassWord.MaxLength = 13;
            this.txtoldPassWord.Name = "txtoldPassWord";
            this.txtoldPassWord.PasswordChar = '*';
            this.txtoldPassWord.PreventEnterBeep = true;
            this.txtoldPassWord.Size = new System.Drawing.Size(284, 33);
            this.txtoldPassWord.TabIndex = 0;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(98, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(87, 32);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "旧密码：";
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 284);
            this.Controls.Add(this.txtoldPassWord);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelXInfo);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.txtrepeatPassWord);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtnewPassWord);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassword";
            this.ShowIcon = false;
            this.Text = "密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtnewPassWord;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtrepeatPassWord;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private DevComponents.DotNetBar.LabelX labelXInfo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtoldPassWord;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}