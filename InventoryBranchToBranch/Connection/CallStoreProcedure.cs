using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Connection
{
    public class CallStoreProcedure
    {
        public static SqlCommand CallStoreProcedure1(string type, string par1, string par2, string par3, string par4,string par5)
        {
            SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = loginSql.SqlConnection;
            sqlCommand.CommandText = "EXEC KOFI_ADDON_BRANCH_TO_BRANCH '"+type+"','"+par1+"','"+par2+"','"+par3+"','"+par4+"','"+par5+"'";
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.CommandText = "KOFI_ADDON_BRANCH_TO_BRANCH"; //[_USP_Call_AddON]
            //sqlCommand.Parameters.AddWithValue("@Type", type);
            //sqlCommand.Parameters.AddWithValue("@Par1", par1);
            //sqlCommand.Parameters.AddWithValue("@Par2", par2);
            //sqlCommand.Parameters.AddWithValue("@Par3", par3);
            //sqlCommand.Parameters.AddWithValue("@Par4", par4);
            //sqlCommand.Parameters.AddWithValue("@Par5", par5);
            return sqlCommand;
        }
    }
}
