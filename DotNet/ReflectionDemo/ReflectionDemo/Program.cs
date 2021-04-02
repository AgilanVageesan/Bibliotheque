using System;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var classToReflectAssembly = Assembly.LoadFrom(@"C:\Abhishek\Great Learning\ReflectionDemo\ClassToReflectOn\bin\Debug\netcoreapp3.1\ClassToReflectOn.dll");

            var types = classToReflectAssembly.GetTypes();

            foreach(var type in types)
            {
                //Member & Type Discovery
                var members = type.GetMembers();
               
                foreach(var member in members)
                {
                    Console.WriteLine("{0}-{1}",member.Name,member.MemberType.ToString());
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("{0}-{1}-{2}", method.Name, method.ReturnType,method.ReturnParameter);

                    var parameters = method.GetParameters();
                    foreach(var parameter in parameters)
                    {
                        Console.WriteLine("{0}-{1}",parameter.Name, parameter.ParameterType.ToString());
                    }

                }
            }

            


            var classInstance = Activator.CreateInstance(types[0]);

            PropertyInfo propInfoAge = types[0].GetProperty("Age");
            propInfoAge.SetValue(classInstance, 20,null);
            int val = (int)propInfoAge.GetValue(classInstance);

            classInstance.GetType().InvokeMember("PrintName",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance, 
                null, classInstance, new string[] {"Abhishek","Hello"});
        
        }
    }
}
