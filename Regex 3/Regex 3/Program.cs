using System;
using System.Collections.Generic;
using System.IO;

namespace Regex
{
    public class Monster
    {
        public string name;
        public bool roll;
    }
    internal class Program
    {
        static List<Monster> monsters = new List<Monster>();
        static void Main(string[] args)
        {
            string[] regex = File.ReadAllLines("Regex.txt");
            Monster monster = new Monster();
            monster.name = regex[0];
            monsters.Add(monster);

            string rollPattern = @"Hit Points: .*\d{2}d";

            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == "")
                {
                    monster = new Monster();
                    monster.name = regex[i + 1];
                    monsters.Add(monster);
                    monster.roll = false;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(regex[i], rollPattern))
                {
                    monster.roll = true;
                }
            }

            foreach (Monster creature in monsters)
            {
                Console.WriteLine($"{creature.name} - 10+ dice: {creature.roll}");
            }
        }
    }
}
