using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int d6roll = 0;
            int d6total = 0;
            int d10roll = 0;
            int d10total = 0;
            int d10roll2 = 0;
            int d10total2 = 0;

            for (int i = 0; i < 3; i++) 
            {
                d6roll = random.Next(1, 7);
                d6total += d6roll;
            }

                Console.WriteLine($"A character with strength {d6total} was created.");

            for (int i = 0; i < 8; i++)
            {
                d10roll= random.Next(1, 11);
                d10total+= d10roll;
            }

                Console.WriteLine($"A gelatinous cube with {d10total + 40} HP appears!");

            for (int i = 0; i < 800; i++)
            {
                d10roll2 = random.Next(1, 11);
                d10total2 += d10roll2;
            }

                Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {d10total2 + 4000} HP. We are doomed!");

        }
    }
}
