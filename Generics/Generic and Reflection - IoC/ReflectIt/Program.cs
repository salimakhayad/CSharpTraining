using System;
using System.Collections.Generic;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {                                     // unbound generic
            var employeeList = CreateCollection(typeof(List<>),typeof(Employee));
            Console.Write(employeeList.GetType().Name);
            var genericArguments = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericArguments)
            {
                Console.Write("[{0}]",arg.Name);
            }
            Console.WriteLine();
            Console.ReadLine();

            // binding methods
            var employeee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employeee, null);
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
}
