using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();
            IEnumerator carEnumerator = carLot.GetEnumerator();
            carEnumerator.MoveNext();
            Car myCar = (Car)carEnumerator.Current;
            Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);

            Console.WriteLine("***** Fun with the Yield Keyword *****\n");
            Garage carLot2 = new Garage();
            // Get items using GetEnumerator().
            foreach (Car c in carLot2)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.CurrentSpeed);
            }
            // Get items (in reverse!) using named iterator.
            foreach (Car c in carLot2.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.CurrentSpeed);
            }
            Console.ReadLine();
        }
    }
}
