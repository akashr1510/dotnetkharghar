using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1();
            o.Display();
            o.Dispose();  //use this rather than o = null;    
            o.Display();
            Console.ReadLine();
        }

        static void Main2(string[] args)
        {
            using (Class1 o = new Class1())
            {
                o.Display();
                //o.Dispose();  //use this rather than o = null;    
            }
            Console.ReadLine();
        }
        static void Main3(string[] args)
        {
            Class1 o = new Class1();
            o.Display();
            o.Dispose();
            o.Display();
            Console.ReadLine();
        }
    }

    public class Class2
    {

        public void Close()
        {
            Console.WriteLine("Dispose");
        }
    }
    public class Class1 : IDisposable
    {
        public Class1()
        {
            //open file here
            //open db here
        }
        bool isDisposed;
        public void Display()
        {
            CheckForDisposed();
            Console.WriteLine("Display called");
        }

        public void Dispose()
        {
            CheckForDisposed();
            //close file
            //close db conn
            Console.WriteLine("Dispose code called. Write code here instead of Destructor");
            isDisposed = true;
        }
        private void CheckForDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Class1");

        }
    }
}
