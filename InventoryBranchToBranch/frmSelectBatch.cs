using InventoryBranchToBranch.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPbouiCOM.Framework;
using InventoryBranchToBranch.Class;

namespace InventoryBranchToBranch
{
    public partial class frmSelectBatch : Form
    {
        string itemType;
        RetiveData rd = new RetiveData();
        public DataTable dt = new DataTable();
        public List<ItemBatches> listBatches { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        //List<ItemBatches> listBatches = new List<ItemBatches>();
        public frmSelectBatch(string itemCode, string itemName, string itemType, string whsCode, double price)
        {
            InitializeComponent();
            this.itemType = itemType;
            txtItemCode.Text = itemCode;
            txtDescription.Text = itemName;
            txtQty.Text = "1";
            txtUnitPrice.Text = (1 * price).ToString();
            dt = rd.GetData("Batch", itemCode, whsCode, "", "", "");
            if (dt.Rows.Count > 0)
            {
                dtGrideAvailable.DataSource = dt;
                dtGrideAvailable.Columns["InputQty"].ReadOnly = false;
            }
        }

        private void dtGrideAvailable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }
        

        private void btnUnSelect_Click_1(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dtSelectedBatches.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = selectedRowCount - 1; i >= 0; i--)
                {
                   dtGrideAvailable.Rows[Convert.ToInt32(dtSelectedBatches.SelectedRows[i].Cells["IndexCell"].Value)].Cells["Quantity"].Value =
                                    Convert.ToDouble(dtGrideAvailable.Rows[Convert.ToInt32(dtSelectedBatches.SelectedRows[i].Cells["IndexCell"].Value)].Cells["Quantity"].Value)
                                    + Convert.ToDouble(dtSelectedBatches.SelectedRows[i].Cells["Quantity"].Value);
                   dtSelectedBatches.Rows.RemoveAt(i);
                }
            }
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dtGrideAvailable.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var a = 0.0;
                for (int i = selectedRowCount - 1; i >= 0; i--)
                {
                    a += Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["InputQty"].Value);
                }
                for (int i = 0; i < dtSelectedBatches.RowCount; i++)
                {
                    a += Convert.ToInt32(dtSelectedBatches.Rows[i].Cells["Quantity"].Value);
                }
                if (a < Convert.ToDouble(txtQty.Text.ToString()) || a > Convert.ToDouble(txtQty.Text.ToString()))
                {
                    MessageBox.Show("Greater or Smaller than Qty");
                }
                else
                {
                    if (a != 0)
                    {
                        //List To Do
                        for (int i = selectedRowCount - 1; i >= 0; i--)
                        {
                            dtGrideAvailable.SelectedRows[i].Cells["Quantity"].Value =
                                    Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["Quantity"].Value)
                                    - Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["InputQty"].Value);
                            dtSelectedBatches.Rows.Add(txtItemCode.Text.ToString()
                                            , i
                                            , dtGrideAvailable.SelectedRows[i].Cells["DistNumber"].Value.ToString()
                                            , Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["InputQty"].Value)
                                            , dtGrideAvailable.SelectedRows[i].Cells["ExpDate"].Value.ToString()
                                            );
                        }
                    }
                }
            }
        }

        private void btnAddBatch_Click_1(object sender, EventArgs e)
        {
            listBatches = new List<ItemBatches>();
            for (int i = 0; i < dtSelectedBatches.RowCount-1; i++)
            {
                var a = dtSelectedBatches.Rows[i].Cells["ItemCode"].Value.ToString();
                listBatches.Add(new ItemBatches
                {
                    ItemCode = dtSelectedBatches.Rows[i].Cells["ItemCode"].Value.ToString(),
                    IndexCell = Convert.ToInt32(dtSelectedBatches.Rows[i].Cells["IndexCell"].Value.ToString()),
                    BatcheCode = dtSelectedBatches.Rows[i].Cells["DistNumber"].Value.ToString(),
                    Qty = Convert.ToDouble(dtSelectedBatches.Rows[i].Cells["Quantity"].Value.ToString()),
                    ExpDate = dtSelectedBatches.Rows[i].Cells["ExpDate"].Value.ToString(),
                });
            }
            Qty = Convert.ToDouble(txtQty.Text.ToString());
            UnitPrice = Convert.ToDouble(txtUnitPrice.Text.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtQty_Validating(object sender, CancelEventArgs e)
        {
            int distance;
            if (int.TryParse(txtQty.Text, out distance) == false)
            {
                e.Cancel = true;
                txtQty.Focus();
                MessageBox.Show("Invalid Number");
                // it's a valid integer => you could use the distance variable here
            }
        }


        private void dtGrideAvailable_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dtGrideAvailable.Columns["InputQty"].Index)
            {
                int newInteger;
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    //dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
                    MessageBox.Show("Invalid Value");
                }
            }
        }
    }
}
