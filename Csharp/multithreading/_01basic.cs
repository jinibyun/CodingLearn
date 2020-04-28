using System;
using System.Threading;

namespace multithreading
{
    public class _01basic
    {
        // NOTE:
        // parameter can be either 
        // "ThreadStart" delegate or "ParameterizedThreadStart" delegate
        // The below shows "ThreadStart" delegate
        public void DoTest()
        {
            // 1. create new thread
            Thread t1 = new Thread(new ThreadStart(Run));
            // start new thread. As soon as it started, it will execute delegate
            t1.Start();

            // 2.
            Thread t2 = new Thread(Run); // compiler infer to this method
            t2.Start();

            // 3. anonymous method
            Thread t3 = new Thread(delegate()
            {
                Run();
            });
            t3.Start();

            // 4. Lambda
            Thread t4 = new Thread(() => Run());
            t4.Start();

            // it is called from "Main Thread"
            Run();
        }

        // output
        // Thread#1: Begin
        // Thread#3: Begin
        // Thread#1: End
        // Thread#3: End
        void Run()
        {
            Console.WriteLine("Thread#{0}: Begin", Thread.CurrentThread.ManagedThreadId);
            
            // Do Something
            Thread.Sleep(3000);

            Console.WriteLine("Thread#{0}: End", Thread.CurrentThread.ManagedThreadId);
        }
    }
}