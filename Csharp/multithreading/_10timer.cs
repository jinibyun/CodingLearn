using System;
using System.IO;
using System.Net;
using System.Timers;

namespace multithreading
{
    public class _10timer
    {
        public void DoTest(){
            
            // Timer support "multi" thread : System.Threading.Timer or System.Timers.Timer
            Timer timer = new System.Timers.Timer();
            timer.Interval = 60 * 60 * 1000; // 1 hour
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }    

        // Timer class supports multi-threading. NOTE: Not always same thread is executing event handler. Therefore be mindful "thread-safe"
        // work thread from thread-pool is executing
        // NOTE: with lock statement is "thread-safe" way.: refer to _11threadSafe.cs
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // download html
            WebClient web = new WebClient();
            string webpage = web.DownloadString("http://mssql.tools");

            // save downloaded html to text file
            string time = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string outputFile = string.Format("page_{0}.html", time);            
            File.WriteAllText(outputFile, webpage);            
        }
    }
}