using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public abstract class RoleDAO : IDAO
    {
        protected string _strConnection = "";

        public abstract List<object> All();
        public abstract DataTable All(bool resultDataTable);
        public abstract void Delete(object a);
        public abstract void Delete(Dictionary<string, string> values);
        public abstract Dictionary<string, string> GetColumns();
        public abstract void Inserṭ̣̣(object a);
        public abstract void Inserṭ̣̣(Dictionary<string, string> values);
        public abstract void Update(object a);
        public abstract void Update(Dictionary<string, string> values);
    }
}