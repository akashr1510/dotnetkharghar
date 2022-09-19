using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//call a method asynchronously using objDel.BeginInvoke
namespace AsyncCodeUsingDelegates1
{
    class Program
    {
        static void Main1()
        {
            Action objDel = Display;
            Console.WriteLine("Before");
            objDel.BeginInvoke(null, null);  //Display runs on a separate thread
            Console.WriteLine("After");

            Console.ReadLine();
        }
        static void Display()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display");
        }
    }
}

//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method
namespace AsyncCodeUsingDelegates2
{
    class Program
    {
        static void Main2()
        {
            Action<string> objDel = Display;
            Console.WriteLine("Before");
            objDel.BeginInvoke("abc",null, null);  //Display runs on a separate thread
            Console.WriteLine("After");

            Console.ReadLine();
        }
        static void Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
        }
    }
}

//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
namespace AsyncCodeUsingDelegates3
{
    class Program
    {
        static void Main3()
        {
            Func<string,string> objDel = Display;
            Console.WriteLine("Before");
            //objDel.BeginInvoke("abc", new AsyncCallback(CallBackFunction), null);
            objDel.BeginInvoke("abc", CallBackFunction, null);
            //callbackFunction will be called after Display is over
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");
        }
    }
}


//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
//make objdel global variable and access it from both functions
namespace AsyncCodeUsingDelegates4
{
    class Program
    {
        static Func<string, string> objDel = Display;
        static void Main4()
        {
            Console.WriteLine("Before");
            //objDel.BeginInvoke("abc", new AsyncCallback(CallBackFunction), null);
            IAsyncResult ar = objDel.BeginInvoke("abc", CallBackFunction, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);
        }
    }
}


//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
//use an anonymous method to access objdel declared in the Main function
namespace AsyncCodeUsingDelegates5
{
    class Program
    {
        static void Main5()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("Before");
            //objDel.BeginInvoke("abc", new AsyncCallback(CallBackFunction), null);
            objDel.BeginInvoke("abc", delegate(IAsyncResult ar)
            {
                Console.WriteLine("callback function called");
                string retval = objDel.EndInvoke(ar);
                Console.WriteLine(retval);
            }, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");
        }
    }
}



//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
// pass objdel as the last parameter in BeginInvoke. access it as ar.AsyncState in the callback func.
namespace AsyncCodeUsingDelegates6
{
    class Program
    {
        static void Main6()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("Before");
            //objDel.BeginInvoke("abc", CallBackFunction, "passed value");
            objDel.BeginInvoke("abc", CallBackFunction, objDel);


            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");

            //string passedvalue = ar.AsyncState.ToString();
            //Console.WriteLine(passedvalue);

            Func<string, string> objDel =(Func<string, string>)ar.AsyncState;
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);
        }
    }
}


//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
// use AsyncResult class to get objdel
namespace AsyncCodeUsingDelegates7
{
    class Program
    {
        static void Main7()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("Before");
            objDel.BeginInvoke("abc", CallBackFunction, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");
            AsyncResult objar = (AsyncResult)ar;

            Func<string, string> objDel = (Func<string, string>)objar.AsyncDelegate;
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);


        }
    }
}



//call a method asynchronously using objDel.BeginInvoke and pass a parameter to the method and use a callback function
// properties/ methods of AsyncResult class
namespace AsyncCodeUsingDelegates8
{
    class Program
    {
        static void Main8()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("Before");
            
            IAsyncResult ar =  objDel.BeginInvoke("abc", CallBackFunction, null);
            AsyncResult objar = (AsyncResult)ar;
            


            Console.WriteLine("After");

            //while (!objar.IsCompleted) ;

            objar.AsyncWaitHandle.WaitOne();


            //Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(10000);
            Console.WriteLine("Display " + s);
            return s.ToUpper();
        }
        static void CallBackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback function called");
            AsyncResult objar = (AsyncResult)ar;

            Func<string, string> objDel = (Func<string, string>)objar.AsyncDelegate;
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);


        }
    }
}



