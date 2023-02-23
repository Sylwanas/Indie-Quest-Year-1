using System;

namespace ConsoleApp1
{
    internal class Program

    {
        static void Main(string[] args)
        {
            var random = new Random();
            int throw1 = random.Next(0, 11);
            if (throw1 == 10)
            {
                Console.WriteLine($"First throw: X Strike! You're on fire!");
            }
            else if (throw1 == 0)
            { 
                Console.WriteLine($"First throw: - Miss! Too bad.");
            }
            else
            {
                Console.WriteLine($"First throw: {throw1}");
            }
            int throwmax1 = 10 - throw1;
            int throw2 = random.Next(0, throwmax1 + 1);
            if (throw1 == 10)
            {
                }
                else if (throw1 + throw2 == 10)
                { 
                Console.WriteLine($"Second throw: / Spare! Nice going.");
                }
                else if (throw2 == 0)
                {
                Console.WriteLine($"Second throw: - Miss! Too bad.");
                }
                else
                {
                Console.WriteLine($"Second throw: {throw2}");
            }
            Console.WriteLine($"Knocked Pins: {throw1 + throw2}");
        }
    }
}
