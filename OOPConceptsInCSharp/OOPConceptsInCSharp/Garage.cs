using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    class Garage
    {
        // The hidden backing field is set to 1.
        public int NumberOfCars { get; set; } = 1;
        // The hidden backing field is set to a new Car object.
        public Car MyAuto { get; set; } = new Car();

        // Must use constructors to override default
        // values assigned to hidden backing fields.
        public Garage()
        {
            MyAuto = new Car();
            NumberOfCars = 1;
        }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
