using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace AsynchronousProgramming.LearnAsync
{
    internal class MultipleAwait
    {
        

        public static  async Task MultipleAwaitsAsync()
        {
            await Task.WhenAll(Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with first task!");
            }), Task.Run(() =>
            {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with second task!");
            }), Task.Run(() => {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with third task!");
            }));
        }

        //There is also a WhenAny(), which signals that one of the tasks have completed. The method returns 
        //the first task that completed.


        public static async Task MultipleAwaitsTake2Async()
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with first task!");
            }));
            tasks.Add(Task.Run(() =>
            {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with second task!");
            }));
            tasks.Add(Task.Run(() =>
            {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with third task!");
            }));
            //await Task.WhenAny(tasks);
            await Task.WhenAll(tasks);
        }

        //NOTE ON DEADLOCK


    //    Calling either Wait(), Result, or GetAwaiter().GetResult() blocks the
    //    calling thread, processes the async method on another thread, then returns back to the calling thread, tying
    //    up two threads to get the work performed.Worse yet, each of these can cause deadlocks, especially if the
    //    calling thread is from the UI of the application.
    }
}
