using System;
using System.Threading;

namespace Learning_Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
              {
                  DemoThread("thread 1:");
              });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                DemoThread("thread 2:");
            });
            t2.Start();
            Console.WriteLine("Hello World!");
        }

        public static void DemoThread(string someText)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                Console.WriteLine($"{someText}--{i}");
            }
        }
    }
}
