using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueTypes
{
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1 = o2;
            o2.i = 300;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
            Console.ReadLine();
        }
        static void Main2()
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1);
            Console.WriteLine(o2);

            Console.ReadLine();
        }

        static void Main3()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }

        static void DataTypes()
        {
            byte b1;
            sbyte b2;
            char ch;
            short sh1;
            ushort sh2;
            int i1; //System.Int32 //4
            uint i2;//System.UInt32 //4
            long l1;
            ulong l2;
            float f;
            double d;
            decimal d2;
            bool b;

            string s;
            object o;

        }
    }
    public class Class1
    {
        public int i;
    }
}
namespace n2  // using ref, out, in
{
    unsafe class Program
    {
        static void Main1()
        {
            int i=123;
            int j;
            Init(out i, out j);
            Swap( ref i,ref j);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }
        static void Swap( ref int i,  ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
           
        }

        unsafe static void PointerExample()
        {
            //Project Properties - Build - Allow unsafe code
            unsafe
            {
                int i;
                int* ptr = &i;

            }
        }
        //out is similar to ref - changes made in func reflect back in calling code
        static void Init(out int i, out int j)
        {
            //the initial value is discarded
            //Console.WriteLine(i);
            i = 100;
            j = 200;
            //out variables MUST be initialized in the function
        }
        static void DoSomethingWithIn(in int i, in int j)
        {
            //i = 200;// i is readonly (in)
            Console.WriteLine(i);
        }

    }
}

namespace n3  // passing ref types
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
        static void DoSomething1(Class1 obj)  //obj =o;
        {
            //changes made in func (changing value of properties) is reflected in calling code o
            obj.i = 200;
        }
        static void DoSomething2(Class1 obj)
        {
            //changes made in func (obj pointing to some other block) is NOT reflected in calling code o

            obj = new Class1();
            obj.i = 200;
        }
        static void DoSomething3(ref Class1 obj)  //try with out also instead of ref
        {
            //changes made in func (obj pointing to some other block) is reflected in calling code o
            obj = new Class1();
            obj.i = 200;
        }
    }

    public class Class1
    {
        public int i;
    }
}

