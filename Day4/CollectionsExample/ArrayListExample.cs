using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsExample
{
    class ArrayListExample
    {
        static void Main1()
        {
            ArrayList obj = new ArrayList();

            obj.Add(10);
            obj.Add(20);
            obj.Add("Vikram");
            obj.Add(10.123);

            obj.Remove(10);
            //obj.RemoveAt(10); //index
            //obj.RemoveRange(0,3)

            //obj.AddRange(collection);
            //obj.Clear(); // Remove All
            // obj.LastIndexOf  obj.IndexOf obj.BinarySearch similar to Array.
            //bool present = obj.Contains(10);
            //obj.CopyTo()  //copy to array or obj.ToArray
            //obj2 = obj.GetRange(0, 3);
            //obj.Insert(0, "aa");
            //obj.InsertRange

            obj.Capacity = 10;
            for (int i = 0; i < 20; i++)
            {
                obj.Add(i);
            }
            obj.TrimToSize();


            foreach (object item in obj)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(obj.Count);
            Console.ReadLine();
        }
    }
}
