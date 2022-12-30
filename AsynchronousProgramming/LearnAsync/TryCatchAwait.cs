using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming.LearnAsync
{
    internal class TryCatchAwait
    {

        static async Task<string> MethodWithTryCatch()
        {
            try
            {
                //Do some work
                return "Hello";
            }
            catch (Exception ex)
            {
                //await LogTheErrors();
                throw;
            }
            finally
            {
                //await DoMagicCleanUp();
            }
        }

        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1_000);
            return 5;
        }

        //The same rules apply for ValueTask as for Task, since ValueTask is just a Task for value types instead of 
        //forcing allocation of an object on the heap.
    }
}
