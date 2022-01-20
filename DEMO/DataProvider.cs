using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DEMO
{
    public class DataProvider
    {
        private static NpgsqlConnection _con;

        private DataProvider() { }

        public static void Init(NpgsqlConnection con)
        {
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
