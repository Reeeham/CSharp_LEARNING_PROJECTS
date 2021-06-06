using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);

    // This class contains methods BinaryOp will
    // point to.
    public class SimpleMath
    {
        public int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int SquareNumber(int a) => a * a;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            BinaryOp b = new BinaryOp(SimpleMath.Subtract);
            // .NET delegates can also point to instance methods as well.
            SimpleMath m = new SimpleMath();
            BinaryOp b2 = new BinaryOp(m.Add);
            DisplayDelegateInfo(b);

            // Invoke Add() method indirectly using delegate object.
            // Invoke() is really called here!
            Console.WriteLine("10 + 10 is {0}", b(10, 10));
            //C# does not require you to explicitly call Invoke() within your codebase
            //Console.WriteLine("10 + 10 is {0}", b.Invoke(10, 10));

            Console.WriteLine("***** Delegates as event enablers *****\n");
            // First, make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);
            // Now, tell the car which method to call
            // when it wants to send us messages.
            // Register multiple targets for the notifications
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);
            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            // Unregister from the second handler.
            c1.UnRegisterWithCarEngine(handler2);


            // We won't see the "uppercase" message anymore!
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }
        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Print the names of each member in the
            // delegate's invocation list.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }

        // This is the target for incoming events.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}
