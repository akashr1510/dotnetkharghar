using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1 obj = new Class1();
            Class1 obj = new Class1(5, 2000);
            obj[2000] = 10;
            Console.WriteLine(obj[2000]);
            Console.ReadLine();
        }
    }

    public class Class1
    {
        int[] arr;
        int offset;
        public Class1(int size, int offset)
        {
            arr = new int[size];
            this.offset = offset;
        }
        //public int this[int index]
        //{
        //    //cw( obj[0] )
        //    get
        //    {
        //        return arr[index];
        //    }
        //    //obj[1] = 10;
        //    set
        //    {
        //        arr[index] = value;
        //    }
        //}

        public int this[int i]
        {
            get
            {
                return arr[i - offset];
            }
            //obj[2000] = 10;
            set
            {
                arr[i - offset] = value;
            }
        }
    }
}
