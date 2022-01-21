using DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Membership
{
    public class Member
    {
        private string _Role;
        private bool _isLogin;
        //private string _userName;
        //private string _password;

        private Member(string role) 
        { 
            _Role = role;
            _isLogin = true;
        }
        
        private static Member _member;

        public static Member GetInstance(string role)
        {
            if (_member == null)
            {
                _member = new Member(role);
            }
            return _member;
        }

        public static bool validateWithRole(string expectedRole)
        {
            if(_member != null)
            {
                if(_member._isLogin == true && _member._Role == expectedRole)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool logoutUser()
        {
            if(_member != null && _member._isLogin == true)
            {
                _member._isLogin = false;
                return true;
            }
            return false;
        }

        public static void DashBoard(IDAO user)
        {
            if (!validateWithRole("admin"))
            {
                // kh co quyen
                MessageBox.Show("Permisstion deny");
                return;
            }
            BaseForm userForm = new BaseForm(user);
            userForm.Show();
            return;
        }
    }
}
