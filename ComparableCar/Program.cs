using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Sorting *****\n");
            // Make an array of Car objects.
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40, 234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40, 4);
            myAutos[4] = new Car("Chucky", 40, 5);

            // Display current array.
            Console.WriteLine("Here is the unordered set of cars:");
            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.petName);

            // Now, sort them using IComparable!
            Array.Sort(myAutos);
            Console.WriteLine();
            // Display sorted array.
            Console.WriteLine("Here is the ordered set of cars:");

            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.petName);
            // Now sort by pet name.
            // Sorting by pet name made a bit cleaner.
            Array.Sort(myAutos, Car.SortByPetName);
            // Dump sorted array.
            Console.WriteLine("Ordering by pet name:");
            foreach (Car c in myAutos)
                Console.WriteLine("{0} {1}", c.CarID, c.petName);

            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "First", "Second", "Third" });
            // Show number of items in ArrayList.
            Console.WriteLine("This collection has {0} items.", strArray.Count);
            // Display contents.
            foreach (string s in strArray)
            {
                Console.WriteLine("Entry: {0}", s);
            }
            Console.ReadLine();
        }
    }
}
