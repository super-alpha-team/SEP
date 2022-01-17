using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public abstract class UserDAO
    {
        protected string _strConnection="";
        public virtual void Insert()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<UserDTO> All()
        {
            throw new System.NotImplementedException();
        }
    }
}