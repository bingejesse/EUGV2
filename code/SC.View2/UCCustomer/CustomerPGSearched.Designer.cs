namespace SC.View2
{
    partial class CustomerPGSearched
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridViewPG = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPG)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(629, 546);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 13;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(430, 546);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(161, 67);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPG
            // 
            this.dataGridViewPG.AllowUserToAddRows = false;
            this.dataGridViewPG.AllowUserToDeleteRows = false;
            this.dataGridViewPG.AllowUserToResizeColumns = false;
            this.dataGridViewPG.AllowUserToResizeRows = false;
            this.dataGridViewPG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewPG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewPG.ColumnHeadersHeight = 30;
            this.dataGridViewPG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.pgcode,
            this.dTime});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPG.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewPG.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewPG.Location = new System.Drawing.Point(55, 135);
            this.dataGridViewPG.MultiSelect = false;
            this.dataGridViewPG.Name = "dataGridViewPG";
            this.dataGridViewPG.ReadOnly = true;
            this.dataGridViewPG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewPG.RowHeadersVisible = false;
            this.dataGridViewPG.RowTemplate.Height = 23;
            this.dataGridViewPG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPG.Size = new System.Drawing.Size(910, 370);
            this.dataGridViewPG.TabIndex = 11;
            // 
            // Id
            // 
            this.Id.HeaderText = "序列号";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // pgcode
            // 
            this.pgcode.HeaderText = "快递单号";
            this.pgcode.Name = "pgcode";
            this.pgcode.ReadOnly = true;
            // 
            // dTime
            // 
            this.dTime.HeaderText = "存件时间";
            this.dTime.Name = "dTime";
            this.dTime.ReadOnly = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(231, 546);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(161, 67);
            this.buttonNext.TabIndex = 14;
            this.buttonNext.Text = "继续查询";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // CustomerPGSearched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridViewPG);
            this.Name = "CustomerPGSearched";
            this.Controls.SetChildIndex(this.dataGridViewPG, 0);
            this.Controls.SetChildIndex(this.buttonRefresh, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            this.Controls.SetChildIndex(this.buttonNext, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridViewPG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pgcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTime;
        private System.Windows.Forms.Button buttonNext;
    }
}
