using DAO;
using DTO;
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
    public partial class UserForm : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView dataGridView = new DataGridView();
        private Button addNewRowButton = new Button();
        private Button updateRowButton = new Button();
        private Button deleteRowButton = new Button();

        private AddForm addForm = new AddForm();
        private UpdateForm updateForm = new UpdateForm();
        private IDAO userDAO;
        public UserForm(IDAO userDAO)
        {
            //InitializeComponent();
            this.userDAO = userDAO;
            SetupLayout();
            SetupUserDataGridView();
            PopulateUserDataGridView();
        }

        private void PopulateUserDataGridView()
        {
            //List<UserDTO> lstUser = userDAO.All();
            List<object> lstUser = userDAO.All();
            foreach (UserDTO u in lstUser)
            {
                dataGridView.Rows.Add(u.Username, u.Password, u.Role);
            }
        }
        private void SetupUserDataGridView()
        {
            this.Controls.Add(dataGridView);

            dataGridView.ColumnCount = 3;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);

            dataGridView.Name = "dataGridView";
            dataGridView.Location = new Point(8, 8);
            dataGridView.Size = new Size(500, 250);
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = false;

            dataGridView.Columns[0].Name = "Username";
            dataGridView.Columns[1].Name = "Password";
            dataGridView.Columns[2].Name = "Role";
            //dataGridView.Columns[2].DefaultCellStyle.Font =
            //    new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void addRowButton_Click(object sender, EventArgs e)
        {
            string[] columns = { "Username", "Password", "Role" };
            addForm.Columns = columns;
            addForm.ShowDialog();
            if(addForm.results.Count != 0)
            {
                string[] row = addForm.results.ToArray();
                dataGridView.Rows.Add(row);
            }
        }
        private void updateRowButton_Click(object sender, EventArgs e)
        {
            

        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 &&
                this.dataGridView.SelectedRows[0].Index !=
                this.dataGridView.Rows.Count - 1)
            {
                this.dataGridView.Rows.RemoveAt(
                    this.dataGridView.SelectedRows[0].Index);
            }
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Size = new Size(160, 34);
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addRowButton_Click);

            updateRowButton.Text = "Update Row";
            updateRowButton.Size = new Size(160, 34);
            updateRowButton.Location = new Point(180, 10);
            updateRowButton.Click += new EventHandler(updateRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Size = new Size(160, 34);
            deleteRowButton.Location = new Point(350, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(updateRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }
    }
}



