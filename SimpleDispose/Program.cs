using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Create a disposable object and call Dispose()
            // to free any internal resources.
           

            MyResourceWrapper rw = new MyResourceWrapper();
            //to ensure the type’s Dispose() method is called in the event of a runtime exception
            try
            {
                // Use the members of rw.
            }
            finally
            {
                // Always call Dispose(), error or not.
                if(rw is IDisposable)
                           rw.Dispose();
                Console.WriteLine();
            }
            Console.WriteLine("***** Fun with Dispose *****\n");
            // Dispose() is called automatically when the using scope exits.
            //If you attempt to “use” an object that does not implement IDisposable, you will receive a
            //compiler error.While this syntax does remove the need to manually wrap disposable objects within try/finally logic
            //// Use a comma-delimited list to declare multiple objects to dispose.
            using (MyResourceWrapper rw2 = new MyResourceWrapper())
            {
                // Use rw object.
            }
            Console.ReadLine();
        }
        // Assume you have imported
        // the System.IO namespace...
        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);
            // Confusing, to say the least!
            // These method calls do the same thing!
            fs.Close();
            fs.Dispose();
        }
    }
}
