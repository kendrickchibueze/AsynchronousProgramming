using System.Threading;

namespace AsynchronousProgramming
{
    public class Printer
    {

        // Lock token.
        private object threadLock = new object();
        //public void PrintNumbers()
        //{
        //    // Display Thread info.
        //    Console.WriteLine("-> {0} is executing PrintNumbers()",
        //    Thread.CurrentThread.Name);
        //    // Print out numbers.
        //    for (int i = 0; i < 10; i++)
        //    {
        //        // Put thread to sleep for a random amount of time.
        //        Random r = new Random();
        //        Thread.Sleep(1000 * r.Next(5));
        //        Console.Write("{0}, ", i);
        //    }
        //    Console.WriteLine();
        //}


        //we can ensure synchronization of shared resources like the console window by using the C# keyword Lock (This is in attempt to solve the problem of concurrency in C# multithreaded applications)

        public void PrintNumbers()
        {
            // Use the private object lock token.
            lock (threadLock)
            {
                //Display Thread info.
                       Console.WriteLine("-> {0} is executing PrintNumbers()",
                       Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }

        }
    }
}