using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionaries_Boss_Level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, int>()
            {

            };

            while (!players.ContainsValue(5))
            {
                Console.WriteLine("Yeeeeeeeehaw partner! Say, what's yer name fella?\n");
                string playerName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"{playerName} huh? DING DING DING! We gotta winner!\n");

                if (players.ContainsKey(playerName))
                {
                    players[playerName] = players[playerName] + 1;
                }

                if (!players.ContainsKey(playerName))
                {
                    players[playerName] = +1;
                }

                foreach (KeyValuePair<string, int> player in players)
                {
                    Console.WriteLine("Player: {0}, Points: {1}", player.Key, player.Value);
                }

                Console.WriteLine();
            }
            Console.WriteLine($"DING DING DING! That's a wrap ya ding dang rapscallians! We got a neeeeeeew sheriff in town! You better be careful! They're a sharp one.");
        }
    }
}
