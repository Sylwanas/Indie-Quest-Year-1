using System;
using System.Numerics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int StartHp = random.Next(1, 101);
            Console.WriteLine($"Warrior HP: {StartHp}");
            Console.WriteLine($"The Regenerate spell is cast!");
            while (StartHp < 50)
            {
                StartHp += 10;
                Console.WriteLine($"Warrior HP: {StartHp}");
            }
            Console.WriteLine($"The Regenerate spell is complete.");
        }
    }
}
