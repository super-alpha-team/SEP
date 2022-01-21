using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP.DEMO
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void products_Click(object sender, EventArgs e)
        {
            IDAO pro = new ProductDAO();
            BaseForm proForm = new ProductForm(pro);
            proForm.ShowDialog();
        }

        private void categories_Click(object sender, EventArgs e)
        {
            IDAO cat = new CategoryDAO();
            BaseForm catForm = new CategoryForm(cat);
            catForm.ShowDialog();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
