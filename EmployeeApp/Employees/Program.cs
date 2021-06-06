using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "youssef";
            fred.SalesNumber = 100;

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            double cost = chucky.GetBenefitCost();
            chucky.GiveBonus(300);
            chucky.DisplayStats();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();

            // Define my benefit level.
            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel =
            Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            // Use "as" to test compatibility at runtime.
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager();
            things[3] = "Last thing";
            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                    Console.WriteLine("Item is not a hexagon");
                else
                {
                    h.Draw();
                }
            }

            Console.ReadLine();
        }
        static void CastingExamples()
        {
            // A Manager "is-a" System.Object, so we can
            // store a Manager reference in an object variable just fine.
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            // OK!
            GivePromotion((Manager)frank);
            // A Manager "is-an" Employee too.
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);
            // A PTSalesPerson "is-a" SalesPerson.
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }

        //Because this method takes a single parameter of type Employee, you can effectively pass any descendant
        //from the Employee class into this method directly
        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} was promoted!", emp.Name);
            //Check if is SalesPerson, assign to variable s
            //if (emp is SalesPerson s)
            //{
            //    Console.WriteLine("{0} made {1} sale(s)!", emp.Name,
            //    (s.SalesNumber));
            //    Console.WriteLine();
            //}
            ////Check if is Manager, if it is, assign to variable m
            //if (emp is Manager m)
            //{
            //    Console.WriteLine("{0} had {1} stock options...", emp.Name,
            //    (m.StockOptions));
            //    Console.WriteLine();
            //}
            Console.WriteLine("{0} was promoted!", emp.Name);
            switch (emp)
            {
               // If the cast in the first case statement succeeds, the variable s will hold an instance of a SalesPerson class
               //These new additions to the is and switch statements provide nice improvements that help reduce the
               // amount of code to perform matching,
                case SalesPerson s when s.SalesNumber > 5:
                    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, s.SalesNumber);
                    break;
                case Manager m:
                    Console.WriteLine("{0} had {1} stock options...", emp.Name, m.StockOptions);
                    break;
                case Intern _:
                    //Ignore interns
                    break;
                case null:
                    //Do something when null
                    break;
            }
        }
    }
}
