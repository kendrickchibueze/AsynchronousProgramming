using AsynchronousProgramming.LearnAsync;

namespace AsynchronousProgramming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {



            //JoinableTask.myJoinableTaskAsync();






            //LearnThread.Run();

            //MultiThread.ShowMultiThread();

            //ParameterizedThreadStartDelegate.Run2();

            //MultiThreadedPrinting.Print();

            //TimerType.TimerCall();

            // DownloadBook.Mydownload();
            //PLINQ.PLINQDataProcessingWithCancellation();

            // await Dowork.DoWorkAsync();
            // await  MultipleAwait.MultipleAwaitsAsync();

            //await MultipleAwait.MultipleAwaitsTake2Async();

            //await  LocalFunctionsWithAsyncAwait.MethodWithProblems(5, 10);

            await DownloadBookAyncAwait.GetBookAsync();










            //To use TPL effectively
            //Lock,
            //Deadlock
            //Race consitions with codes
        }
    }
}