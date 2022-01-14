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

namespace SEP.Forms
{
    public partial class MainForm : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView songDataGridView = new DataGridView();    
        private Button addNewRowButton = new Button();
        private Button updateRowButton = new Button();
        private Button deleteRowButton = new Button();
        public MainForm()
        {
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void songDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.songDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void updateRowButton_Click(object sender, EventArgs e)
        {
            this.songDataGridView.BeginEdit(true);
        }

        
        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.songDataGridView.SelectedRows.Count > 0 &&
                this.songDataGridView.SelectedRows[0].Index !=
                this.songDataGridView.Rows.Count - 1)
            {
                this.songDataGridView.Rows.RemoveAt(
                    this.songDataGridView.SelectedRows[0].Index);
            }
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(updateRowButton_Click);
            
            updateRowButton.Text = "Update Row";
            updateRowButton.Location = new Point(100, 10);
            updateRowButton.Click += new EventHandler(updateRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Location = new Point(200, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(updateRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(songDataGridView);

            songDataGridView.ColumnCount = 5;

            songDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(songDataGridView.Font, FontStyle.Bold);

            songDataGridView.Name = "songDataGridView";
            songDataGridView.Location = new Point(8, 8);
            songDataGridView.Size = new Size(500, 250);
            songDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            songDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            songDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            songDataGridView.GridColor = Color.Black;
            songDataGridView.RowHeadersVisible = false;

            songDataGridView.Columns[0].Name = "Release Date";
            songDataGridView.Columns[1].Name = "Track";
            songDataGridView.Columns[2].Name = "Title";
            songDataGridView.Columns[3].Name = "Artist";
            songDataGridView.Columns[4].Name = "Album";
            songDataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(songDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            songDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            songDataGridView.MultiSelect = false;
            songDataGridView.Dock = DockStyle.Fill;
            //songDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            songDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                songDataGridView_CellFormatting);
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

            songDataGridView.Rows.Add(row0);
            songDataGridView.Rows.Add(row1);
            songDataGridView.Rows.Add(row2);
            songDataGridView.Rows.Add(row3);
            songDataGridView.Rows.Add(row4);
            songDataGridView.Rows.Add(row5);
            songDataGridView.Rows.Add(row6);

            songDataGridView.Columns[0].DisplayIndex = 3;
            songDataGridView.Columns[1].DisplayIndex = 4;
            songDataGridView.Columns[2].DisplayIndex = 0;
            songDataGridView.Columns[3].DisplayIndex = 1;
            songDataGridView.Columns[4].DisplayIndex = 2;
        }
    }
}
