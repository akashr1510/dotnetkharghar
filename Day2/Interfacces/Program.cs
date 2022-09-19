using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            //method 1 - call method directly 
            obj.Insert();

            //method 2 - call method via interface reference
            //IDbFunctions oIDb = new Class1();
            IDbFunctions oIDb = obj;
            oIDb.Insert();

            //method 3
            ((IDbFunctions)obj).Insert();

            Console.ReadLine();
        }

        static void Main2()
        {
            Class1 o = new Class1();
            o.Insert();
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
}

namespace Interfaces2
{
    class Program
    {
        static void Main2(string[] args)
        {
            Class1 obj = new Class1();
            //obj.Delete();

            IDbFunctions oIDb;
            IFileFunctions oIFile;

            oIDb = obj;
            oIFile = obj;

            oIDb.Delete();
            oIFile.Delete();

            Console.ReadLine();
        }
        static void Main()
        {
            //C1 o = new C1();

            //IFileFunctions oIFile = o;
            //oIFile.Delete();

            //((IFileFunctions)o).Delete();


        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
    public class C1 : IDbFunctions, IFileFunctions
    {
       
        public void Delete()
        {
            //iDbFunctions
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }


        public void Update()
        {
            throw new NotImplementedException();
        }

        void IFileFunctions.Close()
        {
            throw new NotImplementedException();
        }

        void IFileFunctions.Delete()
        {
            throw new NotImplementedException();
        }

        void IFileFunctions.Open()
        {
            throw new NotImplementedException();
        }
    }


    public class Class1 : IDbFunctions, IFileFunctions
    {
        public void Close()
        {
            Console.WriteLine("Class1 - IFile.Close");
        }

        void IDbFunctions.Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Open()
        {
            Console.WriteLine("Class1 - IFile.Open");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }

        //void IFileFunctions.Close()
        //{
        //    Console.WriteLine("Class1 - IFile.Close");
        //}

        void IFileFunctions.Delete()
        {
            Console.WriteLine("Class1 - IFile.Delete");
        }

        //void IFileFunctions.Open()
        //{
        //    Console.WriteLine("Class1 - IFile.Open");
        //}
    }
}
