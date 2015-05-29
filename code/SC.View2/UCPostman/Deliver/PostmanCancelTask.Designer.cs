namespace SC.View2
{
    partial class PostmanCancelTask
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
            this.buttonCancel = new GBY.GBYButton();
            this.buttonOk = new GBY.GBYButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Checked = false;
            this.buttonCancel.Del_X = 0F;
            this.buttonCancel.Del_Y = 1F;
            this.buttonCancel.DownImg = global::SC.View2.Properties.Resources.back_next_226x132_down;
            this.buttonCancel.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonCancel.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonCancel.HoverImg = null;
            this.buttonCancel.Location = new System.Drawing.Point(512, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormalImg = global::SC.View2.Properties.Resources.back_next_226x132_normal;
            this.buttonCancel.Size = new System.Drawing.Size(398, 177);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "返回之前操作";
            this.buttonCancel.TextColor = System.Drawing.Color.White;
            this.buttonCancel.TextLeft = 0F;
            this.buttonCancel.TextTop = 10F;
            this.buttonCancel.Toogle = false;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Transparent;
            this.buttonOk.Checked = false;
            this.buttonOk.Del_X = 0F;
            this.buttonOk.Del_Y = 1F;
            this.buttonOk.DownImg = global::SC.View2.Properties.Resources.back_main_226x132_down;
            this.buttonOk.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonOk.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonOk.HoverImg = null;
            this.buttonOk.Location = new System.Drawing.Point(99, 287);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.NormalImg = global::SC.View2.Properties.Resources.back_main_226x132_normal;
            this.buttonOk.Size = new System.Drawing.Size(398, 177);
            this.buttonOk.TabIndex = 24;
            this.buttonOk.Text = "确定取消存件";
            this.buttonOk.TextColor = System.Drawing.Color.White;
            this.buttonOk.TextLeft = 0F;
            this.buttonOk.TextTop = 10F;
            this.buttonOk.Toogle = false;
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // PostmanCancelTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "PostmanCancelTask";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GBY.GBYButton buttonCancel;
        private GBY.GBYButton buttonOk;
    }
}
