using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples1
{
    class Program
    {
        static void Main1()
        {
            //BaseClass o = new BaseClass();
            //o.
            //DerivedClass o = new DerivedClass();
            //o.
        }
    }

    public class BaseClass
    {
        public int a;

    }
    public class DerivedClass : BaseClass
    {
        public int b;

    }
}

namespace InheritanceExamples2
{
    class Program
    {
        static void Main1()
        {
            //BaseClass o = new BaseClass();
            //o.
            //DerivedClass o = new DerivedClass();

            TestAccessSpecifiers.BaseClass o = new TestAccessSpecifiers.BaseClass();
            //o.
        }
    }
    //public -> everywhere
    //private -> same class
    //protected -> same class, derived class
    //internal -> same class, same assembly
    //protected internal -> same class, derived class, same assembly

    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        int a;


    }
    public class DerivedClass  : TestAccessSpecifiers.BaseClass  //:  BaseClass
    {

        void DoNothing()
        {
            //this.

        }
    }
}
//constructors in inheritance
namespace InheritanceExamples3
{

    class Program
    {
        static void Main1()
        {
            //DerivedClass o = new DerivedClass();

            DerivedClass o2 = new DerivedClass(123, 456);
            Console.ReadLine();
        }
    }
    public class BaseClass
    {
        public int i;
        public BaseClass()
        {
            Console.WriteLine("base class no param cons");
            i = 10;
        }
        public BaseClass(int i)
        {
            Console.WriteLine("base class int cons");
            this.i = i;
        }
    }
    public class DerivedClass : BaseClass
    {
        public int j;
        public DerivedClass()
        {
            Console.WriteLine("derived class no param cons");
            //i = 10;
            j = 20;
        }
        public DerivedClass(int i, int j) : base(i)
        {
            Console.WriteLine("derived class int,int cons");
            //this.i = i;
            this.j = j;
        }
    }
}
//overload, hiding, overriding
namespace InheritanceExamples4
{

    class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            //o.Display1();
            //o.Display1("aaa");

            //o.Display2();
           // o.Display3();

            Console.ReadLine();
        }
        static void Main2()
        {
            BaseClass o;

            //o = new BaseClass();
            //o.Display2();
            //o.Display3();

            //Console.WriteLine();
            //Console.WriteLine();
            //o = new DerivedClass();
            //o.Display2();
            //o.Display3();

            //Console.WriteLine();
            //Console.WriteLine();
            //o = new SubDerivedClass();
            //o.Display2();
            //o.Display3();

            //Console.WriteLine();
            //Console.WriteLine();
            o = new SubSubDerivedClass();
            //o.Display2();
            o.Display3();

            Console.ReadLine();

        }

        static void Main3()
        {
            BaseClass o1 = new BaseClass();
            CallDisplay3(o1);

            o1 = new DerivedClass();
            CallDisplay3(o1);

            Console.ReadLine();

        }
        static void CallDisplay3(BaseClass o)
        {
            o.Display3();
        }
    }
    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("Base Display1");
        }

        public void Display2()
        {
            Console.WriteLine("Base Display2");
        }

        public virtual void Display3()
        {
            Console.WriteLine("Base Display3");
        }
    }
    public class DerivedClass : BaseClass
    {

        //overloading the method in the derived class
        public void Display1(string s)
        {
            Console.WriteLine("Derived Display1");
        }

        //hiding the method in the derived class
        public new void Display2()
        {
            Console.WriteLine("Derived Display2");
        }

        //overriding the base class method
        public override void Display3()
        {
            Console.WriteLine("Derived Display3");
        }

    }
    public class SubDerivedClass : DerivedClass
    {

        //overriding the base class method
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived subDisplay3");
        }
    }
    public class SubSubDerivedClass : SubDerivedClass
    {

        //overriding the base class method
        public new void Display3()
        {
            Console.WriteLine("Derived subsubDisplay3");
        }
    }

}

namespace InheritanceExamples5
{
    class Program
    {
        static void Main()
        {
            //AbstractClass obj1 = new AbstractClass();
            DerivedClass obj = new DerivedClass();
            obj.Display();

            Console.ReadLine();
        }
    }

    public abstract class AbstractClass
    {
        public void Display()
        {
            Console.WriteLine("display from abs");
        }

    }

    public class DerivedClass : AbstractClass
    {
        public void Show()
        {
            Console.WriteLine("sjhow");
        }
    }
    public abstract class AbstractClass2
    {
        public abstract void Display();
        public abstract void Show();

    }
   

    public class Class2 : AbstractClass2
    {
        public override void Display()
        {
            Console.WriteLine("display");
        }

        public override void Show()
        {
            Console.WriteLine("show");
        }
    }
}

/*
                    ABSTRACT CLASS      SEALED CLASS
 can instantiate    NO                  YES
 can inherit from   YES                 NO
 */

//to do - create a sealed class