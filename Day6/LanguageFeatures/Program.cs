using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Implicit Variables
namespace LanguageFeatures1
{
    class Program
    {
        static void Main1()
        {
            int i = 123;


            var i2 = 100;  //implicit variable
            //i2 = "aaa"; //error
            var i4 = "aaa";
            var i3 = (short)100;  //implicit variable

            //used only for local variables
            //cant be used for class level vars,fn params and return types

            //i2 = 200;
            Console.WriteLine(i.GetType().ToString());
            Console.WriteLine(i2.GetType().ToString());
            Console.ReadLine();


        }
    }
}

//anonymous type
namespace LanguageFeatures3
{
    class Program
    {
        static void Main2() // ANONYMOUS TYPES
        {
            //Class1 o = new Class1();
            //Class1 o3 = new Class1 { i = 123, j = 456 };      
            
            //var o3 = new  { i = 123, j = 456 };

            var myCar = new { Color = "Red", Model = "Ferrari", Version = "V1", CurrentSpeed = 75 };


            var myCar2 = new { Color = "Blue", Model = "Merc", Version = "V2", CurrentSpeed = 60 };

            Console.WriteLine("{0} {1} {2} {3}", myCar.Color, myCar.Model, myCar.Version, myCar.CurrentSpeed);

            Console.WriteLine(myCar.GetType().ToString());
            Console.WriteLine(myCar2.GetType().ToString());

            Console.ReadLine();
        }

    }
}

//partial classes
namespace LanguageFeatures5
{
    //PARTIAL CLASSES

    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name


    public partial class Class1
    {
        public int i;
    }
    public partial class Class1
    {
        public int j;
    }
    public class Program
    {
        public static void Main1()
        {
            Class1 o = new Class1();
           

        }
    }
}

namespace LanguageFeatures5
{
    public partial class Class1
    {
        public int k;
    }
}


//partial methods
namespace PartialMethods
{
    public class MainClass
    {
        public static void Main1()
        {
            Class1 o = new Class1();

            Console.WriteLine(o.Check());

            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.

    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            //.....
            Validate();
            return isValid;
        }
    }

    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

}

namespace ExtensonMethods
{
    public class MainClass
    {
        public static void Main1()
        {
            string s = "abc";
            s.Display();
            Class1.Display(s);
            s.Show();

            int i = 100;
            Console.WriteLine(i.AddOne());
            Class1.AddOne(i);
            i.Show();

            int j;
            j = i.Add(10);
            j = Class1.Add(i, 10);

            Console.WriteLine(j);


            Console.ReadLine();
        }

        public static void Main()
        {
            ClsMaths obj = new ClsMaths();
            //obj.Subtract

        }
    }

    //create a static class
    //create a static method
    public static class Class1
    {
        //first parameter of extension method needs to be the type for which
        //you are wrting the extension method, preceded by the 'this' keyword
        public static void Display(this string s)
        {
            Console.WriteLine(s);
        }

        public static int AddOne(this int i)
        {
            return i + 1;
        }
        public static int Add(this int i, int x)
        {
            return i + x;
        }

        //extension method for a base class is also available for derived class
        public static void Show(this object s)
        {
            Console.WriteLine(s);
        }

        //if you define an extension method for an interface, 
        // it is also available to all classes that implement that interface
        public static int Subtract(this IMathOperations i, int a, int b)
        {
            return a - b;
        }

    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }

    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }


}
