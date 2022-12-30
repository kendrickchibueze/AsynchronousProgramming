using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AsynchronousProgramming
{
    internal class LearnThread
    {

        //a thread was defined as a path of execution within an executable application.
        //Furthermore, given that threads can be moved between application and contextual boundaries as 
        //required by the runtime, you must be mindful of which aspects of your application are thread-volatile
        //(e.g., subject to multithreaded access) and which operations are atomic(thread-volatile operations are the
        //dangerous ones!).


        public static void Run()
        {
            Console.WriteLine("***** Primary Thread stats *****\n");
            // Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";
            // Print out some stats about this thread.
            Console.WriteLine("ID of current thread: {0}",
             primaryThread.ManagedThreadId);
            Console.WriteLine("Thread Name: {0}",
             primaryThread.Name);
            Console.WriteLine("Has thread started?: {0}",
             primaryThread.IsAlive);
            Console.WriteLine("Priority Level: {0}",
             primaryThread.Priority);
            Console.WriteLine("Thread State: {0}",
             primaryThread.ThreadState);
            Console.ReadLine();
        }
    }
}
