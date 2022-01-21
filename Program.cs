using DAO;
using DTO;
using Npgsql;
using SEP.DAO;
using SEP.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SEP.Membership;
using SEP.DEMO;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

namespace SEP
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();

            // dang ky membership khi bat dau chuong trinh
            Membership.Membership.Register();

            // flow chuong trinh nhu binh thuong
            LoginForm loginForm = new LoginForm();

            Application.Run(loginForm);

        }

        class Foo
        {
            [DisplayName("abc")]
            [Browsable(false)]
            public string Bar { get; set; }
        }
        
    }
}

