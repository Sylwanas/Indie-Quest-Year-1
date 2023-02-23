using System;
using System.Collections.Generic;

namespace Enums
{
    internal class Program
    {

        enum Suit
        {
            Heart,
            Spade,
            Diamond,
            Club
        }
        enum Rank
        {
            Ace=1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        static void Draw(Suit suit, Rank rank)
        {

            //Variables
            string clan;
            string race;

            //Clan
            if (suit == Suit.Heart)
            {
                clan = "♥";
            }
            else if (suit == Suit.Spade)
            {
                clan = "♠";
            }
            else if (suit == Suit.Diamond) 
            {
                clan = "♦";
            }
            else if (suit == Suit.Club) 
            {
                clan = "♣";
            }
            else
            {
                throw new Exception("Wrong suit dummy");
            }

            //Rank
            if (rank == Rank.Ace)
            {
                race = "A";
            }
            else if (rank == Rank.Jack)
            {
                race = "J";
            }
            else if (rank == Rank.Queen)
            {
                race = "Q";
            }
            else if (rank == Rank.King)
            {
                race = "K";
            }
            else
            {
                race = ((int)rank).ToString();
            }
            Console.WriteLine("╭───────╮");
            Console.WriteLine($"│{race,-2}     │");
            Console.WriteLine($"│   {clan}   │");
            Console.WriteLine($"│     {race,2}│");
            Console.WriteLine("╰───────╯");       
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var suits = new List<Suit>(Enum.GetValues<Suit>());
            foreach (Suit suit in suits) 
            {
                for (int i = 1; i <= 13; i++)
                {
                    Draw(suit, (Rank)i);
                }
            }
        }
    }
}
