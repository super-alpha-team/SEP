using DTO;
using Npgsql;
using SEP.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        public List<UserDTO> All()
        {
            List<UserDTO> lstUserDTO = new List<UserDTO>();
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
        
        override
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        override
        public void Insert()
        {
            throw new System.NotImplementedException();
        }

        override
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}