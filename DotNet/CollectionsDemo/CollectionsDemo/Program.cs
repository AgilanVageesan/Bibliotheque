using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //PlayWithList();
            //PlayWithClassList();
            //PlayWithDictionary();
            //PlayWithClassDictionary();
            //PlayWithHashtable();
            //PlayWithGenericSortedList();
            PlayWithNonGenericSortedList();
            //PlayWithStack();
            //PlayWithStackNonGeneric();
            //PlayWithQueue();
            //PlayWithNonGenericQueue();
            //PlayWithBlockingCollections();
            //PlayWithConcurrentDictionary();
            //PlayWithConcurrentQueue();
           // PlayWithConcurrentStack();
            PlayWithConcurrentBag();

            Console.Read();
        }

        //Simple List
        static void PlayWithList()
        {
            //Create List of Strings
            List<string> studentNames = new List<string>();

            //Add Student Names
            studentNames.Add("Ravi"); //Index 0
            studentNames.Add("Ram"); //Index 1
            studentNames.Add("Raj"); //Index 2
            studentNames.Add("Mohit"); //Index 3
            studentNames.Add("Abhishek");// Index 4
            studentNames.Add("Sam");//Index 5
           // Console.WriteLine(studentNames[2]);

            foreach(string name in studentNames)
            {
                Console.WriteLine(name);
            }

            //Remove Student named as Raj
            studentNames.Remove("Raj");

            //Access List
            Console.WriteLine(studentNames[2]);
            Console.Read();
        }

        //Class List
        static void PlayWithClassList()
        {
            //Create List of Strings
            List<StudentDetails> studentNames = new List<StudentDetails>();

            //Add Student Names
            StudentDetails studentDetails1 = new StudentDetails() { studentName = "Abhishek", studentAge = 38, studentClass = "Maths" };
            StudentDetails studentDetails2 = new StudentDetails() { studentName = "Raj", studentAge = 32, studentClass = "Science" };
            studentNames.Add(studentDetails1); 
            studentNames.Add(studentDetails2);

            //Access the List
            Console.WriteLine(studentNames[1].studentName + " | "+ studentNames[1].studentAge + "|" + studentNames[1].studentClass);

            //Remove Student named as Raj
            studentNames.Remove(studentDetails1);

            //Access List
            Console.WriteLine(studentNames.Count);
            Console.Read();
        }

        //Work with Dictionary
        static void PlayWithDictionary()
        {
            //Create Dictionary key: name(string), value: age(int)
            Dictionary<string, int> studentAge = new Dictionary<string, int>();

            //Add items to dictionary. key: Ram, age: 22
            studentAge.Add("Ram", 22); //key : Ram
            //Add items to dictionary. key: Rajesh, age: 24
            studentAge.Add("Rajesh", 24); //key :Rajesh

            studentAge.Add("Abhishek", 38);

            //Access value: Age for key: Rajesh 
           // Console.WriteLine(studentAge["Rajesh"]);

            foreach(string key in studentAge.Keys)
            {
                Console.WriteLine(studentAge[key]);
            }

            //Remove item
            studentAge.Remove("Ram");
        }

        //Work with Dictionary of Class
        static void PlayWithClassDictionary()
        {
            //Create Dictionary key: name(string), value: age(int)
            Dictionary<int, StudentDetails> studentAge = new Dictionary<int, StudentDetails>();

            StudentDetails studentDetails1 = new StudentDetails() { studentName = "Abhishek", studentAge = 38, studentClass = "Maths" };
            StudentDetails studentDetails2 = new StudentDetails() { studentName = "Raj", studentAge = 32, studentClass = "Science" };

            //Add items to dictionary. key: Ram, age: 22
            studentAge.Add(2, studentDetails1);
            //Add items to dictionary. key: Rajesh, age: 24
            studentAge.Add(4, studentDetails2);

            //Access value: Age for key: Rajesh 
            Console.WriteLine(studentAge[4].studentName + " | "+studentAge[4].studentAge+" | "+studentAge[4].studentClass);

            //Remove item
            studentAge.Remove(2);
        }

        //Work with Hashtable
        static void PlayWithHashtable()
        {
            //Create Hash Table
            Hashtable studentData = new Hashtable();

            //key: name, value: Abhishek
            studentData.Add("name", "Abhishek");
            //key: age, value: 38
            studentData.Add("age", 38);
            //key: subject, value: maths
            studentData.Add("subject", "maths");
            //key: 10, value: value for an integer key
            studentData.Add(10, "value for an integer key");

            //Access items for keys age and 10
            Console.WriteLine(studentData["age"]);
            Console.WriteLine(studentData[10]);

            //Remove items with keys 10, age
            studentData.Remove(10);
            studentData.Remove("age");
        }

        //Work with Generic SortedList
        static void PlayWithGenericSortedList()
        {
            //Create SortedList key: name(string), value: age(int)
            SortedList<string, int> studentAge = new SortedList<string, int>();

            //Add items to SortedList. key: Ram, age: 22
            studentAge.Add("Ram", 22);
            //Add items to SortedList. key: Rajesh, age: 24
            studentAge.Add("Rajesh", 24);

            //Access value: Age for key: Rajesh 
            Console.WriteLine(studentAge["Rajesh"]);


            //Remove item
            studentAge.Remove("Ram");


            Console.Read();
        }

        //Work with Non-Generic SortedList
        static void PlayWithNonGenericSortedList()
        {
            //Create SortedList key: name(string), value: age(int)
            SortedList studentAge = new SortedList();

            //Add items to SortedList. key: Ram, age: 22
            studentAge.Add("Ram", 22);  //Index 3
            //Add items to SortedList. key: Rajesh, age: 24
            studentAge.Add("Rajesh", "Maths");  //Index 2
            //Add items to SortedList. key: Ajay, age: 32
            studentAge.Add("Ajay", 32); //Index 0
            //Add items to SortedList. key: Amar, age: English
            studentAge.Add("Ajay1", "English"); //Index 1

            //Access value: Age for key: Rajesh 
            Console.WriteLine(studentAge["Rajesh"]);

            //Access value: Age for key: Rajesh 
            Console.WriteLine(studentAge.GetByIndex(1));

            //Remove item
            studentAge.Remove("Ram");

            Console.Read();
        }

        //Work with Stack
        static void PlayWithStack()
        {
            //Create a Stack of string type
            Stack<string> stackNames = new Stack<string>();

            //Push value Raj
            stackNames.Push("Raj"); //Bottom of the Stack
            //Push value Sam
            stackNames.Push("Sam");
            //Push value Sam
            stackNames.Push("Ram"); //Top of the stack

            //Will get the item top of the Stack i.e Ram
            //The item will get removed post Pop operation
            Console.WriteLine(stackNames.Pop());

            //Will get the item top of the Stack i.e Sam
            //Item will not be removed after Peek operation
            Console.WriteLine(stackNames.Peek());
        }

        //Work with Stack
        static void PlayWithStackNonGeneric()
        {
            //Create a Stack of string type
            Stack stackNames = new Stack();

            //Push value Raj
            stackNames.Push("Raj"); //Bottom of the Stack
            //Push value Sam
            stackNames.Push("Sam");
            //Push value Sam
            stackNames.Push(1); //Top of the stack

            //Will get the item top of the Stack i.e Ram
            //The item will get removed post Pop operation
            Console.WriteLine(stackNames.Pop());

            //Will get the item top of the Stack i.e Sam
            //Item will not be removed after Peek operation
            Console.WriteLine(stackNames.Peek());
        }

        //Work with Queue
        static void PlayWithQueue()
        {
            //Create a Queue of strings
            Queue<string> queueNames = new Queue<string>();

            //Add value to queue Raj
            queueNames.Enqueue("Raj"); //1
            //Add value to queue Sam
            queueNames.Enqueue("Sam"); //2
            //Add value to queue Ram
            queueNames.Enqueue("Ram"); //3

            //Will get the item that got added first i.e Raj
            //Will delete the item Raj from the Queue
            Console.WriteLine(queueNames.Dequeue());

            //Will get the item that is waiting to move out of the Queue i.e Sam
            //Will not delete item from the Queue
            Console.WriteLine(queueNames.Peek());
        }

        //Work with Queue
        static void PlayWithNonGenericQueue()
        {
            //Create a Queue of strings
            Queue queueNames = new Queue();

            //Add value to queue Raj
            queueNames.Enqueue(2); //1
            //Add value to queue Sam
            queueNames.Enqueue("Sam"); //2
            //Add value to queue Ram
            queueNames.Enqueue("Raj"); //3

            //Will get the item that got added first i.e 2
            //Will delete the item Raj from the Queue
            Console.WriteLine(queueNames.Dequeue());

            //Will get the item that is waiting to move out of the Queue i.e Sam
            //Will not delete item from the Queue
            Console.WriteLine(queueNames.Peek());
        }

        //Work with Blocking Collections
        static void PlayWithBlockingCollections()
        {
            //Create Blocking Collection
            BlockingCollection<string> studentNames = new BlockingCollection<string>(4);

            //Add Items. After adding 4 items the Thread goes to sleep 
            //until the items are retrieved
            studentNames.Add("Ravi");
            studentNames.Add("Raj");
            studentNames.Add("Ram");
            studentNames.Add("Sam");

            //Retrieve Items
            //Item Gets Deleted
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(studentNames.Take());
            }

            Console.WriteLine("All items retrieved");
        }

        //Work with ConcurrentDictionary
        static void PlayWithConcurrentDictionary()
        {
            //Create Concurrent Dictionary and add items
            ConcurrentDictionary<string, int> studentAge = new ConcurrentDictionary<string, int>();
            studentAge.TryAdd("Rajesh", 22);
            studentAge.TryAdd("Abhishek", 35);

            //Gets value in the out parameter for the key: Abhishek
            int age;
            studentAge.TryGetValue("Abhishek", out age);
            Console.WriteLine(age);

            //new value : 38 current value to match with : 35
            studentAge.TryUpdate("Abhishek", 38, 35);

            //return the value of item being removed using the out parameter
            studentAge.TryRemove("Abhishek", out age);

            Console.WriteLine(age);
        }

        //Work with ConcurrentQueue
        static void PlayWithConcurrentQueue()
        {
            //Create ConcurrentQueue Collection and items
            ConcurrentQueue<string> studentNames = new ConcurrentQueue<string>();
            studentNames.Enqueue("Ram");
            studentNames.Enqueue("Sam");
            studentNames.Enqueue("Raj");

            //Dequeue item that got first added. Item will get deleted from Queue
            string name;
            studentNames.TryDequeue(out name);
            Console.WriteLine(name);

            //Get the item that is waiting to move out of the Queue.
            //Item will not be deleted from Queue post Peek operation.
            studentNames.TryPeek(out name);
            Console.WriteLine(name);
        }

        //Work with ConcurrentStack
        static void PlayWithConcurrentStack()
        {
            //Create ConcurrentStack Collection and add items
            ConcurrentStack<string> studentNames = new ConcurrentStack<string>();
            studentNames.Push("Ram");
            studentNames.Push("Sam");
            studentNames.Push("Raj");

            //Dequeue item that got added last. Item will get deleted from Stack
            string name;
            studentNames.TryPop(out name);
            Console.WriteLine(name);

            //Get the item that is on top of the Stack.
            //Item will not be deleted from Stack post Peek operation.
            studentNames.TryPeek(out name);
            Console.WriteLine(name);
        }

        //Work with ConcurrentBag
        static void PlayWithConcurrentBag()
        {
            //Create Concurrent Bag and add items
            ConcurrentBag<string> studentName = new ConcurrentBag<string>();
            studentName.Add("Abhishek");
            studentName.Add("Ravi");
            studentName.Add("Raj");

            //Gets item in the out parameter. Item gets deleted
            //You get any random item stored
            string name;
            studentName.TryTake(out name);
            Console.WriteLine(name);

            //Gets item in the out parameter. Item does not get deleted
            //You get any random item stored
            studentName.TryPeek(out name);
            Console.WriteLine(name);
        }
    }
}
