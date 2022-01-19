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
    public partial class AddForm : Form
    {
        private Panel buttonPanel = new Panel();
        private Button addButton = new Button();
        private Button cancelButton = new Button();

        private Dictionary<string, TextBox> inputList = new Dictionary<string, TextBox>();
        private List<Control> controlList = new List<Control>();
        private string[] columns;
        public List<string> results =  new List<string>();

        public string[] Columns { get => columns; set => columns = value; }

        public AddForm()
        {
            //InitializeComponent();
            this.Load += new EventHandler(AddForm_Load);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
            CreateLabel();
        }
        private void addButton_Click(object? sender, EventArgs e)
        {
            foreach (string column in Columns)
            {
                results.Add(inputList[column].Text);
            }
            this.Close();
        }
        protected void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addButton.Text = "Add";
            addButton.Size = new Size(112, 34);
            addButton.Location = new Point(10, 10);
            addButton.Click += new EventHandler(addButton_Click);

            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(112, 34); 
            cancelButton.Location = new Point(122, 10);
            cancelButton.Click += new EventHandler(cancelButton_Click);

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
            results.Clear();

            int i = 0;
            foreach (string column in Columns)
            {
                Label label = new Label();
                label.Text = column;
                label.Size = new Size(100, 20);
                label.Location = new Point(20, 20 + i * 40);
                label.Parent = this;
                this.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Size = new Size(300, 20);
                textBox.Location = new Point(230, 20 + i * 40);
                textBox.Parent = this;
                this.Controls.Add(textBox);

                controlList.Add(label);
                controlList.Add(textBox);
                if (!inputList.ContainsKey(column))
                    inputList.Add(column, textBox);

                i++;
            }
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

    }
}
