using DAO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DAO
{
    public class PostgresSQLDataProvider : IDataProvider
    {
        private static NpgsqlConnection _con;

        public PostgresSQLDataProvider(NpgsqlConnection con)
        {
            //string strConnection = ConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString;
            _con = con;
        }

        public static void ExecuteNoneQuery(string strQuery)
        {
            try
            {
                _con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(strQuery, _con);
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

        public static DataTable ExecuteQuery(string strQuery)
        {
            DataTable dataTable = new DataTable();

            try
            {
                _con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(strQuery, _con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);
            }
            finally
            {
                _con.Close();
            }
            return dataTable;
        }
    }
}
