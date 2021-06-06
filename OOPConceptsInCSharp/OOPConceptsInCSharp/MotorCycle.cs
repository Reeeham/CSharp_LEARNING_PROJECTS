using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    class MotorCycle
    {
        public int driverIntensity;
        public string driverName;

        // Put back the default constructor, which will
        // set all data members to default values.
        public MotorCycle() => Console.WriteLine("In default ctor");

        // Redundant constructor logic!
        public MotorCycle(int intensity) : this(intensity, "") => Console.WriteLine("In ctor taking an int");

        public MotorCycle(String name): this(0,name) => Console.WriteLine("In ctor taking a string");

        // This is the 'master' constructor that does all the real work.
        // Single constructor using optional args.
        public MotorCycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
       
        public void PopAWheely()
        {
            Console.WriteLine("Yeeeeeee Haaaaaeewww!");
        }
        public void SetDriverName(string name)
        {
            driverName= name;
        }

    }
}
