using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            //arr[0] .... arr[4]
            //int j = 10;
            for (int i = 0; i < arr.Length; i++)
            {
                //Console.WriteLine("Enter for index {0} :j = {1} ", i, j);
                Console.WriteLine("Enter for index {0} : ", i);
                arr[i] = int.Parse(Console.ReadLine());
                //arr[i] = Convert.ToInt32 (Console.ReadLine());
            }
            int j = 0;
            foreach (int item in arr)
            {
                //Console.WriteLine(item);
                Console.WriteLine("arr[{0}] is {1} ",j++, item);
            }

            //int pos = Array.IndexOf(arr, 30);
            //int pos = Array.LastIndexOf(arr, 30);
            //int pos = Array.BinarySearch(arr, 30);
            //if (pos == -1)
            //{
            //    Console.WriteLine("not found");
            //}

            //Array.Clear()
            //Array.Copy(arr,arr2,arr.Length)
            //Array.ConstrainedCopy()

            //Array.Sort(arr);
            //Array.Reverse(arr);

            Console.ReadLine();

        }
        //Array.Clear(arr, 0, 5); --clears the array (initialises to def value)
        //Array.Copy(arr, arr2, arr.Length); -- copies from 1st array to 2nd array
        //Array.ConstrainedCopy(arr, 0, arr2, 0, arr.Length);  -- copies from 1st to 2nd, but  rolls back all copied elemnts if there was an error            //Array.CreateInstance(typeof(int), 0)
        //int pos = Array.IndexOf(arr, 10); //returns -1 if not found
        //int pos = Array.LastIndexOf(arr, 10); //returns -1 if not found
        //int pos = Array.BinarySearch(arr, 10); //returns -1 if not found
        //Array.Reverse(arr)
        //Array.Sort(arr)

        static void Main2()
        {
            //int[] arr = new int[5];
            int[,] arr = new int[3, 5];
            //arr[0,0] arr[0,1] arr[0,2] arr[0,3] arr[0,4]
            //arr[1,0] arr[1,1] arr[1,2] arr[1,3] arr[1,4]
            //arr[2,0] arr[2,1] arr[2,2] arr[2,3] arr[2,4]


            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.GetLength(0)); //length of 1st dimension of array
            Console.WriteLine(arr.GetLength(1)); //length of 2nd dimension of array

            Console.WriteLine(arr.GetUpperBound(0)); //upper bound of 1st dimension of array
            Console.WriteLine(arr.GetUpperBound(1)); //upper bound of 2nd dimension of array

            Console.WriteLine(arr.Rank); //no of dimensions

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("Enter value for element no " + i + "," + j);
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();

        }

        static void Main3()
        {
            //jagged
            int[][] arr = new int[5][];
            arr[0] = new int[3]; // arr[0][0]- arr[0][2]
            arr[1] = new int[4];
            arr[2] = new int[2];//  arr[2][0] - arr [2] [1]
            arr[3] = new int[3];
            arr[4] = new int[4];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }

        static void Main()
        {
            int[] arr = new int[3];

            Employee[] objEmps = new Employee[3];

            for (int i = 0; i < objEmps.Length; i++)
            {
                objEmps[i] = new Employee();
                objEmps[i].EmpNo = Convert.ToInt32(Console.ReadLine());
                objEmps[i].Name = Console.ReadLine();
            }
            foreach (Employee item in objEmps)
            {
                Console.WriteLine(item.EmpNo);
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}
