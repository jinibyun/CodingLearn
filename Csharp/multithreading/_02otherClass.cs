using System;
using System.Threading;

namespace multithreading
{
    public class _02otherClass
    {
        public void DoTest()
        {
            Helper obj = new Helper();
            Thread t = new Thread(obj.Run);
            t.Start();

            // from main thread
            obj.Run();
        }
    }

    public class Helper
    {
        public void Run()
        {            
            Console.WriteLine("Thread#{0}: End", Thread.CurrentThread.ManagedThreadId);
        }
    }
}