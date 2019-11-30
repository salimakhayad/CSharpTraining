using System;
using System.Collections.Generic;

namespace CollectIt
{
    public class EmployeeComparer : IEqualityComparer<Employee>,IComparer<Employee>
    {


        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }
    public class DepartmentCollection :
        SortedDictionary<string,SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region Comparing Employees
            var departments = new DepartmentCollection();

            departments.Add("Engineering", new Employee() { Name = "Joy" })
                       .Add("Engineering", new Employee() { Name = "Dani" })
                       .Add("Engineering", new Employee() { Name = "Dani" });


             departments.Add("Sales", new Employee() { Name = "Scott" })
                        .Add("Sales", new Employee() { Name = "Alex" })
                        .Add("Sales", new Employee() { Name = "Dani" });

            foreach (var item in departments)
            {
                Console.WriteLine(item.Key);
                foreach (var department in item.Value)
                {
                    Console.WriteLine("\t" + department.Name);
                }
            }
            Console.ReadLine();
            #endregion
            #region Sorted Set

            // acts like a hashset, sorted keeps them in numerical order

            // var set = new SortedSet<int>();
            // set.Add(3);
            // set.Add(2);
            // set.Add(1);
            #endregion
            #region SortedList
            //var list = new SortedList<int, string>();
            //list.Add(3, "three");
            //list.Add(2, "two");
            //list.Add(1, "one");

            #endregion
            #region SortedDictionairy
            //var employeesByName = new SortedDictionary<string, List<Employee>>();
            //employeesByName.Add("Sales", new List<Employee>() { new Employee(), new Employee(), new Employee(), });
            //employeesByName.Add("Engineering", new List<Employee>() { new Employee(), new Employee() });
            //
            //foreach (var item in employeesByName)
            //{
            //    Console.WriteLine("The Count of employeees for {0} is {1}",
            //        item.Key, item.Value.Count);
            //}
            //Console.ReadLine();
            #endregion
            #region Dictionairy 
            //contains key method, remove values by Key = very good at searching and locating by Key Value
            // var employeesByDepartment = new Dictionary<string, List<Employee>>();
            //
            // employeesByDepartment.Add("Engineering", new List<Employee>() { new Employee() { Name = "Scott" } });
            //
            // employeesByDepartment["Engineering"].Add(new Employee { Name = "Scott" });
            //
            // foreach (var item in employeesByDepartment)
            // {
            //     foreach (var employee in item.Value)
            //     {
            //         Console.WriteLine(employee.Name);
            //     }
            // }






            // 1
            // employeesByName.Add("Scott", new Employee() { Name = "Scott" });  THROWS EXCEPTION => Should be unique (select unique key)
            //var scott = employeesByName["Scott"]; // search by key
            //
            //foreach (var item in employeesByName)
            //{
            //    Console.WriteLine("{0}:{1}", item.Key,item.Value.Name);
            //}
            //Console.ReadLine();

            #endregion
            #region Linked List
            // LinkedList<int> list = new LinkedList<int>();
            // list.AddFirst(2);
            // list.AddFirst(3);
            // 
            // var first = list.First; // return a linkedlist node of int
            // list.AddAfter(first, 5);
            // list.AddBefore(first, 10);
            // 
            // var node = list.First; // next previous value
            // while (node != null)
            // {
            //     Console.WriteLine(node.Value);
            //     node = node.Next;
            // }
            // 
            // foreach (var item in list)
            // {
            //     Console.WriteLine(item);
            // }

            #endregion
            #region HashSet works well with valuetypes

            // intersect , unionWith, symetrickexceptwith etc
            // HashSet<Employee> set = new HashSet<Employee>();
            // var employee = new Employee() { Name = "Harvey"};
            // set.Add(employee);
            // set.Add(employee);
            // 
            // foreach (var item in set)
            // {
            //     Console.WriteLine(item.Name); // UNIQUE REFS AND DIFF VALUE TYPES ONLY.
            // }
            // Console.ReadLine();

            #endregion
            #region Stack LIFO

            // Stack<Employee> stack = new Stack<Employee>();
            // stack.Push(new Employee { Name = "Alex" });
            // stack.Push(new Employee { Name = "Dani" });
            // stack.Push(new Employee { Name = "Chris" });
            //
            // // returns and removes RR
            // while (stack.Count > 0)
            // {
            //     var emp = stack.Pop(); 
            //     Console.WriteLine(emp.Name);
            // }
            // 
            //
            // Console.WriteLine("--");
            //
            //
            // Queue<Employee> queu = new Queue<Employee>();
            // queu.Enqueue(new Employee { Name = "Alex" });
            // queu.Enqueue(new Employee { Name = "Dani" });
            // queu.Enqueue(new Employee { Name = "Chris" });
            //
            // // returns and removes RR
            // while (queu.Count > 0)
            // {
            //     var emp = queu.Dequeue();
            //     Console.WriteLine(emp.Name);
            // }
            // Console.ReadLine();
            #endregion
            #region Queu Fifo
            // Queue<Employee> line = new Queue<Employee>();
            // line.Enqueue(new Employee { Name = "Alex" });
            // line.Enqueue(new Employee { Name = "Dani" });
            // line.Enqueue(new Employee { Name = "Chris" });
            // 
            // // returns and removes RR
            // while (line.Count > 0)
            // {
            //     var emp = line.Dequeue();
            //     Console.WriteLine(emp.Name);
            // }
            // Console.ReadLine();
            #endregion
            #region List
            // -- List
            //2
            //
            // var numbers = new List<int>();
            // var capacity = -1;
            // while (true)
            // {
            //     if (numbers.Capacity != capacity)
            //     {
            //         capacity = numbers.Capacity;
            //         Console.WriteLine(capacity);
            //     }
            //     numbers.Add(1);
            //
            // }


            // 1
            // List<Employee> employees = new List<Employee>
            // {
            //     new Employee { Name = "Scott"},
            //     new Employee { Name = "Scott"}
            // };
            // employees.Add(new Employee() { Name = "Scott" });
            // foreach (var employee in employees)
            // {
            //     Console.WriteLine(employee.Name);
            // }
            // 
            // for (int i = 0; i < employees.Count; i++)
            // {
            //     Console.WriteLine(employees[i].Name);
            // }
            #endregion
            #region Array
            // -- ARRAY
            // Employee[] employees = new Employee[]
            // {
            //     new Employee { Name = "Scott"},
            //     new Employee { Name = "Scott"}
            // };
            // 
            // foreach (var employee in employees)
            // {
            //     Console.WriteLine(employee.Name);
            // }
            // 
            // for (int i = 0; i < employees.Length; i++)
            // {
            //     Console.WriteLine(employees[i].Name);
            // }


            // var employeesByName = new SortedList<string, List<Employee>>();
            //
            // employeesByName.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            // employeesByName.Add("Engineering", new List<Employee> { new Employee(), new Employee() });
            //
            // foreach (var item in employeesByName)
            // {
            //     Console.WriteLine("The count of employees for {0} is {1}", 
            //                 item.Key, item.Value.Count
            //             );
            // }
            #endregion


        }
    }
}
