using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CollectionsExample
{
    class DictionaryExample
    {
        static void Main()
        {
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();

            objDictionary.Add(10, "Shubham");
            objDictionary.Add(20, "Hitesh");
            objDictionary.Add(30, "Mohanish");
            objDictionary.Add(40, "Yogesh");

            objDictionary[50] = "Vikram";  //if key not present , create
            objDictionary[30] = "Anjali"; // if key present overwrite

            objDictionary.Remove(50);
            objDictionary.RemoveAt(0);
            //objDictionary.Contains(key); objDictionary.ContainsKey


            foreach (DictionaryEntry item in objDictionary)
            {
                Console.Write(item.Key);
                Console.WriteLine(item.Value);

            }

            //to do
            Stack s = new Stack();

            //Push, Peek, Pop
            Queue q = new Queue();
            //Enqueue, Peek, Dequeue


            Console.ReadLine();
        }
    }
}
