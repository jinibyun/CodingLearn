using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace multithreading
{
    public class _06Task
    {
        public void DoTest()
        {
            // Task class (from .net 4.0) is the class from getting new thread from threadpool to execut asynchronous process
            // Task : no return
            // Task<T>: return. T is type of return (refer to _07Task_T.cs)


            // Task (immediate start)
            // same concept as ThreadPool's QueueUserWorkItem: This is also immediate start
            Task.Factory.StartNew(new Action<object>(Run), null); //create and execute thread immediately
            Task.Factory.StartNew(new Action<object>(Run), "1st");
            Task.Factory.StartNew(Run, "2nd");
            Task.Factory.StartNew( () => Console.WriteLine("test") );

            // Task (no immediate start)
            // using new Task
            Task t1 = new Task(new Action(Run2));

            // using lambda expression
            Task t2 = new Task(() =>
            {
                Console.WriteLine("Long query");
            });

            // Task thread start
            t1.Start();
            t2.Start();

            // wait for Task to be finished
            t1.Wait();
            t2.Wait();

            Console.ReadLine();
        }

        void Run(object data)
        {
            Console.WriteLine(data == null ? "NULL" : data);

        }

        void Run2()
        {
            Console.WriteLine("Long running method");
        }

    }
}
