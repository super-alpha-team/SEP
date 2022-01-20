using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SEP.DAO;
using System.Reflection;

namespace DAO
{

    public class MySQLUserDAO : UserDAO
    {
        IDataProvider dataProvider;
        public MySQLUserDAO(string strConnection)
        {
            _strConnection = strConnection;
            dataProvider = new MySQLDataProvider(new SqlConnection(_strConnection));
        }

        public override List<object> All()
        {
            List<object> lstUserDTO = new List<object>();
            String query = "SELECT * FROM Users";

            DataTable dt = MySQLDataProvider.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                UserDTO userDTO = new UserDTO();
                userDTO.Password = dr["password"].ToString();
                userDTO.Username = dr["username"].ToString();
                userDTO.Role = dr["role"].ToString();
                lstUserDTO.Add(userDTO);
            }
            return lstUserDTO;
        }

        public override DataTable All(bool resultDataTable)
        {
            string query = "SELECT * FROM Users";
            DataTable dt = MySQLDataProvider.ExecuteQuery(query);
            return dt;
        }

        public override void Delete(object a)
        {
            UserDTO userDTO = (UserDTO)a;
            String query = "delete from Users where Username='" + userDTO.Username.ToString() + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Delete(Dictionary<string, string> values)
        {
            string query = "DELETE FROM Users WHERE username='" + values["username"] + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override Dictionary<string, string> GetColumns()
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(UserDTO).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string name = prop.Name;
                string type = prop.PropertyType.ToString();
                columns.Add(name, type);
            }
            return columns;
        }

        public override void Inserṭ̣̣(object a)
        {
            UserDTO userDTO = (UserDTO)a;
            String query = "insert into Users values(N'" + userDTO.Username.ToString() + "',N'" + userDTO.Password + "',N'" + userDTO.Role + "')";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Inserṭ̣̣(Dictionary<string, string> values)
        {
            string query = "INSERT INTO Users values(N'" + values["username"] + "',N'" + values["password"] + "',N'" + values["role"] + "')";
            PostgresSQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Update(object a)
        {
            UserDTO userDTO = (UserDTO)a;
            String query = "update Users set password='" + userDTO.Password + "', role='" + userDTO.Role + "' WHERE username='" + userDTO.Username + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Update(Dictionary<string, string> values)
        {
            string query = "UPDATE Users SET password='" + values["password"] + "', role='" + values["role"] + "' WHERE username='" + values["username"] + "'";
            PostgresSQLDataProvider.ExecuteNoneQuery(query);
        }
    }
}