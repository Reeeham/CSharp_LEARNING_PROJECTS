using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    // The iteration of the Car can be ordered
    // based on the CarID.
    public class Car : IComparable
    {
        // The 'state' of the Car.
        public readonly int maxSpeed;
        public int CarID { get; set; }
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
        // Property to return the PetNameComparer.
        public static IComparer SortByPetName
        { get { return (IComparer)new PetNameComparer(); } }
        public string petName;
        private int currSpeed;
        private int numberOfDoors = 2;

        //expression-bodied members
        public void PrintState() => Console.WriteLine($"{petName} is going {currSpeed} MPH");

        public void SpeedUp(int delta) => currSpeed += delta;

        public int CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
            {
                /* if (this.CarID > temp.CarID)
                     return 1;
                 if (this.CarID < temp.CarID)
                     return -1;
                 else
                     return 0; */
                return this.CarID.CompareTo(temp.CarID);
            }
            else
                throw new ArgumentException("Parameter is not a Car!");
        }

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

        public Car(string name, int currSp, int id)
        {
            currSpeed = currSp;
            petName = name;
            CarID = id;
        }

        // This helper class is used to sort an array of Cars by pet name.
        public class PetNameComparer : IComparer
        {
            // Test the pet name of each object.
            int IComparer.Compare(object obj1, Object obj2)
            {
                Car car1 = obj1 as Car;
                Car car2 = obj2 as Car;
                if (car1 != null && car2 != null)
                    return String.Compare(car1.petName, car2.petName);
                else
                    throw new ArgumentException("paramter is not a car");

            }


        }
    }
}
