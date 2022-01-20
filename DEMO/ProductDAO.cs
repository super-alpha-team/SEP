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
                proDTO.id = dr["id"].ToString();
                proDTO.name = dr["name"].ToString();
                proDTO.price = dr["price"].ToString();
                proDTO.category_id = dr["category_id"].ToString();
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
            string query = "DELETE FROM \"Products\" WHERE id='" + values["id"] + "'";
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
            string query = "INSERT INTO \"Products\" (id, name, price, category_id) values(N'" + values["id"] + "',N'" + values["name"] + "',N'" + values["price"] + "',N'" + values["category_id"] + "')";
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
            string query = "UPDATE \"Products\" SET name='" + values["name"] + "', price='" + values["price"] + "', category_id='" + values["category_id"] + "' WHERE id='" + values["id"] + "'";
            DataProvider.ExecuteNoneQuery(query);
        }
    }
}
