using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{
    public class _07Task_T
    {
        public void DoTest()
        {
            // Task<T> : can have return value
            // Asynchronous Delegate with return value
            Task<int> task = Task.Factory.StartNew<int>(() => CalcSize("Hello World"));

            // main thread : other job execution
            Thread.Sleep(3000);

            // wait
            int result = task.Result;

            Console.WriteLine("Result={0}", result);

            Console.ReadLine();
        }

        int CalcSize(string data)
        {
            string s = data == null ? "" : data.ToString();
            // assume complex calculation
            return s.Length;
        }
    }
}
