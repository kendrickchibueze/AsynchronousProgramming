using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    internal class PLINQ
    {

        //The PLINQ framework has been optimized in numerous ways,
        //which includes determining whether a query would, in fact, perform faster in a synchronous manner.
        //At runtime, PLINQ analyzes the overall structure of the query, and if the query is likely to benefit from
        //parallelization, it will run concurrently.However, if parallelizing a query would hurt performance, PLINQ
        //just runs the query sequentially. If PLINQ has a choice between a potentially expensive parallel algorithm or
        //an inexpensive sequential algorithm, it chooses the sequential algorithm by default.


        public static void PLINQDataProcessingWithCancellation()
        {
            CancellationTokenSource _cancelToken = new CancellationTokenSource();
            do
            {

                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();
                Console.WriteLine("Processing");
                Task.Factory.StartNew(ProcessIntData);
                Console.Write("Enter Q to quit: ");
                string answer = Console.ReadLine();
                // Does user want to quit?
                if (answer.Equals("Q",
                StringComparison.OrdinalIgnoreCase))
                {
                    _cancelToken.Cancel();
                    break;
                }
            }
            while (true);
            Console.ReadLine();




            void ProcessIntData()
            {
                // Get a very large array of integers.
                int[] source = Enumerable.Range(1, 10_000_000).ToArray();
                // Find the numbers where num % 3 == 0 is true, returned
                // in descending order.
                int[] modThreeIsZero = null;

                try
                {
                    Thread.Sleep(3000);
                    modThreeIsZero = (from num in source.AsParallel().WithCancellation(_cancelToken.Token)
                                      where num % 3 == 0
                                      orderby num descending
                                      select num).ToArray();
                    Console.WriteLine();
                    Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //However, by including a call to AsParallel(), the TPL will attempt to pass the workload off to any 
        //available CPU.

        //Now, inform the PLINQ query that it should be on the lookout for an incoming cancellation request by 
        //chaining on the WithCancellation() extension method and passing in the token






    }
}
