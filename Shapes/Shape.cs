using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
   public abstract class Shape
    {
        public string PetName { get; set; }

        public Shape(string name = "NoName")
        {
            PetName = name;
        }
        // Force all child classes to define how to be rendered.
        public abstract void Draw();

        // Every derived class must now support this method!,ThreeDCircle) must now provide a concrete implementation of this function
        public abstract byte GetNumberOfPoints();

    }
}
