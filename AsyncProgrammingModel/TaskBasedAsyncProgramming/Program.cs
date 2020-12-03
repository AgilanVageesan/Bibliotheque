using System; //https://dotnettutorials.net/lesson/task-parallel-library-overview/ for TPL
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskBasedAsyncProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Wait till Even completes execution
            // await Even();

            //Wait till Odd completes execution
            // await Odd();


            List<Task> listTask = new List<Task>();
          //  listTask.Add(Even());
           // listTask.Add(Odd());

            //Wait till both Even and Odd completes execution
            //Task.WaitAll(listTask.ToArray());

            //Cancel Task after timeout
            try
            {
              //   await DemoCancellationOnTimeOut();
            }
            catch (TaskCanceledException canceledException)
            {
                Console.WriteLine(canceledException.Message);
            }

      //      listTask = new List<Task>();
        //    listTask.Add(Even());
          //  listTask.Add(Odd());
            //Combinator : WhenAll
          //  Task tasks = Task.WhenAll(listTask.ToArray());

            //Wait for all Tasks to complete
            //tasks.Wait();

            listTask = new List<Task>();
            listTask.Add(Even());
            listTask.Add(Odd());
            //Combinator : WhenAny || Completes even if any one of the task gets completed
            Task tasks1 = Task.WhenAny(listTask.ToArray());



            //Wait for all Tasks to complete
            tasks1.Wait();
      
            if (tasks1.IsCompletedSuccessfully)
            {
                Console.WriteLine("Completed Succesfully");
            }
            else if (tasks1.IsFaulted)
            {
                Console.WriteLine("Failed");
            }
            else
            {
                Console.WriteLine("Status not known");
            }

            //Yield example
            Console.WriteLine("************************************************************************");
            //Yield : https://itqna.net/questions/11469/what-usefulness-taskyield

        }

        static async Task Even()
        {
            await Task.Run(new Action(PrintEventNumbers));
        }

        static async Task Odd()
        {
            await Task.Run(new Action(PrintOddNumbers));
        }

        static async Task DemoCancellationOnTimeOut()
        {
            CancellationTokenSource cancellationSource = new CancellationTokenSource(5000);
            
            for (int i = 0; i < 100000; i++)
            {
                if (cancellationSource.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
                Console.WriteLine("Long Task running");
                await Task.Delay(1000);
            }
        }

        static void PrintEventNumbers()
        {
            for(int i=0;i<100;i++)
            {
                if(i%2==0)
                {
                    Console.WriteLine("Even Number : {0}",i);
                    Thread.Sleep(1000);
                }
            }
        }

        static void PrintOddNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("Odd Number : {0}", i);
                   // Thread.Sleep(1000);
                }
            }
        }

    }
}
