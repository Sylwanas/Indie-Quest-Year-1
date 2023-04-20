using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_Manual_1
{
    internal class Program
    {
        public class Monster
        {
            public string name;
            public string description;
            public string alignment;
            public int baseHP;
            public string rollHP;
        }

        static void Main(string[] args)
        {
            string monsterManual = File.ReadAllText("MonsterManual.txt");

            List<Monster> monsters = new List<Monster>();

            MatchCollection matches = Regex.Matches(monsterManual,
                @"(.*)\n" + //Name
                @"(.*), (.*)\n" + //Desc + Alignment
                @"Hit Points: (\d*)(?: \((.*)\))? ?\n" //HP
                );

            foreach (Match match in matches)
            {
                Monster monster = new Monster
                {
                    name = match.Groups[1].Value,
                    description = match.Groups[2].Value,
                    alignment = match.Groups[3].Value,
                    baseHP = Convert.ToInt32(match.Groups[4].Value),
                    rollHP = match.Groups[5].Value,
                };
                monsters.Add(monster);
            }

            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\n-------------------------------------------------------------------------------\n");
                Console.WriteLine($"Name: {monster.name}");
                Console.WriteLine($"Description: {monster.description}");
                Console.WriteLine($"Aligment: {monster.alignment}");
                Console.WriteLine($"Rolled HP: {monster.rollHP}");
            }
        }
    }
}


