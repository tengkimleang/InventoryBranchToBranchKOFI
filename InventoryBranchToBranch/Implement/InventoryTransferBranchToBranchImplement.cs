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
                        oGoodIssue.Lines.Quantity = l.Qty;
                        oGoodIssue.Lines.UnitPrice = l.Price;
                        oGoodIssue.Lines.WarehouseCode = data.GoodIssueWhsCode;
                        //oGoodReceiptPO.Lines.DiscountPercent = l.Discount;
                        //oGoodIssue.Lines.WarehouseCode = l.WarehouseCode;
                        //oGoodReceiptPO.Lines.UoMEntry = Convert.ToInt32(l.UomName);
                        
                        if (l.listSerial != null && l.listSerial.Count()>0)
                            foreach (var serial in l.listSerial)
                            {
                                oGoodIssue.Lines.SerialNumbers.Quantity = serial.Qty;
                                oGoodIssue.Lines.SerialNumbers.InternalSerialNumber = serial.Serial;
                                //oGoodIssue.Lines.SerialNumbers.BaseLineNumber = 1;
                                oGoodIssue.Lines.SerialNumbers.Add();
                            }
                        else if (l.listBatches != null && l.listBatches.Count() > 0)
                            foreach (var batch in l.listBatches)
                            {
                                oGoodIssue.Lines.BatchNumbers.BatchNumber = batch.BatcheCode;
                                oGoodIssue.Lines.BatchNumbers.Quantity = batch.Qty;
                                oGoodIssue.Lines.BatchNumbers.ExpiryDate = Convert.ToDateTime(batch.ExpDate);
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
                        oGoodReceipt.Lines.Quantity = l.Qty;
                        oGoodReceipt.Lines.UnitPrice = l.Price;
                        oGoodReceipt.Lines.WarehouseCode = data.GoodReceiptWhsCode;//
                        //oGoodReceiptPO.Lines.DiscountPercent = l.Discount;
                        //oGoodIssue.Lines.WarehouseCode = l.WarehouseCode;
                        //oGoodReceiptPO.Lines.UoMEntry = Convert.ToInt32(l.UomName);

                        if (l.listSerial != null && l.listSerial.Count() > 0)
                            foreach (var serial in l.listSerial)
                            {
                                oGoodReceipt.Lines.SerialNumbers.Quantity = serial.Qty;
                                oGoodReceipt.Lines.SerialNumbers.InternalSerialNumber = serial.Serial;
                                //oGoodIssue.Lines.SerialNumbers.BaseLineNumber = 1;
                                oGoodReceipt.Lines.SerialNumbers.Add();
                            }
                        else if (l.listBatches != null && l.listBatches.Count() > 0)
                            foreach (var batch in l.listBatches)
                            {
                                oGoodReceipt.Lines.BatchNumbers.BatchNumber = batch.BatcheCode;
                                oGoodReceipt.Lines.BatchNumbers.Quantity = batch.Qty;
                                oGoodReceipt.Lines.BatchNumbers.ExpiryDate = Convert.ToDateTime(batch.ExpDate);
                                oGoodReceipt.Lines.BatchNumbers.Add();
                            }
                        oGoodReceipt.Lines.Add();
                    }
                    RetvalGoodIssue = oGoodIssue.Add();
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
