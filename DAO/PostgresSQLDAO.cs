using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class PostgresSQLDAO : IDAO
    {
        private string _strConnection;
        public PostgresSQLDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        public RoleDAO GetRoleDAO()
        {
            throw new NotImplementedException(_strConnection);
        }

        public UserDAO GetUserDAO()
        {
            return new PostgresSQLUserDAO(_strConnection);
        }
    }
}