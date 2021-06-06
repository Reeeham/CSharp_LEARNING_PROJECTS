using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // NameOfObject.NameOfEvent += new RelatedDelegate(functionToCall);
            Car myCar = new Car();
            //Car.CarEngineHandler d = new Car.CarEngineHandler(CarExplodedEventHandler);
           // myCar.Exploded += d;
            // NameOfObject.NameOfEvent -= new RelatedDelegate(functionToCall);
            //
            //myCar.Exploded -= d;

            Console.WriteLine("***** Fun with Events *****\n");
            //simplify event registration, you can use method group conversion
            Car c1 = new Car("SlugBug", 100, 10);
            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            c1.Exploded -= CarExploded;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);


            Console.WriteLine("***** Prim and Proper Events *****\n");
            // Make a car as usual.
            Car c2 = new Car("SlugBug", 100, 10);
            // Register event handlers.
            c2.AboutToBlow += CarIsAlmostDoomed;
            // Hook into events with lambdas!
            c2.AboutToBlow += (sender, e)  => Console.WriteLine(e.msg);
            EventHandler<CarEventArgs> d1 = new EventHandler<CarEventArgs>(CarExploded);
            c2.Exploded += d1;

            Console.WriteLine("***** Anonymous Methods *****\n");
            Car c3 = new Car("SlugBug", 100, 10);
            // Register event handlers as anonymous methods.
            c3.AboutToBlow += delegate
            {
                Console.WriteLine("Eek! Going too fast!");
            };
            c3.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Message from Car: {0}", e.msg);
            };
            c3.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };
            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c3.Accelerate(20);
            Console.ReadLine();

        }


        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car c)
            {
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        { Console.WriteLine("=> Critical Message from Car: {0}", e.msg); }
        public static void CarExploded(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }
    }

}
