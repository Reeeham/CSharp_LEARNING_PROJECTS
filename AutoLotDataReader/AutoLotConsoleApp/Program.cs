using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;
using static System.Console;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with ADO.NET EF *****\n");

            // int carId = AddNewRecord();
            // WriteLine(carId);
            FunWithLinqQueries();
            ReadLine();
        }
        private static int AddNewRecord(IEnumerable<Car> carsToAdd)
        {
            // Add record to the Inventory table of the AutoLot database.
            using (var context = new AutoLotEntities())
            {
                try
                {
                    // Hard-code data for a new record, for testing.
                    var car = new Car() { Make = "Yugo", Color = "Brown", CarNickName = "Brownie" };
                    context.Cars.AddRange(carsToAdd);
                    context.SaveChanges();
                    // On a successful save, EF populates the database generated identity field.
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }
        private static void PrintAllInventory()
        {
            // Select all items from the Inventory table of AutoLot,
            // and print out the data using our custom ToString() of the Car entity class.
            using (var context = new AutoLotEntities())
            {
                //Select * from Inventory where Make = 'BMW';
                foreach (Car c in context.Cars.Where(c => c.Make == "BMW"))
                {
                    WriteLine(c);
                }
            }
        }
        private static void FunWithLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                //context.Configuration.LazyLoadingEnabled = false;
                //eager loading
                //foreach (Car c in context.Cars.Include(c => c.Orders))
                //{
                //    foreach (Order o in c.Orders)
                //    {
                //        WriteLine(o.OrderId);
                //    }
                //}
                //explicit loading
                //foreach (Car c in context.Cars)
                //{
                //    context.Entry(c).Collection(x => x.Orders).Load();
                //    foreach (Order o in c.Orders)
                //    {
                //        WriteLine(o.OrderId);
                //    }
                //}
                //foreach (Order o in context.Orders)
                //{
                //    context.Entry(o).Reference(x => x.Car).Load();
                //}
                // Get a projection of new data.
                var colorsMakes = from item in context.Cars select new { item.Color, item.Make };
                foreach (var item in colorsMakes)
                {
                    WriteLine(item);
                }
                // Get only items where Color == "Black"
                var blackCars = from item in context.Cars where item.Color == "Black" select item;
                foreach (var item in blackCars)
                {
                    WriteLine(item);
                }
                WriteLine(context.Cars.Find(6));
            }
        }
        private static void ChainingLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                //Not executed
                DbSet<Car> allData = context.Cars;
                //Not Executed.
                var colorsMakes = from item in allData select new { item.Color, item.Make };
                //Now it's executed
                foreach (var item in colorsMakes)
                {
                    WriteLine(item);
                }
            }
        }
        private static void RemoveRecord(int carId)
        {
            // Find a car to delete by primary key.
            using (var context = new AutoLotEntities())
            {
                // See if we have it.
                Car carToDelete = context.Cars.Find(carId);
                if (carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    //This code is purely demonstrative to show the entity state changed to Deleted
                    if (context.Entry(carToDelete).State != EntityState.Deleted)
                    {
                        throw new Exception("Unable to delete the record");
                    }
                    context.SaveChanges();
                }
            }
        }
        private static void RemoveMultipleRecords(IEnumerable<Car> carsToRemove)
        {
            using (var context = new AutoLotEntities())
            {
                //Each record must be loaded in the DbChangeTracker
                context.Cars.RemoveRange(carsToRemove);
                context.SaveChanges();
            }
        }
        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToDelete = new Car() { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine(ex);
                }
            }
        }
        private static void UpdateRecord(int carId)
        {
            // Find a car to delete by primary key.
            using (var context = new AutoLotEntities())
            {
                // Grab the car, change it, save!
                Car carToUpdate = context.Cars.Find(carId);
                if (carToUpdate != null)
                {
                    WriteLine(context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    WriteLine(context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }
    }
}
