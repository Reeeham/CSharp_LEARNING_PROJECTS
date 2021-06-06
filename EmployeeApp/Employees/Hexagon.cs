using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Hexagon 
    {
        public string Name { get; set; }
        public Hexagon() { }
        public Hexagon(string name) { Name = name;  }
        public  void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", Name);
        }
    }
}
