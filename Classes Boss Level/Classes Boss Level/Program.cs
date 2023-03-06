using System;
using System.Collections.Generic;

namespace Classes_Boss_Level
{
    internal class Program
    {
        static Random random = new Random();

        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
        }

        static void ConnectLocations(Location a, Location b) 
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        static void Main(string[] args)
        {
            //Variables
            var locations = new List<Location>();
            var currentLocation = new Location();

            //Places
            var winterfell = new Location();
            winterfell.Name = "Winterfell";
            winterfell.Description = "the capital of the Kingdom of the North.";
            locations.Add(winterfell);

            var pyke = new Location();
            pyke.Name = "Pyke";
            pyke.Description = "the stronghold and seat of House Greyjoy.";
            locations.Add(pyke);

            var riverrun = new Location();
            riverrun.Name = "Riverrun";
            riverrun.Description = "a large castle located in the central-western part of the Riverlands.";
            locations.Add(riverrun);

            var the_trident = new Location();
            the_trident.Name = "The Trident";
            the_trident.Description = "one of the largest and most well-known rivers on the continent of Westeros.";
            locations.Add(the_trident);

            var kings_landing = new Location();
            kings_landing.Name = "King's Landing";
            kings_landing.Description = "the capital, and largest city, of the Seven Kingdoms.";
            locations.Add(kings_landing);

            var highgarden = new Location();
            highgarden.Name = "Highgarden";
            highgarden.Description = "the seat of House Tyrell and the regional capital of the Reach.";
            locations.Add(highgarden);

            //Connecting Places
            ConnectLocations(winterfell, pyke);
            ConnectLocations(winterfell, the_trident);
            ConnectLocations(pyke, riverrun);
            ConnectLocations(pyke, highgarden);
            ConnectLocations(highgarden, riverrun);
            ConnectLocations(highgarden, kings_landing);
            ConnectLocations(kings_landing, riverrun);
            ConnectLocations(kings_landing, the_trident);
            ConnectLocations(the_trident, riverrun);

            //Starting Area
            currentLocation = locations[0];
            Console.WriteLine($"Welcome traveler, you are in {currentLocation.Name}, {currentLocation.Description}");

            //Moving on
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Where would you like to travel next? (enter number)");
                for (int i = 0; i < currentLocation.Neighbors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentLocation.Neighbors[i].Name}");
                }
                Console.WriteLine();

                //Go There
                string travel = Console.ReadLine();
                int travelTo = Convert.ToInt32(travel);
                currentLocation = currentLocation.Neighbors[travelTo - 1];

                //Say Where
                Console.WriteLine();
                Console.WriteLine($"Welcome to {currentLocation.Name}, {currentLocation.Description}");
            }
        }
    }
}
