using System;
using System.Collections.Generic;
using System.IO;

namespace task2
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int read;
            var fs = new FileStream("C:/Users/Leonid/RiderProjects/INFSEC/task2/test.docx", FileMode.Open);
            while (fs.Position < fs.Length)
            {
                read = fs.ReadByte();

                if (dict.TryGetValue(read, out _))
                {
                    dict[read]++;
                }
                else
                {
                    dict.Add(read, 1);
                }
            }
           
            var sum = 0;
            double relSum = 0;
            foreach (var keypair in dict)
            {
                sum += keypair.Value;
                
            }
            
            foreach (var keypair in dict)
            {
                Console.WriteLine("Byte: {0}\tFrequency: {1}\tRelative frequency: {2}", keypair.Key, keypair.Value, (float) keypair.Value / sum);
                relSum += (double)keypair.Value / sum;
            }
            Console.WriteLine("sum: " + sum + ". relative frequency sum: " + relSum ); 
        }
    }
}