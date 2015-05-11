namespace SC.View2
{
    partial class PostmanSPGDelivered
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewPG = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPG)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPG.ColumnHeadersHeight = 30;
            this.dataGridViewPG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.pgcode,
            this.dTime});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPG.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPG.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewPG.Location = new System.Drawing.Point(55, 132);
            this.dataGridViewPG.MultiSelect = false;
            this.dataGridViewPG.Name = "dataGridViewPG";
            this.dataGridViewPG.ReadOnly = true;
            this.dataGridViewPG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewPG.RowHeadersVisible = false;
            this.dataGridViewPG.RowTemplate.Height = 23;
            this.dataGridViewPG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPG.Size = new System.Drawing.Size(910, 370);
            this.dataGridViewPG.TabIndex = 1;
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
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(588, 544);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(161, 67);
            this.buttonHome.TabIndex = 10;
            this.buttonHome.Text = "返回主页";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(271, 544);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(161, 67);
            this.buttonRefresh.TabIndex = 9;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // PostmanSPGDelivered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridViewPG);
            this.Name = "PostmanSPGDelivered";
            this.Controls.SetChildIndex(this.dataGridViewPG, 0);
            this.Controls.SetChildIndex(this.buttonRefresh, 0);
            this.Controls.SetChildIndex(this.buttonHome, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pgcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTime;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonRefresh;
    }
}
