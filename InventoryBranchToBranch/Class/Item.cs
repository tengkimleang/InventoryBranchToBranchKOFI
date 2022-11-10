using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double Qty { get; set; }
        public string ItemType { get; set; }
        public double OnHand { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
        public int LineNum { get; set; }
    }
}
