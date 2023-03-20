using System;
using System.Collections.Generic;
using System.IO;

namespace Regex
{
    public class Monster
    {
        public string name;
        public bool fly;
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

            string speedPattern = @"fly [1-4]\d";

            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == "")
                {
                    monster = new Monster();
                    monster.name = regex[i + 1];
                    monsters.Add(monster);
                    monster.fly = false;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(regex[i], speedPattern))
                {
                    monster.fly = true;
                }
            }

            foreach (Monster creature in monsters)
            {
                if (creature.fly == true)
                {
                    Console.WriteLine($"{creature.name} - 10-49 flying speed: {creature.fly}");
                }
            }
        }
    }
}
