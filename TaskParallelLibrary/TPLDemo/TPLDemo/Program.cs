using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstString = new List<string>();
            lstString.Add("Ram");
            lstString.Add("Sam");
            lstString.Add("Tim");
            lstString.Add("John");
            //SimpleParallelForEachWithCancellation(lstString);
           // ParallelForEachPartitionVariable();
            ManageExceptions();
        }

        static void NoParallel(List<string> lstString)
        {
            foreach(string s in lstString)
            {
                Console.WriteLine(s);
            }
        }

        static void SimpleParallelFor(List<string> lstString)
        {
            Parallel.For(0, 4, i => Console.WriteLine(lstString[i]));
        }

        static void SimpleParallelForEach(List<string> lstString)
        {
            Parallel.ForEach(lstString, n => { Console.WriteLine(n); });
        }
        static void SimpleParallelForEachWithCancellation(List<string> lstString)
        {
            int[] nums = Enumerable.Range(0, 10000000).ToArray();
            CancellationTokenSource cts = new CancellationTokenSource();

            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                Parallel.ForEach(nums, po, (num) =>
                {
                    double d = Math.Sqrt(num);
                    Console.WriteLine("{0} on {1}", d, Thread.CurrentThread.ManagedThreadId);
                    po.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadKey();
        }

        static void ManageExceptions()
        {
            byte[] data = new byte[5000];
            Random r = new Random();
            r.NextBytes(data);

            try
            {
                var exceptions = new ConcurrentQueue<Exception>();

                // Execute the complete loop and capture all exceptions.
                Parallel.ForEach(data, d =>
                {
                    try
                    {
                        // Cause a few exceptions, but not too many.
                        if (d < 3)
                            throw new ArgumentException($"Value is {d}. Value must be greater than or equal to 3.");
                        else
                            Console.Write(d + " ");
                    }
                    // Store the exception and continue with the loop.
                    catch (Exception e)
                    {
                        exceptions.Enqueue(e);
                    }
                });
                Console.WriteLine();

                // Throw the exceptions here after the loop completes.
                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();
                // This is where you can choose which exceptions to handle.
                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException)
                        Console.WriteLine(ex.Message);
                    else
                        ignoredExceptions.Add(ex);
                }
                if (ignoredExceptions.Count > 0) throw new AggregateException(ignoredExceptions);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void ParallelForEachPartitionVariable()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                     {
                                            subtotal += j; //modify local variable
                                         return subtotal; // value to be passed to next iteration
                                     },
                                        // Method to be executed when each partition has completed.
                                        // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => Interlocked.Add(ref total, finalResult)
                                        );

            Console.WriteLine("The total from Parallel.ForEach is "+ total);
        }
    }
}
