using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myInts = { 10, 4, 2, 33, 93 };
            // Specify the placeholder to the generic
            // Sort<>() method.
            Array.Sort<int>(myInts);
            foreach (int i in myInts)
            {
                Console.WriteLine(i);
            }
            // Init a standard array.
            int[] myArrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Init a generic List<> of ints.
            List<int> myGenericList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Init an ArrayList with numerical data.
            ArrayList myList = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<Person> myListOfPersons = new List<Person>{new Person { FirstName = "Reham", LastName = "Gamal",Age = 22 },
                                         new Person { FirstName = "Youssef", LastName = "Yasser",Age = 23 },
                                        new Person { FirstName = "Ree", LastName = "Gamal",Age = 22 }};
            // Print out # of items in List.
            Console.WriteLine("Items in list: {0}", myListOfPersons.Count);
            // Enumerate over list.
            foreach (var person in myListOfPersons)
            {
                Console.WriteLine(person);
            }
            // Insert a new person.
            Console.WriteLine("\n->Inserting new person.");
            myListOfPersons.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Items in list: {0}", myListOfPersons.Count);

            // Copy data into a new array.
            Person[] arrayOfPeople = myListOfPersons.ToArray();
            foreach (Person p in arrayOfPeople)
            {
                Console.WriteLine("First Names: {0}", p.FirstName);
            }



            Console.ReadLine();


        }
        static void SimpleBoxUnboxOperation()
        {
            // Make a ValueType (int) variable.
            int myInt = 25;
            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox the reference back into a corresponding int.
            int unboxedInt = (int)boxedInt;
            // Value types are automatically boxed when
            // passed to a member requesting an object.

            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            // Unboxing occurs when an object is converted back to
            // stack-based data.
            int i = (int)myInts[0];

            // Now it is reboxed, as WriteLine() requires object types!
            Console.WriteLine("Value of your int: {0}", i);
        }
        static void ArrayListOfRandomObjects()
        {
            // The ArrayList can hold anything at all.
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);
        }
        static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));
            // This would be a compile-time error!
            // myPeople.AddPerson(new Car());
            foreach (Person p in myPeople)
                Console.WriteLine(p);
        }

        static void UseGenericList()
        {
            Console.WriteLine("***** Fun with Generics *****\n");
            // This List<> can hold only Person objects.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);
            // This List<> can hold only integers.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];
        }
        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Now look at the top item, pop it, and look again.
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person item is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            try
            {
                Console.WriteLine("\nnFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
            }
        }
        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }
        static void UseGenericQueue()
        {
            // Make a Q with three people.
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Peek at first person in Q.
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);
            // Remove each person from Q.
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            // Try to de-Q again?
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }
        }
        static void UseSortedSet()
        {
            // Make some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
{
new Person {FirstName= "Homer", LastName="Simpson", Age=47},
new Person {FirstName= "Marge", LastName="Simpson", Age=45},
new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
new Person {FirstName= "Bart", LastName="Simpson", Age=8}
};
            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });
            // Still sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
        private static void UseDictionary()
        {
            // Populate using Add() method
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Get Homer.
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);
            // Populate with initialization syntax.
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
{
{ "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
{ "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
   { "Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
};
            // Get Lisa.
            Person lisa = peopleB["Lisa"];
            Console.WriteLine(lisa);
            // Populate with dictionary initialization syntax.
            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
            };
        }
    }
}
