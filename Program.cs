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


            string connetionString = ConfigurationManager.ConnectionStrings["MyApp2"].ConnectionString;
            IDatabaseDAO dao = new MySQLDAO(connetionString);
            IDAO userDAO = dao.GetUserDAO();
            BaseForm mainForm = new(userDAO);

            //DataProvider.Init(new NpgsqlConnection(connetionString));
            //IDAO pro = new ProductDAO();
            //BaseForm mainForm = new ProductForm(pro);

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

