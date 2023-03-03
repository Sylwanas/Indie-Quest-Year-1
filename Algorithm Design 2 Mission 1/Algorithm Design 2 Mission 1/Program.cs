using System;
using System.Collections.Generic;

namespace Algorithm_Design_2_Mission_1
{
    internal class Program
    {
        static Random rearrange = new Random();
        static string Shufflelist(List<string> items)
        { 
            for (int i = items.Count - 1; i > 0; i--) 
            {
                int j = rearrange.Next(i + 1);
                object temp = items[i];
                items[i] = items[j];
                items[j] = (string)temp;
            }
            return string.Join(", ", items);
        }
        static void Main(string[] args)
        {
            var names = new List<string> { "Jim", "Jom", "Jum", "Jem", "Jam" };

            Console.Write("Signed-up participants: ");
            Console.WriteLine(string.Join(", " , names));
            Console.WriteLine("Generating starting order. . . ");
            Console.Write("Starting order: ");
            Console.WriteLine(Shufflelist(names));
        }
    }
}
