using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        // Is the car alive or dead?
        private bool carIsDead;
        // 1) Define a delegate type.
        // This delegate works in conjunction with the
        // Car's events.
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        // This car can send these events.
        public event EventHandler<CarEventArgs> AboutToBlow;
        public event EventHandler<CarEventArgs> Exploded;


        // Class constructors.
        public Car() { }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        
        // 2) Define a member variable of this delegate.
        public CarEngineHandler listOfHandlers;

        // 3) Add registration function for the caller.
        // Now with multicasting support!
        // Note we are now using the += operator, not
        // the assignment operator (=).
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            /*if (listOfHandlers == null)
             * listOfHandlers = methodToCall;
             * else
              listOfHandlers = Delegate.Combine(listOfHandlers, methodToCall) as CarEngineHandler;
             */
            listOfHandlers += methodToCall;
        }
        // 4) Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (carIsDead)
            {
              
                    Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
            }
            if (CurrentSpeed >= MaxSpeed)
                carIsDead = true;
            else
                Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
        }
    

    public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
    {
        listOfHandlers -= methodToCall;
    }
       
    }
        }

