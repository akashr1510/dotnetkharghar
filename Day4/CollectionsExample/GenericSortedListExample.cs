using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
    
    class GenericSortedListExample
    {
         static void Main1()
        {
            SortedList<int, string> objDictionary = new SortedList<int, string>();
            objDictionary.Add(10, "Shubham");
            objDictionary.Add(20, "Hitesh");
            objDictionary.Add(30, "Mohanish");
            objDictionary.Add(40, "Yogesh");

            objDictionary[50] = "Vikram";  //if key not present , create
            objDictionary[30] = "Anjali"; // if key present overwrite

            foreach (KeyValuePair<int, string> item in objDictionary)
            {
                Console.Write(item.Key);
                Console.WriteLine(item.Value);
            }
        }
        static void Main()
        {
            SortedList<int, Employee> objDictionary = new SortedList<int, Employee>();
            objDictionary.Add(1, new Employee { EmpNo = 1, Name = "Vikram" });
            objDictionary.Add(2, new Employee { EmpNo = 2, Name = "H" });
            objDictionary.Add(3, new Employee { EmpNo = 3, Name = "S" });

            foreach (KeyValuePair<int,Employee> item in objDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine( item.Value.Name );
            }
        }
    }

  
}
