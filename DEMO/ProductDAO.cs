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
    internal class ProductDAO :IDAO
    {
        public List<object> All()
        {
            List<object> lstDTO = new List<object>();
            string query = "SELECT * FROM \"Products\"";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                ProductDTO proDTO = new ProductDTO();
                proDTO.Id = dr["id"].ToString();
                proDTO.Name = dr["name"].ToString();
                proDTO.Price = dr["price"].ToString();
                proDTO.CategoryId = dr["category_id"].ToString();
                lstDTO.Add(proDTO);
            }
            return lstDTO;
        }

        public DataTable All(bool resultDataTable)
        {
            string query = "SELECT * FROM \"Products\"";
            DataTable dt = DataProvider.ExecuteQuery(query);
            return dt;
        }

        public void Delete(object a)
        {
            //ProductDTO proDTO = (ProductDTO)a;
            //string query = "DELETE FROM \"Products\" WHERE Id='" + proDTO.Id + "'";
            //DataProvider.ExecuteNoneQuery(query);
        }
        public void Delete(Dictionary<string, string> values)
        {
            string query = "DELETE FROM \"Products\" WHERE Id='" + values["Id"] + "'";
            DataProvider.ExecuteNoneQuery(query);
        }

        public Dictionary<string, string> GetColumns()
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(ProductDTO).GetProperties();
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
            //ProductDTO proDTO = (ProductDTO)a;
            //string query = "INSERT INTO \"Product\" values('" + proDTO.Username + "',N'" + proDTO.Password + "',N'" + proDTO.Role + "')";
            //DataProvider.ExecuteNoneQuery(query);
        }

        public void Inserṭ̣̣(Dictionary<string, string> values)
        {
            string query = "INSERT INTO \"Products\" (Id, Name, Price, CategoryId) values(N'" + values["Id"] + "',N'" + values["Name"] + "',N'" + values["Price"] + values["CategoryId"] + "')";
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
            string query = "UPDATE \"Products\" SET Name='" + values["Name"] + "', Price='" + values["Price"] + "', CategoryId='" + values["CategoryId"] + "' WHERE Id='" + values["Id"] + "'";
            DataProvider.ExecuteNoneQuery(query);
        }
    }
}
