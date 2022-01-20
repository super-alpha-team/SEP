using DAO;
using DTO;
using Npgsql;
using SEP.DAO;
using SEP.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
<<<<<<< HEAD
            IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            IDAO userDAO = dao.GetUserDAO();
            MainForm mainForm = new MainForm(userDAO);
=======
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            //IDAO user = dao.GetUserDAO();
            //UserForm mainForm = new UserForm(user);

            //MainForm mainForm = new MainForm(new PostgresSQLDataProvider(new NpgsqlConnection(connetionString)).ExecuteQuery("SELECT * FROM \"Users\""));
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            DataProvider.Init(new NpgsqlConnection(connetionString));

            IDAO pro = new ProductDAO();

            MainForm mainForm = new ProductFrom(pro);
>>>>>>> 88b311c4778b0a6aeb992ed512908bfc6eafb28a
            Application.Run(mainForm);
        }
    }
}

/*string strConnection = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
IDatabaseDAO dao = new PostgresSQLDAO(strConnection);
IDAO user = dao.GetUserDAO();
Debug.WriteLine(user.GetColumns().ToString());
createForm(user);
void createForm(IDAO user)
{
    List<object> lstUser = user.All();
    foreach (UserDTO u in lstUser)
    {
        Debug.WriteLine("UserName: " + u.Username);
        Debug.WriteLine("PassWord: " + u.Password);
        Debug.WriteLine("Role: " + u.Role);
    }
}*/
/**
 * Info
 * - Table: ABC
 * - 
 * ----------------------------------------------
 * id: ____
 * name: ____
 * age: _____
 * email: ____
 * 
 * 
 * ----------------------------------------------
 *                Cancel - Create | Update | Delete
 *                
 *                ############################################################
 *                
 * Info
 * - User: phamnhut21
 * - Connect to: MySQL
 * ----------------------------------------------
 * table_name_1            table_name_3
 * table_name_2            table_name_4
 * 
 * ----------------------------------------------
 * 
 *                ############################################################
 * 
 * Info
 * - Table: ABC
 * ----------------------------------------------
 *                                      create
 * id   collumn_2    collum_3   action
 * 1    asdf         asdf       update, delete
 * 2    zcvzxcv      zxcvzxcv   update, delete
 * 
 *                 page 2/10
*/