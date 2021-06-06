using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreadedPrinting
{
    class InterlockedThreading
    {

        private object threadLock = new object();
        private int intVal = 0;

        public void AddOne()
        {
            lock(threadLock)
            {
                intVal++;
            }
        }

        public void AddOneByInterlockedClass()
        {
            int newVal = Interlocked.Increment(ref intVal);
        }

        //the Interlocked type allows you to atomically assign numerical and object data.
        //if you want to assign the value of a member variable to the value 83,
        public void SafeAssignment()
        {
            Interlocked.Exchange(ref intVal, 83);
        }

        //Finally, if you want to test two values for equality and change the point of comparison in a thread-safe manner
        //you are able to leverage the Interlocked.CompareExchange()
        public void CompareAndExchange()
        {
            // If the value of i is currently 83, change i to 99.
            Interlocked.CompareExchange(ref intVal, 83, 99);
        }
    }
}
