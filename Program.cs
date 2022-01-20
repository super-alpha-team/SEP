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

<<<<<<< HEAD
            string connetionString = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            //IDAO userDAO = dao.GetUserDAO();
            //MainForm mainForm = new(userDAO);
            DataProvider.Init(new NpgsqlConnection(connetionString));
            IDAO pro = new ProductDAO();
            MainForm mainForm = new ProductForm(pro);
            Application.Run(mainForm);
=======
            Debug.WriteLine("he");
            //string strConnection = ConfigurationManager.ConnectionStrings["MyApp2"].ConnectionString;
            //IDatabaseDAO dao = new MySQLDAO(strConnection);

            //string connetionString = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);

            //IDAO user = dao.GetUserDAO();
            //Debug.WriteLine(user.GetColumns().ToString());

            //List<object> lstUser = user.All();
            //foreach (UserDTO u in lstUser)
            //{
            //    Debug.WriteLine("UserName: " + u.Username);
            //    Debug.WriteLine("PassWord: " + u.Password);
            //    Debug.WriteLine("Role: " + u.Role);
            //}


            //string connetionString = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
            //IDatabaseDAO dao = new PostgresSQLDAO(connetionString);
            //IDAO userDAO = dao.GetUserDAO();
            ////MainForm mainForm = new MainForm(userDAO);
            //DataProvider.Init(new NpgsqlConnection(connetionString));

            //IDAO pro = new ProductDAO();

            //MainForm mainForm = new ProductForm(pro);
            //Application.Run(mainForm);

            //Member m = Member.GetInstance("a");
            //Debug.WriteLine(m);
            Member.someBusinessLogic();
>>>>>>> 01702b53a7163b824a21cb65c681ff78f461d3fb
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