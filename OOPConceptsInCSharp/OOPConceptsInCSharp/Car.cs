using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    class Car
    {
        private Radio myRadio = new Radio();
        // The 'state' of the Car.
        public readonly int maxSpeed;
        public int Speed
        {
            get { return currSpeed; }
            set
            {
                currSpeed = value;
                if (currSpeed > maxSpeed)
                {
                    currSpeed = maxSpeed;
                }
            }
        }
        public string petName;
        private int currSpeed;
        private int numberOfDoors = 2;

        //expression-bodied members
        public void PrintState() => Console.WriteLine($"{petName} is going {currSpeed} MPH");

        public void SpeedUp(int delta) => currSpeed += delta;

        public Car()
        {
            petName = "Chuck";
            currSpeed = 10;
        }
        public Car(int max)
        {
            maxSpeed = max;
        }
        // Here, currSpeed will receive the
        // default value of an int (zero).
        public Car(String pn)
        {
            petName = pn;
        }

        public Car(String pn, int cs)
        {
            petName = pn;
            currSpeed = cs;
        }
        public void TurnOnRadio(bool onOff)
        {
            // Delegate call to inner object.
            myRadio.Power(onOff);
        }
    }
}
