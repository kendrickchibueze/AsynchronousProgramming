using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    public static class ThreadPool
    {

        //public static bool QueueUserWorkItem(WaitCallback callBack);
        //public static bool QueueUserWorkItem(WaitCallback callBack, object state);

        public static void callThreadPool()
        {
            Console.WriteLine("***** Fun with the .NET Core Runtime Thread Pool *****\n");
            Console.WriteLine("Main thread started. ThreadID = {0}",
             Environment.CurrentManagedThreadId);
            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            // Queue the method ten times.
            for (int i = 0; i < 10; i++)
            {
                //ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
            static void PrintTheNumbers(object state)
            {
                Printer task = (Printer)state;
                task.PrintNumbers();
            }
        }
    }
}
