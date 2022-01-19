using DAO;
using DTO;
using SEP.Forms;
using SEP.Membership;
using System.Configuration;
using System.Diagnostics;

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
            //Application.Run(new MainForm());

            string strConnection = ConfigurationManager.ConnectionStrings["MyApp"].ConnectionString;
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
            }
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