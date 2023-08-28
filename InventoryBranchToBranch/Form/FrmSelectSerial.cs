using InventoryBranchToBranch.Class;
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

namespace InventoryBranchToBranch
{
    public partial class FrmSelectSerial : Form
    {
        string itemType;
        RetiveData rd = new RetiveData();
        public DataTable dt = new DataTable();
        public List<ItemSerials> listSerials { get; set; }
        public double QtySerial { get; set; }
        public double UnitPriceSerial { get; set; }
        public FrmSelectSerial(string itemCode, string itemName, string itemType, string whsCode, double price)
        {
            InitializeComponent();
            this.itemType = itemType;
            txtItemCode.Text = itemCode;
            txtDescription.Text = itemName;
            txtQty.Text = "1";
            txtUnitPrice.Text = (1 * price).ToString();
            dt = rd.GetData("SERIAL", itemCode, whsCode, "", "", "");
            if (dt.Rows.Count > 0)
            {
                dtGrideAvailable.DataSource = dt;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount = dtGrideAvailable.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = selectedRowCount - 1; i >= 0; i--)
                    {
                        var test = dtGrideAvailable.SelectedRows[i].Cells["ItemCode"].Value.ToString();
                    }
                    var a = 0.0;
                    for (int i = selectedRowCount - 1; i >= 0; i--)
                    {
                        a += Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["Qty"].Value);
                    }
                    for (int i = 0; i < dtSelectedBatches.RowCount; i++)
                    {
                        a += Convert.ToInt32(dtSelectedBatches.Rows[i].Cells["Qty"].Value);
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
                                //dtGrideAvailable.SelectedRows[i].Cells["Quantity"].Value =
                                //        Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["Quantity"].Value)
                                //        - Convert.ToDouble(dtGrideAvailable.SelectedRows[i].Cells["InputQty"].Value);
                                dtSelectedBatches.Rows.Add(
                                                  dtGrideAvailable.SelectedRows[i].Cells["ItemCode"].Value.ToString()
                                                , dtGrideAvailable.SelectedRows[i].Cells["Serial"].Value
                                                , dtGrideAvailable.SelectedRows[i].Cells["Qty"].Value.ToString()
                                                , i
                                                );
                                dtGrideAvailable.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dtSelectedBatches.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                try
                {
                    for (int i = selectedRowCount - 1; i >= 0; i--)
                    {
                        var a = dtSelectedBatches.SelectedRows[i].Cells["ItemCode"].Value.ToString();
                    }
                    for (int i = selectedRowCount - 1; i >= 0; i--)
                    {
                        //dtGrideAvailable.Rows[Convert.ToInt32(dtSelectedBatches.SelectedRows[i].Cells["IndexCell"].Value)].Cells["Quantity"].Value =
                        //                 Convert.ToDouble(dtGrideAvailable.Rows[Convert.ToInt32(dtSelectedBatches.SelectedRows[i].Cells["IndexCell"].Value)].Cells["Quantity"].Value)
                        //                 + Convert.ToDouble(dtSelectedBatches.SelectedRows[i].Cells["Quantity"].Value);

                        DataRow newRow = dt.NewRow();
                        newRow["ItemCode"] = dtSelectedBatches.SelectedRows[i].Cells["ItemCode"].Value.ToString();
                        newRow["Serial"] = dtSelectedBatches.SelectedRows[i].Cells["Serial"].Value.ToString();
                        newRow["Qty"] = dtSelectedBatches.SelectedRows[i].Cells["Qty"].Value.ToString();
                        dt.Rows.Add(newRow);
                        //dtGrideAvailable.Rows.Add(dtSelectedBatches.SelectedRows[i].Cells["ItemCode"].Value.ToString()
                        //                        , dtSelectedBatches.SelectedRows[i].Cells["Serial"].Value.ToString()
                        //                        , dtSelectedBatches.SelectedRows[i].Cells["Qty"].Value.ToString());
                        dtSelectedBatches.Rows.RemoveAt(i);
                    }
                }catch(Exception ex){

                }
            }
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            listSerials = new List<ItemSerials>();
            for (int i = 0; i < dtSelectedBatches.RowCount - 1; i++)
            {
                listSerials.Add(new ItemSerials
                {
                    ItemCode = dtSelectedBatches.Rows[i].Cells["ItemCode"].Value.ToString(),
                    Serial = dtSelectedBatches.Rows[i].Cells["Serial"].Value.ToString(),
                    Qty = Convert.ToDouble(dtSelectedBatches.Rows[i].Cells["Qty"].Value.ToString()),
                });
            }
            this.QtySerial = Convert.ToDouble(txtQty.Text.ToString());
            this.UnitPriceSerial = Convert.ToDouble(txtUnitPrice.Text.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
