using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionPredicate
{
    class Program
    {
        static void Main1()
        {
            Action objDel1 = Display;
            objDel1();

            Action<string> objDel2 = Display;
            objDel2("aaa");

            Console.ReadLine();
        }
        static void Main()
        {
            Func<int, int, int> obj1 = Add;
            Console.WriteLine(obj1(10,20));

            Func<string, decimal, int> obj2 = M1;
            Console.WriteLine(obj2("aaaa", 1.2M));

            Func<int, bool> obj3 = IsEven;
            Console.WriteLine( obj3(1001 ));

            Predicate<int> obj4 = IsEven;
            Console.WriteLine(obj4(1001));

            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("Display called");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display called" + s);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int M1(string a, decimal b)
        {
            return a.Length;
        }
        static bool IsEven(int a)
        {
            return a % 2 == 0;
        }
    }
}
