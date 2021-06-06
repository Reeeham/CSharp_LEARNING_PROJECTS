using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");
            // Create and open a connection.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =@"Data Source=DESKTOP-A2OVA97\SQLEXPRESS02;Integrated Security=true;Initial Catalog=AutoLot;Connect Timeout=30";
                connection.Open();
                ShowConnectionStatus(connection);
                // Create a SQL command object.
                string sql = "Select * From Inventory;Select * from Customers";
                SqlCommand myCommand = new SqlCommand(sql, connection);
                // Obtain a data reader a la ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    do
                    {
                        // Loop over the results.
                        while (myDataReader.Read())
                        {
                            //Console.WriteLine($"-> Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]},Color: { myDataReader["Color"]}.");
                            Console.WriteLine("***** Record *****");
                            for (int i = 0; i < myDataReader.FieldCount; i++)
                            {
                                Console.WriteLine($"{myDataReader.GetName(i)} = { myDataReader.GetValue(i)} ");
                            }
                            Console.WriteLine();
                        }
                    } while (myDataReader.NextResult());


                }

            }
            // Create a connection string via the builder object.
            //var cnStringBuilder = new SqlConnectionStringBuilder
            //{
            //    InitialCatalog = "AutoLot",
            //    DataSource = @"(localdb)\mssqllocaldb",
            //    ConnectTimeout = 30,
            //    IntegratedSecurity = true
            //};
            //using (SqlConnection connection = new SqlConnection())
            //{
            //    connection.ConnectionString = cnStringBuilder.ConnectionString;
            //    connection.Open();
            //    ShowConnectionStatus(connection);
            //}
                Console.ReadLine();
        }

        private static void ShowConnectionStatus(SqlConnection connection)
        {
            // Show various stats about current connection object.
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine("Database Location :{0}",connection.DataSource);
            Console.WriteLine($"Database Name : {connection.Database}");
            Console.WriteLine($"Connection Timeout : {connection.ConnectionTimeout}");
            Console.WriteLine($"Connection State : {connection.State}\n");
        }
    }
    }
