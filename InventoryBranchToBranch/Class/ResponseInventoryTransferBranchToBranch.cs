using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Class
{
    public class ResponseInventoryTransferBranchToBranch
    {
        public int ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public string DocNum { get; set; }
        public string EDocNum { get; set; }
        public string DocEntry { get; set; }
    }
}
