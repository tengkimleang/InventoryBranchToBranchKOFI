using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public class ItemLine
    {
        public string ItemCode { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        public string ItemType { get; set; }
        public List<ItemBatches> listBatches { get; set; }
        public List<ItemSerials> listSerial { get; set; }
    }
}
