using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
            // All of these invocations call the
            // same Draw() method!
            Octagon oct = new Octagon();
            IDrawToForm idtf = (IDrawToForm)oct;
            idtf.Draw();
         
            // Could also use the "is" keyword.
            if (oct is IDrawToMemory dtm) dtm.Draw();

            // Shorthand notation if you don't need
            // the interface variable for later use.
            ((IDrawToPrinter)oct).Draw();

            Console.ReadLine();
        }
    }
}
