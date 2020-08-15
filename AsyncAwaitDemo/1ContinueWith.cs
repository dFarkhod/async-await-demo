using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContinueWithDemo
{
    class ContinueWithDemo
    {
        public static async Task Main()
        {
           await DownloadStringContent("https://jsonplaceholder.typicode.com/todos/7")
                .ContinueWith(downloadTask => WriteContent(downloadTask.Result));
           
            Console.Read();
        }

        static async Task<string> DownloadStringContent(string url)
        {
            Console.WriteLine("Faylni yuklash boshlandi...");
            var client = new HttpClient();
            string content = await client.GetStringAsync(url);
            Console.WriteLine($"Faylni yuklash yakunlandi: {content}");
            return content;
        }

        static async Task WriteContent(string content)
        {
            Console.WriteLine("Faylni saqlash boshlandi...");
            string path = "c:\\temp\\savedfile.txt";
            await File.WriteAllTextAsync(path, content);
            Console.WriteLine($"Faylni saqlash yakunlandi: {path}");

        }
    }
}
