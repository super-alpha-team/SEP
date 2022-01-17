using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public abstract class RoleDAO
    {
        protected string _strConnection = "";
        public virtual List<RoleDTO> All()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Insert()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}