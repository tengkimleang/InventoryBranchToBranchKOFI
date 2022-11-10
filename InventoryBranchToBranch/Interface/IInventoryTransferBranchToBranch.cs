using InventoryBranchToBranch.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Interface
{
    public interface IInventoryTransferBranchToBranch
    {
       Task<ResponseInventoryTransferBranchToBranch> InventoryTransferBranchToBranchPost(InventoryTransferBranchToBranchPOST data);
    }
}
