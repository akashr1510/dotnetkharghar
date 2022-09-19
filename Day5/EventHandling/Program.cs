using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class Program
    {
        //static void Main1()
        //{
        //    Class1 objCls1 = new Class1();
        //    objCls1.InvalidP1 += objCls1_InvalidP1;
        //    objCls1.P1 = 1000;
        //    Console.ReadLine();
        //}
        static void Main2()
        {
            Class1 objCls1 = new Class1();
            objCls1.InvalidP1 += ObjCls1_InvalidP1;
            objCls1.InvalidP1 += func2;
            objCls1.P1 = 1000;

            Console.WriteLine();
            Console.WriteLine();
            objCls1.InvalidP1 -= ObjCls1_InvalidP1;
            objCls1.InvalidP1 -= func2;
            objCls1.P1 = 1000;

            Console.ReadLine();
        }

        private static void ObjCls1_InvalidP1()
        {
            Console.WriteLine("event handled here");
        }

        private static void func2()
        {
            Console.WriteLine("event handled here 2");
        }


        //static void objCls1_InvalidP1()
        //{
        //    Console.WriteLine("event handling code called");
        //}
    }
    //step1 : create the delegate class having the same signature as the event handling function
    public delegate void Del1();
    public class Class1
    {
        //step 2 : declare the event as an object of the delegate class
        public event Del1 InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3: raise an event here - InvalidP1
                    if(InvalidP1!=null)
                        InvalidP1();
                }
            }
        }
    }
}
//parameters in events
namespace EventHandling2
{
    class Program
    {
        static void Main()
        {
            Class1 objClass1 = new Class1();
            objClass1.InvalidP1 += ObjClass1_InvalidP1;
            objClass1.P1 = 10000;
            Console.ReadLine();
        }

        private static void ObjClass1_InvalidP1(int InvalidValue)
        {
            Console.WriteLine("Invalid Value passed was " + InvalidValue);
        }
    }

    //developer
    //step 1 : create a delegate class having the same signature as the event handler
    public delegate void Del1(int InvalidValue);


    public class Class1
    {
        //Step 2 : declare an event ( event is a delegate object)
        

        public event Del1 InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3: call the event whenever needed (make a call to delegate object)
                    if (InvalidP1 != null)  //if no handlers are present then Exception is thrown. Check for null to avoid exception
                        InvalidP1(value);
                }
            }
        }
    }

}

