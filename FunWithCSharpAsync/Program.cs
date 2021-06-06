using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace FunWithCSharpAsync
{
    class Program
    {
        static async Task Main(string[] args)
        { 

            Console.WriteLine(" Fun With Async ===>");
            //This is to prompt Visual Studio to upgrade project to C# 7.1
            List<int> l = default;
            //ommitted for brevity
            string message = await DoWorkAsync();
            Console.WriteLine(DoWorkAsync().Result);
            Console.WriteLine("Completed");
            //To halt execution until an async method returns with a void return type, simply call Wait() on the Task
             MethodReturningVoidAsync().Wait();
            await MethodReturningVoidAsync();
            Console.WriteLine("Void method completed");
            Console.WriteLine("Completed");
            Console.WriteLine("Completed");
            Console.WriteLine("Completed");
            Console.WriteLine("Completed");
            Console.WriteLine("Completed");
            Console.WriteLine("Completed");
            Console.ReadLine();

        }

        private static async Task<string> DoWorkAsync()
        {
            //The Run() method takes a Func<> or Action<> delegate
            return await Task.Run(() =>
            {
                Thread.Sleep(3_000);
                return "Done with work!";
            });
        }

        private static string DoWork()
        {
            Thread.Sleep(5000);
            return "Done with work!";
        }
        static async Task MethodReturningVoidAsync()
        {
            await Task.Run(() => { /* Do some work here... */
                Thread.Sleep(4_000);
            });
            Console.WriteLine("Void method completed");
        }
        static async Task MultiAwaitsAsync()
        {
            await Task.Run(() => { Thread.Sleep(2_000); });
            Console.WriteLine("Done with first task!");
            await Task.Run(() => { Thread.Sleep(2_000); });
            Console.WriteLine("Done with second task!");
            await Task.Run(() => { Thread.Sleep(2_000); });
            Console.WriteLine("Done with third task!");
        }
        //static async Task<string> MethodWithTryCatch()
        //{
        //    try
        //    {
        //        //Do some work
        //        return "Hello";

        //    }
        //    catch (Exception ex)
        //    {
        //        await LogTheErrors();
        //        throw;

        //    }
        //    finally
        //    {
        //        await DoMagicCleanUp();
        //    }
        //}

        //t’s just a Task for value types instead of forcing allocation of an object on the heap
        //For stack variables, the ValueTask is more efficient than the Task object, which might
        //cause boxing and unboxing.
        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1000);
            return 5;
        }
        //Parameter checking and other error handling should be done in the main section of
        //the method, with the actual async portion moved to a private function.
        static async Task  MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            await Task.Run(() =>
            {
                //Call long running method
                Thread.Sleep(4_000);
                Console.WriteLine("First Complete");
                //Call another long running method that fails because
                //the second parameter is out of range
                Console.WriteLine("Something bad happened");
            });
        }
        static async Task MethodWithProblemFixed(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if(secondParam < 0)
            {
                Console.WriteLine("Bad Data");
                return;
            }
             actualImplementation();
            async Task actualImplementation()
            {
                await Task.Run(() => 
                {
                    //Call long running method
                    Thread.Sleep(4_000);
                    Console.WriteLine("First Complete");
                    //Call another long running method that fails because
                    //the second parameter is out of range
                    Console.WriteLine("Something bad happened");
                });
            }
        }
    }
}
    