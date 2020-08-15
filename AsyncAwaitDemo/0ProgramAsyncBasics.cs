using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class AsyncDemo
    {
        static void Main()
        {
            Task task = new Task(Demo);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void Demo()
        {
            Task<int> readFileTask = ReadFile("c:\\temp\\largefile.txt");
            Console.WriteLine(" Boshqa ish 1 ");
            Console.WriteLine(" Boshqa ish 2 ");
            Console.WriteLine(" Boshqa ish 3 ");
            int length = await readFileTask;
            Console.WriteLine(" Fayldagi matn uzunligi: " + length);
            Console.WriteLine(" Undan keyingi ish 1 ");
            Console.WriteLine(" Undan keyingi ish 2 ");
        }

        static async Task<int> ReadFile(string file)
        {
            int length = 0;
            Console.WriteLine($"Faylni o'qish boshlandi {file}...");
            using (StreamReader reader = new StreamReader(file))
            {
                string s = await reader.ReadToEndAsync();
                length = s.Length;
            }
            Console.WriteLine("Faylni o'qish yakunlandi.");
            return length;
        }
    }
}

