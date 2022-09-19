using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //int? a ;
            //Nullable<string> a;
            //a = null;

            MyStack<int> obj = new MyStack<int>(3);
            obj.Push(10);
            obj.Push(20);
            obj.Push(30);
            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());

            MyStack<string> obj2 = new MyStack<string>(3);
            obj2.Push("pa");
            obj2.Push("b");
            obj2.Push("c");
            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());


            Console.ReadLine();
        }
    }
    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class MyStack<T>
    //where T : class  - T must be a reference type
    //where T : struct - T must be a value type
    //where T : ClassName - T must be either ClassName or a derived class
    //where T : InterfaceName - T must be a class that implements InterfaceName
    //where T : new() //- T must have a no parameter constructor

    //constraints can be combined. new() must appear at the end if new() is used
    //where T : ClassName, InterfaceName
    //where T : ClassName, InterfaceName, new()
    {
        T[] arr;
        public MyStack(int Size)
        {
            arr = new T[Size];
            //int x = new int();
            //Employee o = new Employee();
            //T o = new T();
        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
}
