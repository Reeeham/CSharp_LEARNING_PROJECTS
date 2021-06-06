using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreads
{
    public  class AddParams
    {
        public int a, b;
        public AddParams(int num1,int num2)
        {
            a = num1;
            b = num2;
        }
    }


    class Program
    {
        //way to force a thread to wait until another is completed is to use the AutoResetEvent class
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        


        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",Thread.CurrentThread.ManagedThreadId);
            // Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10,10);
            //ParameterizedThreadStart takes method that takes object and returns nothing
            Thread bgroundThread = new Thread(new ParameterizedThreadStart(Add));
            // This is now a background thread.
            bgroundThread.IsBackground = true;
            bgroundThread.Start(ap);
            // Force a wait to let other thread finish.

            // Wait here until you are notified!
            waitHandle.WaitOne();
    
            Console.WriteLine("Other thread is done!");
            // Tell other thread we are done.
            waitHandle.Set();


        }
        static void Add(object data)
        {
            if(data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}",Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}",ap.a,ap.b,ap.a+ap.b);
            }
        }
    }
        
}
