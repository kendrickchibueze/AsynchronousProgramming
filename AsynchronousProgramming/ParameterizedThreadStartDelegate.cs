using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Timers;

namespace AsynchronousProgramming
{
    internal class ParameterizedThreadStartDelegate
    {

        public int a, b;
        public ParameterizedThreadStartDelegate(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }




        public static void Add(object data)
        {

            //AutoResetEvent _waitHandle = new AutoResetEvent(false);

            if (data is ParameterizedThreadStartDelegate ap)
            {
                Console.WriteLine("ID of thread in Add(): {0}",
                Environment.CurrentManagedThreadId);
                Console.WriteLine("{0} + {1} is {2}",
                ap.a, ap.b, ap.a + ap.b);

                // Tell other thread we are done.
               // _waitHandle.Set();
            }
        }


        public static  void Run()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
             Environment.CurrentManagedThreadId);
            // Make an ParameterizedThreadStartDelegate object to pass to the secondary thread.
            ParameterizedThreadStartDelegate ap = new ParameterizedThreadStartDelegate(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            // Force a wait to let other thread finish.
            Thread.Sleep(5);
            Console.ReadLine();
        }


        //In the above example, Sleep was called with an arbitrary time to let the other thread finish.One simple
        //and thread-safe way to force a thread to wait until another is completed is to use the AutoResetEvent class. 
        //In the thread that needs to wait, create an instance of this class and pass in false to the constructor to
        //signify you have not yet been notified.Then, at the point at which you are willing to wait, call the WaitOne()
        //method.

        public static void Run2()
        {

            AutoResetEvent _waitHandle = new AutoResetEvent(false);

            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
             Environment.CurrentManagedThreadId);
            // Make an ParameterizedThreadStartDelegate object to pass to the secondary thread.
            ParameterizedThreadStartDelegate ap = new ParameterizedThreadStartDelegate(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);


            // Wait here until you are notified!
            _waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }



        //        Foreground threads can prevent the current application from terminating.The.NET
        //Core Runtime will not shut down an application(which is to say, unload the hosting
        //AppDomain) until all foreground threads have ended.
        //•	 Background threads (sometimes called daemon threads) are viewed by the.NET
        //Core Runtime as expendable paths of execution that can be ignored at any point
        //in time (even if they are currently laboring over some unit of work). Thus, if all
        //foreground threads have terminated, all background threads are automatically killed
        //when the application domain unloads.



            // It is important to note that foreground and background threads are not synonymous with primary
            //and worker threads.By default, every thread you create via the Thread.Start() method is automatically a
            //foreground thread.


        //all foreground threads must finish their work before the AppDomain is 
        //unloaded from the hosting process


    }
}
