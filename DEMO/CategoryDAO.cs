using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace SEP.DEMO
{
    public class CategoryDAO : IDAO
    {
        public List<object> All()
        {
            List<object> lstDTO = new List<object>();
            string query = "SELECT * FROM \"Categories\"";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDTO catDTO = new CategoryDTO();
                catDTO.Id = dr["Id"].ToString();
                catDTO.Name = dr["Name"].ToString();
                lstDTO.Add(catDTO);
            }
            return lstDTO;
        }

        public DataTable All(bool resultDataTable)
        {
            string query = "SELECT * FROM \"Categories\"";
            DataTable dt = DataProvider.ExecuteQuery(query);
            return dt;
        }

        public void Delete(object a)
        {
            //UserDTO userDTO = (UserDTO)a;
            //string query = "DELETE FROM \"Users\" WHERE username='" + userDTO.Username + "'";
            //PostgresSQLDataProvider.ExecuteNoneQuery(query);
        }
        public void Delete(Dictionary<string, string> values)
        {
            string query = "DELETE FROM \"Categories\" WHERE Id='" + values["Id"] + "'";
            DataProvider.ExecuteNoneQuery(query);
        }

        public Dictionary<string, string> GetColumns()
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(CategoryDTO).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string name = prop.Name;
                string type = prop.PropertyType.ToString();
                columns.Add(name, type);
            }
            return columns;
        }

        public void Inserṭ̣̣(object a)
        {
            //UserDTO userDTO = (UserDTO)a;
            //string query = "INSERT INTO \"Users\" values('" + userDTO.Username + "',N'" + userDTO.Password + "',N'" + userDTO.Role + "')";
            //PostgresSQLDataProvider.ExecuteNoneQuery(query);
        }

        public void Inserṭ̣̣(Dictionary<string, string> values)
        {
            string query = "INSERT INTO \"Categories\" (Id,Name) values(N'" + values["Id"] + "',N'" + "',N'" + values["Name"] + "')";
            DataProvider.ExecuteNoneQuery(query);
        }

        public void Update(object a)
        {
            //UserDTO userDTO = (UserDTO)a;
            //string query = "UPDATE \"Users\" SET password='" + userDTO.Password + "', role='" + userDTO.Role + "' WHERE username='" + userDTO.Username + "'";
            //PostgresSQLDataProvider.ExecuteNoneQuery(query);
        }
        public void Update(Dictionary<string, string> values)
        {
            string query = "UPDATE \"Categories\" SET Name='" + values["Name"] + "' WHERE Id='" + values["Id"] + "'";
            DataProvider.ExecuteNoneQuery(query);
        }
    }
}
