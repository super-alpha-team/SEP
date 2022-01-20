using DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DAO
{
    internal class MySQLDataProvider : IDataProvider
    {
        private static MySqlConnection _con;

        public MySQLDataProvider(MySqlConnection con)
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

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, _con);

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
                MySqlCommand cmd = new MySqlCommand(strQuery, _con);
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
