using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.s_Display();
            Class1.s_i = 100;
            
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 100;

            Class1.s_P1 = 10;
            Console.ReadLine();
        }
    }

    public class Class1
    {

        //single copy for the class
        public static int s_i;
        public int i;
        
        //can directly access the static func without creating an object
        public static void s_Display()
        {
            Console.WriteLine("s disp");
            //Console.WriteLine(i); //from static member only static members can be directly accessed.
            Console.WriteLine(s_i); 
            Console.WriteLine(s_P1);
        }
        public void Display()
        {
            Console.WriteLine("d");
            Console.WriteLine(i);
            Console.WriteLine(s_i);
        }
        private int p1;
        public int P1
        {
            set
            {
                if (value < 10)
                    p1 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return p1;
            }
        }
        //why static property? --- single copy with validation
        private static int s_p1;
        public static int s_P1
        {
            set
            {
                if (value < 10)
                    s_p1 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return s_p1;
            }
        }
        //why static constructor -- initialise static members
        static Class1()
        {
            Console.WriteLine("static cons called");
            s_P1 = 1;
            s_i = 20;
        }
    }
   
    //can only have static members
    //cannot instantiate the class
    //cannot use it as a base class

    public static class Class2
    {
        //TO DO : try this

    }
}

//why static variable?--- single copy
//why property? --- validation
//why static property? --- single copy with validation

//why constructor? -- initialise members
//why static constructor -- initialise static members

//when static cons called - when class is loaded into memory
//when is the class loaded into memory -- first obj is created or static member accessed for the first time
//static cons is implicitly called
//static cons is parameterless, and cannot be overloaded
//static cons is implicitly private and therefore cannot have an access specifier