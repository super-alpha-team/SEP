﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using SEP.Forms;

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

    }
}
