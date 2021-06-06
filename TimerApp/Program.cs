using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
namespace TimerApp //that will print the current time every second until the user presses a key to terminate the application.
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            // Create the delegate for the Timer type.
            TimerCallback timerCallback = new TimerCallback(PrintTime);
            // Establish timer settings.
            //Using a Stand-Alone Discard because the Timer variable isn’t used in any execution path
            //so it can be replaced with a discard
            var _ = new Timer(
                timerCallback,// The TimerCallback delegate object.
                "Hello From Main", // Any info to pass into the called method (null for no info).
                0, // Amount of time to wait before starting (in milliseconds).
                1000//// Interval of time between calls (in milliseconds).
                );
            Console.WriteLine("Hit Enter key to terminate...");
            Console.ReadLine();
            /*the PrintTime() method will be called roughly every second and will pass in no additional
             * information to said method*/

            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");

            Console.WriteLine("Main thread started. ThreadID = {0}",Thread.CurrentThread.ManagedThreadId);
            Printer p = new Printer();
            WaitCallback waitCallback = new WaitCallback(PrintTheNumbers);
            // Queue the method ten times.
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(waitCallback, p);
                Console.WriteLine("All tasks queued");
                Console.ReadLine();
            }


        }

        private static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }

        //given that the TimerCallback delegate can only call methods that match this signature.
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }

    }
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
}
