using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();
                Console.WriteLine("Processing");
                Task.Factory.StartNew(() => ProcessIntData());
                Console.Write("Enter Q to quit: ");
                string answer = Console.ReadLine();
                // Does user want to quit?
                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadLine();
        }

        private static void ProcessIntData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order
            int[] modThreeIsZero = null;
            try
            {
                //If you want to inform the TPL to execute this query in parallel
                //the TPL will attempt to pass the workload off to an available CPU.
                modThreeIsZero = (from i in source.AsParallel().WithCancellation(cancelToken.Token)
                                  where i % 3 == 0 orderby i descending select i).ToArray();
                Console.WriteLine($"Found { modThreeIsZero.Count()} numbers that match query!");
            }catch(OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
