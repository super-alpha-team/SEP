using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public interface IDAO
    {
        UserDAO GetUserDAO();
        RoleDAO GetRoleDAO();
    }
}