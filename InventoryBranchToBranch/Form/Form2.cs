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
    public partial class Form2 : Form
    {
        string itemType;
        RetiveData rd = new RetiveData();
        public DataTable dt = new DataTable();
        List<ItemBatches> listBatches = new List<ItemBatches>();
        public Form2(string itemCode, string itemName, string itemType, string whsCode)//double price
        {
            InitializeComponent();
            this.itemType = itemType;
            txtItemCode.Text = itemCode;
            txtDescription.Text = itemName;
            txtQty.Text = "1";
           // txtUnitPrice.Text = (1 * price).ToString();
            //txtLineTotal.Text = (Convert.ToDouble(txtQty.Text.ToString()) * Convert.ToDouble(txtUnitPrice.Text.ToString())).ToString();
            
        }
    }
}
