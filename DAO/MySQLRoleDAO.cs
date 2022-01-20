using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data;
using SEP.DAO;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace DAO
{
    internal class MySQLRoleDAO : RoleDAO
    {
        public MySQLRoleDAO(string strConnection)
        {
            _strConnection = strConnection;
            IDataProvider dataProvider = new MySQLDataProvider(new MySqlConnection(_strConnection));
        }

        public override List<object> All()
        {
            List<object> lstRoleDTO = new List<object>();
            String query = "SELECT * FROM Role";

            DataTable dt = MySQLDataProvider.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                RoleDTO roleDTO = new RoleDTO();
                roleDTO.RoleName = dr["rolename"].ToString();
                //roleDTO.Id = dr["id"].ToString();

                lstRoleDTO.Add(roleDTO);
            }
            return lstRoleDTO;
        }

        public override DataTable All(bool resultDataTable)
        {
            string query = "SELECT * FROM Roles";
            DataTable dt = MySQLDataProvider.ExecuteQuery(query);
            return dt;
        }

        public override void Delete(object a)
        {
            RoleDTO roleDTO = (RoleDTO)a;
            String query = "delete from Role where id='" + roleDTO.Id.ToString() + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Delete(Dictionary<string, string> values)
        {
            String query = "delete from Role where id='" + values["id"] + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override Dictionary<string, string> GetColumns()
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(RoleDTO).GetProperties();
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
            RoleDTO roleDTO = (RoleDTO)a;
            String query = "insert into Role values(N'" + roleDTO.RoleName.ToString() + "')";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Inserṭ̣̣(Dictionary<string, string> values)
        {
            String query = "insert into Role values(N'" + values["rolename"] + "')";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Update(object a)
        {
            RoleDTO roleDTO = (RoleDTO)a;
            String query = "update Role set RoleName='" + roleDTO.RoleName.ToString() + "' WHERE id='" + roleDTO.Id + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }

        public override void Update(Dictionary<string, string> values)
        {
            String query = "update Role set RoleName='" + values["rolename"] + "' WHERE id='" + values["id"] + "'";
            MySQLDataProvider.ExecuteNoneQuery(query);
        }
    }
}