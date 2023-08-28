using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public sealed class GetItemListFromExcel
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string AccountCode { get; set; }
        public string SerialBatch { get; set; }
        public string ItemType { get; set; }
        //public string BranchCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
