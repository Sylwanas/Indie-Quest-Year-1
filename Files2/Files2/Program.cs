using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Files2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shaggy: Hey there friend, what's your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Shaggy: {playerName} huh? That's pretty rad.");
            string[] backers = File.ReadAllLines("Backers.txt");
            if (backers.Contains(playerName)) 
            {
                Console.WriteLine($"Shaggy: Zoinks {playerName}! I forgot you were part of the mystery gang, get in the mystery van so we can like, solve some mysteries!");
            }
            else
            {
                Console.WriteLine($"Shaggy: Well it was cool meeting you {playerName}, but me and the gang gotta scram, see you later dude!");
            }
        }
    }
}
