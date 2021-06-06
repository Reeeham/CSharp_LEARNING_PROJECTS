using AutoLotDAL_Core2.EF;
using AutoLotDAL_Core2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLotDAL_Core2.DataInitialization
{
    public static class MyDataInitializer
    {
        ///Seeding the database , initializing the database with data using migrations
        ///or the base classes that drop and recreate the db , it's easy to recreate manually
        ///seeding the db simply means creating records in code and adding then using ef funcctions
        
        public static void InitializeData(AutoLotContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{FirstName = "Dave", LastName = "Brenner"},
                new Customer{ FirstName = "Matt" , LastName = "Walton"},
                new Customer{ FirstName = "Steve" , LastName = "Hagen"},
                new Customer{ FirstName = "Pat" , LastName = "Walton"},
                new Customer{ FirstName = "Bad" , LastName = "Customer"}
            };
            customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();
            var cars = new List<Inventory>
            {
               new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
               new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
               new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
               new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
               new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
               new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
               new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
               new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
               new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"}
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
            var orders = new List<Order>{
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));
            context.SaveChanges();
            context.CreditRisks.Add(new CreditRisk
            {
                Id = customers[4].Id,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName,
            });
            context.Database.OpenConnection();
            try
            {
                var tableName = context.GetTableName(typeof(CreditRisk));
                //In 2.0 , must seperate .Net string interpoltion from SQL i bnterpolation
                var rawSqlString = $"SET IDENTITY_INSERT dbo.{tableName} ON;";
                context.Database.ExecuteSqlCommand(rawSqlString);
                context.SaveChanges();
                //the query gets into a pramaterized query like this SET IDENTITY_INSERT dbo.@p0 ON
                ///if you don't want paramterized quey then you musn't use string interpolation
                rawSqlString = $"SET IDENTITY_INSERT dbo.{tableName} OFF;";
                context.Database.ExecuteSqlCommand(rawSqlString);

            }
            finally
            {
                context.Database.CloseConnection();

            }
        }
        //to drop the existing database and create the database
        public static void RecreateDatabase(AutoLotContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

        }
        //you might not always want to drop and create the database so next you'll create methods to delete 
        //the existing data and reset the sequences 
        public static void ClearData(AutoLotContext context)
        {
            ExecuteDeleteSql(context, "Orders");
            ExecuteDeleteSql(context, "Customers");
            ExecuteDeleteSql(context, "Inventory");
            ExecuteDeleteSql(context, "CreditRisks");
            ResetIdentity(context);

        }
        private static void ExecuteDeleteSql(AutoLotContext context, string tableName)
        {
            //with 2.0 must seperate string interpolation if not passing in params
            var rawSqlString = $"Delete from dbo.{tableName}";
            context.Database.ExecuteSqlCommand(rawSqlString);
        }

        private static void ResetIdentity(AutoLotContext context)
        {
            var tables = new[] { "Inventory", "Orders", "Customers", "CreditRisks" };
            foreach(var item in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"dbo.{item}\",RESEED, -1);";
                context.Database.ExecuteSqlCommand(rawSqlString);


            }
        }
    }
}
