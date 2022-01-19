using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class MySQLDAO : IDatabaseDAO
    {
        private string _strConnection;
        public MySQLDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        public IDAO GetUserDAO()
        {
            throw new NotImplementedException();
        }

        public IDAO GetRoleDAO()
        {
            throw new NotImplementedException();
        }
    }
}