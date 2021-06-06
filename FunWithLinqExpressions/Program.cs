using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");
            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH",
                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love",NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible",NumberInStock = 120},
                new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness",NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet",NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}};
            // We will call various methods here!
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
            Console.ReadLine();
        }
        static void ListProductNames(ProductInfo[] products)
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;
            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }
        static void GetCountFromQuery()
        {//Obtaining Counts Using Enumerable
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
"System Shock 2"};
            // Get count from the query.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();
            // Print out the number of items.
            Console.WriteLine("{0} items honor the LINQ query.", numb);
        }
        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Get names of products, alphabetized.
            var subset = from p in products orderby p.Name ascending select p;
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
        }
        static void DisplayDiff()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            // Get the common members.
            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
            // Get the union of these containers.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            //Removing Duplicates
            var carDistinct = (from c in myCars select c).Concat(from c2 in yourCars select c2).Distinct();
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Prints Yugo.
            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
                                      // Prints:
                                      // Yugo Aztec BMW BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            // Various aggregation examples.
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }
        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter","System Shock 2"};
            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter","System Shock 2"};
            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            var subset = currentVideoGames.Where(game => game.Contains(" "))
            .OrderBy(game => game).Select(game => game);
            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter","System Shock 2"};
            // Build the necessary Func<> delegates using anonymous methods.
            Func<string, bool> searchFilter = delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };
            // Pass the delegates into the methods of Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).
            Select(itemToProcess);
            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
    }
}
