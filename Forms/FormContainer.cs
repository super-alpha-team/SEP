using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP.Forms
{
    public partial class FormContainer : Form
    {
        protected Button btnAdd = new Button();

        public FormContainer()
        {
            
        }
        protected virtual void addBtnAdd()
        {
            this.btnAdd.Location = new System.Drawing.Point(301, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.Controls.Add(this.btnAdd);
        }
        protected virtual void BtnAdd_Click(object sender, EventArgs e) { }

        private void FormContainer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
