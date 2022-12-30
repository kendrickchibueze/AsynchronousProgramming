using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    internal class TimerType
    {
        static void PrintTime(object state)
        {
            Console.Clear();
            Console.WriteLine("Time is: {0}",
            DateTime.Now.ToLongTimeString());
        }

        public static void TimerCall()
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            // Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);
            
             Timer t = new Timer(
             timeCB, // The TimerCallback delegate object.
             null, // Any info to pass into the called method (null for no info).
             0, // Amount of time to wait before starting (in milliseconds).
             1000); // Interval of time between calls (in milliseconds).
                        Console.WriteLine("Hit Enter key to terminate...");
            Console.ReadLine();
        }



            
            //If you did want to send in some information for use by the delegate target, simply substitute the null
            //value of the second constructor parameter with the appropriate information, like so:
            //// Establish timer settings.
            ///

            //Timer t = new Timer(timeCB, "Hello From C# 10.0", 0, 1000);


            //        You can then obtain the incoming data as follows:

            //static void PrintTime(object state)
            //        {
            //            Console.WriteLine("Time is: {0}, Param is: {1}",
            //            DateTime.Now.ToLongTimeString(), state.ToString());
            //        }
    }
}
