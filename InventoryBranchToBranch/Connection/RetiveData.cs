using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Connection
{
    public class RetiveData
    {
        public DataTable GetData(string Type,string par1,string par2,string par3,string par4,string par5)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            //LoginSql loginSql = new LoginSql(LoginSql.Type.SAP);
            var cmd = "EXEC KOFI_ADDON_BRANCH_TO_BRANCH '" + Type + "','" + par1 + "','" + par2 + "','" + par3 + "','" + par4 + "','" + par5 + "'";
            sqlDataAdapter = new SqlDataAdapter("EXEC KOFI_ADDON_BRANCH_TO_BRANCH '" + Type + "','" + par1 + "','" + par2 + "','" + par3 + "','" + par4 + "','" + par5 + "'"
                , new SqlConnection(ConnectionString.SqlConnectionSap));
            try
            {
                sqlDataAdapter.Fill(dataTable);
                var a = dataTable.Rows;
                return dataTable;
            }
            catch
            {
                return null;
            }
        }
    }
}
