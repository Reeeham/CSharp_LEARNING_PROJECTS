using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
      
            Console.WriteLine("***** LINQ Return Values *****\n");
            IEnumerable<string> subset = GetStringSubset();
            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
};
            Console.WriteLine("***** LINQ over ArrayList *****");
            // Here is a nongeneric collection of cars.
            ArrayList myCarsArrayList = new ArrayList() {
new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
};
            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCarsArrayList.OfType<Car>();
            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            Console.ReadLine();
        }
        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                                      "System Shock 2"};

            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;
           // IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g =>g).Select(g => g);
            ReflectOverQueryResults(subset, "Extension Methods");
            ReflectOverQueryResults(subset, "Extension Methods");
            foreach (string s in subset)
                Console.WriteLine("Item {0} :" , s);
        }
        static void QueryOverStringsWithExtensionMethods()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                                             "System Shock 2"};
            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset =
            currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        static void QueryOverStringsLongHand()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
"System Shock 2"};
            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }
            // Now sort them.
            Array.Sort(gamesWithSpaces);
            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }
        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
{
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Print only items less than 10.
            // Use implicit typing here...
            var subset = from i in numbers where i < 10 select i;
            //Get data RIGHT NOW as int[].
            int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();
            // Get data RIGHT NOW as List<int>.
            List<int> subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList<int>();

            foreach (var i in subset)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);
        }
        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            // Note subset is an IEnumerable<string>-compatible object.
            IEnumerable<string> theRedColors = from c in colors where c.Contains("Red") select c;
            return theRedColors;
        }
        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var theRedColors = from c in colors where c.Contains("Red") select c;
            // Map results into an array.
            return theRedColors.ToArray();
        }
        static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<>, where the Speed is
            // greater than 55.
            var fastCars = from c in myCars where c.Speed > 55 && c.Make == "BMW" select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();
            // Prints out 10, 400, and 8.
            foreach (int i in myInts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }
    }
}
