using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{
    // NOTE
    // 1. "Data Parallelism"
    // With Parallel class, using Parallel.For() and Parallel.ForEach() method, multiple threads handle splitted data of big data
    // PLINQ or Parallel class

    // 2. "Task Parallelism"
    // Split big "Task" into small
    // Task, TaskFactory or Parallel.Invoke()


    public class _08parallel
    {
        public void DoTest(){
            // 0.
            testWithoutParallel();
            testWithParallel();

            // 1
            // DataParallel();

            // 2
            // TaskParallel();
        }        

        private void testWithoutParallel()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            foreach (int i in integerList)
            {
                long total = DoSomeIndependentTimeconsumingTask();
                Console.WriteLine("{0} - {1}", i, total);
            };
            stopwatch.Stop();
            Console.WriteLine($"Non-Parallel Execution time: { stopwatch.ElapsedMilliseconds}");
        }

        private void testWithParallel()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            Parallel.ForEach(integerList, i =>
            {
                long total = DoSomeIndependentTimeconsumingTask();
                Console.WriteLine("{0} - {1}", i, total);

                // for showing thread
                Console.WriteLine(@"value of i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
            });
            stopwatch.Stop();
            Console.WriteLine($"Parallel Execution time: { stopwatch.ElapsedMilliseconds}");
        }

        private long DoSomeIndependentTimeconsumingTask()
        {
            //Do Some Time Consuming Task here
            //Most Probably some calculation or DB related activity
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }

        private void DataParallel()
        {
            Console.WriteLine("DataParallel");
            // procedural
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 50000; i++)
            {
                Console.WriteLine("{0}: {1}",
                    Thread.CurrentThread.ManagedThreadId, i);
            }
            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.Read();

            // 1
            // parallel (data parallel)
            // multi thread parallel processing
            //
            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(0, 50000, (i) => {
                Console.WriteLine("{0}: {1}",
                    Thread.CurrentThread.ManagedThreadId, i);
            });
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        private void TaskParallel()
        {
            Console.WriteLine("TaskParallel");
            // Using Parallel.Invoke(), handle multiple jobs in parallel
            // Not like, Task and Task<T>, it creates less threads (grouping threads)
            // eg) 100 action method using Task create 100 threads, but Parallel.Invoke creates less than 100 thread for same case

            // exeucte 5 different jobs in parallel
            Parallel.Invoke(
                () => method1(),
                () => method2(),
                () => method3(),
                () => method4(),
                () => method5()
            );

        }

        private void method1() { }
        private void method2() { }
        private void method3() { }
        private void method4() { }
        private void method5() { }
    }
}