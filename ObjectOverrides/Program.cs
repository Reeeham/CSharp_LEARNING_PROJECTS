using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p1 = new Person();
            // Use inherited members of System.Object.
            Console.WriteLine("ToString: {0}", p1.ToString());
            Console.WriteLine("Hash code: {0}", p1.GetHashCode());
            Console.WriteLine("Type: {0}", p1.GetType());
            // Make some other references to p1.
            Person p2 = p1;
            object o = p2;
            // Are the references pointing to the same object in memory?
            if (o.Equals(p1) && p2.Equals(o))
            {
                Console.WriteLine("Same instance!");
            }

            bool result = Person.Equals(p1, o);
            Console.WriteLine(result);

            // NOTE: We want these to be identical to test
            // the Equals() and GetHashCode() methods.
            Person p3 = new Person("Homer", "Simpson", 50);
            Person p4 = new Person("Homer", "Simpson", 50);

            // Get stringified version of objects.
            Console.WriteLine("p1.ToString() = {0}", p3.ToString());
            Console.WriteLine("p2.ToString() = {0}", p4.ToString());
            // Test overridden Equals().
            Console.WriteLine("p3 = p4?: {0}", p3.Equals(p4));

            // Test hash codes.
            Console.WriteLine("Same hash codes?: {0}", p3.GetHashCode() == p4.GetHashCode());
            Console.WriteLine();

            // Change age of p2 and test again.
            p3.Age = 45;
            Console.WriteLine("p3.ToString() = {0}", p3.ToString());
            Console.WriteLine("p4.ToString() = {0}", p4.ToString());
            Console.WriteLine("p3 = p4?: {0}", p3.Equals(p4));
            Console.WriteLine("Same hash codes?: {0}", p3.GetHashCode() == p4.GetHashCode());

            Console.ReadLine();
        }
    }
    }

