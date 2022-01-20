using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    internal class PostgresSQLDAO : IDatabaseDAO
    {
        private string _strConnection;
        public PostgresSQLDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        public IDAO GetRoleDAO()
        {
            return new PostgresSQLRoleDAO(_strConnection);
        }

        public IDAO GetUserDAO()
        {
            return new PostgresSQLUserDAO(_strConnection);
        }
    }
}