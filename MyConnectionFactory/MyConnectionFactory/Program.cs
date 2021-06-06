using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

// Need these to get definitions of common interfaces,
// and various connection objects for our test.
namespace MyConnectionFactory
{// A list of possible providers.
    enum DataProvider{
        SqlServer, OleDb, Odbc, None
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Very Simple Connection Factory *****\n");
            // Read the provider key.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];
            // Transform string to enum.
            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                Console.WriteLine("Sorry, no provider exists!");
                Console.ReadLine();
                return;
            }
            //
            // Transform string to enum.
            // Get a specific connection.
            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");
            // Open, use and close connection...


            // Get the factory for the SQL data provider.
            DbProviderFactory sqlFactory =
            DbProviderFactories.GetFactory("System.Data.SqlClient");
            Console.ReadLine();

        }
        // This method returns a specific connection object
        // based on the value of a DataProvider enum
        private static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch(dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }
        
    }
}
