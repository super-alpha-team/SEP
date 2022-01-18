using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class MySQLRoleDAO : RoleDAO
    {
        public MySQLRoleDAO(string strConnection)
        {
            _strConnection = strConnection;
        }
        override
        public List<RoleDTO> All()
        {
            throw new System.NotImplementedException();
        }

        override
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        override
        public void Insert()
        {
            throw new System.NotImplementedException();
        }

        override
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}