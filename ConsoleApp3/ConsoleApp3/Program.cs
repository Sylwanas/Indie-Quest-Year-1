using System;
using System.Threading;
using System.Xml.Schema;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int roll = 0;
            int total = 0;
            do
            {
                roll = random.Next(1,7);
                total += roll;
                Console.WriteLine($"The player rolls: {roll}");
            } 
            while (roll < 6);
            Console.WriteLine($"Total score: {total}");
        }
    }
}
