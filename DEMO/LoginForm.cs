﻿using System;
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
            //Membership.login(usernameTextBox.Text, passwordTextBox.Text); boolean
        }
    }
}
