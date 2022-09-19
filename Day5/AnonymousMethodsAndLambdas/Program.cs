using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethodsAndLambdas
{
    class Program
    {
        static void Main1()
        {
            int i = 100;
            Action o1 = delegate()
            {
                Console.WriteLine("Anon method called");
                Console.WriteLine(++i);
            };
            o1();

            Console.ReadLine();
        }
        static void Main(string[] args)
        {

            Func<int, int, int> o1 = delegate(int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(o1(10,20));
            Console.ReadLine();
        }
        //static void Display()
        //{
        //    Console.WriteLine("Display called");
        //}
        //static int Add(int a, int b)
        //{
        //    return a + b;
        //}
    }
}
