using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsyncCallbackDelegate
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10,
            new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.");
            // Assume other work is performed here...
            while (!isDone)
            {
                Console.WriteLine("Working....");
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
        //callback method  must take IAsyncResult and returns void
        /*the static AddComplete() method will be invoked by the AsyncCallback delegate when the Add()
           method has completed.*/
        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.
            ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            // Now get the result.
            AsyncResult ar = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            // Retrieve the informational object and cast it to string.
            string msg = (string)iar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
