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
    public partial class UpdateForm : Form
    {
        private Panel buttonPanel = new Panel();
        private Button updateButton = new Button();
        private Button cancelButton = new Button();

        private Dictionary<string, TextBox> inputList = new Dictionary<string, TextBox>();
        private List<Control> controlList = new List<Control>();
        public Dictionary<String, String> columns = new Dictionary<string, string>();
        public List<string> results = new List<string>();

        public UpdateForm()
        {
            //InitializeComponent();
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
            results.Clear();

            int i = 0;
            foreach (string key in columns.Keys)
            {
                Label label = new Label();
                label.Text = key;
                label.Size = new Size(100, 20);
                label.Location = new Point(20, 20 + i * 40);
                label.Parent = this;
                this.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = columns[key];
                textBox.Size = new Size(300, 20);
                textBox.Location = new Point(230, 20 + i * 40);
                textBox.Parent = this;
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
            updateButton.Click += new EventHandler(updateButton_Click);

            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(112, 34);
            cancelButton.Location = new Point(122, 10);
            cancelButton.Click += new EventHandler(cancelButton_Click);

            buttonPanel.Controls.Add(updateButton);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);

        }
        private void updateButton_Click(object? sender, EventArgs e)
        {
            foreach (string key in columns.Keys)
            {
                results.Add(inputList[key].Text);
            }
            this.Close();
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }


    }
}
