﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace SEP.Membership
{
    public class Membership
    {
        private IDatabaseDAO dao;
        private Membership() {
            string dataBaseType = ConfigurationManager.AppSettings["DatabaseType"].ToString().ToLower();
            string connetionString = ConfigurationManager.ConnectionStrings[dataBaseType].ConnectionString;
            if (dataBaseType.ToLower() == "mysql")
            {
                dao = new MySQLDAO(connetionString);
            }
            if (dataBaseType.ToLower() == "postgresql")
            {
                dao = new PostgresSQLDAO(connetionString);
            }
            new DAO.Migration(dataBaseType);
            user = dao.GetUserDAO();
            role = dao.GetRoleDAO();
        }

        private static IDAO user;
        private static IDAO role;
        public static Membership Register()
        {
            if (_instance == null)
            {
                _instance = new Membership();
            }
            return _instance;
        }

        private static Membership _instance;

        public static bool Login(string username, string password)
        {
            List<object> lstUser = user.All();
            foreach (UserDTO u in lstUser)
            {
                if(u.Username == username && u.Password == password)
                {
                    Member.GetInstance(u.Role);
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

        public bool Logout()
        {
            return Member.logoutUser();
        }
    }
}
