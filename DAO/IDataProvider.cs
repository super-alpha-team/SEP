using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public interface IDataProvider
    {
        void ExecuteNoneQuery(string strQuery);
        DataTable ExecuteQuery(string strQuery);
    }
}