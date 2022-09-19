
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClassConcepts
{
    class Program
    {
        static void Main1()
        {
            //System.Console.WriteLine("Hello World");
            //System.Console.ReadLine();

            System.Console.WriteLine("Hello World");
            System.Console.ReadLine();

        }
        static void Main2()
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
        static void Main3()
        {
            Class1 o; //o is a reference of type Class1
            o = new Class1(); // create an object and make o refer to it
            o.Display();
            Console.ReadLine();
        }
        static void Main4()
        {
            Class1 o = new Class1();
            o.Display();
            o.Display("aaa");

            Console.WriteLine(o.Add(10, 20, 30));
            Console.WriteLine(o.Add(10, 20));


            Console.WriteLine(o.Add4(1, 2, 3, 4, 5, 6, 7));

            Console.WriteLine(o.LocalFuncExample(10));

            Console.ReadLine();
        }
        static void Main5()
        {
            Class1 o = new Class1();

            Console.WriteLine(o.Add(10, 20, 30));  // positional parameters

            Console.WriteLine(o.Add(c: 30)); //named parameter
            Console.WriteLine(o.Add(c: 30, a: 10)); //named parameter
                                                    // Console.WriteLine(o.Add2(c: 30)); //named parameter - error
            Console.ReadLine();
        }

        static void Main6()
        {
            Class2 o = new Class2();
            //o.i = ++o.i + o.i++ - --o.i - o.i--;

            //Console.WriteLine(o.i);

            //o.Seti(10);
            //Console.WriteLine(o.Geti());

            o.Prop1 = 10;  //set
            Console.WriteLine(o.Prop1);  //get

            o.Prop4 = "aaa";

            Console.ReadLine();
        }
        static void Main7()
        {
            Class2 o = new Class2();
            Class2 o2 = new Class2(1, "b");
            Console.WriteLine(o.Prop1);
            Console.WriteLine(o.Prop2);

            o = null;
            o2 = null;
            //GC.Collect();
            Console.ReadLine();


        }
        static void Main()
        {
            //Class3 o = new Class3();
            //o.Prop1 = 5;
            //o.Prop3 = "a";

            //object initializer
            Class3 o1 = new Class3() { Prop1 = 5, Prop3 = "a" };
            Class3 o2 = new Class3{ Prop1 = 5, Prop3 = "a" };


            Console.ReadLine();


        }

        //functions
        public class Class1 //:Object
        {
            public void Display()
            {
                Console.WriteLine("Disp");
            }
            public void Display(string s)
            {
                Console.WriteLine("Disp" + s);
            }

            //public int Add(int a, int b)
            //{
            //    return a + b;
            //}
            //public int Add(int a, int b, int c)
            //{
            //    return a + b + c;
            //}

            //optional parameters - default values
            public int Add(int a = 0, int b = 0, int c = 0)
            {
                return a + b + c;
            }
            public int Add2(int a, int b, int c)
            {
                return a + b + c;
            }
            //params needs to be the last parameter of the func
            //params needs an array as a parameter
            public int Add4(params int[] arr)
            {
                int result = 0;
                foreach (int item in arr)
                {
                    result += item;
                }
                return result;
            }
            public int LocalFuncExample(int a)
            {
                int b = 10;
                LocalFunc2();
                return LocalFunc();

                //if this code needs to called repeatedly (eg in a loop)
                //local func can not have an access specifier (implicitly private)
                //local func can only be called from the outer func ( func which contains the local func)
                //local func can access variables defined in the outer func
                int LocalFunc()
                {
                    //LocalFunc2();
                    return a * b * 2;
                }
                void LocalFunc2()
                {
                    Console.WriteLine(a * b * 2);
                }
            }
        }
        public class Class2
        {
            #region Properties
            private int i;  //field
            public void Seti(int Value)
            {
                if (Value < 100)
                    i = Value;
                else
                    Console.WriteLine("invalid value");
            }
            public int Geti()
            {
                return i;
            }

            private int prop1;
            public int Prop1
            {
                set
                {
                    if (value < 100)
                        prop1 = value;
                    else
                        Console.WriteLine("invalid value");
                }
                get
                {
                    return prop1;
                }

            }

            private string prop2;
            public string Prop2
            {
                set
                {
                    if (value != "AAA")
                        prop2 = value;
                    else
                        Console.WriteLine("invalid value");
                }
                get
                {

                    return prop2;
                }

            }

            // TO DO - Create a read only property (Hint -- only get, no set)

            private string prop3;
            public string Prop3
            {
                set
                {
                    prop3 = value;
                }
                get
                {
                    return prop3;
                }

            }

            //automatic property
            //code get/set is generated by the compiler
            //private variable is generated by the compiler
            public string Prop4 { get; set; }

            //ILDASM
            #endregion

            //public Class2()
            //{
            //    this.Prop1 = 10;
            //    this.Prop2 = "aa";
            //}
            //public Class2(int Prop1, string Prop2)
            //{
            //    this.Prop1 = Prop1;
            //    this.Prop2 = Prop2;
            //}
            public Class2(int Prop1 = 10, string Prop2 = "aa")
            {
                this.Prop1 = Prop1;
                this.Prop2 = Prop2;
            }

            //DONT EVER WRITE A DESTRUCTOR
            ~Class2()
            {
                Console.WriteLine("des");
               // Console.ReadLine();
            }
        }
        public class Class3
        {
            private int prop1;
            public int Prop1
            {
                set
                {
                    if (value < 100)
                        prop1 = value;
                    else
                        Console.WriteLine("invalid value");
                }
                get
                {
                    return prop1;
                }

            }
            private string prop3;
            public string Prop3
            {
                set
                {
                    prop3 = value;
                }
                get
                {
                    return prop3;
                }

            }

        }
    }
}
