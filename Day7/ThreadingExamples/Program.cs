using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExamples
{
    class Program
    {
        static void Main1()
        {
            //Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t1 = new Thread(Func1);
            Thread t2 = new Thread(Func2);

            //t1.IsBackground = true;
            //t2.IsBackground = true;
            //program does not wait for  a background thread to finish executing
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }

            //t1.Abort();
            //t1.Suspend();  //deprecated
            //t1.Resume();//deprecated

            //t1.Suspend(); //deprecated
            //instead of suspend, use this
            //WaitHandle wh = new AutoResetEvent(false);
            //wh.WaitOne();


            //t1.Resume();//deprecated
            // instead of resume, use this
            // ((AutoResetEvent)wh).Set();


            //if ( t1.ThreadState == ThreadState.)

            t1.Join();  //waits for t1 to join ( waits for t1 to get over)
            //this code should run only after t1 is over
            Console.WriteLine("code after t1 is over");

            Console.ReadLine();
        }
        static void Func1()
        {
            //Thread.Sleep(10000);

            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("First : " + i);
            }

        }
        static void Func2()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Second : " + i);
            }

        }
    }
}

namespace ThreadingExamples2
{
    class Program1
    {
        static void Main2()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            //Thread t2 = new Thread(new ParameterizedThreadStart(Func2));
            Thread t2 = new Thread(Func2);
            t1.Start("o1");
            t2.Start("o2");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            Console.ReadLine();
        }

        //TO DO : Pass 2 values to the func.
        //Hint : Create a class/struct that has 2 properties and pass an object of the class
        static void Func1(object o)
        {
            //Employee emp = (Employee) o;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString() + o.ToString());
            }
        }
    }
}

//ThreadPool
namespace ThreadingExamples3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }
        static void Main3()
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            ThreadPool.QueueUserWorkItem(PoolFunc1, "aaa");
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));
            ThreadPool.QueueUserWorkItem(PoolFunc2);


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            int workerthreads, iothreads;

            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);

            //ThreadPool.SetMinThreads
            //ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine();
        }
    }
}

//synchronization
namespace Eg3
{
    class MainClass
    {
        static object lockObject = new object();
        static int i = 0;
        static void Main()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            //Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }
        static void FuncLock()
        {
            lock (lockObject) //Monitor.Enter(lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked()
        {
            Interlocked.Add(ref i, 10);   //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i); //++i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i); //--i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100); //i = 100;
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

    }
}
