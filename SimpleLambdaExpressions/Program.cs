using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        public delegate string VerySimpleDelegate();
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            Console.ReadLine();
        }
        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
           
            // Now, use a C# lambda expression.
            // "i" is our parameter list.
            // "(i % 2) == 0" is our statement set to process "i".
            evenNumbers = list.FindAll(i => (i % 2) == 0);

            // Now, explicitly state the parameter type.
            List<int> evenNumbers2 = list.FindAll((int i) => (i % 2) == 0);

            // Now, wrap the expression as well.
            List<int> evenNumbers3 = list.FindAll((i) => ((i % 2) == 0));

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();



            // Register with delegate as a lambda expression.
            LambdaExpressionsMultipleParams.SimpleMath m = new LambdaExpressionsMultipleParams.SimpleMath();
            m.SetMathHandler((msg, result) =>
            { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            //if you are using a lambda expression to interact with a delegate taking no parameters at all, you
            //may do so by supplying a pair of empty parentheses as the parameter.
            // Prints "Enjoy your string!" to the console.
            VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
            Console.WriteLine(d());
            // This will execute the lambda expression.
            m.Add(10, 10);
              
               Console.ReadLine();
        }
        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(
                delegate (int i)
                {
                    return (i % 2) == 0;
                });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        // Target for the Predicate<> delegate.
        static bool IsEvenNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }
        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Now process each argument within a group of
            // code statements.
            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }
}
