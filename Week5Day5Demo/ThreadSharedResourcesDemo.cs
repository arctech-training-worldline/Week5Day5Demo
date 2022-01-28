using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Day5Demo
{
    /// <summary>
    /// Create a class Called NumberManager
    /// Create a method called ProcessNumber which take a int parameter
    /// This class also has two data fields Count and EvenCount
    /// In the ProcessNumber method, increment Count whenever this method is called
    /// Also increment EvenCount if the parameter is an even number
    /// </summary>
    internal class ThreadSharedResourcesDemo
    {
        public static void SimpleNoThreadDemo()
        {
            Console.WriteLine("SimpleNoThreadDemo Started.");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var numberManager = new NumberManager();

            for (var i = 0; i < 500; i++)
            {
                numberManager.ProcessNumber(i);
            }

            stopWatch.Stop();
            Console.WriteLine($"Total Count={numberManager.Count}, EvenCount={numberManager.EvenCount}");
            Console.WriteLine($"SimpleNoThreadDemo Ended. Time Elapsed={stopWatch.ElapsedMilliseconds}");
        }

        public static void SimpleThreadDemo()
        {
            Console.WriteLine("SimpleThreadDemo Started.");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var numberManager = new NumberManager();
            var allThreads = new Thread[500];

            for (var i = 0; i < 500; i++)
            {
                allThreads[i] = new Thread(numberManager.ProcessNumber);
                allThreads[i].Start(i);
                //numberManager.ProcessNumber(i);
            }

            // Wait for all threads to finish
            foreach (var thread in allThreads)
            {
                thread.Join();
            }

            stopWatch.Stop();
            Console.WriteLine($"Total Count={numberManager.Count}, EvenCount={numberManager.EvenCount}");
            Console.WriteLine($"SimpleThreadDemo Ended. Time Elapsed={stopWatch.ElapsedMilliseconds}");
        }
    }

    internal class NumberManager
    {
        private readonly object _objectLock = new();
        private readonly Random _random = new();
        internal int Count { get; set; }
        internal int EvenCount { get; set; }
        internal void ProcessNumber(object param)
        {
            var num = (int) param;
            Thread.Sleep(_random.Next(1, 5));
            
            // Thread Safe
            // Whenever shared resources are being accessed by multiple threads
            // always lock the code block
            lock(_objectLock)
            {
                Count++;

                if (num % 2 == 0)
                    EvenCount++;
            }
        }
    }
}
