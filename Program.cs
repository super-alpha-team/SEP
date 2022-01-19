using DAO;
using DTO;
using SEP.DAO;
using SEP.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEP
{
    internal static class Program
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
            IDAO dao = new PostgresSQLDAO(connetionString);
            UserDAO user = dao.GetUserDAO();
            UserForm form = new UserForm(user);
            Application.Run(form);
        }
    }
}

/*string strConnection = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
IDAO dao = new PostgresSQLDAO(strConnection);
UserDAO user = dao.GetUserDAO();
List<UserDTO> lstUser = user.All();
foreach (UserDTO u in lstUser)
{
    Debug.WriteLine("UserName: " + u.Username);
    Debug.WriteLine("PassWord: " + u.Password);
    Debug.WriteLine("Role: " + u.Role);
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