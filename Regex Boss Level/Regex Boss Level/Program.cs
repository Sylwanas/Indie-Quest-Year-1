using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Regex_Boss_Level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gameList = new[] { "https://store.steampowered.com/app/1811260/EA_SPORTS_FIFA_23/", "https://store.steampowered.com/app/1588610/Beers_and_Boomerangs/", "https://store.steampowered.com/app/2206340/Aokana__Four_Rhythms_Across_the_Blue__EXTRA2/", "https://store.steampowered.com/app/1173340/War_Trains/", "https://store.steampowered.com/app/1517290/Battlefield_2042/", "https://store.steampowered.com/app/1416420/Expansion__Europa_Universalis_IV_Leviathan/" };

            for (int i = 0; i < gameList.Length; i++)
            {
                var httpClient = new HttpClient();
                string htmlCode = httpClient.GetStringAsync($"{gameList[i]}").Result;

                string findName = @"<title>(.*)\son\sSteam</title>";
                string findRecent = @"<.*summary(?:positive|mixed)?.*?>(.*(Positive|Mixed|Negative))<";
                string findOverall = @"<.*data-tooltip-html(?:positive|mixed)?.*?>(.*(Positive|Mixed|Negative))<";

                Match matchName = Regex.Match(htmlCode, findName);
                Match matchRecent = Regex.Match(htmlCode, findRecent);
                Match matchOverall = Regex.Match(htmlCode, findOverall);

                Console.WriteLine($"The reviews for {matchName.Groups[1].Value} are:");
                Console.WriteLine($"Recent: {matchRecent.Groups[1].Value}");
                Console.WriteLine($"Overall: {matchOverall.Groups[1].Value}");
                Console.WriteLine();
            }
        }
    }
}
