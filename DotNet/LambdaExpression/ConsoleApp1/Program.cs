using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    class Program
    {
        delegate void AddDelegate(int a, int b);
        static void Main(string[] args)
        {
            AddDelegate addDelegate = (int a, int b) => Console.WriteLine(a + b) ;
            addDelegate += (int a, int b) =>  Console.WriteLine(a - b) ;
            addDelegate(4, 5);
            //Console.WriteLine(addDelegate(4, 5));
            // EasyExpressionTree();


            //Anonymous Method
            //  AddDelegate addDelegate = (int a, int b)=>{ return a + b; };
            //  Console.WriteLine(addDelegate(4, 5));






            StudentDetails studentDetails = new StudentDetails() { Name="Tim",Age=22, Roll=8,Marks=36, Subject="Maths"};
            StudentDetails studentDetails1 = new StudentDetails() { Name = "Tim", Age = 24, Roll = 1, Marks = 36, Subject = "Maths" };
            StudentDetails studentDetails2 = new StudentDetails() { Name = "Rim", Age = 26, Roll = 2, Marks = 50, Subject = "English" };
            StudentDetails studentDetails3 = new StudentDetails() { Name = "Abhi", Age = 32, Roll = 4, Marks = 80, Subject = "English" };
            StudentDetails studentDetails4 = new StudentDetails() { Name = "Ram", Age = 35, Roll = 5, Marks = 20, Subject = "Maths" };
            StudentDetails studentDetails5 = new StudentDetails() { Name = "Ramesh", Age = 35, Roll = 10, Marks = 30, Subject = "Science" };

            StudentHobbies hobby = new StudentHobbies() {Roll = 1, Hobby="Sports"  };
            StudentHobbies hobby1 = new StudentHobbies() { Roll = 2, Hobby = "Blogger",Name="Rim" };
            StudentHobbies hobby2 = new StudentHobbies() { Roll = 4, Hobby = "Blogger" };
            StudentHobbies hobby3 = new StudentHobbies() { Roll = 5, Hobby = "Music" };
            StudentHobbies hobby4 = new StudentHobbies() { Roll = 8, Hobby = "Dancing" };


            List<StudentDetails> listStudentDetails = new List<StudentDetails>();
            listStudentDetails.Add(studentDetails);
            listStudentDetails.Add(studentDetails1);
            listStudentDetails.Add(studentDetails2);
            listStudentDetails.Add(studentDetails3);
            listStudentDetails.Add(studentDetails4);
            listStudentDetails.Add(studentDetails5);

            List<StudentHobbies> listHobbies = new List<StudentHobbies>();
            listHobbies.Add(hobby);
            listHobbies.Add(hobby1); 
            listHobbies.Add(hobby2); 
            listHobbies.Add(hobby3); 
            listHobbies.Add(hobby4);
            //-------------------------------------
            // Simple Linq
            //-------------------------------------
            //Where

            /* var result = from n in listStudentDetails
                          where n.Age > 32
                          select new { n.Name, n.Marks };

             foreach(var itr in result)
             {
                 Console.WriteLine(itr.Name);
                 Console.WriteLine(itr.Marks);
             }

             //Group By
             var result1 = from n in listStudentDetails
                          group n by n.Subject into subject
                          select new { subject.Key, subject };

             foreach (var itr in result1)
             {
                 Console.WriteLine("{0}-{1}", itr.Key, itr.subject.Count());
             }

             //Join
             var result2 = from n in listStudentDetails
                           join h in listHobbies
                           on n.Roll equals h.Roll
                           select new { n.Roll, n.Name, h.Hobby };

             foreach (var itr in result2)
             {
                 Console.WriteLine("{0}-{1}-{2}", itr.Roll, itr.Name, itr.Hobby);
             }

             //Sort
             var sortedResult = from n in listStudentDetails
                                where n.Age > 25
                                orderby n.Roll descending
                                select n;
             foreach (var itr in sortedResult)
             {
                 Console.WriteLine("{0}-{1}-{2}-{3}",itr.Roll,itr.Name,itr.Age,itr.Marks);
             }
             */


            //---------------------------------------------------------------------------------------
            //------------------------- Simple Lambda Expressions------------------------------------
            //---------------------------------------------------------------------------------------

            //Simple Where
            //var res = listStudentDetails.Where(n => n.Age > 25);


            //Simple Select
            var res = listStudentDetails.Select(n => new { n.Age, n.Marks });
           

            //Simple Where & Select
            // var res = listStudentDetails.Select(n=> new { n.Age,n.Marks }).Where(n => n.Age > 25);

            //Simple Group By
            //var res = listStudentDetails.GroupBy(n => n.Subject).Select(n => new { Subject = n.Key, Count = n.Count() });

            //Simple Group By - Bit more complex
            //var res = listStudentDetails.GroupBy(n => n.Subject).Select(n => new { Subject = n.Key, Sum = n.Sum(n=>n.Marks) });

            //Play with Join
            // var res = listStudentDetails.Join(listHobbies, n => new{ n.Roll,n.Name}, p => new { p.Roll, p.Name }, (n, p) => new {n.Roll,n.Name, p.Hobby });

            //Play with Join - Where
            //var res = listStudentDetails.Join(listHobbies, n => n.Roll, p => p.Roll, (n, p) => new { n.Roll, n.Name, p.Hobby }).Where(n=>n.Roll>2);

            //OrderBy - Asc, Desc
            //Sum
            //Count

            //Group Join/Left Outer Join
            // var res = listStudentDetails.GroupJoin(listHobbies, n => n.Roll, p => p.Roll, (n, p) => new { n.Roll, n.Name,p});

            //Group Join/Right Outer Join
            // Swap and achieve or massage o/p using SelectMany

            //Defered Execution
            //var res = listStudentDetails.Where(n => n.Age > 25);

            //Immediate Execution
            //var res = listStudentDetails.Where(n => n.Age > 25).ToList();

            //---------------------------------------------------------------------------------------
            //------------------------Lambda Deep Dive-----------------------------------------------
            //---------------------------------------------------------------------------------------

            //Expression Lambda
            // var res = listStudentDetails.Where(n => n.Age > 25);

            //Statement Lambda
            /*  bool isRollPresent = listStudentDetails.Any(n =>
              {
                  foreach (var t in n)
                      Console.WriteLine("Hello World {0}", t);
                  return true;
              });

              foreach (var itr in res)
              {
                  Console.WriteLine("{0}-{1}", itr.Age, itr.Marks);
              }
              */
            /*
            // Expression Lambda . No return type
            Action<int,int> Sum = (a,b) => Console.WriteLine(a+b);
            Sum(22,44);

            // Expression Lambda Takes one argument Returns int value
            Func<int, int> Sum1 = (a) => a=a+4;
            Console.WriteLine(Sum1(0));

          // Expression Lambda Takes two argument Returns int value
          Func<int,int,int> Sum2 = (a,b) => a+b ;
          Console.WriteLine(Sum2(22,33));


          Console.WriteLine("*****************************************************************");
          Console.WriteLine("*****************************************************************");

          // Statement Lambda . No return type
          Action<int, int> Sum3 = (a, b) => { Console.WriteLine(a + b); };
          Sum3(22, 44);

          // Statement Lambda Takes one argument Returns int value
          Func<int, int> Sum4 = (a) => { a = a + 4; return a; };
          Console.WriteLine(Sum4(0));

          // Statement Lambda Takes two argument Returns int value
          Func<int, int, int> Sum5 = (a, b) => { int c = a + b; return c; };
          Console.WriteLine(Sum5(22, 33));
          /////////////////////////////////////////////////////////////////////////////////////
          //Play with Expression Tree
          */

            Console.Read();
        }

        public static void EasyExpressionTree()
        {
            // Build Expression Tree
            var paramA = Expression.Parameter(typeof(int), "a");
            var paramB = Expression.Parameter(typeof(int), "b");
            var paramC = Expression.Parameter(typeof(int), "c");
            var paramD = Expression.Parameter(typeof(int), "d");
            var expressionLeft = Expression.Multiply(paramA, paramB);
            var expressionRight = Expression.Multiply(paramC, paramD);
            var sumExpression = Expression.Add(expressionLeft, expressionRight);
            var easyExpression = Expression.Lambda<Func<int, int, int, int, int>>(sumExpression, paramA, 
                paramB, paramC, paramD);
            
            //Interpret Expression Tree
            Console.WriteLine("Body :");
            Console.WriteLine(easyExpression.Body);
            Console.WriteLine("Parameters :");
            foreach (var param in easyExpression.Parameters)
            {
                Console.WriteLine(param.Name);
            }

            //Execute Expression Tree
            //Create a Delegate that we can execute
             var compile = easyExpression.Compile();

            //Execute the Delegate
            var output = compile(3, 4, 5, 6);
            Console.WriteLine(output);
            
        }
    }

    class StudentDetails
    {
        public string Name;
        public string Subject;
        public int Age;
        public int Marks;
        public int Roll;
    }

    class StudentHobbies
    {
        public string Name;
        public string Hobby;
        public int Roll;
    }
}
