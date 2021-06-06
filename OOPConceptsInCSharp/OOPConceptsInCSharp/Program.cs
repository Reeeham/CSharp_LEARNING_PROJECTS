using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Encapsulation Concept
            /* Car myCar = new Car();

             for(int i=0; i<10; i++)
             {
                 myCar.SpeedUp(5);
                 myCar.PrintState();
             }
             // Make a Car called Mary going 0 MPH.
             Car mary = new Car("Mary");
             mary.PrintState();
             // Make a Car called Daisy going 75 MPH.
             Car daisy = new Car("Daisy", 75);
             daisy.PrintState(); */
            #endregion

            #region Constructor chaining 
            /*    // Make a Motorcycle.
                MotorCycle m = new MotorCycle(5);
                m.SetDriverName("Tiny");
                m.PopAWheely();

                MotorCycle m2 = new MotorCycle(name: "Rere");
                Console.WriteLine("Name = {0} , intensity = {1} ", m2.driverName,m2.driverIntensity); */
            #endregion

            #region Static understanding
            /*  
               Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
               SavingsAccount s1 = new SavingsAccount(50);
               // Try to change the interest rate via property.
               SavingsAccount.SetInterestRate(0.08);
               // Make a second account.
               SavingsAccount s2 = new SavingsAccount(100);

               Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate()); */
            #endregion

            #region Static Classes
            /* Console.WriteLine("***** Fun with Static Classes *****\n");
             // This is just fine.
             TimeUtilClass.PrintDate();
             TimeUtilClass.PrintTime();   */
            #endregion

            #region inheritance
            /* // Notice that the object user has no clue that the Car class is using an inner Radio object
            // Call is forwarded to Radio internally.
            Car viper = new Car();
            viper.TurnOnRadio(false); */
            #endregion

            #region polymorphism through interface
            /*Shape[] myShapes = new Shape[3];
            myShapes[0] = new Hexagon();
            myShapes[1] = new Circle();
            myShapes[2] = new Hexagon();

            foreach(Shape shape in myShapes)
            {
                // Use the polymorphic interface!
                shape.Draw();
            }

            Console.ReadLine(); */
            #endregion

            #region default values of properties
            /*  Garage g = new Garage();
              // OK, prints default value of zero.
              // Make a car.
              Car c = new Car();
              c.petName = "Frank";
              c.PrintState();
              g.MyAuto = c;
              Console.WriteLine("Number of Cars: {0}", g.NumberOfCars);
              // Runtime error! Backing field is currently null!
              Console.WriteLine(g.MyAuto.petName);
              Console.ReadLine();
              */
            #endregion

            #region inheritance

            Console.WriteLine("***** Basic Inheritance *****\n");
            // Make a Car object and set max speed.
            Car myCar = new Car(80);
            // Set the current speed, and print it.
            myCar.Speed = 100;
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);

            Console.WriteLine("***** Basic Inheritance *****\n");
            // Now make a MiniVan object.
            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH",myVan.Speed);
            Console.ReadLine();
            #endregion

        }
    }
}
