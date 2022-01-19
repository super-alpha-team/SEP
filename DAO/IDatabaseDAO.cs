using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public interface IDatabaseDAO
    {
        IDAO GetUserDAO();
        IDAO GetRoleDAO();
    }
}