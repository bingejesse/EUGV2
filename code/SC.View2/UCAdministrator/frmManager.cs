using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DareneExpressCabinetClient.Resource;
using System.Collections;
using DareneExpressCabinetClient.Controller;
using System.Windows.Forms.VisualStyles;
using DareneExpressCabinetClient;
using System.Diagnostics;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;
using Domain;

namespace SC.View2
{
    public partial class frmManager : Form
    {
        PackageManager pm;
        BoxsManager bm;
        ServerService serverService;
        IDictionaryEnumerator enu;
        //bool bstate = true;

        private const string openColName = "开/关";
        private const string deletePackageColName = "删除包裹";
        private const string boxStateColName = "箱子状态";

        public frmManager()
        {
            InitializeComponent();
            
            pm = PackageManager.GetInstance();
            bm = BoxsManager.GetInstance();
            serverService = ServicesFactory.GetInstance().GetServerService();
            enu = bm.BoxsDictionary.GetEnumerator();
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewDisableButtonColumn openCol = new DataGridViewDisableButtonColumn();
            openCol.Name = openColName;
            DataGridViewDisableButtonColumn deletePackageCol = new DataGridViewDisableButtonColumn();
            deletePackageCol.Name = deletePackageColName;
            DataGridViewDisableButtonColumn boxStateCol = new DataGridViewDisableButtonColumn();
            boxStateCol.Name = boxStateColName;

            dataGridView1.Columns.Add(openCol);
            dataGridView1.Columns.Add(deletePackageCol);
            dataGridView1.Columns.Add(boxStateCol);
            Initialize();
            UpdateData();
        }
        private void Initialize()
        {
            for (int i = 0; i < bm.BoxsDictionary.Count; i++)
            {
                dataGridView1.Rows.Add();
            }
        }

        private void UpdateData()
        {
            DataGridViewDisableButtonCell btnCell;
            enu = bm.BoxsDictionary.GetEnumerator();
            int index = 0;
            while (enu.MoveNext())
            {
                Box box = (Box)(enu.Entry.Value);
                dataGridView1.Rows[index].Cells["code"].Value = box.Code;
                if (box.IsIdle)
                {
                    dataGridView1.Rows[index].Cells["idle"].Value = "√";

                    btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[index].Cells[deletePackageColName];

                    btnCell.Enabled = false;
                    btnCell.ReadOnly = true;
                }
                else
                {
                    dataGridView1.Rows[index].Cells["idle"].Value = "×";

                }
                dataGridView1.Rows[index].Cells[boxStateColName].Value = "停用";
                switch (box.CurrentState)
                {
                    case Box.State.Close:
                        dataGridView1.Rows[index].Cells["state"].Value = "----";
                        break;
                    case Box.State.Open:
                        dataGridView1.Rows[index].Cells["state"].Value = "----";
                        break;
                    case Box.State.Fault:
                        dataGridView1.Rows[index].Cells["state"].Value = "停用";
                        dataGridView1.Rows[index].Cells[boxStateColName].Value = "启用";
                        break;
                }
                switch (box.ThisSize)
                {
                    case Box.Size.S:
                        dataGridView1.Rows[index].Cells["size"].Value = "小";
                        break;
                    case Box.Size.M:
                        dataGridView1.Rows[index].Cells["size"].Value = "中";
                        break;
                    case Box.Size.L:
                        dataGridView1.Rows[index].Cells["size"].Value = "大";
                        break;
                }
                dataGridView1.Rows[index].Cells["location"].Value = box.CoordinateInfo.X.ToString() + box.CoordinateInfo.Y.ToString();
                dataGridView1.Rows[index].Cells[openColName].Value = "开门";
                dataGridView1.Rows[index].Cells[deletePackageColName].Value = "删除包裹";
                
                index++;

            }
            dataGridView1.Invalidate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int code = (int)dataGridView1.Rows[e.RowIndex].Cells["code"].Value;
                //openbox
                if (e.ColumnIndex == 5)
                {
                    bool issuccess = bm.Find(code).Open();
                    UpdateData();

                    CLog4net.LogInfo("管理员开箱："+code);
                }
                //删包裹
                if (e.ColumnIndex == 6)
                {
                    DataGridViewDisableButtonCell btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[e.RowIndex].Cells[deletePackageColName];
                    if (btnCell.Enabled)
                    {
                        DialogResult dr = MessageBox.Show("确认操作", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (dr == DialogResult.Cancel)
                        {
                            return;
                        }

                        BoxsManager.GetInstance().ClearBox(code);
                        //MessageBox.Show(issuccess.ToString());
                        UpdateData();

                        bool issuccess = pm.TakePackage(code, 2);
                        CLog4net.LogInfo("管理员删除包裹：" + code + " success:" + issuccess);

                        ServerCallback3 sc= serverService.ManagerDeletePackage(code.ToString(), AboutConfig.GetInstance().GetAbout());
                        if (!sc.Success)
                        {
                            CLog4net.LogInfo("管理员删除包裹失败：" + code + " 服务器信息：" + sc.Message);
                            //return; //如果是因为服务器找不到需要删除的包裹，删包裹失败返回，那么客户端箱子将永远不能清空；
                        }
                    }
                }
                //disable box
                if (e.ColumnIndex == 7)
                {
                    DialogResult dr = MessageBox.Show("确认操作", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    //DataGridViewDisableButtonCell btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[e.RowIndex].Cells["open"];
                    if (bm.Find(code).CurrentState == Box.State.Fault)
                    {
                        bm.EnableBox(code);
                        //btnCell.Enabled = true;
                        UpdateData();

                        CLog4net.LogInfo("管理员启用箱子：" + code);
                    }
                    else
                    {
                        bm.DisableBox(code);
                        UpdateData();

                        CLog4net.LogInfo("管理员停用箱子：" + code);
                    }

                }
            }
            catch (Exception ex)
            {
                CLog4net.LogError("管理员操作异常："+ex.ToString());
            }
            
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

        }

        #region 一键测试

        private bool isTesting = false;
        private string testInfo = "";
        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (isTesting)
            {
                return;
            }
            this.buttonTest.Enabled = false;
            this.isTesting = true;
            backgroundWorkerTest.WorkerReportsProgress = true; // 设置可以通告进度
            backgroundWorkerTest.WorkerSupportsCancellation = true; // 设置可以取消
            backgroundWorkerTest.RunWorkerAsync(this);
        }

        int index = 0;
        private void TestAllBoxs()
        {
            CLog4net.LogInfo("管理员一键开箱");
            IDictionaryEnumerator enu = bm.BoxsDictionary.GetEnumerator();

            while (enu.MoveNext())
            {
                Box cab = (Box)(enu.Entry.Value);

                if (!cab.CurrentState.Equals(Box.State.Fault))
                {
                    index += 1;
                    cab.Open();
                    testInfo = string.Format("当前测试箱子：{0}", cab.CoordinateInfo.X.ToString() + cab.CoordinateInfo.Y.ToString());
                    this.backgroundWorkerTest.ReportProgress(index, testInfo);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void backgroundWorkerTest_DoWork(object sender, DoWorkEventArgs e)
        {
            TestAllBoxs();
        }

        private void backgroundWorkerTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.labelTest.Text = e.UserState.ToString();
        }

        private void backgroundWorkerTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.labelTest.Text = "测试完成";
            this.isTesting = false;
            this.buttonTest.Enabled = true;
        }

        #endregion

    }

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }

    }
}
