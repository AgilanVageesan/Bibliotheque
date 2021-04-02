using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace EventBasedAsyncProgramming
{
    class Program
    {

        static void Main(string[] args)
        {
            EasyAsync easyAsync = new EasyAsync();
            easyAsync.EasyEventCompleted += new EasyCompletedEventHandler(EasyAsyncCompleted_Hander);
            easyAsync.EasyEventAsync("Easy EAP 1", "EAP 1");
            easyAsync.EasyEventAsync("Easy EAP 2", "EAP 2");

            Console.WriteLine("Last Statement");
            Console.ReadLine();
        }

        static void EasyAsyncCompleted_Hander(object sender, EasyAsyncCompletedEventArgs e)
        {
            Console.WriteLine(e.UserState.ToString() + " completed.");
        }
    }
    public delegate void EasyCompletedEventHandler(object sender, EasyAsyncCompletedEventArgs e);

    public class EasyAsync
    {

        private delegate void WorkerEventHandler(string message, AsyncOperation asyncOp);

        private SendOrPostCallback onEasyEventCompletedDelegate;

        public event EasyCompletedEventHandler EasyEventCompleted;

        public EasyAsync()
        {
            onEasyEventCompletedDelegate = new SendOrPostCallback(EasyEventOpsCompleted);
        }

        private void EasyEventOpsCompleted(object operationState)
        {
            EasyAsyncCompletedEventArgs e = operationState as EasyAsyncCompletedEventArgs;
            EasyEventCompleted(this, e);
        }

        public void EasyEventAsync(string requester, object userState)
        {
            AsyncOperation asynchronousOps = AsyncOperationManager.CreateOperation(userState);
            WorkerEventHandler worker = new WorkerEventHandler(EasyEventExecutor);

            //Asynchronous Execution
            worker.BeginInvoke(requester, asynchronousOps, null, null);
        }

        private void EasyEventExecutor(string requester, AsyncOperation asyncOps)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2500);
                Console.WriteLine("{0} -- {1}",requester,i.ToString());
            }
        }
    }

    public class EasyAsyncCompletedEventArgs : AsyncCompletedEventArgs
    {
        public EasyAsyncCompletedEventArgs(Exception ex, bool canceled, object userState)
            : base(ex, canceled, userState)
        {

        }
    }
}
