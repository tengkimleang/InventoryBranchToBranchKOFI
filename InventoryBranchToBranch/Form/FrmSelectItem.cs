using InventoryBranchToBranch.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryBranchToBranch.Class;
using System.Windows.Forms;
using System.Threading;

namespace InventoryBranchToBranch
{
    public partial class FrmSelectItem : Form
    {
        string whsCode;
        string priceList;
        RetiveData rd = new RetiveData();
        public static DataTable dt = new DataTable();
        public Item ItemList { get; set; }
        public List<ItemBatches> listBatches { get; set; }
        public List<ItemSerials> listSerials { get; set; }
        public FrmSelectItem(string item="",string whsCode="",string priceList="")
        {
            InitializeComponent();
            this.whsCode = whsCode;
            this.priceList = priceList;
            dt = rd.GetData("GetItemByFilter", item, whsCode, priceList, "", "");
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txtSearch.Text.ToString() == "")
            {
                dt = rd.GetData("GetItemByFilter", "*", whsCode, priceList, "", "");
            }
            else
            {
                dt = rd.GetData("GetItemByFilter", txtSearch.Text.ToString(), whsCode, priceList, "", "");
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }  
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected && dataGridView1.Rows[e.Row.Index].Selected==true) 
            {
                dataGridView1.Rows[e.Row.Index].Selected = false;
                var rowIndex = e.Row.Index;
                ItemList = new Item();
                ItemList.ItemCode = dataGridView1.Rows[rowIndex].Cells["ItemCode"].Value.ToString();
                ItemList.ItemName = dataGridView1.Rows[rowIndex].Cells["ItemName"].Value.ToString();
                ItemList.OnHand = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OnHand"].Value.ToString());
                ItemList.UnitPrice = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OnHand"].Value.ToString());
                ItemList.ItemType = dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString();
                if (dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString() == "B")
                {
                    frmSelectBatch frm = new frmSelectBatch(dataGridView1.Rows[rowIndex].Cells["ItemCode"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ItemName"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString()
                                            , whsCode
                                            , Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["Price"].Value.ToString())
                                            );// , Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["Price"].Value.ToString())
                    this.Hide();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ItemList.Qty = frm.Qty;
                        ItemList.UnitPrice = frm.UnitPrice;
                        listBatches = frm.listBatches;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        this.Show();
                    }
                }
                else if (dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString() == "S")
                {
                    FrmSelectSerial frm = new FrmSelectSerial(dataGridView1.Rows[rowIndex].Cells["ItemCode"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ItemName"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString()
                                            , whsCode
                                            , Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["Price"].Value.ToString())
                                            );
                    this.Hide();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ItemList.Qty = frm.QtySerial;
                        ItemList.UnitPrice = frm.UnitPriceSerial;
                        listSerials = frm.listSerials;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        this.Show();
                    }
                }
                else
                {
                    frmItemNone frm = new frmItemNone(dataGridView1.Rows[rowIndex].Cells["ItemCode"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ItemName"].Value.ToString()
                                            , dataGridView1.Rows[rowIndex].Cells["ManageItem"].Value.ToString()
                                            , Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["Price"].Value.ToString())
                                            );
                    this.Hide();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ItemList.Qty = frm.QtyItemNone;
                        ItemList.UnitPrice = frm.UnitPriceItemNone;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
        }
    }
}
