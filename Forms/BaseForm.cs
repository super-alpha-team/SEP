using DAO;
using SEP.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SEP
{
    public class BaseForm : Form
    {
        private Implementation i;

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
        protected void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Size = new Size(160, 34);
            addNewRowButton.Location = new Point(10, 10);
            //addNewRowButton.Click += new EventHandler(AddRowButton_Click);

            updateRowButton.Text = "Update Row";
            updateRowButton.Size = new Size(160, 34);
            updateRowButton.Location = new Point(180, 10);
            //updateRowButton.Click += new EventHandler(UpdateRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Size = new Size(160, 34);
            deleteRowButton.Location = new Point(350, 10);
            //deleteRowButton.Click += new EventHandler(DeleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(updateRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(dataGridView);
            //dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

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
    }
}