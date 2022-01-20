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
    internal partial class UpdateForm : Form
    {
        private Panel buttonPanel = new();
        private Button updateButton = new();
        private Button cancelButton = new();

        private Dictionary<string, TextBox> inputList = new();
        private List<Control> controlList = new();
        public Dictionary<string, string> columns = new();
        public bool isCancel = false;

        public UpdateForm()
        {
            this.Load += new EventHandler(UpdateForm_Load);
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            CreateLabel();
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
            foreach (string key in columns.Keys)
            {
                Label label = new()
                {
                    Text = key,
                    Size = new Size(100, 20),
                    Location = new Point(20, 20 + i * 40),
                    Parent = this
                };
                this.Controls.Add(label);

                TextBox textBox = new()
                {
                    Text = columns[key],
                    Size = new Size(300, 20),
                    Location = new Point(230, 20 + i * 40),
                    Parent = this
                };
                if (i==0) textBox.ReadOnly = true;
                this.Controls.Add(textBox);

                controlList.Add(label);
                controlList.Add(textBox);
                if (!inputList.ContainsKey(key))
                    inputList.Add(key, textBox);

                i++;
            }
        }
        protected void SetupLayout()
        {
            this.Size = new Size(600, 500);

            updateButton.Text = "Update";
            updateButton.Size = new Size(112, 34);
            updateButton.Location = new Point(10, 10);
            updateButton.Click += new EventHandler(UpdateButton_Click);

            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(112, 34);
            cancelButton.Location = new Point(122, 10);
            cancelButton.Click += new EventHandler(CancelButton_Click);

            buttonPanel.Controls.Add(updateButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);

        }
        private void UpdateButton_Click(object? sender, EventArgs e)
        {
            foreach (string key in columns.Keys)
            {
                columns[key] = inputList[key].Text;
            }
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }


    }
}
