using System;
using System.Threading;

namespace multithreading
{
    public class _11threadSafe
    {
        private int counter = 100;
        private object lockObject = new object();
        public void DoTest()
        {
            // 10 thread execute same method
            for (int i = 0; i < 10; i++)
            {
                new Thread(UnsafeCalc).Start();    
            }
            Console.WriteLine ("------------");
             // 10 thread execute same method
            for (int i = 0; i < 10; i++)
            {
                new Thread(safeCalc).Start();    
            }
        }        

        // unsafe thread method
        private void UnsafeCalc(object obj)
        {
            // all thread trying to change
            counter++;

            // pretend complicated process
            for (int i = 0; i < counter; i++)
                for (int j = 0; j < counter; j++) ;
            
            Console.WriteLine(counter);            
        }

        // safe thread method
        // "thread-safe" = "thread synchronization"
        private void safeCalc(object obj)
        {
            // only one thread execute one method at a time 
            // lock : same as Monitor.Enter() and Monitor.Exit() 
            lock (lockObject)
            {                
                counter++;
                // pretend complicated process
                for (int i = 0; i < counter; i++)
                    for (int j = 0; j < counter; j++) ;

                Console.WriteLine(counter);
            }
        }
    }
}