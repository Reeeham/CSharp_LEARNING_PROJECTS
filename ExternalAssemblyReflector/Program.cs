using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO; // For FileNotFoundException definition.

namespace ExternalAssemblyReflector
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
           // string asmName = "";
            Assembly asm = null;
            // Make use of AssemblyName to define the display name.
            AssemblyName asmName;
            asmName = new AssemblyName();
            asmName.Name = "CarLibrary";
            Version v = new Version("1.0.0.0");
            asmName.Version = v;
            Assembly a = Assembly.Load(asmName);
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");
                // Get name of assembly.
                //asmName = Console.ReadLine();
                // Does user want to quit?
               /* if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }*/
                // Try to load assembly.
                try
                {
                    asm = Assembly.Load(asmName);//you can pass full path C:\MyCode\CarLibrary.dll
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }
            } while (true);
        }
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            var types = from m in asm.GetTypes() select m;
            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }
    }
}
