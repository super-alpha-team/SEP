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
    internal partial class AddForm : Form
    {
        private Panel buttonPanel = new();
        private Button addButton = new();
        private Button cancelButton = new();

        private Dictionary<string, TextBox> inputList = new();
        private List<Control> controlList = new();
        public Dictionary<string, string> columns = new();
        public bool isCancel = false;

        public AddForm()
        {
            this.Load += new EventHandler(AddForm_Load);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            CreateLabel();
        }
        private void AddButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputList.First().Value.Text))
            {
                inputList.First().Value.Focus();
                MessageBox.Show("Key should not be left blank!");
            }
            else
            {
                foreach (string key in columns.Keys)
                {
                    columns[key] = inputList[key].Text;
                }
                this.Close();
            }
        }
        protected void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addButton.Text = "Add";
            addButton.Size = new Size(112, 34);
            addButton.Location = new Point(10, 10);
            addButton.Click += new EventHandler(AddButton_Click);

            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(112, 34); 
            cancelButton.Location = new Point(122, 10);
            cancelButton.Click += new EventHandler(CancelButton_Click);

            buttonPanel.Controls.Add(addButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void CreateLabel()
        {
            foreach (Control control in controlList)
            {
                this.Controls.Remove(control);
            }

            controlList.Clear();
            inputList.Clear();

            int i = 0;
            foreach (string column in columns.Keys)
            {
                Label label = new()
                {
                Text = column,
                Size = new Size(150, 25),
                Location = new Point(20, 20 + i * 40),
                Parent = this,
                };
                this.Controls.Add(label);

                TextBox textBox = new()
                {
                    Size = new Size(300, 20),
                    Location = new Point(230, 20 + i * 40),
                    Parent = this
                };
                this.Controls.Add(textBox);

                controlList.Add(label);
                controlList.Add(textBox);
                if (!inputList.ContainsKey(column))
                    inputList.Add(column, textBox);

                i++;
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }

    }
}
