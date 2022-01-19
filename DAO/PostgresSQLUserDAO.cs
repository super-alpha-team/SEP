using DTO;
using Npgsql;
using SEP.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAO
{
    public class PostgresSQLUserDAO : UserDAO
    {
        public PostgresSQLUserDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        override
        public List<object> All()
        {
            List<object> lstUserDTO = new List<object>();
            string query = "SELECT * FROM \"Users\"";
            IDataProvider provider = new PostgresSQLDataProvider(new NpgsqlConnection(_strConnection));
            DataTable dt = provider.ExecuteQuery(query);
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

        public override void Delete(object a)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetColumns()
        {
            Dictionary<string, string> columns=new Dictionary<string, string>();
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
            throw new NotImplementedException();
        }

        public override void Update(object a)
        {
            throw new NotImplementedException();
        }
    }
}