using InventoryBranchToBranch.Class;
using InventoryBranchToBranch.Connection;
using InventoryBranchToBranch.Interface;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Implement
{
    public class InventoryTransferBranchToBranchImplement : IInventoryTransferBranchToBranch
    {
        private int ErrCode;
        private string ErrMsg;
        public Task<Class.ResponseInventoryTransferBranchToBranch> InventoryTransferBranchToBranchPost(InventoryTransferBranchToBranchPOST data)
        {
            try
            {
                Documents oGoodIssue;
                Documents oGoodReceipt;
                Company oCompany;
                var RetvalGoodIssue = 0;
                var RetvalGoodReceipt = 0;
                //SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();
                SapConnection login = new SapConnection();
                if (login.LErrCode() == 0)
                {
                    oCompany = login.Company;
                    oCompany.StartTransaction();                    
                    oGoodIssue = (Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                    oGoodIssue.Series = data.GoodIssueSeries;
                    oGoodIssue.PaymentGroupCode = data.GoodIssuePriceList;
                    oGoodIssue.DocDate = data.GoodIssueDocumentDate;
                    oGoodIssue.DocDueDate = data.GoodIssueDocumentDate;
                    oGoodIssue.Reference2 = data.GoodIssueRef;
                    oGoodIssue.BPL_IDAssignedToInvoice = data.GoodIssueBranchID;
                    foreach (var l in data.ListItemList)
                    {
                        oGoodIssue.Lines.ItemCode = l.ItemCode;
                        oGoodIssue.Lines.Quantity = l.Quantity;
                        oGoodIssue.Lines.UnitPrice = l.UnitPrice;
                        oGoodIssue.Lines.WarehouseCode = data.GoodIssueWhsCode;
                        oGoodIssue.Lines.AccountCode = l.AccountCode;
                        //oGoodReceiptPO.Lines.DiscountPercent = l.Discount;
                        //oGoodReceiptPO.Lines.UoMEntry = Convert.ToInt32(l.UomName);
                        if (l.ItemType == "S") 
                        {
                            oGoodIssue.Lines.SerialNumbers.Quantity = l.Quantity;
                            oGoodIssue.Lines.SerialNumbers.InternalSerialNumber = l.SerialBatch;
                            oGoodIssue.Lines.SerialNumbers.Add();
                        }
                        else if (l.ItemType == "B")
                        {
                            oGoodIssue.Lines.BatchNumbers.BatchNumber = l.SerialBatch;
                            oGoodIssue.Lines.BatchNumbers.Quantity = l.Quantity;
                            oGoodIssue.Lines.BatchNumbers.Add();
                        }
                        oGoodIssue.Lines.Add();
                    }
                    oGoodReceipt = (Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                    oGoodReceipt.Series = data.GoodReceiptSeries;
                    oGoodReceipt.PaymentGroupCode = data.GoodIssuePriceList;
                    oGoodReceipt.DocDate = data.GoodReceiptDocumentDate;
                    oGoodReceipt.DocDueDate = data.GoodReceiptDocumentDate;
                    oGoodReceipt.Reference2 = data.GoodReceiptRef;
                    oGoodReceipt.BPL_IDAssignedToInvoice = data.GoodReceiptBranchID;
                    foreach (var l in data.ListItemList)
                    {
                        oGoodReceipt.Lines.ItemCode = l.ItemCode;
                        oGoodReceipt.Lines.Quantity = l.Quantity;
                        oGoodReceipt.Lines.UnitPrice = l.UnitPrice;
                        oGoodReceipt.Lines.WarehouseCode = data.GoodReceiptWhsCode;
                        oGoodReceipt.Lines.AccountCode = l.AccountCode;
                        if (l.ItemType == "S")
                        {
                            oGoodReceipt.Lines.SerialNumbers.Quantity = l.Quantity;
                            oGoodReceipt.Lines.SerialNumbers.InternalSerialNumber = l.SerialBatch;
                            oGoodReceipt.Lines.SerialNumbers.Add();
                        }
                        else if (l.ItemType == "B")
                        {
                            oGoodReceipt.Lines.BatchNumbers.BatchNumber = l.SerialBatch;
                            oGoodReceipt.Lines.BatchNumbers.Quantity = l.Quantity;
                            oGoodReceipt.Lines.BatchNumbers.Add();
                        }
                        oGoodReceipt.Lines.Add();
                    }
                    RetvalGoodIssue = oGoodIssue.Add();
                    var docEntryGoodIssue = oCompany.GetNewObjectKey();
                    if (RetvalGoodIssue != 0)
                    {
                        oCompany.GetLastError(out ErrCode, out ErrMsg);
                        if (oCompany.InTransaction) oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        return Task.FromResult(new ResponseInventoryTransferBranchToBranch
                        {
                            ErrorCode = ErrCode,
                            ErrorMsg = ErrMsg,
                            DocEntry = null
                        });
                    }
                    RetvalGoodReceipt = oGoodReceipt.Add();
                    var docEntryGoodReceipt = oCompany.GetNewObjectKey();
                    if (RetvalGoodReceipt != 0)
                    {
                        oCompany.GetLastError(out ErrCode, out ErrMsg);
                        if (oCompany.InTransaction) oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        return Task.FromResult(new ResponseInventoryTransferBranchToBranch
                        {
                            ErrorCode = ErrCode,
                            ErrorMsg = ErrMsg,
                            DocEntry = null
                        });
                    }
                    oCompany.EndTransaction(BoWfTransOpt.wf_Commit);
                    RetiveData rd = new RetiveData();
                    rd.GetData("UpdateDocEntryToGoodIReceptAndUpdateDocEntryToGoodIssue", docEntryGoodReceipt, docEntryGoodIssue, "", "", "");
                    return Task.FromResult(new ResponseInventoryTransferBranchToBranch
                    {
                        ErrorCode = 0,
                        ErrorMsg = "",
                        DocEntry = oCompany.GetNewObjectKey()
                    });
                }

                return Task.FromResult(new ResponseInventoryTransferBranchToBranch
                {
                    ErrorCode = login.LErrCode(),
                    ErrorMsg = login.SErrMsg()
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseInventoryTransferBranchToBranch
                {
                    ErrorCode = ex.HResult,
                    ErrorMsg = ex.Message
                });
            }
        }
    }
}
