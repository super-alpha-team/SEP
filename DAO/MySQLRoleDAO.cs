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
    public class MySQLRoleDAO : RoleDAO
    {
        IDataProvider dataProvider;
        public MySQLRoleDAO(string strConnection)
        {
            _strConnection = strConnection;
            dataProvider = new MySQLDataProvider(new SqlConnection(_strConnection));
        }

        public override List<object> All()
        {
            List<object> lstRoleDTO = new List<object>();
            String query = "SELECT * FROM Role";

            DataTable dt = dataProvider.ExecuteQuery(query);

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
            throw new NotImplementedException();
        }

        public override void Delete(object a)
        {
            RoleDTO roleDTO = (RoleDTO)a;
            String query = "delete from Role where id=" + roleDTO.Id.ToString();
            dataProvider.ExecuteNoneQuery(query);
        }

        public override void Delete(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
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
            String query = "insert into Role values(" + roleDTO.RoleName.ToString() + ")";
            dataProvider.ExecuteNoneQuery(query);
        }

        public override void Inserṭ̣̣(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }

        public override void Update(object a)
        {
            RoleDTO roleDTO = (RoleDTO)a;
            String query = "update Role set RoleName=" + roleDTO.RoleName.ToString() + ")";
            dataProvider.ExecuteNoneQuery(query);
        }

        public override void Update(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
    }
}