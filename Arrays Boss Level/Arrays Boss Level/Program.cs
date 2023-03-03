using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Arrays_Boss_Level
{
    internal class Program
    {
        static Random random = new Random();

        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
            //Variables
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            //Right
            if (direction == 0) 
            { 
                for (int x = startX; x < width; x++) 
                {
                    roads[x, startY] = true;
                }
            }

            //Down
            if (direction == 1)
            {
                for (int y = startY; y < height; y++)
                {
                    roads[startX, y] = true;
                }
            }

            //Left
            if (direction == 2)
            {
                for (int x = startX; x >= 0; x--) 
                {
                    roads[x, startY] = true;
                }
            }

            //Up
            if (direction == 3)
            {
                for (int y = startY; y >= 0; y--)
                {
                    roads[startX, y] = true;
                }   
            }
        }
        static void GenerateIntersection(bool[,] roads, int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                int newIntersection = random.Next(0,11);

                if (newIntersection > 6)
                {
                    GenerateRoad(roads, x, y, random.Next(4));
                }
            }
        }

        static void Main(string[] args)
        {
            //Variables
            bool[,] map = new bool[40, 20];
            int width = map.GetLength(0);
            int height = map.GetLength(1);

            //Road Generation
            for (int i = 0; i < 4; i++)
            {
                GenerateIntersection(map, random.Next(width), random.Next(height));
                /*GenerateRoad(map, random.Next(width - 1), random.Next(height - 1), random.Next(4));*/
            }

            //Map Generation
            for (int y = 0; y < height; y++) 
            { 
                for (int x = 0; x < width; x++) 
                {
                    Console.Write(map[x, y] ? "#" : ".");
                }
                Console.WriteLine();
            }

        }
    }
}
