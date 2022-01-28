using System;
using System.Diagnostics;
using System.Threading;

namespace Week5Day5Demo.ThreadDemos
{
    internal class ThreadPoolDemo
    {
        public static void Demo()
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("Demo using Thread started.");
            stopwatch.Start();

            MethodWithThread();

            stopwatch.Stop();
            Console.WriteLine($"Time consumed by MethodWithThread is : {stopwatch.ElapsedMilliseconds}");


            stopwatch.Reset();
            Console.WriteLine("Demo using Thread Pool");
            stopwatch.Start();
            
            MethodWithThreadPool();
            
            stopwatch.Stop();
            Console.WriteLine($"Time consumed by MethodWithThreadPool is : {stopwatch.ElapsedMilliseconds}");
        }

        private static void MethodWithThread()
        {
            for (var i = 0; i < 100; i++)
            {
                var thread = new Thread(Test);
                thread.Start();
            }
        }

        private static void MethodWithThreadPool()
        {
            for (var i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(Test);
            }
        }

        private static void Test(object param)
        {
            
        }
    }
}
