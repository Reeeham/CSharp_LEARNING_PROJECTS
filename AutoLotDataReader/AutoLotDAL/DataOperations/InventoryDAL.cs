using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// You will use the SQL server
// provider; however, it would also be
// permissible to use the ADO.NET
// factory pattern for greater flexibility.
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;


        public InventoryDAL() :this(@"Data Source=DESKTOP-A2OVA97\SQLEXPRESS02;Integrated Security=true;Initial Catalog=AutoLot")
            {

        }
        public InventoryDAL(string connString) => _connectionString = connString;

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }
        private void CloseConnection()
        {
            if(_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }

        public List<Inventory> GetAllInventory()
        {
            OpenConnection();
            // This will hold the records.
            List<Inventory> inventory = new List<Inventory>();
            // Prep command object.
            string sql = "Select * from Inventory";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while(dataReader.Read())
                {
                    inventory.Add(new Inventory
                    { CarId = (int)dataReader["CarId"],
                                       Color = (string)dataReader["Color"],
                                       Make = (string)dataReader["Make"],
                                       PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }

        public Inventory GetCar(int id)
        {
            OpenConnection();
            Inventory car = null;
            string sql = $"Select * from Inventory where CarId = {id}";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while(dataReader.Read())
                {
                    car = new Inventory
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };
                }
                dataReader.Close();
            }
            return car;
        }

        public void InsertAuto(string color,string make, string petName)
        {
            OpenConnection();
            string sql = $"insert into Inventory (Make,Color,PetName) values ('{make}','{color}','{petName}')";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        //create the strongly typed insertCar method
        public void InsertAuto(Inventory car)
        {
            OpenConnection();
            // Format and execute SQL statement.
            string sql = "Insert Into Inventory" +"(Make, Color, PetName) Values" +"(@Make, @Color, @PetName)";
            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);
                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);
                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
                CloseConnection();
            }
            
        }

        public void DeleteCar(int id)
        {
            OpenConnection();
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }catch(SqlException ex)
                {
                    Exception error = new Exception("Sorry, That car is on order", ex);
                    throw error;
                }
            }
            CloseConnection();

        }
        public void UpdateCarPetName(int id,string newPetName)
        {
            OpenConnection();
            // Get ID of car to modify the pet name.
            string sql = $"Update Inventory set PetName = '{newPetName}' where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

            }
            CloseConnection();
        }

        // Establish name of stored proc.
        public string LookUpPetName(int carId)
        {
            OpenConnection();
            string carPetName;
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                // Input param.
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(param);
                // Output param.
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(param);
                // Execute the stored proc.
                command.ExecuteNonQuery();
                // Return output param.
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx,int custId)
        {
            OpenConnection();
            // First, look up current name based on customer ID.
            string fName;
            string lName;
            var cmdSelect = new SqlCommand($"select * from Customers Where CustId='{custId}'", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if(dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            // Create command objects that represent each step of the operation.
            var cmdRemove = new SqlCommand($"Delete from Customers where CustId = {custId}", _sqlConnection);
            var cmdInsert = new SqlCommand($"Insert into CreditRisks (FirstName , LastName) values('{fName}','{lName}') ", _sqlConnection);
            // We will get this from the connection object.
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();
                // Enlist the commands into this transaction.
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;
                // Execute the commands.
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();
                // Simulate error.
                if(throwEx)
                {
                    throw new Exception("sorry! error database failed!  transaction failed ");
                }
                tx.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Any error will roll back transaction. Using the new conditional access operator to
                //check for null.
                tx?.Rollback();

            }
            finally
            {
                CloseConnection();
            }
        }

    }
}
