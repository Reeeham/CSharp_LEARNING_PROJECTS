using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    class Program
    {
        // A generic Point structure.
        public struct Point<T>
        {
            // Generic state date.
            private T xPos;
            private T yPos;
            // Generic constructor.
            public Point(T xVal, T yVal)
            {
                xPos = xVal;
                yPos = yVal;
            }
            // Generic properties.
            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }
            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }
            public override string ToString() => $"[{xPos}, {yPos}]";
            // Reset fields to the default value of the
            // type parameter.
            public void ResetPoint()
            {
                xPos = default(T);
                yPos = default(T);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Generic Structures *****\n");
            // Point using ints.
            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine("p.ToString()={0}", p.ToString());
            p.ResetPoint();
            Console.WriteLine("p.ToString()={0}", p.ToString());
            Console.WriteLine();
            // Point using double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            p2.ResetPoint();
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            Console.ReadLine();
        }
        // MyGenericClass derives from object, while
        // contained items must have a default ctor.
        //however, you should be aware that the new() constraint must always be listed last!
        public class MyGenericClass<K, T> where K :  new() where T : struct, IComparable<T>
        {
            // This method will swap any structure, but not classes.
            static void Swap<T>(ref T a, ref T b) where T : struct
            {
            }
        }
        // Illustrative code only!
        /*public class BasicMath<T> where T : operator + , operator - ,operator *, operator / {
            public T Add(T arg1, T arg2)
            { return arg1 + arg2; }
            public T Subtract(T arg1, T arg2)
            { return arg1 - arg2; }
            public T Multiply(T arg1, T arg2)
            { return arg1 * arg2; }
            public T Divide(T arg1, T arg2)
            { return arg1 / arg2; }
        } */
    }
}
