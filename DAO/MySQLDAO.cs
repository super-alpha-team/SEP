using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class MySQLDAO : IDAO
    {
        private string _strConnection;
        public MySQLDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        public UserDAO GetUserDAO()
        {
            throw new NotImplementedException();
        }

        public RoleDAO GetRoleDAO()
        {
            throw new NotImplementedException();
        }
    }
}