using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace multithreading
{
    // NOTE: this process is emulating "window form" using console application
    public class _05BackgroundWorkerEvent
    {
        // BackgroundWorker is event-based asynchronous process which is based on thread from threadpool
        private BackgroundWorker worker;

        public void DoTest()
        {
            // BackgroundWorker class's events
            // 1. DoWork : "Worker thread". it cannot access to UI control
            // On cancelling,  call CancelAsync()
            // check with CancellationPending property if it is cancelled or not

            // 2. ProgressChanged: "UI Thread". it can access to UI control
            // 3. RunWorkerCompleted: "UI Thread". it can access to UI control


            // progress and cancellation
            worker = new BackgroundWorker(); // thread from threadpool
            worker.WorkerReportsProgress = true; // progress
            worker.WorkerSupportsCancellation = true; // cancellation is possible

            // event handler
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            // start worker thread 
            worker.RunWorkerAsync();
            Console.ReadLine();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // pretent uploading
            int N = 100;
            for (int i = 1; i <= N; i++)
            {
                // whehter worker is cancelled?
                if (worker.CancellationPending)
                {
                    e.Cancel = true; // cancel
                    return;
                }

                // uploading.....
                string filename = "Data_" + i + ".txt";
                Upload(filename);

                // Progress: i %
                worker.ReportProgress(i, filename);
            }

            e.Result = N;
        }

        void Upload(string fileName)
        {
            Console.WriteLine("Uploading " + fileName);
            
            // pretend: 1 second per 1 file upload
            Thread.Sleep(1000);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // pretent to show UI control
            // textBox1.Text = string.Format("Progress : {0} %", e.ProgressPercentage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Progress : {0} %", e.ProgressPercentage));
            Console.ResetColor();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // pretent to show UI control
            if (e.Cancelled)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                // textBox1.Text = "work is cancelled";
                Console.WriteLine("work is cancelled");
                Console.ResetColor();
            }
            else if (e.Error != null)
            {
                throw e.Error;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // textBox1.Text = string.Format("{0} files updated", e.Result);
                Console.WriteLine(string.Format("{0} files updated", e.Result));
                Console.ResetColor();
            }
        }
    }
}
