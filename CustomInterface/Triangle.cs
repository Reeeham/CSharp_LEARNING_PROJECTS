using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }

        public Triangle(string name) : base(name) { }
        public byte Points { get { return 3; } }

        public byte NumberOfPoints => throw new NotImplementedException();

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", PetName);
        }

        public override byte GetNumberOfPoints()
        {
            throw new NotImplementedException();
        }
    }
}
