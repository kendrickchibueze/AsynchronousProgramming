using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming.LearnAsync
{
    internal class LocalFunctionsWithAsyncAwait
    {


        //In the following update, the checks are done in a synchronous manner, and then 
        //the private function is executed asynchronously:
        public static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if (secondParam < 0)
            {
                Console.WriteLine("Bad data");
                return;
            }
            await actualImplementation();
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
