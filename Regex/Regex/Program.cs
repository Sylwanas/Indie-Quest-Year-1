using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_3____1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] regexArray = File.ReadAllLines("Regex.txt");

            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();

            for (int axis1 = 0; axis1 < 3; axis1++)
            {
                for (int axis2 = 0; axis2 < 3; axis2++)
                {
                    namesByAlignment[axis1, axis2] = new List<string>();
                }
            }

            string[] axis1Values = new[] { "chaotic", "neutral", "lawful" };
            string[] axis2Values = new[] { "evil", "neutral", "good" };

            for (int i = 0; i < regexArray.Length; i++)
            {
                Match match = Regex.Match(regexArray[i], @"((chaotic|neutral|lawful) (evil|neutral|good)|neutral)");
                if (match.Success)
                {
                    string monsterName = regexArray[i - 1];

                    if (match.Groups[1].Value == "neutral")
                    {
                        namesByAlignment[1, 1].Add(monsterName);
                    }
                    else
                    {
                        string axis1Text = match.Groups[2].Value;
                        string axis2Text = match.Groups[3].Value;
                        int axis1 = Array.IndexOf(axis1Values, axis1Text);
                        int axis2 = Array.IndexOf(axis2Values, axis2Text);
                        namesByAlignment[axis1, axis2].Add(monsterName);
                    }
                }
                else if (Regex.IsMatch(regexArray[i], @"unaligned"))
                {
                    namesOfUnaligned.Add(regexArray[i - 1]);
                }
                else if (Regex.IsMatch(regexArray[i], @"any alignment"))
                {
                    namesOfAnyAlignment.Add(regexArray[i - 1]);
                }
                else if (Regex.IsMatch(regexArray[i], @"any.*alignment"))
                {
                    namesOfSpecialCases.Add(regexArray[i - 1] + regexArray[i].Substring(regexArray[i].IndexOf(",")));
                }
            }

            for (int axis1 = 0; axis1 < 3; axis1++)
            {
                for (int axis2 = 0; axis2 < 3; axis2++)
                {
                    string aligmentName = $"{axis1Values[axis1]} {axis2Values[axis2]}";

                    if (aligmentName == "neutral neutral")
                    {
                        aligmentName = "true neutral";
                    }
                    Console.WriteLine($"{aligmentName} monsters:");
                    foreach (string name in namesByAlignment[axis1, axis2])
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Unaligned monsters:");
            foreach (string name in namesOfUnaligned)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Any aligned monsters:");
            foreach (string name in namesOfAnyAlignment)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Special aligned monsters:");
            foreach (string name in namesOfSpecialCases)
            {
                Console.WriteLine(name);
            }
        }
    }
}