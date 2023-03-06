using System;
using System.Collections.Generic;

namespace Dictionaries_Mission_2
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            var countries = new SortedList<string, string>
            {
                { "France", "Paris" },
                { "Japan", "Tokyo" },
                { "Germany", "Berlin" },
                { "Brazil", "Brasilia" },
                { "Russia", "Moscow" }
            };
           
            while (countries.Count > 0)
            {
                int randomCountry = random.Next(countries.Count);
                Console.WriteLine($"What city is the capital {countries.Keys[randomCountry]}?");
                string guess = Console.ReadLine();

                if (guess == countries.Values[randomCountry])
                {
                    Console.WriteLine("That answer is correct.");
                    countries.Remove(countries.Keys[randomCountry]);
                }
                else
                {
                    Console.WriteLine($"Incorrect, {countries.Values[randomCountry]} is the capital of {countries.Keys[randomCountry]}, try again.");
                }
                Console.WriteLine();
            }
            if (countries.Count == 0)
            {
                Console.WriteLine("You answered them all correctly! Congratulations");
            }
            else
            {
                Console.WriteLine("You failed, go open an Atlas nerd");
            }
        }
    }
}
