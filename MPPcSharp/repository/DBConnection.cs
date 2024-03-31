
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;

namespace Lab2MPP.Repository
{
    internal class DBConnection
    {
        private static IDbConnection instance = null;


        public static IDbConnection getConnection(IDictionary<string, string> props)
        {
            try {
                if (instance == null || instance.State == System.Data.ConnectionState.Closed)
                {
                    instance = getNewConnection(props);

                    instance.Open();
                }
            }
            catch (Exception e) { Console.WriteLine("in DBconnnection avem eroare : " + e); }
            
            return instance;
        }

        private static IDbConnection getNewConnection(IDictionary<string, string> props)
        {
            String connectionString = props["ConnectionString"];
            Console.WriteLine("SQLite ---Se deschide o conexiune la  ... {0}", connectionString);
            return new SqliteConnection(connectionString);
            //return ConnectionUtils.ConnectionFactory.getInstance().createConnection(props);
        }

    }
}
