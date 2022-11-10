using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public class ItemBatches
    {
        public string ItemCode { get; set; }
        public string BatcheCode { get; set; }
        public double Qty { get; set; }
        public string ExpDate { get; set; }
        public int IndexCell { get; set; }
    }
}
