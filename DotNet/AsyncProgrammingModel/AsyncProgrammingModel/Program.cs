using System;
using System.IO;
using System.Text;

namespace AsyncProgrammingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            //EasyAsync();
            WaitUnitilHandle();
            //KeepPolling();
        }

        static void EasyAsync()
        {
            byte[] fileBytesBuffer = new byte[200000];
            FileStream fsReadFile = new FileStream("myText.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);

            //Begins Async Operation
            IAsyncResult result = fsReadFile.BeginRead(fileBytesBuffer, 0, fileBytesBuffer.Length, null, null);
            Console.WriteLine("This is truely Async !! I am a Pro !! I am not blocked");

            //Waits till Async Operation completes
            int numBytes = fsReadFile.EndRead(result);

            fsReadFile.Close();
            Console.WriteLine("Number of Bytes Read : {0}", numBytes);
            Console.WriteLine(Encoding.UTF8.GetString(fileBytesBuffer, 0, fileBytesBuffer.Length));
        }

        static void WaitUnitilHandle()
        {
            byte[] fileBytesBuffer = new byte[200];
            FileStream fsReadFile = new FileStream("myText.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);

            //Begins Async Operation
            IAsyncResult result = fsReadFile.BeginRead(fileBytesBuffer, 0, fileBytesBuffer.Length, null, null);
            
            //Blocks the current thread and waits till Async Operation is complete
            result.AsyncWaitHandle.WaitOne();

            //Waits till Async Operation completes
            int numBytes = fsReadFile.EndRead(result);

            fsReadFile.Close();
            Console.WriteLine("Number of Bytes Read : {0}", numBytes);
            Console.WriteLine(Encoding.UTF8.GetString(fileBytesBuffer, 0, fileBytesBuffer.Length));
        }

        static void KeepPolling()
        {
            byte[] fileBytesBuffer = new byte[200];
            FileStream fsReadFile = new FileStream("myText.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);

            //Begins Async Operation
            IAsyncResult result = fsReadFile.BeginRead(fileBytesBuffer, 0, fileBytesBuffer.Length, null, null);

            while (result.IsCompleted != true)
            {
                //Show Progress Bar. Keep waiting.
            }

            //Waits till Async Operation completes
            int numBytes = fsReadFile.EndRead(result);

            fsReadFile.Close();
            Console.WriteLine("Number of Bytes Read : {0}", numBytes);
            Console.WriteLine(Encoding.UTF8.GetString(fileBytesBuffer, 0, fileBytesBuffer.Length));
        }
    }
}
