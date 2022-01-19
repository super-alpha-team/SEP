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
        public UpdateForm()
        {
            //InitializeComponent();
            this.Load += new EventHandler(UpdateForm_Load);

        }

        private Panel buttonPanel = new Panel();
        private Button updateButton = new Button();
        private Button cancelButton = new Button();

        private string[] row;
        private Dictionary<string, TextBox> inputList = new Dictionary<string, TextBox>();
        private List<Control> controlList = new List<Control>();

        public string[] Row { get => row; set => row = value; }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            SetupLayout();
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

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
