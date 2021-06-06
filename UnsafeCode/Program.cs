using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    class Program
    { // This entire structure is "unsafe" and can
      // be used only in an unsafe context.
        unsafe struct Node
        {
            public int Value;
            public Node* Left;
            public Node* Right;
        }
        // This struct is safe, but the Node2* members
        // are not. Technically, you may access "Value" from
        // outside an unsafe context, but not "Left" and "Right".

        public struct Node2
        {
            public int Value;
            // These can be accessed only in an unsafe context!
            public unsafe Node2* Left;
            public unsafe Node2* Right;
        }
        struct Point
        {
            public int x;
            public int y;
            public override string ToString() => $"({x}, {y})";
        }
        class PointRef // <= Renamed and retyped.
        {
            public int x;
            public int y;
            public override string ToString() => $"({x}, {y})";
        }
        static unsafe void Main(string[] args)
        {
            
                // Work with pointer types here!
                int myInt = 10;
                // OK, because we are in an unsafe context.
                SquareIntPointer(&myInt);
                Console.WriteLine("myInt: {0}", myInt);

            // Can't work with pointers here!
            int myInt2 = 5;
            // Compiler error! Must be in unsafe context!
            SquareIntPointer(&myInt2);
            Console.WriteLine("myInt: {0}", myInt2);

            Console.WriteLine("***** Calling method with unsafe code *****");
            // Values for swap.
            int i = 10, j = 20;
            // Swap values "safely."
            Console.WriteLine("\n***** Safe swap *****");
            Console.WriteLine("Values before safe swap: i = {0}, j = {1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);
            // Swap values "unsafely."
            Console.WriteLine("\n***** Unsafe swap *****");
            Console.WriteLine("Values before unsafe swap: i = {0}, j = {1}", i, j);
            unsafe { UnsafeSwap(&i, &j); }
            Console.WriteLine("Values after unsafe swap: i = {0}, j = {1}", i, j);
            UseSizeOfOperator();
            Console.ReadLine();
        }
        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            // Square the value just for a test.
            *myIntPointer *= *myIntPointer;
        }
        static unsafe void PrintValueAndAddress()
        {
            int myInt;
            // Define an int pointer, and
            // assign it the address of myInt.
            int* ptrToMyInt = &myInt;
            // Assign value of myInt using pointer indirection.
            *ptrToMyInt = 123;
            // Print some stats.
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }
        public unsafe static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        static unsafe void UsePointerToPoint()
        {
            // Access members via pointer.
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());
            // Access members via pointer indirection.
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }
        static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
                p[k] = (char)k;
        }
        public unsafe static void UseAndPinPoint()
        {
            PointRef pt = new PointRef
            {
                x = 5,
                y = 6
            };
            // Pin pt in place so it will not
            // be moved or GC-ed.
            fixed (int* p = &pt.x)
            {
                // Use int* variable here!
            }
            // pt is now unpinned, and ready to be GC-ed once
            // the method completes.
            Console.WriteLine("Point is: {0}", pt);
        }
        static unsafe void UseSizeOfOperator()
        {
            //the C# sizeof keyword is used to obtain the size in bytes
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
            Console.WriteLine("The size of double is {0}.", sizeof(double));
            Console.WriteLine("The size of decimal is {0}.", sizeof(decimal));
            Console.WriteLine("The size of float is {0}.", sizeof(float));
            Console.WriteLine("The size of Point is {0}.", sizeof(Point));
        }
    }
}
