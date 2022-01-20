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
        private DataGridView dataGridView = new();    
        private Button addNewRowButton = new();
        private Button updateRowButton = new();
        private Button deleteRowButton = new();
        private Panel buttonPanel = new();

        private AddForm addForm = new();
        private UpdateForm updateForm = new();
        private BindingSource bindingSource = new();
        private DataTable dataTable = new();
        private IDAO dao;

        public MainForm(IDAO dao)
        {
            this.dao = dao;
            this.dataTable = dao.All(true);
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            BindData(dataTable);
        }

        private Dictionary<string,string> GetColumns(DataTable dataTable)
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            foreach (DataColumn dr in dataTable.Columns)
            {
                columns.Add(dr.ColumnName.ToString().ToLower(), null);
            }
            return columns;
        }
        protected void AddRowButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> columns = GetColumns(dataTable);
            addForm.columns = columns;
            addForm.ShowDialog();
            if (!addForm.isCancel)
            {
                string[] row = addForm.columns.Values.ToArray();
                DataRow newRow = dataTable.NewRow();
                newRow.ItemArray = row;
                dataTable.Rows.Add(newRow);
                Dictionary<string, string> newData = new();
                foreach (string key in addForm.columns.Keys)
                {
                    newData.Add(key, addForm.columns[key]);
                }
                dao.Inserṭ̣̣(newData);
            }
        }
        private void RowUpdate()
        {
            if (this.dataGridView.SelectedRows.Count > 0 &&
                this.dataGridView.SelectedRows[0].Index !=
                this.dataGridView.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                Dictionary<string, string> columns = GetColumns(dataTable);
                foreach (string key in columns.Keys)
                {
                    columns[key] = (string)selectedRow.Cells[key].Value;
                }
                updateForm.columns = columns;
                updateForm.ShowDialog();
                if (!addForm.isCancel)
                {
                    string[] row = updateForm.columns.Values.ToArray();
                    selectedRow.SetValues(row);
                    Dictionary<string, string> updateData = new();
                    foreach (string key in updateForm.columns.Keys)
                    {
                        updateData.Add(key, updateForm.columns[key]);
                    }
                    dao.Update(updateData);
                }
            }
        }
        protected void UpdateRowButton_Click(object sender, EventArgs e)
        {
            RowUpdate();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RowUpdate();
        }

        protected void DeleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 &&
                this.dataGridView.SelectedRows[0].Index !=
                this.dataGridView.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                Dictionary<string, string> deleteData = new();
                foreach (string key in GetColumns(dataTable).Keys)
                {
                    deleteData.Add(key, (string)selectedRow.Cells[key].Value);
                }
                dao.Delete(deleteData); 
                this.dataGridView.Rows.RemoveAt(
                    this.dataGridView.SelectedRows[0].Index);
            } 
        }

        protected void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Size = new Size(160, 34);
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(AddRowButton_Click);
            
            updateRowButton.Text = "Update Row";
            updateRowButton.Size = new Size(160, 34);
            updateRowButton.Location = new Point(180, 10);
            updateRowButton.Click += new EventHandler(UpdateRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Size = new Size(160, 34);
            deleteRowButton.Location = new Point(350, 10);
            deleteRowButton.Click += new EventHandler(DeleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(updateRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(dataGridView);
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

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
            dataGridView.AutoResizeColumns(
             DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }

        private void BindData(DataTable dataTable)
        {
            dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = dataTable;
        }
    }
}
