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
            this.buttonTakePG = new GBY.GBYButton();
            this.buttonSearch = new GBY.GBYButton();
            this.SuspendLayout();
            // 
            // buttonTakePG
            // 
            this.buttonTakePG.BackColor = System.Drawing.Color.Transparent;
            this.buttonTakePG.Checked = false;
            this.buttonTakePG.Del_X = 0F;
            this.buttonTakePG.Del_Y = 1F;
            this.buttonTakePG.DownImg = global::SC.View2.Properties.Resources.button_custom_getpackage_down;
            this.buttonTakePG.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonTakePG.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonTakePG.HoverImg = null;
            this.buttonTakePG.Location = new System.Drawing.Point(102, 268);
            this.buttonTakePG.Name = "buttonTakePG";
            this.buttonTakePG.NormalImg = global::SC.View2.Properties.Resources.button_custom_getpackage_normal;
            this.buttonTakePG.Size = new System.Drawing.Size(398, 177);
            this.buttonTakePG.TabIndex = 2;
            this.buttonTakePG.Text = "取快递";
            this.buttonTakePG.TextColor = System.Drawing.Color.White;
            this.buttonTakePG.TextLeft = -20F;
            this.buttonTakePG.TextTop = 10F;
            this.buttonTakePG.Toogle = false;
            this.buttonTakePG.UseVisualStyleBackColor = false;
            this.buttonTakePG.Click += new System.EventHandler(this.buttonTakePG_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.Checked = false;
            this.buttonSearch.Del_X = 0F;
            this.buttonSearch.Del_Y = 1F;
            this.buttonSearch.DownImg = global::SC.View2.Properties.Resources.button_custom_query_down;
            this.buttonSearch.Font = new System.Drawing.Font("方正中倩简体", 36F);
            this.buttonSearch.HighLight = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.buttonSearch.HoverImg = null;
            this.buttonSearch.Location = new System.Drawing.Point(525, 268);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.NormalImg = global::SC.View2.Properties.Resources.button_custom_query_normal;
            this.buttonSearch.Size = new System.Drawing.Size(398, 177);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "查询快递";
            this.buttonSearch.TextColor = System.Drawing.Color.White;
            this.buttonSearch.TextLeft = 50F;
            this.buttonSearch.TextTop = 10F;
            this.buttonSearch.Toogle = false;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
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

        private GBY.GBYButton buttonTakePG;
        private GBY.GBYButton buttonSearch;

    }
}
