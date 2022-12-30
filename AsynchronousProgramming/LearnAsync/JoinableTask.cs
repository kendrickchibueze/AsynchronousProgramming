using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming.LearnAsync
{
    internal class JoinableTask
    {
       


        public static async Task myJoinableTaskAsync()
        {

            JoinableTaskFactory joinableTaskFactory = new JoinableTaskFactory(new JoinableTaskContext());
            joinableTaskFactory.Run(async () =>
            {
                //await MethodReturningVoidTaskAsync();
                //await SomeOtherAsyncMethod();
                //example
                await MultipleAwait.MultipleAwaitsTake2Async();
            });



          

        }


        //NOTE:You can also use the JoinableTaskFactory and the new WaitAsync() method when calling an asynchronous code  from 
       // synchronous code
    }


}
