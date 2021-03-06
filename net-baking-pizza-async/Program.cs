﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace net_baking_pizza_async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine("開始進行製作披薩...");

            var tasks製作披薩餅皮前 = new List<Task>();
            var tasks烤製披薩前 = new List<Task>();
            var tasks開始食用前 = new List<Task>();

            tasks烤製披薩前.Add(Task.Run(烤箱預熱));

            tasks製作披薩餅皮前.Add(Task.Run(製作麵團).ContinueWith(t => 發麵()));
            tasks製作披薩餅皮前.Add(Task.Run(準備醬料));
            tasks製作披薩餅皮前.Add(Task.Run(準備配料));

            await Task.WhenAll(tasks製作披薩餅皮前);

            tasks烤製披薩前.Add(Task.Run(製作披薩餅皮與塗抹醬料和放置配料));

            await Task.WhenAll(tasks烤製披薩前);

            tasks開始食用前.Add(Task.Run(烤製披薩));
            tasks開始食用前.Add(Task.Run(準備餐具與飲料));

            await Task.WhenAll(tasks開始食用前);

            披薩完成_開始食用();

            watch.Stop();
            Console.WriteLine($"同步設計披薩製作共花費:{watch.ElapsedMilliseconds} 毫秒");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void 烤箱預熱()
        {
            Console.WriteLine($"烤箱預熱中，預計 3 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(3000);
            Console.WriteLine($"烤箱預熱 完成");
        }
        static void 製作麵團()
        {
            Console.WriteLine($"製作麵團中，預計 0.3 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(300);
            Console.WriteLine($"麵團製作 完成");
        }
        static void 發麵()
        {
            Console.WriteLine($"麵團發麵中，預計 0.8 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(800);
            Console.WriteLine($"麵團發麵 完成");
        }
        static void 準備醬料()
        {
            Console.WriteLine($"準備醬料中，預計 0.2 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(200);
            Console.WriteLine($"準備醬料 完成");
        }
        static void 準備配料()
        {
            Console.WriteLine($"準備配料中，預計 0.2 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(200);
            Console.WriteLine($"準備配料 完成");
        }
        static void 製作披薩餅皮與塗抹醬料和放置配料()
        {
            Console.WriteLine($"製作披薩餅皮與塗抹醬料和放置配料中，預計 0.3 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(300);
            Console.WriteLine($"製作披薩餅皮與塗抹醬料和放置配料 完成");
        }
        static void 烤製披薩()
        {
            Console.WriteLine($"烤製披薩中，預計 0.6 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(600);
            Console.WriteLine($"烤製披薩 完成");
        }
        static void 準備餐具與飲料()
        {
            Console.WriteLine($"準備餐具與飲料中，預計 0.2 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(200);
            Console.WriteLine($"準備餐具與飲料 完成");
        }
        static void 披薩完成_開始食用()
        {
            Console.WriteLine($"披薩完成_開始食用，預計 1 秒鐘 [Thread:{Thread.CurrentThread.ManagedThreadId}]");
            Thread.Sleep(100);
            Console.WriteLine($"披薩完成_開始食用 完成");
        }
    }
}
