using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists_Boss_Level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            var random = new Random();
            int rollD8 = 0;
            int basiliskHp = 0;
            int roll1D4 = 0;
            int roll1D20 = 0;
            var characters = new List<string> { "Athos", "Porthos", "Aramis", "d'Artagnan" };

            Console.Write("Companions ");
            Console.Write(string.Join(", ", characters));
            Console.WriteLine(" walk on the road to Paris.");

            //Basilisk HP
            for (int a = 0; a < 8; a++)
            {
                rollD8 = random.Next(1, 9);
                basiliskHp += rollD8;
            }
            basiliskHp += 16;
            Console.WriteLine($"A basilisk with {basiliskHp} HP appears!");

            //Damage Calculations
            while (basiliskHp > 0)
            {
                foreach (var character in characters)
                {
                    for (int b = 0; b < 2; b++)
                    {
                        roll1D4 = random.Next(1, 5);
                    }
                    Console.Write(character);
                    Console.Write($" deals {roll1D4} damage!");
                    basiliskHp -= roll1D4;
                    if (basiliskHp <= 0)
                    {
                        basiliskHp = 0;
                        Console.WriteLine($" The basilisk has {basiliskHp} HP remaining.");
                        Console.WriteLine("\nTriomphe! The companions continue to Paris! Tous pour un, un pour tous!\n");
                        break;
                    }
                    Console.Write($" The basilisk has {basiliskHp} HP remaining.");
                    Console.WriteLine();
                    roll1D4 = 0;
                }
                //Petrify Save
                roll1D20 = random.Next(1, 21);
                if (roll1D20 <= 8 && basiliskHp > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20 + 3} and is turnt to stone!\n\n");
                    characters.Remove(characters[randomChar]);
                }
                else if (roll1D20 >= 9 && basiliskHp > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20 + 3} and is not turnt to stone!\n\n");
                }
                //Everyone Dead Check
                if (characters.Count == 0)
                {
                    Console.WriteLine("\nAll of the companions are dead! Merde!\n");
                    Environment.Exit(0);
                }
            }
        }
    }
}
