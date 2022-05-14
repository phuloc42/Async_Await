using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await
{
    internal class Program
    {
        static void DoSomething(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs}....... start");
                Console.ResetColor();
            }
           
            for (int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs, 10}{i, 2}");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
                
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs}....... end");
                Console.ResetColor();
            }
            
        }
        
        /*static async Task Task2()
        {
            Task t2 = new Task(
                () =>
                {
                    DoSomething(10, "T2", ConsoleColor.Green);
                }
            );//()=>{}
            t2.Start();
            await t2;
            Console.WriteLine("T2 da hoan thanh");
            
        }
        static async Task Task3()
        {
            Task t3 = new Task((object ob) =>
            {
                String tenTacVu = (string)ob;
                DoSomething(4, tenTacVu, ConsoleColor.Yellow);
            }, "T3");
            t3.Start();
            await t3;
            Console.WriteLine("T3 da hoan thanh");
           
        }*/

        //async/await

        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
                () => {
                    DoSomething(10, "T4", ConsoleColor.Yellow);
                    return "Return T4";
                }
                ); //() =>{return string;}
            t4.Start();
            string kq = await t4;
            Console.WriteLine("done T4");
            return kq;
        }
        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>((object ob) =>
            {
                string t = (string)ob;
                DoSomething(4, t, ConsoleColor.Cyan);
                return $"Return from {t}";
            }, "T5");//(object ob) =>{return string;}
            t5.Start();
            string kq = await t5;
            return kq;
        }

        static async Task Main(string[] args)
        {
            //synchronous
            //task
            Task<string> t4 = Task4();
            Task<string> t5 = Task5();
            /*  Task t2 = Task2();
              Task t3 = Task3();*/

           

            DoSomething(6, "T1",ConsoleColor.Magenta);
            // DoSomething(10,"T2", ConsoleColor.Green);
            //DoSomething(4, "T3", ConsoleColor.Yellow);

            //t2.Wait();
            //t3.Wait();
            //Task.WaitAll(t2,t3);
            /*await t2;
            await t3;*/
            await t4;
            await t5;
            var kq4 = await t4;
            var kq5= await t5;
            Console.WriteLine(kq4);
            Console.WriteLine(kq5);
            Console.WriteLine("Hello World!");
        }
    }
}
