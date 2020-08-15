using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskRunDemo
{
    class TaskRunDemo
    {
        public static async Task Main()
        {
           var result = await Task.Run(() => ReadFile("c:\\temp\\samplefile.txt"));
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static string ReadFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            return fileContent;
        }
    }
}
