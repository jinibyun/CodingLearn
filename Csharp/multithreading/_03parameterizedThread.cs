using System;
using System.Threading;

namespace multithreading
{
    public class _03parameterizedThread
    {
        public void DoTest()
        {
            // ThreadStart: no parameter
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            // ParameterizedThreadStart: parameter
            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(10.00);
            
            // ThreadStart: by using this way, we can still pass parameter
            Thread t3 = new Thread(() => Sum(10, 20, 30));
            t3.Start();
        }

        void Run()
        {
            Console.WriteLine("Run");
        }

        void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0},area={1}", r, area);
        }

        void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            Console.WriteLine(sum);
        }
    }
}