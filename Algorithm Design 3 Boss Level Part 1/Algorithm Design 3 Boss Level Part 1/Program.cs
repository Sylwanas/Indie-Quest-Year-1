using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Algorithm_Design_3_Boss_Level_Part_1
{
    internal class Program
    {
        static Random random = new Random();

        static void Map(int width, int height)
        {
            //Prepare map variables
            int depth = 4;
            char[,,] characters = new char[width, height, depth];
            ConsoleColor[,,] foreGround = new ConsoleColor[width, height, depth];
            ConsoleColor[,,] backGround = new ConsoleColor[width, height, depth];

            //Prepare background COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    backGround[x, y, 3] = ConsoleColor.Green;
                    characters[x, y, 3] = ' ';
                }
            }

            //Prepare trees COMPLETED
            int forestBorder = width / 3;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    backGround[forestBorder, y, 2] = ConsoleColor.DarkGreen;
                    foreGround[forestBorder, y, 2] = ConsoleColor.Green;
                    characters[forestBorder, y, 2] = 'T';

                    int forest = random.Next(1, 11);

                    if (forestBorder > 40) ;
                    forest = random.Next(1, 11);

                    if (forest <= 4 && forestBorder > 0)
                    {
                        forestBorder--;
                    }
                    else if (forest <= 7 && forestBorder < height - 1)
                    {
                        forestBorder++;
                    }
                }
            }

            //Prepare river
            int riverdivide = width / 8;
            int river = width - riverdivide;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    backGround[river, y, 2] = ConsoleColor.Blue;
                    foreGround[river, y, 2] = ConsoleColor.DarkBlue;
                    characters[river, y, 2] = 'Y';
                }
            }

            //Prepare road COMPLETED
            int roadY = height / 2;

            for (int x = 0; x < width; x++)
            {
                backGround[x, roadY, 1] = ConsoleColor.DarkGray;
                foreGround[x, roadY, 1] = ConsoleColor.Gray;
                characters[x, roadY, 1] = '#';

                int roadDirection = random.Next(1, 11);
                if (roadDirection <= 1 && roadY > 0)
                {
                    roadY--;
                }
                else if (roadDirection <= 2 && roadY < height - 1)
                {
                    roadY++;
                }
            }

            //Prepare border COMPLETED
            for (int y = 0; y < height; y++)
            {
                backGround[0, y, 0] = ConsoleColor.DarkYellow;
                foreGround[0, y, 0] = ConsoleColor.Yellow;
                characters[0, y, 0] = '|';

                backGround[width - 1, y, 0] = ConsoleColor.DarkYellow;
                foreGround[width - 1, y, 0] = ConsoleColor.Yellow;
                characters[width - 1, y, 0] = '|';

                for (int x = 0; x < width; x++)
                {
                    backGround[x, 0, 0] = ConsoleColor.DarkYellow;
                    foreGround[x, 0, 0] = ConsoleColor.Yellow;
                    characters[x, 0, 0] = '-';

                    backGround[x, height - 1, 0] = ConsoleColor.DarkYellow;
                    foreGround[x, height - 1, 0] = ConsoleColor.Yellow;
                    characters[x, height - 1, 0] = '-';

                    if (x == 0 || x == width - 1)
                    {
                        characters[x, 0, 0] = '+';
                    }
                    if (y == height -1)
                    {
                        characters[0, y, 0] = '+';
                    }
                    if (x == width -1 && y == height -1)
                    {
                        characters[x, y, 0] = '+';
                    }
                }
            }

            //Drawing map to console
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        Console.BackgroundColor = backGround[x, y, z];
                        Console.ForegroundColor = foreGround[x, y, z];
                        Console.Write(characters[x, y, z]);
                        if (characters[x, y, z] != '\0')
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {           
            Map(60, 30);
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}