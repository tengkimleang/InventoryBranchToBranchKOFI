using InventoryBranchToBranch.Class;
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
    public partial class frmItemNone : Form
    {
        public double QtyItemNone { get; set; }
        public double UnitPriceItemNone { get; set; }
        public frmItemNone(string itemCode, string itemName, string itemType, double price)
        {
            InitializeComponent();
            txtItemCode.Text = itemCode;
            txtDescription.Text = itemName;
            txtQty.Text = "1";
            txtUnitPrice.Text = (1 * price).ToString();
        }

        private void btnAddItemNone_Click(object sender, EventArgs e)
        {
            QtyItemNone = Convert.ToDouble(txtQty.Text.ToString());
            UnitPriceItemNone = Convert.ToDouble(txtUnitPrice.Text.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
