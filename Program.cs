using DAO;
using DTO;
using Npgsql;
using SEP.DAO;
using SEP.Forms;
using Membership = SEP.Membership;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SEP.Membership;
using SEP.DEMO;

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

            string connetionString = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            //IDAO userDAO = dao.GetUserDAO();
            //BaseForm mainForm = new(userDAO);

            DataProvider.Init(new NpgsqlConnection(connetionString));
            IDAO pro = new ProductDAO();
            BaseForm mainForm = new ProductForm(pro);

            Application.Run(mainForm);
        }
        
        
    }
}

