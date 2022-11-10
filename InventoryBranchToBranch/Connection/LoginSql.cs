using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBranchToBranch.Connection
{
    public class LoginSql
    {
        private string _ErrorMessage;
        private int _ErrorCode;
        private SqlConnection _SqlConnection;
        public int ErrorCode
        {
            get
            {
                return _ErrorCode;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }
        public SqlConnection SqlConnection
        {
            get
            {
                return _SqlConnection;
            }
        }
        public enum Type
        {
            SAP, SQL
        }
        public LoginSql(Type type)
        {
            //ConnectionString.SqlConnectionSap = ConfigurationManager.AppSettings["connectionString"];//"Data Source=SAPP1;Initial Catalog=Test_Kofi_220427;User Id=sa;Password=SAPB1Admin";
            //ConnectionString.SqlConnectionSap = "Data Source=SAPP1;Initial Catalog=DB_KOFI_COLTD_BKK_21-03-22;User Id=sa;Password=SAPB1Admin";
            //ConfigurationManager.AppSettings["connectionString"];
            //ConnectionString.SqlConnectionSap = "Data Source=WIN2012B192;Initial Catalog=DB_KOFI_API_TESTING_10-01-2022;User Id=sa;Password=SAPB1Admin";
            ConnectionSql(type);
        }
        private bool CheckConnection(SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Open) return true; else return false;
        }
        private void ConnectionSql(Type type)
        {
            try
            {
                if (type == Type.SAP)
                {
                    _SqlConnection = new SqlConnection();
                    _SqlConnection.ConnectionString = ConnectionString.SqlConnectionSap;
                    if (CheckConnection(_SqlConnection) == false)
                    {
                        _SqlConnection.Open();
                    }
                }
                else if (type == Type.SQL)
                {
                    _SqlConnection.ConnectionString = ConnectionString.SqlConnectionSap;
                    if (CheckConnection(_SqlConnection) == false)
                    {
                        _SqlConnection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                _ErrorCode = ex.GetHashCode();
                _ErrorMessage = ex.Message;
                _SqlConnection = null;
            }
        }
    }
}
