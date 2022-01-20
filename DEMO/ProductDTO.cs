using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DEMO
{
    public class ProductDTO
    {
        private string _productId;
        private string _productName;
        private string _productPrice;
        private string _categoryId;
        public string id { get => _productId; set => _productId = value; }
        public string name { get => _productName; set => _productName = value; }
        public string price { get => _productPrice; set => _productPrice = value; }
        public string category_id { get => _categoryId; set => _categoryId = value; }
    }
}
