using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace SEP.Membership
{
    public class Membership
    {
        private Membership() { }

        private IDAO user;
        private IDAO role;

        public Membership(IDatabaseDAO databaseDAO)
        {
            user = databaseDAO.GetUserDAO();
            role = databaseDAO.GetRoleDAO();
        }

        public bool Login(string username, string password)
        {
            List<object> lstUser = user.All();
            foreach (UserDTO u in lstUser)
            {
                if(u.Username == username && u.Password == password)
                {
                    return true;
                }
            }
           
            return false;
        }

        public bool LoginWithAdminRole(string username, string password)
        {
            List<object> lstUser = user.All();
            foreach (UserDTO u in lstUser)
            {
                if (u.Username == username && u.Password == password && u.Role == "admin")
                {
                    return true;
                }
            }

            return false;
        }

        public bool Register(string username, string password)
        {
            List<object> lstUser = user.All();
            foreach (UserDTO u in lstUser)
            {
                if (u.Username == username)
                {
                    return false;
                }
            }
            UserDTO newUser = new UserDTO();
            newUser.Username = username;
            newUser.Password = password;

            user.Inserṭ̣̣(newUser);

            return true;
        }

        public bool Logout(string username)
        {
            
            return true;
        }
    }
}
