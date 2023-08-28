using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public class InventoryTransferBranchToBranchPOST
    {
        public int GoodReceiptSeries { get; set; }
        public int GoodReceiptPriceList { get; set; }
        public DateTime GoodReceiptDocumentDate { get; set; }
        public string GoodReceiptRef { get; set; }
        public int GoodReceiptBranchID { get; set; }
        public string GoodReceiptWhsCode { get; set; }
        public int GoodIssueSeries { get; set; }
        public int GoodIssuePriceList { get; set; }
        public DateTime GoodIssueDocumentDate { get; set; }
        public string GoodIssueRef { get; set; }
        public int GoodIssueBranchID { get; set; }
        public string GoodIssueWhsCode { get; set; }
        public List<GetItemListFromExcel> ListItemList { get; set; }
    }
}
