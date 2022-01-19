using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Membership
{
    public class Membership
    {
        private Membership() { }

        private static Membership? _membership;
        private string? _username { get; set; }
        private string? _password { get; set; }
        private string? _role { get; set; }

        public static Membership getMembership()
        {
            if (_membership == null)
            {
                _membership = new Membership();
            }
            return _membership;
        }

        public static void registerApp (DataConnection data)
        {
            data.createConnection();

            

        }

        public static Tuple<string, bool> login(string username, string password) {
            //todo: call DAO to get login data
            //check xem 


            return new Tuple<string, bool>(username, true);
        }
    }
}
