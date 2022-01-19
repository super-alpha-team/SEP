using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public abstract class RoleDAO : IDAO
    {
        protected string _strConnection = "";

        public abstract List<object> All();

        public abstract void Delete(object a);
        public abstract Dictionary<string, string> GetColumns();
        public abstract void Inserṭ̣̣(object a);

        public abstract void Update(object a);
    }
}