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

namespace DareneExpressCabinetClient
{
    public partial class frmManager : Form
    {
        PackageManager pm;
        BoxsManager bm;
        IDictionaryEnumerator enu;
        //bool bstate = true;
        public frmManager()
        {
            InitializeComponent();
            SystemController sc = new SystemController();
            pm = PackageManager.GetInstance();
            bm = BoxsManager.GetInstance();
            enu = bm.BoxsDictionary.GetEnumerator();
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewDisableButtonColumn openCol = new DataGridViewDisableButtonColumn();
            openCol.Name = "open";
            DataGridViewDisableButtonColumn deletePackageCol = new DataGridViewDisableButtonColumn();
            deletePackageCol.Name = "deletePackage";
            DataGridViewDisableButtonColumn boxStateCol = new DataGridViewDisableButtonColumn();
            boxStateCol.Name = "boxState";

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
                Box cab = (Box)(enu.Entry.Value);
                dataGridView1.Rows[index].Cells["code"].Value = cab.Code;
                if (cab.IsIdle)
                {
                    dataGridView1.Rows[index].Cells["idle"].Value = "是";

                    btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[index].Cells["deletePackage"];

                    btnCell.Enabled = false;
                    btnCell.ReadOnly = true;
                }
                else
                {
                    dataGridView1.Rows[index].Cells["idle"].Value = "否";

                }
                dataGridView1.Rows[index].Cells["boxState"].Value = "停用";
                switch (cab.CurrentState)
                {
                    case Box.State.Close:
                        dataGridView1.Rows[index].Cells["state"].Value = "关闭";
                        break;
                    case Box.State.Open:
                        dataGridView1.Rows[index].Cells["state"].Value = "打开";
                        break;
                    case Box.State.Fault:
                        dataGridView1.Rows[index].Cells["state"].Value = "不可用";
                        dataGridView1.Rows[index].Cells["boxState"].Value = "启用";
                        break;
                }
                switch (cab.ThisSize)
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
                dataGridView1.Rows[index].Cells["location"].Value = cab.CoordinateInfo.X + "," + cab.CoordinateInfo.Y;
                dataGridView1.Rows[index].Cells["open"].Value = "开门";
                dataGridView1.Rows[index].Cells["deletePackage"].Value = "删除包裹";
                
                index++;

            }
            dataGridView1.Invalidate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int code = (int)dataGridView1.Rows[e.RowIndex].Cells["code"].Value;
            //openbox
            if (e.ColumnIndex == 5)
            {
                bool issuccess = bm.Find(code).Open();
                
                //MessageBox.Show(issuccess.ToString());
                UpdateData();
            }
            //删包裹
            if (e.ColumnIndex == 6)
            {
                DataGridViewDisableButtonCell btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[e.RowIndex].Cells["deletePackage"];
                if (btnCell.Enabled)
                {
                    bool issuccess = pm.TakePackage(code, 2);
                    //MessageBox.Show(issuccess.ToString());
                    UpdateData();
                }    
            }
            //disable box
            if (e.ColumnIndex == 7)
            {
                //DataGridViewDisableButtonCell btnCell = (DataGridViewDisableButtonCell)dataGridView1.Rows[e.RowIndex].Cells["open"];
                if (bm.Find(code).CurrentState == Box.State.Fault)
                {
                    bm.DisableBox(code);
                    //btnCell.Enabled = true;
                    UpdateData();
                }
                else
                {
                    bm.EnableBox(code);
                    UpdateData();
                }
                
            }
        }

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
