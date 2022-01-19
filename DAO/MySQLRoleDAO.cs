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

        public override List<object> All()
        {
            throw new NotImplementedException();
        }

        public override void Delete(object a)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetColumns()
        {
            throw new NotImplementedException();
        }

        public override void Inserṭ̣̣(object a)
        {
            throw new NotImplementedException();
        }

        public override void Update(object a)
        {
            throw new NotImplementedException();
        }
    }
}