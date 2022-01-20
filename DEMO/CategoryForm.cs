using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DEMO
{
    public class CategoryForm : BaseForm
    {
        public CategoryForm(IDAO dao) : base(dao)
        {
            //if(role == "user")
            //{
            //    base.deleteRowButton.Disable = false;
            //}
        }

        protected override void LayoutConfig()
        {
            base.LayoutConfig();
            base.addNewRowButton.BackColor = Color.ForestGreen;
            base.deleteRowButton.BackColor = Color.Red;
        }
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            if (1 != 1)
            {
                // kh co quyen
            }
            //base.AddRowButton_Click(sender, e);

        }
    }
}
