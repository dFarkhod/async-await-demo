using Breakfast;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Coffee cup = PrepareCoffee();
            Console.WriteLine($" qahva tayyor");

            var eggsTask = FryEggsAsync(2);
            var toastTask = MakeToastWithJamAsync(2);
            var breakfastTasks = new List<Task> { eggsTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine($" tuxum tayyor");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine($" non tayyor");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice juice = PourJuice();
            Console.WriteLine($" sharbat tayyor");
            Console.WriteLine($" Nonushta tayyor!");
            sw.Stop();
            Console.WriteLine($" Nonushtaga ketgan vaqt {sw.ElapsedMilliseconds / 1000} soniya"); 
            Console.Read();
        }

        static async Task<Toast> MakeToastWithJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyJam(toast);
            return toast;
        }

        private static Juice PourJuice()
        {
            Console.WriteLine($" Sharbat quyish...");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine($" Nonga murabbo surish...");
        }

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($" Non bo'lagini tosterga solish");
            }
            Console.WriteLine($" Toster ishini boshladi...");
            await Task.Delay(3000);
            Console.WriteLine($" Nonni tosterdan olish");
            return new Toast();
        }

        private static async Task<Egg> FryEggsAsync(int eggsCount)
        {
            Console.WriteLine($" tovani qizdirish...");
            await Task.Delay(3000);
            Console.WriteLine($" tovaga {eggsCount}ta tuxum chaqish");
            Console.WriteLine($" tuxumlarni qovurish...");
            await Task.Delay(3000);
            Console.WriteLine($" tuxumlarni likopchaga solish");
            return new Egg();
        }

        private static Coffee PrepareCoffee()
        {
            Console.WriteLine($" Qahvani tayyorlash...");
            Task.Delay(500).Wait();
            Console.WriteLine($" Qahvani quyish");
            return new Coffee();
        }
    }
}