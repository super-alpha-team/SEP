using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Membership
{
    public class PostgesqlDataConnection: DataConnection
    {
        public String dataSource { get; set; }
        public String server { get; set; }
        public String port { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        public PostgesqlDataConnection(string dataSource, string server, string port, string username = null, string password = null)
        {
            this.dataSource = dataSource;
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
        }

        string DataConnection.createConnection()
        {
            string connetionString = @"Server=" + this.server + ";Port=" + this.port + ";Database=" + this.dataSource;
                

            if (this.username != null && this.password != null)
            {
                connetionString += ";User Id=" + this.username + ";Password=" + this.password;
            }


            return connetionString;
        }
    }
}
