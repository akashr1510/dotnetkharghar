using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    //step 1 - create a delegate class having the same signature as the method to call
    public delegate void Del1();
    public delegate int DelAdd(int a, int b);
    class Program
    {
        static void Main1()
        {
            //step 2 : create an object of the delegate class and pass the function name as a parameter
            Del1 objDel = new Del1(Display);

            //step 3 : call the delegate object (like calling the function)
            objDel();
            Console.ReadLine();
        }
        static void Main2()
        {
            Del1 objDel = Display;

            objDel();
            Console.ReadLine();
        }

        static void Main3()
        {
            Del1 objDel = Display;
            objDel();

            objDel = Show;
            objDel();
            Console.ReadLine();
        }
        //Object
        //Delegate
        //MultiCastDelegate
        //Del1
        static void Main4()
        {
            Del1 objDel = Display;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel += Show;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.ReadLine();
        }
        static void Main5()
        {
            Del1 objDel = Display;
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel = (Del1)Delegate.Combine(objDel, new Del1(Show));
            //objDel += Show;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            //objDel -= Display;
            objDel();

            Console.ReadLine();
        }

        static void Main6()
        {
            DelAdd objAdd = Add;
            Console.WriteLine(objAdd(10,20));
            Console.ReadLine();
        }
        static void Main7()
        {
            Del1 objDel = Class1.Display;
            objDel();

            Class1 o1 = new Class1();
            objDel = o1.Show;
            objDel();
            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("Display called");
        }
        static void Show()
        {
            Console.WriteLine("Show called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }

        //to do - try multicast delegates for funcs that have a return value
    }
    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("Display called");
        }
        public void Show()
        {
            Console.WriteLine("Show called");
        }
    }
}

namespace UsingDelegatesAsAParameterToAFunction  //allows us to decide which func to call at run time (late binding)
{
    //public delegate int DelAdd(int a = 0, int b = 0);
    public delegate int DelAdd(int a, int b);
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(CallMathOperation(Add, 20, 10));
            Console.WriteLine(CallMathOperation(Subtract, 3, 2));
            Console.WriteLine(CallMathOperation(Multiply, 10, 3));
            Console.WriteLine(CallMathOperation(Divide, 9, 3));
            Console.ReadLine();
        }
        static int CallMathOperation(DelAdd objDelAdd, int i, int j)
        {
            //return objDelAdd();  //if you use default values/optional parameters
            return objDelAdd(i, j);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }

    }
}

