using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAO
{
    public interface IDataProvider
    {
        static void ExecuteNoneQuery(string strQuery) { }
        static DataTable ExecuteQuery(string strQuery)
        {
            throw new NotImplementedException();   
        }
    }
}