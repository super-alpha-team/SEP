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

        protected Button addNewRowButton = new();
        protected Button updateRowButton = new();
        protected Button deleteRowButton = new();
        protected Panel buttonPanel = new();
        protected DataGridView dataGridView = new();

        public BaseForm(IDAO dao)
        {
            this.i = new Implementation(dao);
            SetupLayout();
        }

        private void SetupLayout()
        {
            LayoutConfig();
            i.BindData(dataGridView);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(updateRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(dataGridView);

            addNewRowButton.Click += new EventHandler(AddRowButton_Click);
            updateRowButton.Click += new EventHandler(UpdateRowButton_Click);
            deleteRowButton.Click += new EventHandler(DeleteRowButton_Click);
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
        }

        protected virtual void LayoutConfig()
        {
            this.Size = new Size(600, 400);
            addNewRowButton.Text = "Add Row";
            addNewRowButton.Size = new Size(160, 34);
            addNewRowButton.Location = new Point(10, 10);

            updateRowButton.Text = "Update Row";
            updateRowButton.Size = new Size(160, 34);
            updateRowButton.Location = new Point(180, 10);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Size = new Size(160, 34);
            deleteRowButton.Location = new Point(350, 10);

            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);

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
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }

        protected virtual void Update()
        {
            i.Update(dataGridView.SelectedRows[0]);
        }
        
        protected virtual void Delete()
        {
            if (dataGridView.SelectedRows.Count > 0 &&
               dataGridView.SelectedRows[0].Index !=
               dataGridView.Rows.Count - 1)
            {
                i.Delete(dataGridView.SelectedRows[0]);
                dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
            }
            else
            {
                ShowMessage("Please select a row that can be deleted");
            }
        }

        protected virtual void Add()
        {
            i.Add();
        }
        protected void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void AddRowButton_Click(object? sender, EventArgs e)
        {
            Add();
        }
        private void UpdateRowButton_Click(object? sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 &&
                dataGridView.SelectedRows[0].Index !=
                dataGridView.Rows.Count - 1)
            {
                Update();
            }
            else
            {
                ShowMessage("Please select an updatable row");
            }
        }
        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 &&
                dataGridView.SelectedRows[0].Index !=
                dataGridView.Rows.Count - 1)
            {
                Update();
            }
            else
            {
                ShowMessage("Please select an updatable row");
            }
        }
        private void DeleteRowButton_Click(object? sender, EventArgs e)
        {
            Delete();
        }

    }
}