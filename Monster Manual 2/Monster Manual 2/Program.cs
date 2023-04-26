using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_Manual_1
{
    internal class Program
    {
        public enum ArmorTypeId
        {
            Unspecified,
            NaturalArmor,
            LeatherArmor,
            StuddedLeather,
            HideArmor,
            ChainShirt,
            ChainMail,
            ScaleMail,
            Plate,
            Other
        }

        public class Monster
        {
            public string name;
            public string description;
            public string alignment;
            public string rollHP;
            public string armor;
            public ArmorTypeId armorTypeId;
        }

        static void Main(string[] args)
        {
            string monsterManual = File.ReadAllText("MonsterManual.txt");

            string[] armorTypeNames = Enum.GetNames<ArmorTypeId>();
            ArmorTypeId[] armorTypeIds = Enum.GetValues<ArmorTypeId>();

            List<Monster> monsters = new List<Monster>();

            MatchCollection matches = Regex.Matches(monsterManual,
                @"(.*)\n" + //Name
                @"(.*), (.*)\n" + //Desc + Alignment
                @"Hit Points: \d*(?: \((.*)\))? ?\n" + //HP
                @"Armor Class: (\d*) \((.*)\)" //Armor + Type
                );

            foreach (Match match in matches)
            {
                string armorType = match.Groups[6].Value;
                string[] armorTypeSplits = armorType.Split(' ');
                armorTypeNames = Enum.GetNames<ArmorTypeId>();
                ArmorTypeId[] armorTypes = Enum.GetValues<ArmorTypeId>();
                ArmorTypeId tempArmorType = ArmorTypeId.Other;
                string armorSearch = armorTypeSplits.Length > 1 ? armorTypeSplits[0] + armorTypeSplits[1] : armorTypeSplits[0];

                for (int i = 0; i < armorTypeNames.Length; i++)
                {
                    if (armorTypeNames[i].Contains(armorSearch))
                    {
                        tempArmorType = armorTypes[i];
                    }
                }

                Monster monster = new Monster
                {
                    name = match.Groups[1].Value,
                    description = match.Groups[2].Value,
                    alignment = match.Groups[3].Value,
                    rollHP = match.Groups[4].Value,
                    armor = match.Groups[5].Value,

                };
                monster.armorTypeId = tempArmorType;
                monsters.Add(monster);
            }

            Console.WriteLine("Welcome user, what would you like to be informed about?\n");
            List<Monster> severalMonsters = new List<Monster>();
            Monster lookUpMonster = new Monster();
            bool foundMonster = false;
            bool searching = true;
            do
            {
                Console.WriteLine("Please enter either a (n)ame or (a)rmor.");
                string chooseType = Console.ReadLine();

                while (chooseType != "n" || chooseType != "a")
                {
                    if (chooseType == "n")
                    {
                        Console.WriteLine("Please enter the name of the monster you wish to be informed about.");
                    }
                    else if (chooseType == "a")
                    {
                        Console.WriteLine("Please enter the number of the armor type you wish to be informed about.?");
                    }
                    if (chooseType != null)
                    {
                        break;
                    }
                }

                if (chooseType == "n")
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
                            Console.WriteLine($"Armor Class: {creature.armor}");
                            Console.WriteLine($"Armor Type: {creature.armorTypeId}");
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
                        Console.WriteLine($"Armor Class: {severalMonsters[number - 1].armor}");
                        Console.WriteLine($"Armor Type: {severalMonsters[number - 1].armorTypeId}");
                    }

                    severalMonsters.Clear();

                    if (!foundMonster)
                    {
                        Console.WriteLine($"I could not any results containing {monsterSearch}. please try again.");
                    }
                    foundMonster = false;

                    Console.WriteLine();
                }

                while (chooseType == "a")
                {
                    int count = 1;
                    foreach (string showArmor in Enum.GetNames(typeof(ArmorTypeId)))
                    {
                        Console.WriteLine($"{count}. {showArmor}");
                        count++;
                    }

                    string pickArmor = Console.ReadLine();
                    int pickedArmor = Convert.ToInt32(pickArmor);

                    foreach (Monster monster in monsters)
                    {
                        ArmorTypeId armorResult = (ArmorTypeId)pickedArmor - 1;

                        if (monster.armorTypeId == armorResult)
                        {
                            severalMonsters.Add(monster);
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
                            Console.WriteLine($"Armor Class: {creature.armor}");
                            Console.WriteLine($"Armor Type: {creature.armorTypeId}");
                        }
                    }

                    if (severalMonsters.Count > 1)
                    {
                        Console.WriteLine($"I found several results. Which one would you like to know more about?");
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
                        Console.WriteLine($"Armor Class: {severalMonsters[number - 1].armor}");
                        Console.WriteLine($"Armor Type: {severalMonsters[number - 1].armorTypeId}");
                    }
                    severalMonsters.Clear();
                    chooseType = null;
                    Console.WriteLine();
                }

            } while (searching == true);
        }
    }
}
