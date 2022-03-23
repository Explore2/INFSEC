using System;
using System.IO;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fs = new FileStream("C:/Users/Leonid/RiderProjects/task1/task1/test.docx", FileMode.Open);
            Console.WriteLine(fs.Length);
        }
    }
}