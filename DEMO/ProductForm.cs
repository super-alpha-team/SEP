using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using SEP.Forms;

namespace SEP.DEMO
{
    public class ProductForm : MainForm
    {
        public ProductForm(IDAO dao) : base(dao)
        {

        }
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            if (1 != 1)
            {
                // kh co quyen
            }
            base.AddRowButton_Click(sender, e);

        }

    }
}
