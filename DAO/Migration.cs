using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;

namespace SEP.DAO
{

    internal class Migration
    {
        string _connetionString;
        string? _databaseName;
        string? _databaseType;
        public Migration(string nameConnectionString)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _connetionString =  ConfigurationManager.ConnectionStrings[nameConnectionString].ConnectionString;
            _databaseName = (configFile.AppSettings.Settings["DatabaseName"]!=null ? configFile.AppSettings.Settings["DatabaseName"].Value.ToString(): null);
            _databaseType = configFile.AppSettings.Settings["DatabaseType"].Value.ToString();
            if (_databaseName == null)
            {
                CreateDatabase();
                CreateTable();
            }
        }

        void ExtractProperties(string classType)
        {
            PropertyInfo[] props = Type.GetType(classType).GetProperties();
            List<string> columns = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                string name = prop.Name.ToLower();
                columns.Add(name);
            }
        }

        void CreateTable()
        {
            switch (_databaseType.ToLower())
            {
                case "mysql":
                    new MySQLDataProvider(new MySqlConnection(_connetionString));
                    MySQLDataProvider.ExecuteNoneQuery("CREATE TABLE `Users` (`username` VARCHAR(20) NOT NULL PRIMARY KEY, `password` VARCHAR(20) NOT NULL, `role` VARCHAR(20) NOT NULL);");
                    break;
                case "postgresql":
                    new PostgresSQLDataProvider(new NpgsqlConnection(_connetionString));
                    PostgresSQLDataProvider.ExecuteNoneQuery("CREATE TABLE \"Users\" (\"username\" VARCHAR(20) NOT NULL PRIMARY KEY, \"password\" VARCHAR(20) NOT NULL, \"role\" VARCHAR(20) NOT NULL);");
                    break;
                default:
                    break;
            }
        }

        void CreateTable(string tableName, List<string> columns) { }

        void CreateDatabase()
        {
            char[] separatingStrings = { ';' };
            string databaseInfo = _connetionString.Split(separatingStrings).Where(x => x.Split("=").First().ToLower().Equals("database")).First();
            string connetionString = _connetionString.Replace(databaseInfo, "");
            connetionString = connetionString.Replace(";;", ";");
            _databaseName = databaseInfo.Split("=").Last();
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            switch (_databaseType.ToLower())
            {
                case "mysql":
                    new MySQLDataProvider(new MySqlConnection(connetionString));
                    MySQLDataProvider.ExecuteNoneQuery("create database `" + _databaseName+"`");
                    break;
                case "postgresql":
                    new PostgresSQLDataProvider(new NpgsqlConnection(connetionString));
                    PostgresSQLDataProvider.ExecuteNoneQuery("create database \"" + _databaseName+"\"");
                    break;
                default:
                    break;
            }
            configFile.AppSettings.Settings.Add("DatabaseName", _databaseName);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
