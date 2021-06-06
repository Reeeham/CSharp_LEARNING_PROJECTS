using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// BigInteger lives here!
using System.Numerics;
using System.Windows.Forms;


namespace SimplerCSharpConsoleApp
{
    class Program
    {
        #region enum example 1 
        enum EmpType
        {
            Manager, // = 0
            Grunt, // = 1
            Contractor, // = 2
            VicePresident // = 3
        }
        #endregion
        // Begin with 102.
        #region Enum example2
        enum EmpType1
        {
            Manager = 102,
            Grunt, // = 103
            Contractor, // = 104
            VicePresident // = 105
        }
        #endregion
        enum EmpType3 : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }
        class DatabaseReader
        {
            // Nullable data field.
            public int? numericValue = null;
            public bool? boolValue = true;
            // Note the nullable return type.
            public int? GetIntFromDatabase()
            { return numericValue; }
            // Note the nullable return type.
            public bool? GetBoolFromDatabase()
            { return boolValue; }
        }
        struct Point
        {
            // Fields of the structure.
            public int X;
            public int Y;
            public Point(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }
            // Add 1 to the (X, Y) position.
            public void Increment()
            {
                X++; Y++;
            }
            // Subtract 1 from the (X, Y) position.
            public void Decrement()
            {
                X--; Y--;
            }
            // Display the current position.
            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
            public (int XPos, int YPos) Deconstruct => (X,Y);
        }
        static void Main(string[] args)
        {
            // Helper method within the Program class.
            //ShowEnvironmentDetails();

            //GetUserData();

            /* Console.WriteLine("******************My First C# App ***********************");
             Console.WriteLine("******************Hello world ***********************");
             Console.WriteLine();
             Console.ReadLine();  */
            //windows forms library reference

            /*       Escape characters    
             *       
             *       \' Inserts a single quote into a string literal.
             *       \" Inserts a double quote into a string literal
             *       \\ Inserts a backslash into a string literal. This can be quite helpful when defining file ornetwork paths
             *       \a Triggers a system alert (beep). For console programs, this can be an audio clue to the user.
             *       \n Inserts a new line (on Windows platforms).
             *       \r Inserts a carriage return.
             *       \t Inserts a horizontal tab into the string literal.
             *       */

            //DisplayMessage();

            //LocalVarDeclarations();

            // NewingDataTypes();

            // ObjectFunctionality();

            //CharFunctionality();

            //ParseFromStrings();

            //ParseFromStringsWithTryParse();

            //UseDatesAndTimes();

            //UseBigInteger();

            //DigitSeparators();

            // BinaryLiterals();

            //BasicStringFunctionality();

            //EscapeChars();

            // StringEquality();

            //StringEqualitySpecifyingCompareRules();

            //StringsAreImmutable();

            //FunWithStringBuilder();

            // StringInterpolation();

            /* Console.WriteLine("***** Fun with type conversions *****");
             // Add two shorts and print the result.
             short numb1 = 9, numb2 = 10;
             Console.WriteLine("{0} + {1} = {2}",
             numb1, numb2, Add(numb1, numb2)); */

            /*Console.WriteLine("***** Fun with type conversions *****");
            short numb1 = 30000, numb2 = 30000;
            // Explicitly cast the int into a short (and allow loss of data).
            short answer = (short)Add(numb1, numb2);
            Console.WriteLine("{0} + {1} = {2}",
            numb1, numb2, answer);
            NarrowingAttempt(); */

            // Assuming /checked is enabled,
            // this block will not trigger
            // a runtime exception.
            /* unchecked
             {
                 byte b1 = 100;
                 byte b2 = 250;
                 byte sum = (byte)(b1 + b2);
                 Console.WriteLine("sum = {0} ", sum);
             }*/

            // LinqQueryOverInts();

            // WhileLoopExample();

            //SwitchOnEnumExample();

            //ArrayOfObjects();
            //RectMultidimensionalArray();
            // JaggedMultidimensionalArray();
            /*       Member of Array Class:  Clear(),CopyTo(),Length,
             *       Rank =>This property returns the number of dimensions of the current array.
             *       ,Reverse,Sort()   */

            //SystemArrayFunctionality();

            //they can be declared inside the method call
            //Add(90, 90, out int ans);
            //Console.WriteLine("90 + 90 = {0}", ans);

            /* int i; string str; bool b;
             FillTheseValues(out i, out str, out b);
             Console.WriteLine("Int is: {0}", i);
             Console.WriteLine("String is: {0}", str);
             Console.WriteLine("Boolean is: {0}", b);   */

            /*  string str1 = "Flip";
              string str2 = "Flop";
              Console.WriteLine("Before: {0}, {1} ", str1, str2);
              SwapStrings(ref str1, ref str2);
              Console.WriteLine("After: {0}, {1} ", str1, str2);
              Console.ReadLine();  */

            #region Ref locals and params
            /* string[] stringArray = { "one", "two", "three" };
             int pos = 1;
             Console.WriteLine("=> Use Simple Return");
             Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
             var output = SimpleReturn(stringArray, pos);
             output = "new";
             Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);*/
            #endregion

            #region Ref locals and params
            /*string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            */
            #endregion
            #region Params
            //double average;
            //average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            //Console.WriteLine("Average of data is: {0}", average);
            //// ...or pass an array of doubles.
            //double[] data = { 4.0, 3.2, 5.7 };
            //average = CalculateAverage(data);
            //Console.WriteLine("Average of data is: {0}", average);
            //// Average of 0 is 0!
            //Console.WriteLine("Average of data is: {0}", CalculateAverage());
            //// Pass in a comma-delimited list of doubles... 
            #endregion
            #region nullable types
            /* // Compiler errors!
            // Value types cannot be set to null!
            bool myBool = null;
            int myInt = null;
            // OK! Strings are reference types.
            string myString = null;
            DatabaseReader dr = new DatabaseReader();
            // If the value from GetIntFromDatabase() is null,
            // assign local variable to 100.
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length} arguments.");
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");  */
            #endregion
            #region tuples
            (string, int, string) values = ("a", 5, "c");
            var values1 = ("a", 5, "c");
            Console.WriteLine($"First item: {values.Item1}");
            Console.WriteLine($"Second item: {values.Item2}");
            Console.WriteLine($"Third item: {values.Item3}");
            (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
            var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
            Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
            Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}");
            //Using the item notation still works!
            Console.WriteLine($"First item: {valuesWithNames.Item1}");
            Console.WriteLine($"Second item: {valuesWithNames.Item2}");
            Console.WriteLine($"Third item: {valuesWithNames.Item3}");
            (int, int) example = (Custom1: 5, Custom2: 7);
            (int Field1, int Field2) example2 = (Custom1: 5, Custom2: 7);
            Console.WriteLine("=> Inferred Tuple Names");
            var foo = new { Prop1 = "first", Prop2 = "second" };
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");
            var (first, _, last) = SplitNames("Philip F Japikse");
            Console.WriteLine($"{first}:{last}");
            /*Point p = new Point(7, 5);
            var pointValues = p.Deconstruct();
            Console.WriteLine($"X is: {pointValues.XPos}");
            Console.WriteLine($"Y is: {pointValues.YPos}");*/
            #endregion
            //EnterLogData("Oh no! Grid can't find data");
            //EnterLogData("Oh no! I can't find the payroll data", "CFO");

            //DisplayFancyMessage(message: "Wow! Very Fancy indeed!",textColor: ConsoleColor.DarkRed,backgroundColor: ConsoleColor.White);
            // A custom enumeration.
            // Make a contractor type.
            #region enum using
            /* EmpType emp = EmpType.Contractor;
             AskForBonus(emp);
             // Print storage for the enum.
             Console.WriteLine("EmpType uses a {0} for storage",Enum.GetUnderlyingType(emp.GetType()));
             // This time use typeof to extract a Type.
             Console.WriteLine("EmpType uses a {0} for storage",Enum.GetUnderlyingType(typeof(EmpType)));
             Console.WriteLine("emp is a {0}.", emp.ToString());
             // Prints out "Contractor = 100".
             Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);
             EmpType e2 = EmpType.Contractor;
             // These types are enums in the System namespace.
             DayOfWeek day = DayOfWeek.Monday;
             ConsoleColor cc = ConsoleColor.Gray;
             EvaluateEnum(e2);
             EvaluateEnum(day);
             EvaluateEnum(cc);
             Console.ReadLine(); */
            #endregion
            #region struct type
            //  Console.WriteLine("***** A First Look at Structures *****\n");
            // Create an initial Point.
            /*Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();
            // Adjust the X and Y values.
            myPoint.Increment();
            myPoint.Display();
            // Error! Did not assign Y value.
            Point p1;
            p1.X = 10;
            // p1.Display();
            // Set all fields to default values
            // using the default constructor.
            Point p2 = new Point(50, 60);
            // Prints X=0,Y=0.
            p2.Display(); */
            #endregion
            #region Passing ref-types by value.
            /* Console.WriteLine("***** Passing Person object by value *****");
             Person fred = new Person("Fred", 12);
             Console.WriteLine("\nBefore by value call, Person is:");
             fred.Display();
             SendAPersonByValue(fred);
             Console.WriteLine("\nAfter by value call, Person is:");
             fred.Display(); */
            #endregion
            #region Passing Reference Types by Reference
            /*Console.WriteLine("***** Passing Person object by reference *****");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();
            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display(); */

            #endregion
            Console.ReadLine();

        }
        //This is the one of the examples from the out parameter section.It returns three values but requires
        //three parameters passed in as transport mechanisms for the calling code.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
       // By using a tuple, you can remove the parameters and still get the three values back.
        static (int a, string b, bool c) FillTheseValues()
          {
              return (9, "Enjoy your string.", true);
          }
        static (string first, string middle, string last) SplitNames(string fullName)
        {
            //do what is needed to split the name apart
            return ("Philip", "F", "Japikse");
        }
        static void LocalNullableVariables()
        {
            // Define some local nullable variables.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
            // Error! Strings are reference types!
            // string? s = "oops";
            // Define some local nullable types using Nullable<T>.
            //Nullable<int> nullableInt = 10;
            //Nullable<double> nullableDouble = 3.14;
            //Nullable<bool> nullableBool = null;
            //Nullable<char> nullableChar = 'a';
            //Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }
        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));
            // Get all name-value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                enumData.GetValue(i));
            }
            Console.WriteLine();
        }
        // Enums as parameters.
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }
        #region RefTypeValTypeParams
        class Person
        {
            public string personName;
            public int personAge;
            // Constructors.
            public Person(string name, int age)
            {
                personName = name;
                personAge = age;
            }
            public Person() { }
            public void Display()
            {
                Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
            }
            
        }
        static void SendAPersonByValue(Person p)
        {
            // Change the age of "p"?
            p.personAge = 99;
            // Will the caller see this reassignment?
            p = new Person("Nikki", 99);
        }
        static void SendAPersonByReference(ref Person p)
        {
            // Change some data of "p".
            p.personAge = 555;
            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }
        #endregion
        #region Value&ReferenceType
        // Structures and enumerations implicitly extend System.ValueType.
        public abstract class ValueType : object
        {
            /*public virtual bool Equals(object obj);
            public virtual int GetHashCode();
            public Type GetType();
            public virtual string ToString(); */
            // Local structures are popped off
            // the stack when a method returns.
            static void LocalValueTypes()
            {
                // Recall! "int" is really a System.Int32 structure.
                int i = 0;
                // Recall! Point is a structure type.
                Point p = new Point();
            } // "i" and "p" popped off the stack here!

              // Assigning two intrinsic value types results in
              // two independent variables on the stack.
            static void ValueTypeAssignment()
            {
                Console.WriteLine("Assigning value types\n");
                Point p1 = new Point(10, 10);
                Point p2 = p1;
                // Print both points.
                p1.Display();
                p2.Display();
                // Change p1.X and print again. p2.X is not changed.
                p1.X = 100;
                Console.WriteLine("\n=> Changed p1.X\n");
                p1.Display();
                p2.Display();
            }
        }
        
        // Classes are always reference types.
        class PointRef
        {
            public int X;
            public int Y;
            // Same members as the Point structure...
            // Be sure to change your constructor name to PointRef!
            public PointRef(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }
            static void ReferenceTypeAssignment()
            {
                Console.WriteLine("Assigning reference types\n");
                PointRef p1 = new PointRef(10, 10);
                PointRef p2 = p1;
                // Print both point refs.
                p1.Display();
                p2.Display();
                // Change p1.X and print again.
                p1.X = 100;
                Console.WriteLine("\n=> Changed p1.X\n");
                p1.Display();
                p2.Display();
            }
            // Display the current position.
            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
        }
        class ShapeInfo
        {
            public string InfoString;
            public ShapeInfo(string info)
            {
                InfoString = info;
            }
        }
        struct Rectangle
        {
            // The Rectangle structure contains a reference type member.
            public ShapeInfo RectInfo;
            public int RectTop, RectLeft, RectBottom, RectRight;
            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                RectInfo = new ShapeInfo(info);
                RectTop = top; RectBottom = bottom;
                RectLeft = left; RectRight = right;
            }
            public void Display()
            {
                Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
                "Left = {3}, Right = {4}",RectInfo.InfoString, RectTop, RectBottom, RectLeft, RectRight);
            }
        }
        #endregion
        // Overloaded Add() method.
        static int AddWrapper(int x, int y)
        {
            //Do some validation here
            return Add();
            int Add()
            {
                return x + y;
            }
        }
        static int Add(int x, int y)
        { return x + y; }
        static double Add(double x, double y)
        { return x + y; }
        static long Add(long x, long y)
        { return x + y; }
        static void DisplayFancyMessage(ConsoleColor textColor,ConsoleColor backgroundColor, string message)
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
        // Error! The default value for an optional arg must be known
        // at compile time!
        //static void EnterLogData(string message,string owner = "Programmer", DateTime timeStamp = DateTime.Now)
        //{
        //    Console.Beep();
        //    Console.WriteLine("Error: {0}", message);
        //    Console.WriteLine("Owner of Error: {0}", owner);
        //    Console.WriteLine("Time of Error: {0}", timeStamp);
        //}

        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }
        // Return average of "some number" of doubles.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }
        // Returning a reference.
        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        // Returns the value at the array position.
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }
        // Reference parameters.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
        /*  static void ThisWontCompile(out int a)
          {
          //if you want to determine whether a string is a valid date format but don’t care about the parsed
          if (DateTime.TryParse(dateString, out _)  { //do something }
              Console.WriteLine("Error! Forgot to assign output arg!");
          }*/
       
        // Output parameters must be assigned by the called method.
        static int Add(int x, int y, out int ans)
        {
            return ans = x + y;
        }
        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array.");
            // Initialize items at startup.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
            // Print out names in declared order.
            Console.WriteLine("-> Here is the array:");
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");
            // Reverse them...
            Array.Reverse(gothicBands);
            Console.WriteLine("-> The reversed array");
            // ... and print them.
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");
            // Clear out all but the first member.
            Console.WriteLine("-> Cleared out all but one...");
            Array.Clear(gothicBands, 1, 2);
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();
        }
        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");
            // A jagged MD array (i.e., an array of arrays).
            // Here we have an array of 5 different arrays.
            int[][] myJagArray = new int[5][];
            // Create the jagged array.
            for (int i = 0; i < myJagArray.Length; i++)
                myJagArray[i] = new int[i + 7];
            // Print each row (remember, each element is defaulted to zero!).
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                    Console.Write(myJagArray[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");
            // A rectangular MD array.
            int[,] myMatrix;
            myMatrix = new int[3, 4];
            // Populate (3 * 4) array.
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    myMatrix[i, j] = i * j;
            // Print (3 * 4) array.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(myMatrix[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array of Objects.");
            // An array of objects can be anything at all.
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";
            foreach (object obj in myObjects)
            {
                // Print the type and value for each item in array.
                Console.WriteLine("Type: {0}, Value: {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("=> Implicit Array Initialization.");
            // a is really int[].
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a is a: {0}", a.ToString());
            // b is really double[].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b is a: {0}", b.ToString());
            // c is really string[].
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c is a: {0}", c.ToString());
            Console.WriteLine();
        }
        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Creation.");
            // Create an array of ints containing 3 elements indexed 0, 1, 2
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;
            // Now print each value.
            foreach (int i in myInts)
                Console.WriteLine(i);
            // Create a 100 item string array, indexed 0 - 99
            string[] booksOnDotNet = new string[100];

            Console.WriteLine("=> Array Initialization.");
            // Array initialization syntax using the new keyword.
            string[] stringArray = new string[]
            { "one", "two", "three" };
            Console.WriteLine("stringArray has {0} elements", stringArray.Length);
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;
            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
            Console.WriteLine();
        }
        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.Write("Please choose an option: ");
            string userChoice = Console.ReadLine();
            object choice;
            //This is a standard constant pattern switch statement to set up the example
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }
            //This is new the pattern matching switch statement
            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer {0}.", i);
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string. {0}", s);
                    break;
                case decimal d:
                    Console.WriteLine("Your choice is a decimal. {0}", d);
                    break;
                default:
                    Console.WriteLine("Your choice is something else");
                    break;
            }
            Console.WriteLine();
        }

        public static void SwitchWithGoto()
        {
            var foo = 5;
            switch (foo)
            {
                case 1:
                    //do something
                    goto case 2;
                case 2:
                    //do something else
                    break;
                case 3:
                    //yet another action
                    goto default;
                default:
                    //default action
                    break;
            }
        }
        static void SwitchOnEnumExample()
        {
            Console.Write("Enter your favorite day of the week: ");
            DayOfWeek favDay;
            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input!");
                return;
            }
            switch (favDay)
            {
                case DayOfWeek.Sunday:
                    Console.WriteLine("Football!!");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Another day, another dollar");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("At least it is not Monday");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("A fine day.");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Almost Friday...");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules!");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Great day indeed.");
                    break;
            }
        }

        // Switch on a numerical value.
        static void SwitchExample()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            string langChoice = Console.ReadLine();
            int n = int.Parse(langChoice);
            switch (n)
            {
                case 1:
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case 2:
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
        }
        private static void ExecuteIfElseUsingConditionalOperator()
        {
            string stringData = "My textual data";
            Console.WriteLine(stringData.Length > 0
            ? "string is greater than 0 characters"
            : "string is not greater than 0 characters");
            Console.WriteLine();
        }
        static void IfElseExample()
        {
            // This is illegal, given that Length returns an int, not a bool.
            string stringData = "My textual data";
            if (stringData.Length > 0)//wrong lazem akteb stringData.Length>0 
            {
                Console.WriteLine("string is greater than 0 characters");
            }
            else
            {
                Console.WriteLine("string is not greater than 0 characters");
            }
            Console.WriteLine();
        }
        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("In do/while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "yes"); // Note the semicolon!
        }
        static void WhileLoopExample()
        {
            string userIsDone = "";
            // Test on a lower-class copy of the string.
            while (userIsDone.ToLower() != "yes")
            {
                Console.WriteLine("In while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            }
        }
        // Iterate array items using foreach.
        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string c in carTypes)
                Console.WriteLine(c);
            int[] myInts = { 10, 20, 30, 40 };
            foreach (int i in myInts)
                Console.WriteLine(i);
        }
        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // LINQ query!
            var subset = from i in numbers where i < 10 select i;
            // subset is a low - level LINQ data type
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            // Hmm...what type is subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }
        static void ImplicitTypingIsStrongTyping()
        {
            // The compiler knows "s" is a System.String.
            var s = "This variable can only hold string data!";
            s = "This is fine...";
            // Can invoke any member of the underlying type.
            string upper = s.ToUpper();
            // Error! Can't assign numerical data to a string!
            //s = 44;
        }
        static void DeclareImplicitVars()
        {
            // Implicitly typed local variables
            // are declared as follows:
            // var variableName = initialValue;
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";
            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }

        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            // This time, tell the compiler to add CIL code
            // to throw an exception if overflow/underflow
            // takes place.
            try
            {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine("sum = {0}", sum);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Another compiler error!
        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;
            // Explicitly cast the int into a byte (no loss of data).
            myByte = (byte)myInt;
            Console.WriteLine("Value of myByte: {0}", myByte);

            Console.WriteLine("Value of myByte: {0}", myByte);
        }
        // Arguments are passed by value by default.
        //static int Add(int x, int y)
        //{
        //    return x + y;
        //}

        static void StringInterpolation()
        {
            // Some local variables we will plug into our larger string
            int age = 4;
            string name = "Soren";
            // Using curly bracket syntax.
            string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
            // Using string interpolation
            // string greeting2 = $"Hello {name} you are {age} years old.";
            string greeting2 = $"Hello {name.ToUpper()} you are {age} years old.";

        }
        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }

        static void StringsAreImmutable()
        {
            // Set initial string value.
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);
            // Uppercase s1?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);
            // Nope! s1 is in the same format!
            Console.WriteLine("s1 = {0}", s1);
        }

        static void StringEqualitySpecifyingCompareRules()
        {
            Console.WriteLine("=> String equality (Case Insensitive:");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Check the results of changing the default compare rules.
            Console.WriteLine("Default rules: s1={0},s2={1}s1.Equals(s2): {2}", s1, s2,
            s1.Equals(s2));
            Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",
            s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2,
            s1.IndexOf("E"));
            Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase):{0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
        }

        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Test these strings for equality.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
        }

        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);
            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");
            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");
            Console.WriteLine();
            //// The following string is printed verbatim,
            // thus all escape characters are displayed.
            //Using verbatim strings
            //Also note that verbatim strings can be used to preserve white space for strings that flow over
            // multiple lines.
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");
        }
        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}",
            firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", ""));
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = String.Concat(s1, s2);
            Console.WriteLine(s3);
            Console.WriteLine();
        }
        private static void BinaryLiterals()
        {
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}", 0b0001_0000);
            Console.WriteLine("Thirty Two: {0}", 0b0010_0000);
            Console.WriteLine("Sixty Four: {0}", 0b0100_0000);
        }
        static void DigitSeparators()
        {
            Console.WriteLine("=> Use Digit Separators:");
            Console.Write("Integer:");
            Console.WriteLine(123_456);
            Console.Write("Long:");
            Console.WriteLine(123_456_789L);
            Console.Write("Float:");
            Console.WriteLine(123_456.1234F);
            Console.Write("Double:");
            Console.WriteLine(123_456.12);
            Console.Write("Decimal:");
            Console.WriteLine(123_456.12M);
        }

        static void UseBigInteger()
        {
            Console.WriteLine("=> Use BigInteger:");
            BigInteger biggy =
            BigInteger.Parse("9999999999999999999999999999999999999999999999");
            Console.WriteLine("Value of biggy is {0}", biggy);
            Console.WriteLine("Is biggy an even value?: {0}", biggy.IsEven);
            Console.WriteLine("Is biggy a power of two?: {0}", biggy.IsPowerOfTwo);
            BigInteger reallyBig = BigInteger.Multiply(biggy,
            BigInteger.Parse("8888888888888888888888888888888888888888888"));
            Console.WriteLine("Value of reallyBig is {0}", reallyBig);
        }

        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times:");
            // This constructor takes (year, month, day).
            DateTime dt = new DateTime(2015, 10, 17);
            // What day of the month is this?
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            // Month is now December.
            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());
            // This constructor takes (hours, minutes, seconds).
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);
            // Subtract 15 minutes from the current TimeSpan and
            // print the result.
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
        }
        static void ParseFromStringsWithTryParse()
        {
            Console.WriteLine("=> Data type parsing with TryParse:");
            if (bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b: {0}", b);
            }
            string value = "Hello";
            if (double.TryParse(value, out double d))
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }
            Console.WriteLine();
        }
        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = Char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            Console.WriteLine();
        }

        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}",
            char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}",
            char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}",
            char.IsPunctuation('?'));
            MessageBox.Show("Ok");
        }

        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System.Object Functionality:");
            // A C# int is really a shorthand for System.Int32,
            // which inherits the following members from System.Object.
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            MessageBox.Show("Ok");
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool(); // Set to false.
            int i = new int(); // Set to 0.
            double d = new double(); // Set to 0.
            DateTime dt = new DateTime(); // Set to 1/1/0001 12:00:00 AM
            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
        }
        static void LocalVarDeclarations()
        {/*
            Console.WriteLine("=> Data Declarations:");
            // Local variables are declared as so:
            // dataType varName;
           int myInt = 0;
            string myString = "Rere";
            bool b1 = true, b2 = false, b3 = b1;
            Console.WriteLine("Your data: {0}, {1}, {2}, {3}, {4}",myInt, myString, b1, b2, b3);
            Console.WriteLine(); 
            Console.WriteLine("=> Default Declarations:");
            int myInt1 = default;
            MessageBox.Show(""+myInt1);
            */
        }

        static void DisplayMessage()
        {
            // Using string.Format() to format a string literal.
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            // You need to reference PresentationFramework.dll
            // in order to compile this line of code!
            MessageBox.Show(userMessage);
        }

        static void ShowEnvironmentDetails()
        {
            // Print out the drives on this machine,
            // and other interesting details.
            /* foreach (string drive in Environment.GetLogicalDrives())
                 Console.WriteLine("Drive: {0}", drive);
             Console.WriteLine("OS: {0}", Environment.OSVersion);
             Console.WriteLine("UserName : {0}", Environment.UserName);
             Console.WriteLine("Version : {0}", Environment.Is64BitOperatingSystem.ToString());
             Console.WriteLine("Number of processors: {0}",Environment.ProcessorCount);
             Console.WriteLine(".NET Version: {0}",
             Environment.Version); */

            Console.WriteLine("***** Basic Console I/O *****");

            Console.ReadLine();

            // FormatNumericalData();
        }

        static void FormatNumericalData()
        { /*
            /* C or c for currency . D or d for decimal .
             * E or e for exponential format . 
             * F or f for fixed point format . G or g stands for general(fixed or potential) .
             * N or n used for basic numerical format .
             * X or x for hexadecimal format uppercase X for hex uppercase character
             * 
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);  

            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.

            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            */
        }

        static void GetUserData()
        {/*
                // Get name and age.
                Console.Write("Please enter your name: ");
                string userName = Console.ReadLine();
                Console.Write("Please enter your age: ");
                string userAge = Console.ReadLine();
                // Change echo color, just for fun.
                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Echo to the console.
                Console.WriteLine("Hello {0}! You are {1} years old.",
                userName, userAge);
                // Restore previous color.
                Console.ForegroundColor = prevColor;
                */
        }

    }
}