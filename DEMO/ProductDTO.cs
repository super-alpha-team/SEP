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
        public string Id { get => _productId; set => _productId = value; }
        public string Name { get => _productName; set => _productName = value; }
        public string Price { get => _productPrice; set => _productPrice = value; }
        public string CategoryId { get => _categoryId; set => _categoryId = value; }
    }
}
