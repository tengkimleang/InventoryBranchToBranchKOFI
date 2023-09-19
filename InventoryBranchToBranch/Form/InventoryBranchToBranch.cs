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
using SAPbouiCOM.Framework;
using InventoryBranchToBranch.Interface;
using InventoryBranchToBranch.Implement;
using System.IO;
using System.Threading;
using InventoryBranchToBranch.Lib;

namespace InventoryBranchToBranch
{
    public partial class InventoryBranchToBranch : Form
    {
        RetiveData rd = new RetiveData();
        List<Item> ListItem { get; set; }
        List<GetItemListFromExcel> ListItemLine = new List<GetItemListFromExcel>();
        public InventoryBranchToBranch()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = rd.GetData("SERIES", "60", "", "", "", "");
            cboSeries.DisplayMember = "SeriesName";
            cboSeries.ValueMember = "Series";
            cboSeries.DataSource = dt;
            txtMaxNumberGoodIssue.Text = "-----";//dt.Rows[0]["DocNum"].ToString();
            dt = new DataTable();
            dt = rd.GetData("SERIES", "59", "", "", "", "");
            cboSeriesGoodReceipt.DisplayMember = "SeriesName";
            cboSeriesGoodReceipt.ValueMember = "Series";
            cboSeriesGoodReceipt.DataSource = dt;
            txtDocNumGoodReceipt.Text = "----";//dt.Rows[0]["DocNum"].ToString();
            txtDocNumGoodReceipt.Enabled = false;
            dt = new DataTable();
            dt = rd.GetData("PriceList", "", "", "", "", "");
            cboPriceList.DisplayMember = "Name";
            cboPriceList.ValueMember = "Code";
            cboPriceList.DataSource = dt;
            dt = new DataTable();
            dt = rd.GetData("Branch", "", "", "", "", "");
            cboGoodIssueBranch.DisplayMember = "Name";
            cboGoodIssueBranch.ValueMember = "Code";
            cboGoodIssueBranch.DataSource = dt;
            dt = new DataTable();
            dt = rd.GetData("Branch", "", "", "", "", "");
            cboGoodReceiptBranch.DisplayMember = "Name";
            cboGoodReceiptBranch.ValueMember = "Code";
            cboGoodReceiptBranch.DataSource = dt;
            //dataGridView1.DataSource = lsItem;
            //dataGridView1.AllowUserToAddRows = true;
            //dataGridView1.AllowUserToDeleteRows = true;
            //dataGridView1.EditModeChange;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete")
            //{
            //    //if MessageBox.Show("Are you sure to Delete")
            //    var itemToRemove = ListItemLine.SingleOrDefault(r => 
            //                                                    r.ItemCode == dataGridView1.Rows[e.RowIndex].Cells["ItemCode"].Value &&
            //                                                    r.Quantity == Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value) &&
            //                                                    r.UnitPrice == Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Total"].Value)
            //                                                    );
            //    if (itemToRemove != null)
            //        ListItemLine.Remove(itemToRemove);
            //    dataGridView1.Rows.RemoveAt(e.RowIndex);
            //    var a = 1;
            //    for (int i = 0; i < dataGridView1.RowCount; i++)
            //    {
            //        dataGridView1.Rows[i].Cells["No"].Value = a;
            //        a++;
            //    }
            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ItemCode")
            {
                
            }
        }

        private void cboGoodIssueBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboGoodIssueBranch.SelectedValue != null)
            {
                DataTable dt = new DataTable();
                dt = rd.GetData("WHsByBranch", cboGoodIssueBranch.SelectedValue.ToString(), "", "", "", "");
                txtWhsFrom.Text = dt.Rows[0][0].ToString();
            }

        }

        private void cboGoodReceiptBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboGoodReceiptBranch.SelectedValue != null)
            {
                DataTable dt = new DataTable();
                dt = rd.GetData("WHsByBranch", cboGoodReceiptBranch.SelectedValue.ToString(), "", "", "", "");
                txtWhsTo.Text = dt.Rows[0][0].ToString();
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView1.Rows[e.Row.Index].Cells["No"].Value = e.Row.Index + 1;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            #region Comment
            //if (e.StateChanged == DataGridViewElementStates.Selected && dataGridView1.Rows[e.Row.Index].Selected == true) 
            //{ 
            //    var rowIndex = e.Row.Index;
            //    dataGridView1.Rows[e.Row.Index].Selected = false;
            //    FrmSelectItem frm = new FrmSelectItem("*", txtWhsFrom.Text, cboPriceList.SelectedValue.ToString());
            //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        dataGridView1.Rows.Add(rowIndex + 1
            //                              , frm.ItemList.ItemCode
            //                              , frm.ItemList.ItemName
            //                              , frm.ItemList.Qty
            //                              , frm.ItemList.UnitPrice
            //                              , frm.ItemList.Qty * frm.ItemList.UnitPrice);
            //        if (frm.ItemList.ItemType == "B")
            //        {
            //            ListItemLine.Add(new GetItemListFromExcel
            //            {
            //                ItemCode = frm.ItemList.ItemCode,
            //                ItemType = frm.ItemList.ItemType,
            //                listBatches = frm.listBatches,
            //                Price = frm.ItemList.UnitPrice,
            //                Qty = frm.ItemList.Qty
            //            });
            //        }
            //        else if (frm.ItemList.ItemType == "S")
            //        {
            //            ListItemLine.Add(new GetItemListFromExcel
            //            {
            //                ItemCode = frm.ItemList.ItemCode,
            //                ItemType = frm.ItemList.ItemType,
            //                listSerial = frm.listSerials,
            //                Price = frm.ItemList.UnitPrice,
            //                Qty = frm.ItemList.Qty
            //            });
            //        }
            //        else
            //        {
            //            ListItemLine.Add(new GetItemListFromExcel
            //            {
            //                ItemCode = frm.ItemList.ItemCode,
            //                ItemType = frm.ItemList.ItemType,
            //                Price = frm.ItemList.UnitPrice,
            //                Qty = frm.ItemList.Qty
            //            });
            //        }

            //        //dataGridView1.Rows[rowIndex].Cells["ItemCode"].Value = frm.ItemList.ItemCode;
            //        //dataGridView1.Rows[rowIndex].Cells["ItemName"].Value = frm.ItemList.ItemName;
            //        //dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = 1;
            //        //dataGridView1.Rows[rowIndex].Cells["UnitPrice"].Value = frm.ItemList.UnitPrice;
            //        //dataGridView1.Rows[rowIndex].Cells["Total"].Value = 1 * frm.ItemList.UnitPrice;
            //    }
            //}
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to add this transaction?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                IInventoryTransferBranchToBranch iInventoryTransferBranchToBranch = new InventoryTransferBranchToBranchImplement();
                InventoryTransferBranchToBranchPOST data = new InventoryTransferBranchToBranchPOST();
                //Good Issue
                data.GoodIssueSeries = Convert.ToInt32(cboSeries.SelectedValue.ToString());
                data.GoodIssuePriceList = Convert.ToInt32(cboPriceList.SelectedValue.ToString());
                data.GoodIssueDocumentDate = Convert.ToDateTime(dtpDocDate.Value);
                data.GoodIssueRef = txtRefGoodIssue.Text.ToString();
                data.GoodIssueBranchID = Convert.ToInt32(cboGoodIssueBranch.SelectedValue);
                data.GoodIssueWhsCode = txtWhsFrom.Text.ToString();

                //Good Receipt
                data.GoodReceiptSeries = Convert.ToInt32(cboSeriesGoodReceipt.SelectedValue.ToString());
                data.GoodReceiptPriceList = Convert.ToInt32(cboPriceList.SelectedValue.ToString());
                data.GoodReceiptDocumentDate = Convert.ToDateTime(dtpDocDate.Value);
                data.GoodReceiptRef = txtRefGoodReceipt.Text.ToString();
                data.GoodReceiptBranchID = Convert.ToInt32(cboGoodReceiptBranch.SelectedValue.ToString());
                data.GoodReceiptWhsCode = txtWhsTo.Text.ToString();
                data.ListItemList = ListItemLine;
                frmLoading frm = new frmLoading();
                frm.Show();
                var a = iInventoryTransferBranchToBranch.InventoryTransferBranchToBranchPost(data).Result;
                frm.Close();
                if (a.ErrorCode != 0)
                {
                    MessageBox.Show("Error Code " + a.ErrorCode + ": " + a.ErrorMsg.ToString());
                }
                else
                {
                    MessageBox.Show("Successful");//+ a.DocEntry
                    dataGridView1.DataSource=null;
                    ListItemLine.Clear();
                }
            }
        }

        private async void btnUploadExcelFile_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";//x
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            }));
            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            // e.g C:\Users\MyName\Desktop\myfile.json
            Console.WriteLine(selectedPath);
            var exportPath = new LoadExcelToDataTable();
            var z=await exportPath.LoadExcel(selectedPath);
            ListItemLine = z.Data;
            dataGridView1.DataSource = ListItemLine;
        }
    }
}
