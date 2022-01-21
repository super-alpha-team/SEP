using DAO;
using SEP.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEP.DEMO
{
    public class CategoryForm : BaseForm
    {
        public CategoryForm(IDAO dao) : base(dao)
        {
            
        }

        protected override void LayoutConfig()
        {
            base.LayoutConfig();
            addNewRowButton.Text = "Add Category";

            updateRowButton.Text = "Update Category";

            deleteRowButton.Text = "Delete Category";
        }

        [Sep("admin")]
        protected override void Update()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            SepAttribute attr = (SepAttribute)method.GetCustomAttributes(typeof(SepAttribute), true)[0];
            bool value = attr.IsAllow;    //Assumes that MyAttribute has a property called Value
            if (value)
            {
                base.Update();
            }
            else
            {
                MessageBox.Show("permisstion deny");
            }
        }
        protected override void Add()
        {
            if (!Membership.Member.validateWithRole("admin"))
            {
                // kh co quyen
                MessageBox.Show("permisstion deny");
                return;
            }
            base.Add();
        }

        protected override void Delete()
        {
            if (!Membership.Member.validateWithRole("admin"))
            {
                // kh co quyen
                MessageBox.Show("permisstion deny");
                return;
            }
            base.Delete();
        }
    }
}
