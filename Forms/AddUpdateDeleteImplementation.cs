using DAO;
using SEP.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP
{
    internal class AddUpdateDeleteImplementation : Implementation
    {
        private AddForm addForm = new();
        private UpdateForm updateForm = new();
        private DataTable dataTable;
        private IDAO dao;

        private BindingSource bindingSource = new();

        public AddUpdateDeleteImplementation(IDAO dao)
        {
            this.dao = dao;
            this.dataTable = dao.All(true);
        }

        private Dictionary<string, string> GetColumns(DataTable dataTable)
        {
            Dictionary<string, string> columns = new();
            foreach (DataColumn dr in dataTable.Columns)
            {
                columns.Add(dr.ColumnName.ToString().ToLower(), null);
            }
            return columns;
        }
        public void Add()
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
        public void Update(DataGridViewRow selectedRow)
        {
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
        public void Delete(DataGridViewRow selectedRow)
        {
            Dictionary<string, string> deleteData = new();
            foreach (string key in GetColumns(dataTable).Keys)
            {
                deleteData.Add(key, (string)selectedRow.Cells[key].Value);
            }
            dao.Delete(deleteData);
        }
        public void BindData(DataGridView dataGridView)
        {
            dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = dataTable;
        }
    }
}
