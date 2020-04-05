using System;
using System.Threading;

namespace multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            // no parameter method : _01basic and _02otherClass
            // var obj = new _01basic();
            // var obj = new _02otherClass();

            // parameter: ParameterizedThreadStart
            // var obj = new _03parameterizedThread();

            // threadPool
            // var obj = new _04threadPool();

            // BackgroundWorker: Emulating windows application using console application
            // var obj = new _05BackgroundWorkerEvent();

            // Task
            // var obj = new _06Task();

            // Task<T>
            // var obj = new _07Task_T();

            // parallel (data parallel)
            // var obj = new _08parallel();

            // Async and Await
            // var obj = new _09AwaitAyanc();

            // timer
            // var obj = new _10timer();

            // thread safe
            var obj = new _11threadSafe();

            // var obj = new _09threadSafe();

            obj.DoTest();


            // NOTE: other than lock (thread safe), Monitor, Mutex, Semaphone, AutoResetEvent, CountDownEvetn are just skipped
        }
    }
}
