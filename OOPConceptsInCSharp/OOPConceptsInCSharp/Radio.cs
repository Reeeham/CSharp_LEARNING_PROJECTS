using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    // An internal class with a private default constructor.
    internal class Radio
    {

        public Radio() { }
        public void Power( bool turnOn)
        {
            Console.WriteLine($"Radio on {turnOn}");
        }
        
    }
}
