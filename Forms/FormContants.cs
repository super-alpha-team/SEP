using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Forms
{
    public enum FormType
    {
        Main = 1, // show list table and user, permission, so on

        Create = 2, // create new data table specify
        Update = 3, // update one by id
        ViewOne = 5, // view one by id
        ViewList = 6, // view list by table and filter
        Delete = 4, // delete one by id
    };

}
