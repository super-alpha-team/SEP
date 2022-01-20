using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DEMO
{
    public class CategoryDTO
    {
        private string _categoryName;
        private string _categoryId;
        public string Name { get => _categoryName; set => _categoryName = value; }
        public string Id { get => _categoryId; set => _categoryId = value; }
    }
}
