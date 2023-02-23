using System;
using System.IO;
using System.Net.Security;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "playername.txt";
            if (File.Exists(playerNamePath))
            {
                string playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Sup {playerName}, didn't think I'd see you again.");
            }
            else
            {
                Console.WriteLine("Hey nerd, what's your name?");
                string playerName = Console.ReadLine();
                Console.WriteLine($"{playerName} huh? Pretty dumb name.");
                File.WriteAllText(playerNamePath, playerName);
            }
        }
    }
}
