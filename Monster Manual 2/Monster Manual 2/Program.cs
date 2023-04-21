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

            Console.WriteLine("Welcome user, what monster would you like to be informed about?");
            List<Monster> severalMonsters = new List<Monster>();
            Monster lookUpMonster = new Monster();
            bool foundMonster = false;
            bool searching = true;
            do
            {
                string monsterSearch = Console.ReadLine();

                foreach (Monster monster in monsters)
                {
                    if (monster.name.ToLower().Contains(monsterSearch.ToLower()))
                    {
                        lookUpMonster = monster;
                        severalMonsters.Add(monster);
                        foundMonster = true;
                    }
                }

                if (severalMonsters.Count == 1)
                {
                    foreach (Monster creature in severalMonsters)
                    {
                        Console.WriteLine($"Name: {creature.name}");
                        Console.WriteLine($"Description: {creature.description}");
                        Console.WriteLine($"Aligment: {creature.alignment}");
                        Console.WriteLine($"Rolled HP: {creature.rollHP}");
                    }
                }

                if (severalMonsters.Count > 1)
                {
                    Console.WriteLine($"I found several results containing {monsterSearch}. Which one would you like to know more about?");
                    for (int i = 0; i < severalMonsters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {severalMonsters[i].name}");
                    }
                    string numberSearch = Console.ReadLine();
                    int number = Convert.ToInt32(numberSearch);
                    Console.WriteLine($"Name: {severalMonsters[number - 1].name}");
                    Console.WriteLine($"Description: {severalMonsters[number - 1].description}");
                    Console.WriteLine($"Aligment: {severalMonsters[number - 1].alignment}");
                    Console.WriteLine($"Rolled HP: {severalMonsters[number - 1].rollHP}");
                }

                severalMonsters.Clear();

                if (foundMonster == false)
                {
                    Console.WriteLine($"I could not any results containing {monsterSearch}, please try again.");
                }
                foundMonster = false;

            } while (searching == true);
        }
    }
}
/*
 *                     if (monster.name.ToLower().Contains(monsterSearch.ToLower()))
                    {
                        lookUpMonster = monster;
                        severalMonsters.Add(monster);

                        if (severalMonsters.Count > 1)
                        {
                            Console.WriteLine("There are several results user, which one would you like to know more about?");
                            foreach (Monster creature in severalMonsters)
                            {
                                Console.WriteLine($"{creature.name}");
                            }
                            string monsterNumber = Console.ReadLine();
                            int result = Convert.ToInt32(monsterNumber);
                            Console.WriteLine($"Name: {monster.name[result - 1]}");
                            Console.WriteLine($"Description: {monster.description[result - 1]}");
                            Console.WriteLine($"Aligment: {monster.alignment[result - 1]}");
                            Console.WriteLine($"Rolled HP: {monster.rollHP[result - 1]}");
                            foundMonster = true;
                            break;
                        }
                    }

*/
