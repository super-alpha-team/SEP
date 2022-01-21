using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEP
{
    public interface Implementation
    {
        public void Add();
        public void Update(DataGridViewRow selectedRow);
        public void Delete(DataGridViewRow selectedRow);
        public void BindData(DataGridView dataGridView);
    }
}