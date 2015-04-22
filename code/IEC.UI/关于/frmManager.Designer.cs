namespace IEC.UI
{
    partial class frmManager
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.backgroundWorkerTest = new System.ComponentModel.BackgroundWorker();
            this.panelCenter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.idle,
            this.state,
            this.size,
            this.location});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(844, 304);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // code
            // 
            this.code.HeaderText = "智能柜号";
            this.code.Name = "code";
            // 
            // idle
            // 
            this.idle.HeaderText = "是否空闲";
            this.idle.Name = "idle";
            // 
            // state
            // 
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            // 
            // size
            // 
            this.size.HeaderText = "大小";
            this.size.Name = "size";
            // 
            // location
            // 
            this.location.HeaderText = "位置";
            this.location.Name = "location";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelBottom.Controls.Add(this.labelTest);
            this.panelBottom.Controls.Add(this.buttonTest);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 304);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(844, 91);
            this.panelBottom.TabIndex = 1;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(193, 40);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(83, 12);
            this.labelTest.TabIndex = 1;
            this.labelTest.Text = "当前测试箱子:";
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTest.Location = new System.Drawing.Point(46, 26);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(119, 47);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "一键测试";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // backgroundWorkerTest
            // 
            this.backgroundWorkerTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTest_DoWork);
            this.backgroundWorkerTest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTest_ProgressChanged);
            this.backgroundWorkerTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTest_RunWorkerCompleted);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.SystemColors.Control;
            this.panelCenter.Controls.Add(this.dataGridView1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(844, 304);
            this.panelCenter.TabIndex = 2;
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 395);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.MinimizeBox = false;
            this.Name = "frmManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "快递柜管理器";
            this.Load += new System.EventHandler(this.frmManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn idle;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelTest;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTest;
        private System.Windows.Forms.Panel panelCenter;
    }
}