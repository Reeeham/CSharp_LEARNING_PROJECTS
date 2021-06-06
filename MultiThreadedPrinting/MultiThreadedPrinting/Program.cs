using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace MultiThreadedPrinting
{
    // All methods of Printer are now thread safe!
    [Synchronization]
    public class Printer : ContextBoundObject
    {
        // Lock token. when you want to use lock on a static method make this object static
        private object threadLock = new object();

        public void PrintNumbers()
        {
            lock (threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");

                for (int i = 0; i < 10; i++)
                {
                    // Put thread to sleep for a random amount of time.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads *****\n");
            // Use the current object as the thread token.
           
                // All code within this scope is thread safe.
                Printer p = new Printer();
            
            
            // Make 10 threads that are all pointing to the same
            // method on the same object.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
                {
                    Name = $"Worker Thread #{i}"
                };
            }
            // Now start each one.
            foreach (Thread thread in threads)
            {
                thread.Start();

            }

        }
    }
}
