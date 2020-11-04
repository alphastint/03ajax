using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _03ajax
{

    public class ThreadWork
    {
        static int value = 100;

        private static readonly object Mutex = new object();
        public static void DoWork1()
        {
            lock (Mutex)
            {
                value = 200;
                Thread.Sleep(1000);
                Console.WriteLine($"Thread 1 {value}");
            }
        }

        public static void DoWork2()
        {
            lock (Mutex)
            {
                value = 300;
                Thread.Sleep(1000);
                Console.WriteLine($"Thread 2 {value}");
            }
        }

    }


    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // Thread thread1 = new Thread(ThreadWork.DoWork1);
            // Thread thread2 = new Thread(ThreadWork.DoWork2);
            // thread1.Start();
            // thread2.Start();
            // Console.WriteLine("threads started");

            // thread1.Join();
            // thread2.Join();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
