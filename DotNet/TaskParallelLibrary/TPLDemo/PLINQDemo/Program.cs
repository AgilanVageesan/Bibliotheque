using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            WorkWithFiles();
        }

        static void SimplePLINQ()
        {
            var myNumbers = Enumerable.Range(10, 1000);

            var result = from n in myNumbers.AsParallel()
                         where n % 2 == 0
                         select n;
            foreach(var n in result)
            {
                Console.WriteLine(n);
            }
        }

        static void SimplePLINQOrdered()
        {
            var myNumbers = Enumerable.Range(10, 1000);
            var result = from n in myNumbers.AsParallel().AsOrdered()
                         where n % 2 == 0
                         select n;
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }

        static void SimplePLINQSeqCombined()
        {
            var myNumbers = Enumerable.Range(10, 1000);
            var result = (from n in myNumbers.AsParallel().AsOrdered()
                         where n % 2 == 0
                         select n).AsSequential().Take(100);
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }

        static void SimplePLINQException()
        {
            string[] names = { "Abhishek", "Tony", "Ram", "Sam","T","Ravi"};
            var query = from name in names.AsParallel()
                                where name[2] == 'h'  //throw indexoutofrange
                                select new { name = name, thread = Thread.CurrentThread.ManagedThreadId };

            try
            {
                query.ForAll(e => Console.WriteLine("Name: {0}, Thread:{1}", e.name, e.thread));
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                    if (ex is IndexOutOfRangeException)
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                }
            }

        }

        static void WorkWithFiles()
        {


            string path = @"C:\Abhishek";
            var sw = Stopwatch.StartNew();
            int count = 0;
            string[] files = null;
            try
            {

                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified directory {0} was not found.", path);
            }

            var fileContents = from file in files.AsParallel()
                               let extension = Path.GetExtension(file)
                               where extension == ".txt" || extension == ".htm"
                               let text = File.ReadAllText(file)
                               select new FileResult { Text = text, FileName = file }; //Or ReadAllBytes, ReadAllLines, etc.

            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                    count++;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle((ex) =>
                {
                    if (ex is UnauthorizedAccessException)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine("FileIteration_1 processed {0} files in {1} milliseconds", count, sw.ElapsedMilliseconds);
        
    }

        static void PLINQWithCancelation()
        {
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            var cts = new CancellationTokenSource();

            // Start a new asynchronous task that will cancel the
            // operation from another thread. Typically you would call
            // Cancel() in response to a button click or some other
            // user interface event.
            Task.Factory.StartNew(() =>
            {
                Random rand = new Random();
                Thread.Sleep(rand.Next(150, 500));
                cts.Cancel();
            });

            int[] results = null;
            try
            {
                results = (from num in source.AsParallel().WithCancellation(cts.Token)
                           where num % 3 == 0
                           orderby num descending
                           select num).ToArray();
                
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions != null)
                {
                    foreach (Exception e in ae.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Cancel();
                cts.Dispose();
            }
            if (results != null)
            {
                foreach (var v in results)
                    Console.WriteLine(v);
            }

            Console.WriteLine();
            Console.ReadKey();
        }

       /* static int CheckOdd(int num)
        {
            Thread.Sleep(100);
            if (num % 3 == 0)
            {
                return 0;
            }
            return 1;
        }*/
    
    }
    struct FileResult
    {
        public string Text;
        public string FileName;
    }
}
