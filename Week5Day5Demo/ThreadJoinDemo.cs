using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Day5Demo
{
    internal class ThreadJoinDemo
    {
        public static void DemoNoThread()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("DemoNoThread Started...");

            DoWork(1);
            DoWork(2);
            DoWork(3);

            stopWatch.Stop();
            Console.WriteLine($"DemoNoThread Ended. Time elapsed = {stopWatch.ElapsedMilliseconds}");
        }

        public static void DemoThread()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("DemoThread Started...");

            var t1 = new Thread(DoWork);
            var t2 = new Thread(DoWork);
            var t3 = new Thread(DoWork);

            t1.Start(1);
            t2.Start(2);
            t3.Start(3);

            stopWatch.Stop();
            Console.WriteLine($"DemoThread Ended. Time elapsed = {stopWatch.ElapsedMilliseconds}");
        }

        public static void DemoThreadWithJoin()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("DemoThread Started...");

            var t1 = new Thread(DoWork);
            var t2 = new Thread(DoWork);
            var t3 = new Thread(DoWork);

            t1.Start(1);
            t2.Start(2);
            t3.Start(3);

            // if we want to wait for all foreground threads to finish
            // at any other point than the end of main
            // use the Join method
            t1.Join();
            t2.Join();
            t3.Join();

            stopWatch.Stop();
            Console.WriteLine($"DemoThread Ended. Time elapsed = {stopWatch.ElapsedMilliseconds}");

            // The main thread anyway waits for all foreground threads to complete
            // however it wait at the end after it has finished executing all statements in main thread
        }

        private static void DoWork(object param)
        {
            var num = (int)param;
            //Pretend DoWork function is doing some important work
            //for 2 minutes
            Thread.Sleep(2000);
            Console.WriteLine($"DoWork {num}");
        }
    }
}
