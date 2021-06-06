using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Need to import this namespace to do any reflection!
using System.Reflection;
namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = "";
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");
                // Get name of type.
                typeName = Console.ReadLine();
                //System.Int32
                //System.Collections.ArrayList
                //System.Threading.Thread
                //System.Void
                //System.IO.BinaryWriter
                //System.Math
                //System.Console
                //MyTypeViewer.Program
                //System.Collections.Generic.List`1 , Here, you are using the numerical value of 1, given that List<T> has only one type parameter.
                //if you want to reflect over Dictionary<TKey, TValue>, you would supply the value 2

                //Does user want to quit
                if (typeName.Equals("Q",StringComparison.OrdinalIgnoreCase))
            {
                    break;
            }
                try
                {
                    Type type = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(type);
                    ListFields(type);
                    ListProps(type);
                    ListMethods(type);
                    ListInterfaces(type);


                }catch
                {
                    Console.WriteLine("Sorry , can't find type");
                }
            } while (true);
        }
        // Display method names of type.
        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                // Get return type.
                string retVal = m.ReturnType.FullName;
                string paramInfo = "( ";
                // Get params.
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
                }
                paramInfo += " )";
                // Now display the basic method sig.
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            Console.WriteLine();
        }
        // Display field names of type.
        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = from m in t.GetFields() select m.Name;
            foreach (var name in fieldNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }
        // Display property names of type.
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }
        // Display implemented interfaces.
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
        }
        // Just for good measure.
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }
}
