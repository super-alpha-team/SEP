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
        private Panel buttonPanel = new Panel();
        private DataGridView dataGridView = new DataGridView();    
        private Button addNewRowButton = new Button();
        private Button updateRowButton = new Button();
        private Button deleteRowButton = new Button();

        private BindingSource bindingSource = new BindingSource();
        private AddForm addForm = new AddForm();
        private UpdateForm updateForm = new UpdateForm();
        public MainForm(UserDAO userDAO)
        {
            //BindData(dataTable);
            //SetupLayout();
            SetupLayout();
            SetupUserDataGridView();
            PopulateUserDataGridView(userDAO);
            //this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //SetupLayout();
            //SetupUserDataGridView();
            //PopulateUserDataGridView();
        }

        //private void songDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e != null)
        //    {
        //        if (this.dataGridView.Columns[e.ColumnIndex].Name == "Release Date")
        //        {
        //            if (e.Value != null)
        //            {
        //                try
        //                {
        //                    e.Value = DateTime.Parse(e.Value.ToString())
        //                        .ToLongDateString();
        //                    e.FormattingApplied = true;
        //                }
        //                catch (FormatException)
        //                {
        //                    Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
        //                }
        //            }
        //        }
        //    }
        //}

        private void addRowButton_Click(object sender, EventArgs e)
        {
            // Open add form
            addForm.ShowDialog();
            //string[] row = { "11/22/1968", "29", "Revolution 9",
            //"Beatles", "The Beatles [White Album]" };

            //dataGridView.Rows.Add(row);
        }
        private void updateRowButton_Click(object sender, EventArgs e)
        {
            // this.dataGridView.BeginEdit(true);
            DataGridViewRow row = this.dataGridView.SelectedRows[0];
            //string[] row0 = { "11/22/1968", "29", "Revolution 9",
            //"Beatles", "The Beatles [White Album]" }; 
            
            if (row == null)
            {
                return;
            }
            string[] sample = { };
            int i = 1;
            
            updateForm.ShowDialog();
            
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

        private void SetupDataGridView()
        {
            this.Controls.Add(dataGridView);

            dataGridView.ColumnCount = 5;

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

            dataGridView.Columns[0].Name = "Release Date";
            dataGridView.Columns[1].Name = "Track";
            dataGridView.Columns[2].Name = "Title";
            dataGridView.Columns[3].Name = "Artist";
            dataGridView.Columns[4].Name = "Album";
            dataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;
            //songDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dataGridView.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    songDataGridView_CellFormatting);
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
            dataGridView.Columns[2].DefaultCellStyle.Font =
                new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void PopulateUserDataGridView(UserDAO user) 
        {
            List<UserDTO> lstUser = user.All();
            foreach (UserDTO u in lstUser)
            {
                dataGridView.Rows.Add(u.Username, u.Password, u.Role);
            }
            //string[] row0 = { "11/22/1968", "29", "Revolution 9",
            //"Beatles", "The Beatles [White Album]" };
            //string[] row1 = { "1960", "6", "Fools Rush In",
            //"Frank Sinatra", "Nice 'N' Easy" };
            //string[] row2 = { "11/11/1971", "1", "One of These Days",
            //"Pink Floyd", "Meddle" };
            //string[] row3 = { "1988", "7", "Where Is My Mind?",
            //"Pixies", "Surfer Rosa" };
            //string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            //"Cramps", "Psychedelic Jungle" };
            //string[] row5 = { "6/10/2003", "13",
            //"Scatterbrain. (As Dead As Leaves.)",
            //"Radiohead", "Hail to the Thief" };
            //string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            //dataGridView.Rows.Add(row0);
            //dataGridView.Rows.Add(row1);
            //dataGridView.Rows.Add(row2);
            //dataGridView.Rows.Add(row3);
            //dataGridView.Rows.Add(row4);
            //dataGridView.Rows.Add(row5);
            //dataGridView.Rows.Add(row6);

            //dataGridView.Columns[0].DisplayIndex = 3;
            //dataGridView.Columns[1].DisplayIndex = 4;
            //dataGridView.Columns[2].DisplayIndex = 0;
            //dataGridView.Columns[3].DisplayIndex = 1;
            //dataGridView.Columns[4].DisplayIndex = 2;
        }
        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            dataGridView.Rows.Add(row0);
            dataGridView.Rows.Add(row1);
            dataGridView.Rows.Add(row2);
            dataGridView.Rows.Add(row3);
            dataGridView.Rows.Add(row4);
            dataGridView.Rows.Add(row5);
            dataGridView.Rows.Add(row6);

            dataGridView.Columns[0].DisplayIndex = 3;
            dataGridView.Columns[1].DisplayIndex = 4;
            dataGridView.Columns[2].DisplayIndex = 0;
            dataGridView.Columns[3].DisplayIndex = 1;
            dataGridView.Columns[4].DisplayIndex = 2;
        }
    }
}
