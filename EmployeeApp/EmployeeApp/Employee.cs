using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
   partial class Employee
    // Field Data
    // Constructors
    // Methods
    // Properties

    /* * Using partial classes, you could choose to move (for example) the properties, constructors, and field
         data into a new file named Employee.Core.cs The first step is to add the partial keyword to the current
         class definition and cut the code to be placed into the new file like this( partial class Employee)*/
    //Remember that every aspect of a partial class definition must be marked with the partial keyword!
    { // Field data.
        private string empName;
        private int empID;
        private float currPay;
        // New field and property.
        private int empAge;
        private string empSSN;
        // A static point of data.
        private static double currInterestRate = 0.04;
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
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
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
        // Constructors.
        public Employee() { }
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
        public void GiveBonus(float amount)
        {
            currPay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("Pay: {0}", currPay);
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
    }
}
