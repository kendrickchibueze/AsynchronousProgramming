using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming.LearnAsync
{
    internal class Dowork
    {
       

         public static async Task<string> DoWorkAsync()
        {
            Run();
            
            return await Task.Run(() =>

            {
                Thread.Sleep(5000);
                return "Done with work!";
            });
        }

        public static async void Run()
        {
            Console.WriteLine("***Fun With Async***");
            string message = await DoWorkAsync();
            Console.WriteLine(message);
        }



        //The implementation of DoWorkAsync() now directly returns a Task<T> object, which is the return value 
        //of Task.Run(). The Run() method takes a Func<> or Action<> delegate, and as you know by this point in the
        //text, you can simplify your life by using a lambda expression

        // Basically, your new version of DoWorkAsync() is essentially saying the following:

        //When you call me, I will run a new task.This task will cause the calling thread to sleep for 
        //five seconds, and when it is done, it gives me a string return value.I will put this string in a
        //new Task<string> object and return it to the caller


        //NOTE:
        //when a delegate is queued to run asynchronously, it is scheduled to run on a
        //separate thread.This detail is handled by the.NET Core Runtime.This is typically done using the .NET Core
        //Runtime managed thread pool but can be overridden with a custom implementation.


        //An “awaitable” method is simply a method that returns a Task or Task<T>.

    }
}
