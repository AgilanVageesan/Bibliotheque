using System;
using System.Collections.Generic;

namespace ExploreDatatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //sizeof
            Console.WriteLine("Byte size : {0}",sizeof(byte));
            Console.WriteLine("Byte int : {0}", sizeof(int));
            Console.WriteLine("Byte ulong : {0}", sizeof(ulong));
            Console.WriteLine("Byte bool : {0}", sizeof(bool));

            //Tuple C# 7 or later
            (double, int, string) myTuple = (2.2,6,"Hello Tuple");
            Console.WriteLine(myTuple.Item1);
            Console.WriteLine(myTuple.Item2);
            Console.WriteLine(myTuple.Item3);
            List<(double, int, string)> myTupleList = new List<(double, int, string)>();
            myTupleList.Add((2.2, 6, "Hello Tuple 1"));
            myTupleList.Add((2.2, 7, "Hello Tuple 2"));
            myTupleList.Add((2.2, 8, "Hello Tuple 3"));

            foreach(var tupleItr in myTupleList)
            {
                Console.WriteLine(tupleItr.Item1);
                Console.WriteLine(tupleItr.Item2);
                Console.WriteLine(tupleItr.Item3);
            }

            //Nullable
            int? nullTest = null; //Can assign null values
            Console.WriteLine((nullTest is null ? true : false));
            nullTest = 1;
            Console.WriteLine((nullTest is null ? true : false));
            Console.WriteLine((nullTest is null ? true : false));
            //Struct
            MyStruct strct = new MyStruct();
            strct.x = 2;
            strct.y = "Hello Struct";
            Console.WriteLine(strct.x);
            Console.WriteLine(strct.y);
            Console.WriteLine(Colors.green);

            Console.WriteLine(Colors.green==(Colors)5?true:false);
            Console.WriteLine(Colors.green == (Colors)6 ? true : false);

            //Late binding
            dynamic printSomething = new Students();
            printSomething.PrintSomthing();
            //printSomething.PrintSomthing1(); // No error at compile time. But run time exception
            Console.Read();
        }

    }

    enum Colors
    {
        red=2,
        yellow = 3,
        green =5,
        orange =6
    }
    public struct MyStruct
    {
        public int x;
        public string y;
    }

    public class Students
    {
        public void PrintSomthing()
        {
            Console.WriteLine("Hello");
        }
    }
}
