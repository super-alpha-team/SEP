using Npgsql;
using SEP.DEMO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String usr = usernameTextBox.Text;
            String pwd = passwordTextBox.Text;
            if (Membership.Membership.Login(usr, pwd))
            {
                // init my database provider
                string connetionString = ConfigurationManager.ConnectionStrings["postgresql"].ConnectionString;
                DataProvider.Init(new NpgsqlConnection(connetionString));

                // go to dashboard
                Dashboard db = new Dashboard();
                this.Close();
                db.Show();
            } else
            {
                MessageBox.Show("Login fail");
            }

        }

    }
}
