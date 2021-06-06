using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
  
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("***** GC Basics *****");
            Console.WriteLine("***** Fun with System.GC *****");
            // Print out estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
            // Force a garbage collection and wait for each object to be finalized.
            // Only investigate generation 0 objects.
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            // MaxGeneration is zero based, so add 1 for display purposes.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));
            // Create a new Car object on the managed heap. We are returned a reference to this
            //object("refToMyCar").
            // Print out generation of refToMyCar.
            Car refToMyCar = new Car("Zippy", 50);
            Console.WriteLine("\nGeneration of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
            // Make a ton of objects for testing purposes.
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();
            // Collect only gen 0 objects.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            // See if tonsOfObjects[9000] is still alive.
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");
            // Print out how many times a generation has been swept.
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
            Console.ReadLine();
            // Print out generation of refToMyCar.
            Console.WriteLine("Generation of refToMyCar is: {0}",
            GC.GetGeneration(refToMyCar));
            // The C# dot operator (.) is used to invoke members on the object using our reference
            // variable.
            Console.WriteLine(refToMyCar.ToString());

            Console.ReadLine();
        }
        public enum GCCollectionMode
        {
            Default, // Forced is the current default.
            Forced, // Tells the runtime to collect immediately!
            Optimized // Allows the runtime to determine whether the current time is optimal to reclaim objects.
        }
    }
   
}
