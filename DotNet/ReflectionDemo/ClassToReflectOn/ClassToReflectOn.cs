using System;

namespace ClassToReflectOn
{
    public class ClassToReflectOn
    {
        int name;
        int age;

        public int Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public void PrintName(string requestor,string x)
        {
            Console.WriteLine("Requested by {0}--{x}", requestor,x);
        }
    }
}
