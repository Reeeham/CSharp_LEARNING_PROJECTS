using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConceptsInCSharp
{
    class SavingsAccount
    {
        // Instance-level data.
        public double currBalance;

        // A static point of data.
        public static double currInterestRate;

        public SavingsAccount(double balance)
        {
            //currInterestRate = 0.04; // This is static data!
            currBalance = balance;
        }
        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate)
        { currInterestRate = newRate; }

        public static double GetInterestRate()
        { return currInterestRate; }
        /* 
         * “In static ctor!” prints only one time, 
         * as the CLR calls all static constructors before the first use
         * (and never calls them again for that instance of the application).*/
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }
    }
}
