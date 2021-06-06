using AutoLotDAL.EF;
using AutoLotDAL_Core2.EF;
using AutoLotDAL_Core2.DataInitialization;
using System;
using System.Linq;
using AutoLotDAL_Core2.Models;
using AutoLotDAL_Core2.Repos;
using Microsoft.EntityFrameworkCore;


namespace AutoLotDAL_Core2.TestDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with ADO>NET EF Core 2 ******\n");
            using (var context = new AutoLotContext())
            {
                MyDataIntializer.RecreateDatabase(context);
                MyDataInitializer.InitializeData(context);
                foreach(Inventory c in context.Cars)
                {
                    Console.WriteLine(c);

                }
            }
            Console.ReadLine();
        }
        /// running this code first drops and creates the database (using the migrations)
        /// populates the data and then retrieves the records first using AutoLotContext and then using InventoryRepo
        /// 
    }
}
