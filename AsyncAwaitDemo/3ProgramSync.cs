using Breakfast;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Coffee cup = PourCoffee();
            Console.WriteLine("qahva tayyor");

            Egg eggs = FryEggs(2);
            Console.WriteLine("tuxum tayyor");

            Toast toast = ToastBread(2);
            ApplyJam(toast);
            Console.WriteLine("non tayyor");

            Juice juice = PourJuice();
            Console.WriteLine("sharbat tayyor");
            Console.WriteLine("Nonushta tayyor!");

            sw.Stop();
            Console.WriteLine($"Nonushtaga ketgan vaqt {sw.ElapsedMilliseconds / 1000} soniya");
            Console.Read();
        }

        private static Juice PourJuice()
        {
            Console.WriteLine("Sharbat quyish...");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Nonga murabbo surish...");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Non bo'lagini tosterga solish");
            }
            Console.WriteLine("Toster ishini boshladi...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Nonni tosterdan olish");
            return new Toast();
        }

        private static Egg FryEggs(int eggsCount)
        {
            Console.WriteLine("Tovani isitish...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"{eggsCount} ta tuxumni chaqish");
            Console.WriteLine("tuxumlarni qovurish...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Tuxumlarni likopchaga solish");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Qahvani tayyorlash...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Qahvani quyish");
            return new Coffee();
        }
    }
}