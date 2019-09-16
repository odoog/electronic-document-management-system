using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace SocketServer
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {

            string host;
            int port;
            string database;
            string username;
            string password;

            using (FileStream fstream = new FileStream(System.IO.Path.Combine(Environment.CurrentDirectory, "dbConfig.txt"), FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                string[] configInfo = textFromFile.Split(new char[] { ';' });
                host = configInfo[0];
                port = Int32.Parse(configInfo[1]);
                database = configInfo[2];
                username = configInfo[3];
                password = configInfo[4];
            }

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}