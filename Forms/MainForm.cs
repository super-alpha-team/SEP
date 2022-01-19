using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using DAO;
using DTO;

namespace SEP.Forms
{
    public partial class MainForm : Form
    {
        private DataGridView dataGridView = new DataGridView();    
        private Button addNewRowButton = new Button();
        private Button updateRowButton = new Button();
        private Button deleteRowButton = new Button();
        private Panel buttonPanel = new Panel();

        private AddForm addForm = new AddForm();
        private UpdateForm updateForm = new UpdateForm();
        private BindingSource bindingSource = new BindingSource();
        private DataTable dataTable = new DataTable();
        private IDAO dao;

        public MainForm(IDAO dao)
        {
            this.dao = dao;
            this.dataTable = dao.All(true);
            this.Load += new EventHandler(this.MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            BindData(dataTable);
        }
        protected void addRowButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> columns = dao.GetColumns();
            addForm.columns = columns;
            addForm.ShowDialog();
            if (addForm.results.Count != 0)
            {
                string[] row = addForm.results.ToArray();
                DataRow newRow = dataTable.NewRow();
                newRow.ItemArray = row;
                dataTable.Rows.Add(newRow);
                Dictionary<string, string> newData = new Dictionary<string, string>();
                foreach (string key in addForm.columns.Keys)
                {
                    newData.Add(key.ToLower(), addForm.columns[key]);
                }
                dao.Inserṭ̣̣(newData);
            }
        }
        protected void updateRowButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            Dictionary<string, string> columns = dao.GetColumns();
            foreach (string key in columns.Keys)
            {
                columns[key] = (string)selectedRow.Cells[key].Value;
            }
            updateForm.columns = columns;
            updateForm.ShowDialog();
            if (updateForm.results.Count != 0)
            {
                string[] row = updateForm.results.ToArray();
                selectedRow.SetValues(row);
                Dictionary<string, string> updateData = new Dictionary<string, string>();
                foreach (string key in updateForm.columns.Keys)
                {
                    updateData.Add(key.ToLower(), updateForm.columns[key]);
                }
                dao.Update(updateData);
            }
        }

        protected void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 &&
                this.dataGridView.SelectedRows[0].Index !=
                this.dataGridView.Rows.Count - 1)
            {
                this.dataGridView.Rows.RemoveAt(
                    this.dataGridView.SelectedRows[0].Index);
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                Dictionary<string, string> deleteData = new Dictionary<string, string>();
                foreach (string key in dao.GetColumns().Keys)
                {
                    deleteData.Add(key.ToLower(), (string)selectedRow.Cells[key].Value);
                }
                dao.Delete(deleteData);
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

        private void BindData(DataTable dataTable)
        {
            this.Controls.Add(dataGridView);

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);

            dataGridView.Name = dataTable.TableName;
            dataGridView.Location = new Point(8, 8);
            dataGridView.Size = new Size(500, 250);
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = false;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;

            dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = dataTable;
            dataGridView.AutoResizeColumns(
           DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
    }
}
