using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
    class ListExample
    {
      
        static void Main1()
        {
            List<int> obj = new List<int>();
            obj.Add(10);
            obj.Remove(10);
            foreach (int item in obj)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ReadLine();
        }
        static void Main()
        {
            List<Employee> obj = new List<Employee>();

            obj.Add(new Employee { EmpNo = 1, Name = "Vikram" });
            obj.Add(new Employee { EmpNo = 2, Name = "Harsh" });
            obj.Add(new Employee { EmpNo = 3, Name = "Shweta" });
            obj.Add(new Employee { EmpNo = 4, Name = "Ananya" });

            foreach (Employee item in obj)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}
