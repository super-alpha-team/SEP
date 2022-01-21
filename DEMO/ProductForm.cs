using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAO;
using SEP.Forms;
using SEP.Membership;

namespace SEP.DEMO
{
    public class ProductForm : BaseForm
    {
        public ProductForm(IDAO dao) : base(dao)
        {
        }

        protected override void LayoutConfig()
        {
            base.LayoutConfig();
            base.addNewRowButton.BackColor = Color.ForestGreen;
            base.deleteRowButton.BackColor = Color.Red;
        }

    }
}
