using DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DAO
{
    public class MySQLDataProvider : IDataProvider
    {
        private static SqlConnection _con;

        public MySQLDataProvider(SqlConnection con)
        {
            //string strConnection = ConfigurationManager.ConnectionStrings["BookOnlineDB"].ConnectionString;
            _con = con;
        }

        public static DataTable ExecuteQuery(string strQuery)
        {
            DataTable resTable = new DataTable();

            try
            {
                _con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(strQuery, _con);

                adapter.Fill(resTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);
            }
            finally
            {
                _con.Close();
            }

            return resTable;
        }

        public static void ExecuteNoneQuery(string strQuery)
        {
            try
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand(strQuery, _con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);
            }
            finally
            {
                _con.Close();
            }
        }
    }
}
