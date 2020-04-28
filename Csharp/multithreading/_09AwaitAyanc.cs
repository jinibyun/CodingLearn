using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{
    public class _09AwaitAyanc
    {
        public void DoTest()
        {
            RunIt();
        }

        // let compiler to know this method has "await" (c# 5.0)
        private async void RunIt()
        {
            // Call long time consuming process "asynchronously"
            // Task class has "GetAwaiter()" method
            Task<double> task = Task<double>.Factory.StartNew(() => LongCalc(10));

            Console.ReadLine();

            // "wait" for Task to be finished. 
            // but main thread is not blocked            
            // compiler add necessary code automatically not to block main thread
            await task;            

            // After Task is finished, then below's value is updated
            // main thread will execute below
            // textBox1.Text = task.Result.ToString();
            Console.WriteLine(task.Result.ToString());
        }

        double LongCalc(double r)
        {
            // long process....
            Thread.Sleep(3000);
            return 3.14 * r * r;
        }

    }
}
