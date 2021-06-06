using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Rusty", 90);
            try
            {
                car.Accelerate(50);
            }
            catch (CarIsDeadException ex) when (ex.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                // This new line will only print if the when clause evaluates to true.
                Console.WriteLine("Catching car is dead!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.CauseOfError);
                Console.WriteLine(ex.ErrorTimeStamp);
                try
                {
                    FileStream fs = File.Open("D:\\data science.txt", FileMode.Open);

                }
                catch (Exception e2)
                {
                    //Throw an exception that record the new exception
                    // as well as the message of the first exception
                    throw new CarIsDeadException(e2.Message, e2);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }// This will catch any other exception
             // beyond CarIsDeadException or
             // ArgumentOutOfRangeException.
            catch
            {
                // a generic catch
                Console.WriteLine("oh something wrong happened !!");
                // Do any partial processing of this error and pass the buck.
                //if your catch block is only able to partially
                // handle the error at hand
                throw;
            }
            finally
            {
                // this will always occur. Eception or not
                /*If you did not include a finally block, the radio would not be turned off if an exception were
                  encounteredclose a file, or detach from a database (or whatever), a finally block ensures a location
                  for proper cleanup*/
                car.CrankTunes(false);
            }//catch(Exception e){}
            Console.ReadLine();
           
        }
    }
}
