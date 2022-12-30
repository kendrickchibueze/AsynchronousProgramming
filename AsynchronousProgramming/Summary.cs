using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AsynchronousProgramming
{
    internal class Summary
    {

        //        Methods(as well as lambda expressions or anonymous methods) can be marked
        //with the async keyword to enable the method to do work in a nonblocking manner.
        //•	 Methods(as well as lambda expressions or anonymous methods) marked with the
        //async keyword will run synchronously until the await keyword is encountered.
        //•	 A single async method can have multiple await contexts.
        //•	 When the await expression is encountered, the calling thread is suspended until the
        //awaited task is complete.In the meantime, control is returned to the caller of the method.
        //•	 The await keyword will hide the returned Task object from view, appearing to
        //directly return the underlying return value.Methods with no return value simply 
        //return void.
        //•	 Parameter checking and other error handling should be done in the main section of
        //the method, with the actual async portion moved to a private function.
        //•	 For stack variables, the ValueTask is more efficient than the Task object, which might
        //cause boxing and unboxing.
        //•	 As a naming convention, methods that are to be called asynchronously should be
        //marked with the Async suffix.



        //Note
            // I wrapped things up by covering
            //the role of the async and await keywords.As you have seen, these keywords are using many types of the TPL
            //framework in the background; however, the compiler does most of the work to create the complex threading
            //and synchronization code on your behalf
    }
}
