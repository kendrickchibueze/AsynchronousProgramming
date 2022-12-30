using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Threading.Channels;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AsynchronousProgramming
{
    internal class MultiThreadedPrinting
    {




        public static void Print()
        {
            Console.WriteLine("*****Synchronizing Threads *****\n");
            Printer p = new Printer();
            // Make 10 threads that are all pointing to the same
            // method on the same object.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
                {
                    Name = $"Worker thread #{i}"
                };
            }
            // Now start each one.
            foreach (Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
        
            //Before looking at some test runs, let’s recap the problem.The primary thread within this AppDomain
            //begins life by spawning ten secondary worker threads.Each worker thread is told to make calls on the
            //PrintNumbers() method on the same Printer instance.Given that you have taken no precautions to lock 
            //down this object’s shared resources (the console), there is a good chance that the current thread will be
            //kicked out of the way before the PrintNumbers() method is able to print the complete results. Because
            //you do not know exactly when (or if) this might happen, you are bound to get unpredictable results
    }
}
