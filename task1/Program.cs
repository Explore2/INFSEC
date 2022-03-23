using System;
using System.IO;
using System.Text;
namespace task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fs = new FileStream("C:/Users/Leonid/RiderProjects/INFSEC/task1/test.docx", FileMode.Open);
            Console.WriteLine(fs.Length);
        }
    }
}