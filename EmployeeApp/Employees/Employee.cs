using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
   public abstract partial class Employee
    // Field Data
    // Constructors
    // Methods
    // Properties

    /* * Using partial classes, you could choose to move (for example) the properties, constructors, and field
         data into a new file named Employee.Core.cs The first step is to add the partial keyword to the current
         class definition and cut the code to be placed into the new file like this( partial class Employee)*/
    //Remember that every aspect of a partial class definition must be marked with the partial keyword!
    { // Field data.
        protected string empName;
        protected int empID;
        protected float currPay;
        // New field and property.
        protected int empAge;
        protected string empSSN;
        // A static point of data.
        protected static double currInterestRate = 0.04;
        // A static property.
        public static double InterestRate
        {
            get { return currInterestRate; }
            set { currInterestRate = value; }
        }
        // Automatic properties!No need to define backing fields.like this
        // Read-only property? This is OK!
        // Write only property? Error!
        public int MyProperty { get; set; }

        // Properties!
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15) Console.WriteLine("Error! Name length exceeds 15 characters!");
                else empName = value;
            }
        }
        

        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        //expression bodied members
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }

        // Contain a BenefitPackage object.
        //At this point, you have successfully contained another object.has-a relation ship (delegation or aggregation/containment)
        protected BenefitPackage empBenefits = new BenefitPackage();

        public BenefitPackage benefit { get { return empBenefits; } set { empBenefits = value; } }



        // Constructors.
        public Employee() { }
        public Employee(string name, int age , int id , float pay , string ssn ):this(name,age,id,pay)
        {
            empSSN = ssn;
        }
        public Employee(string name, int age, int id, float pay)
        {
            // Better! Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            // Humm, this seems like a problem...
            if (name.Length > 15)
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            else
                empName = name;
            empID = id;
            empAge = age;
            currPay = pay;
        }
        public Employee(string name, int id, float pay): this(name, 0, id, pay) { }
        // Methods.

        // This method can now be "overridden" by a derived class.
        public virtual void GiveBonus(float amount)
        {
            currPay += amount;
        }
        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("Pay: {0}", currPay);
            Console.WriteLine("SSN: {0}", SocialSecurityNumber);
        }
        // Accessor (get method).
        public string GetName()
        {
            return empName;
        }
        // Mutator (set method).
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            else
                empName = name;
        }

        // Expose certain benefit behaviors of object.
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }
            // Assume we have other members that represent
            // dental/health benefits, and so on.
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }
       
    }
}
