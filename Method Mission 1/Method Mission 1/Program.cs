using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Lists_Boss_Level
{
    internal class Program
    {
        //Rolling Method
        static Random random = new Random();
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int roll = 0;
            for (int a = 0; a < numberOfRolls; a++)
            {
                roll += random.Next(1, diceSides + 1);
            }
            roll += fixedBonus;
            return roll;
        }

        //Combat Method
        static void SimulateCombat(List<string> characters, string monsterName, int monsterHP, int savingThrowDC)
        {

            //Flavor
            Console.WriteLine($"A hideous {monsterName} with {monsterHP} HP has appeared!");
            
            //Damage Calculations
            while (monsterHP > 0)
            {
                foreach (var character in characters)
                {
                    int roll2D6 = DiceRoll(2, 6, 0);
                    Console.Write(character);
                    Console.Write($" deals {roll2D6} damage!");
                    monsterHP -= roll2D6;
                    if (monsterHP <= 0)
                    {
                        monsterHP = 0;
                        Console.WriteLine($" The {monsterName} has {monsterHP} HP remaining.");
                        Console.WriteLine("\nTriomphe! The companions continue to Paris! Tous pour un, un pour tous!\n");
                        break;
                    }
                    Console.Write($" The {monsterName} has {monsterHP} HP remaining.");
                    Console.WriteLine();
                }
                //DC Save
                int roll1D20 = DiceRoll(1, 20, 3);
                if (roll1D20 <= savingThrowDC && monsterHP > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20} and is turnt to mush!\n\n");
                    characters.Remove(characters[randomChar]);
                }
                else if (roll1D20 >= savingThrowDC && monsterHP > 0)
                {
                    int randomChar = random.Next(characters.Count);
                    Console.Write(characters[randomChar]);
                    Console.Write($" rolls a {roll1D20} and is not turnt to mush!\n\n");
                }
                //Everyone Dead Check
                if (characters.Count == 0)
                {
                    Console.WriteLine("All of the companions are dead! Merde!");
                    Environment.Exit(0);
                }
            }
        }
        static void Main(string[] args)
        {
            //Variables
            var characters = new List<string> { "Athos", "Porthos", "Aramis", "d'Artagnan" };

            //Flavor
            Console.Write("Companions ");
            Console.Write(string.Join(", ", characters));
            Console.WriteLine(" walk on the road to Paris.");

            //Calling
            SimulateCombat(characters, "orc", DiceRoll(2, 8, 6), 10);
            SimulateCombat(characters, "azer", DiceRoll(6, 8, 12), 18);
            SimulateCombat(characters, "troll", DiceRoll(8, 10, 40), 16);

            //Characters Alive
            if (characters.Count == 1)
            {
                Console.Write("Only ");
                Console.Write(string.Join(" ",characters));
                Console.Write(" has survived.\n");
                Environment.Exit(0);
            }
            if (characters.Count <= 1);
            {
                Console.Write(string.Join(", ", characters));
                Console.Write(" have survived!\n");
                Environment.Exit(0);
            }
        }
    }
}