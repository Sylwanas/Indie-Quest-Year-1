using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Dictionaries_Mission_1
{
    internal class Program
    {

        static Random random = new Random();

        static void Main(string[] args)
        {
            var hosts = new Dictionary<int, string>()
            {
                { 1998, "France" },
                { 2002, "Japan" },
                { 2006, "Germany" },
                { 2010, "South Africa" },
                { 2014, "Brazil" },
                { 2018, "Russia"},
                { 2022, "Qatar" }
            };

            while (hosts.Count > 0) 
            {
                int hostYear = hosts.Keys.First();
                int randomYear = hostYear + random.Next(hosts.Count) * 4;
                if (!hosts.ContainsKey(randomYear)) 
                {
                    randomYear = hostYear + random.Next(hosts.Count) * 4;
                    continue;
                }
                Console.WriteLine($"Which country hosted the world cup during {randomYear}?");

                if (hosts[randomYear] == Console.ReadLine())
                {
                    Console.WriteLine("That answer is correct.");
                    hosts.Remove(randomYear);
                }
                else
                {
                    Console.WriteLine($"Incorrect, the {randomYear} world cup was hosted in {hosts[randomYear]}, try again.");
                }
                Console.WriteLine();
            }
            if (hosts.Count == 0)
            {
                Console.WriteLine("You answered them all correctly! Congratulations");
            }
            else 
            {
                Console.WriteLine("You failed, go watch some fussball nerd");
            }
        }
    }
}
