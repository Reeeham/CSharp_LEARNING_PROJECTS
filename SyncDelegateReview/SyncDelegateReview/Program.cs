using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncDelegateReview
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);

        static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Invoke Add() in a synchronous manner.
            BinaryOp binaryOp = new BinaryOp(Add);
            //could also write binaryOp.Invoke(10,10)
            int answer = binaryOp(10, 10);
            // These lines will not execute until
            // the Add() method has completed.
            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);

            Console.WriteLine("***** Async Delegate Invocation *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Once the next statement is processed,
            // the calling thread is now blocked until
            // BeginInvoke() completes.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);
            // This call takes far less than five seconds!
            //Thread.Sleep(1000);
            // This message will keep printing until
            // the Add() method is finished.
            //ar.IsCompleted
            /*while (!ar.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);//it prevents the same message from printing hundreds of times 
            }*/
            while (!ar.AsyncWaitHandle.WaitOne(1000, true))/*The benefit of WaitHandle.WaitOne() is that you can specify the
                                            maximum wait time. If the specified amount of time is exceeded, WaitOne() returns false*/  
            {
                Console.WriteLine("Doing more work in Main()!");
            }
            // Now we are waiting again for other thread to complete!
            int answer2 = b.EndInvoke(ar);
            Console.WriteLine("10 + 10 is {0}.", answer2);
           

            Console.ReadLine();

        }

        private static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            int result = x + y;
            return result;
            
        }
    }
}
