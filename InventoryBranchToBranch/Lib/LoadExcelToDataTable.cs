using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryBranchToBranch.Class;

namespace InventoryBranchToBranch.Lib
{
    public class LoadExcelToDataTable
    {
        public Task<ResponseData<List<GetItemListFromExcel>>> LoadExcel(string filePath)
        {
            try
            {
                #region Export
                var sheetName = "Sheet1";

                //Use this connection string if you have Office 2007+ drivers installed and 
                //your data is saved in a .xlsx file
                var connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;
                                                  Data Source={filePath};
                                                  Extended Properties=""Excel 12.0 Xml;HDR=YES""";

                //Creating and opening a data connection to the Excel sheet 
                using (var conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM [{sheetName}$]";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                    dataAdapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    var obj = new List<GetItemListFromExcel>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (/*dataTable.Rows.IndexOf(row) != 0 && */!string.IsNullOrEmpty(row[0].ToString()))
                        {
                            obj.Add(new GetItemListFromExcel
                            {
                                ItemCode = row[0].ToString(),
                                ItemName = row[1].ToString(),
                                Quantity = Convert.ToInt32(row[2].ToString()),
                                UnitPrice = Convert.ToDouble(row[3].ToString()),
                                TotalPrice = Convert.ToDouble(row[4].ToString()),
                                AccountCode = row[5].ToString(),
                                SerialBatch = row[6].ToString(),
                                ItemType = row[7].ToString(),
                                //WhsCode = row[6].ToString(),
                                //BranchCode = row[7].ToString()
                            });
                        }
                    }
                    return Task.FromResult(new ResponseData<List<GetItemListFromExcel>>
                    {
                        ErrorCode = 0,
                        Data = obj
                    });
                }
                #endregion
            }
            catch (Exception ex)
            {
                Task.FromResult(new ResponseData<List<GetItemListFromExcel>>
                {
                    ErrorCode = ex.HResult,
                    ErrorMessage = ex.Message,
                });
            }
            return Task.FromResult(new ResponseData<List<GetItemListFromExcel>>
            {
                ErrorCode = -1,
                ErrorMessage = "Internal Error Contact System Admin",
            });
        }
    }
}
