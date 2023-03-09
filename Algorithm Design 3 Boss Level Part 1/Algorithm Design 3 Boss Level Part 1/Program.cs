using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Algorithm_Design_3_Boss_Level_Part_1
{
    internal class Program
    {
        static Random random = new Random();

        static void Map(int width, int height)
        {
            //Prepare map variables COMPLETED
            int depth = 4;
            char[,,] characters = new char[width, height, depth];
            ConsoleColor[,,] foreGround = new ConsoleColor[width, height, depth];
            ConsoleColor[,,] backGround = new ConsoleColor[width, height, depth];

            //Prepare Field COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    backGround[x, y, 2] = ConsoleColor.Green;
                    characters[x, y, 2] = ' ';
                }
            }

            //Prepare Forest COMPLETED
            int forestBorder = width / 8;
            for (int y = 0; y < height; y++)
            {
                int forest = random.Next(1, 11);
                if (forest <= 3 && forestBorder > 0)
                {
                    forestBorder--;
                }
                else if (forest <= 6 && forestBorder < width - forest)
                {
                    forestBorder++;
                }

                for (int i = 0; i < forestBorder; i++)
                {
                    backGround[forestBorder - i, y, 2] = ConsoleColor.DarkGreen;
                    foreGround[forestBorder - i, y, 2] = ConsoleColor.Green;
                    characters[forestBorder - i, y, 2] = 'T';
                }
            }

            //Prepare Trees COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int placeTree = random.Next(1, 11);

                    if (placeTree == 1)
                    {
                        backGround[x, y, 2] = ConsoleColor.DarkGreen;
                        foreGround[x, y, 2] = ConsoleColor.Green;
                        characters[x, y, 2] = 'T';
                    }
                }
            }

            //Prepare River COMPLETED
            int riverDivide = width / 8;
            int river = width - riverDivide * 2;
            int riverDirection;
            int riverWidth = random.Next(3,5);
            int[] riverStore = new int[height];

            for (int y = 0; y < height; y++)
            {
                riverDirection = random.Next(1, 11);
                riverStore[y] = riverDirection;

                char riverChar;

                if (riverDirection <= 2 && river > 0)
                {
                    river--;
                    riverChar = '/';
                }
                else if (riverDirection <= 4 && river < width - riverDivide)
                {
                    river++;
                    riverChar = '\\';
                }
                else
                {
                    riverChar = '|';
                }

                for (int i = 0; i < riverWidth; i++)
                {
                    backGround[river - i, y, 2] = ConsoleColor.Blue;
                    foreGround[river - i, y, 2] = ConsoleColor.Cyan;
                    characters[river - i, y, 2] = riverChar;
                }
            }

            //Prepare Wall COMPLETED
            int wall = width / 4;
            for (int y = 0; y < height; y++)
            {
                int wallDirection = random.Next(1, 21);
                char wallChar;

                if (wallDirection <= 1 && wall > 0)
                {
                    wall--;
                    wallChar = '/';
                }
                else if (wallDirection <= 2 && wall < width)
                {
                    wall++;
                    wallChar = '\\';
                }
                else
                {
                    wallChar = '|';
                }

                for (int i = 0; i < 2; i++)
                {
                    backGround[wall - i, y, 2] = ConsoleColor.Black;
                    foreGround[wall - i, y, 2] = ConsoleColor.Gray;
                    characters[wall - i, y, 2] = wallChar;
                }
            }

            //See River
            bool IsRiver(int x, int y)
            {
                if (x < width && x >= 0)
                {
                    return backGround[x, y, 2] == ConsoleColor.Blue;
                }
                else
                {
                    return false;
                }
            }

            //See Wall
            bool IsWall(int x, int y)
            {
                if (x < width && x >= 0)
                {
                    return backGround[x, y, 2] == ConsoleColor.Black;
                }
                else
                {
                    return false;
                }
            }
            
            //Prepare Road COMPLETED
            int roadY = height / 2;

            int bridgeStartX = 0;
            int bridgeEndX = 0;
            int bridgeY = 0;
            bool onBridge = false;
            bool leftShore = false;


            int wallStartX = 0;
            int wallEndX = 0;
            int wallY = 0;
            bool onWall = false;

            for (int x = 0; x < width; x++)
            {
                backGround[x, roadY, 1] = ConsoleColor.DarkGray;
                foreGround[x, roadY, 1] = ConsoleColor.Gray;
                characters[x, roadY, 1] = '#';

                if (IsRiver(x + riverWidth / 2, roadY) && bridgeStartX == 0) 
                {
                    onBridge = true;
                    bridgeStartX = x;
                    bridgeY = roadY;
                }

                if (IsRiver(x - riverWidth / 2, roadY))
                {
                    leftShore = true;
                }

                if (leftShore == true && !IsRiver(x - riverWidth / 2, roadY))
                {
                    leftShore = false;
                    onBridge= false;
                    bridgeEndX = x;
                }

                if (IsWall(x + 1, roadY))
                {
                    onWall = true;
                    wallStartX = x;
                    wallY = roadY;
                }

                if (IsWall(x - 1, roadY))
                {
                    onWall = false;
                    wallEndX = x;
                }

                if (!onBridge && !onWall)
                {
                    int roadDirectionX = random.Next(1, 11);
                    if (roadDirectionX <= 1 && roadY > 0)
                    {
                        roadY--;
                    }
                    else if (roadDirectionX <= 2 && roadY < height - 1)
                    {
                        roadY++;
                    }
                }
            }

            //See Road 
            bool IsBelowRoad(int x, int y)
            {
                if (y < height && y >= 0)
                {
                    return backGround[x, y, 1] == ConsoleColor.DarkGray;
                }
                else
                {
                    return false;
                }
            }

            //River Road COMPLETED 
            int roadXMinus = width / 3;
            int roadX = width - roadXMinus;
            bool belowRoad = false;

            for (int y = 0; y < height; y++)
            {
                if (IsBelowRoad(roadX, y + 1))
                {
                    belowRoad = false;
                }
                else if (IsBelowRoad(roadX, y - 1))
                {
                    belowRoad = true;
                }

                int roadDirection = riverStore[y];
                if (roadDirection <= 2)
                {
                    roadX--;
                }
                else if (roadDirection <= 4)
                {
                    roadX++;
                }

                if (belowRoad == true)
                {
                    backGround[roadX, y, 1] = ConsoleColor.DarkGray;
                    foreGround[roadX, y, 1] = ConsoleColor.Gray;
                    characters[roadX, y, 1] = '#';
                }                
            }

            //Prepare Bridge COMPLETED
            for (int i = bridgeStartX; i < bridgeEndX; i++)
            {
                backGround[i, bridgeY - 1, 2] = ConsoleColor.Gray;
                foreGround[i, bridgeY - 1, 2] = ConsoleColor.DarkYellow;
                characters[i, bridgeY - 1, 2] = '-';

                backGround[i, bridgeY + 1, 2] = ConsoleColor.Gray;
                foreGround[i, bridgeY + 1, 2] = ConsoleColor.DarkYellow;
                characters[i, bridgeY + 1, 2] = '-';
            }

            //Prepare Turrets NOT DONE 
            backGround[wallStartX, wallY - 1, 2] = ConsoleColor.Black;
            foreGround[wallStartX, wallY - 1, 2] = ConsoleColor.Gray;
            characters[wallStartX, wallY - 1, 2] = '[';

            backGround[wallStartX + 1, wallY - 1, 2] = ConsoleColor.Black;
            foreGround[wallStartX + 1, wallY - 1, 2] = ConsoleColor.Gray;
            characters[wallStartX + 1, wallY - 1, 2] = ']';

            backGround[wallStartX, wallY + 1, 2] = ConsoleColor.Black;
            foreGround[wallStartX, wallY + 1, 2] = ConsoleColor.Gray;
            characters[wallStartX, wallY + 1, 2] = '[';

            backGround[wallStartX + 1, wallY + 1, 2] = ConsoleColor.Black;
            foreGround[wallStartX + 1, wallY + 1, 2] = ConsoleColor.Gray;
            characters[wallStartX + 1, wallY + 1, 2] = ']';

            //Prepare name COMPLETED
            string title = "The Greatest Adventure Map";
            int namePlace = width / 2 - title.Length / 2;
            for (int i = 0; i < title.Length; i++)
            {
                backGround[namePlace + i, 1, 0] = ConsoleColor.DarkYellow;
                foreGround[namePlace + i, 1, 0] = ConsoleColor.Yellow;
                characters[namePlace + i, 1, 0] = title[i];
            }
            
            //Prepare vertical border COMPLETED
            for (int y = 0; y < height; y++)
            {
                backGround[0, y, 0] = ConsoleColor.DarkYellow;
                foreGround[0, y, 0] = ConsoleColor.Yellow;
                characters[0, y, 0] = '|';

                backGround[width - 1, y, 0] = ConsoleColor.DarkYellow;
                foreGround[width - 1, y, 0] = ConsoleColor.Yellow;
                characters[width - 1, y, 0] = '|';     
            }

            //Prepare horizontal border COMPLETED
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
                    characters[x, height - 1, 0] = '+';
                }
            }

            //Drawing map to console COMPLETED
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
            Map(120, 30);
            
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}