using System;

namespace Algorithm_Design_3_Boss_Level_Part_1
{
    internal class Program
    {
        static Random random = new Random();

        static void Map(int width, int height)
        {
            //Preparing map variables for drawing with 3d arrays, with the different layers (width, height and depth, this  will decide position and layer.) COMPLETED
            int depth = 4;
            char[,,] characters = new char[width, height, depth];
            ConsoleColor[,,] foreGround = new ConsoleColor[width, height, depth];
            ConsoleColor[,,] backGround = new ConsoleColor[width, height, depth];

            //Preparing green field to be drawn, put all over the map on the second layer so that later detection for the wall works. COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Drawing field
                    backGround[x, y, 2] = ConsoleColor.Green;
                    characters[x, y, 2] = ' ';
                }
            }

            //Preparing forest, forestBorder decides how far into the map the forest goes. COMPLETED
            int forestBorder = width / 8;
            for (int y = 0; y < height; y++)
            {
                //Random generation for if the border goes left or right.
                int forest = random.Next(1, 11);
                if (forest <= 3 && forestBorder > 0)
                {
                    forestBorder--;
                }
                else if (forest <= 6 && forestBorder < width - forest)
                {
                    forestBorder++;
                }

                //Drawing the background, foreground and trees.
                for (int i = 0; i < forestBorder; i++)
                {
                    backGround[forestBorder - i, y, 2] = ConsoleColor.DarkGreen;
                    foreGround[forestBorder - i, y, 2] = ConsoleColor.Green;
                    characters[forestBorder - i, y, 2] = 'T';
                }
            }

            //Preparing random trees to be all over the map for more variety and better looking. COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Drawing the randomly placed trees.
                    int placeTree = random.Next(1, 11);
                    if (placeTree == 1)
                    {
                        backGround[x, y, 2] = ConsoleColor.DarkGreen;
                        foreGround[x, y, 2] = ConsoleColor.Green;
                        characters[x, y, 2] = 'T';
                    }
                }
            }

            //Preparing the rivers position, width and how it will move around. COMPLETED
            int riverDivide = width / 8;
            int river = width - riverDivide * 2;
            int riverDirection;
            int riverWidth = random.Next(3, 5);
            int[] riverStore = new int[height];

            for (int y = 0; y < height; y++)
            {
                //Randomly deciding how the river will move and storing it for later the road following the river so that it can copy the movement. 
                riverDirection = random.Next(1, 11);
                riverStore[y] = riverDirection;

                //Riverchar for different symbols based on how the river turns. 
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

                //Drawing the river.
                for (int i = 0; i < riverWidth; i++)
                {
                    backGround[river - i, y, 2] = ConsoleColor.Blue;
                    foreGround[river - i, y, 2] = ConsoleColor.Cyan;
                    characters[river - i, y, 2] = riverChar;
                }
            }

            //Preparing the walls position, width and how it will move around. COMPLETED
            int wall = width / 4;
            for (int y = 0; y < height; y++)
            {
                //Same thing as with riverChar, just so it displays based on how it moves (lower chance to move.)
                int wallDirection = random.Next(1, 11);
                char wallChar;

                if (wallDirection <= 5 && wall > 0)
                {
                    wall--;
                    wallChar = '/';
                }
                else if (wallDirection <= 11 && wall < width)
                {
                    wall++;
                    wallChar = '\\';
                }
                else
                {
                    wallChar = '|';
                }

                //Drawing the wall.
                for (int i = 0; i < 2; i++)
                {
                    backGround[wall - i, y, 2] = ConsoleColor.Black;
                    foreGround[wall - i, y, 2] = ConsoleColor.Gray;
                    characters[wall - i, y, 2] = wallChar;
                }
            }

            //Function for the road to be able to detect the river and then put the bridge and stay straight.
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

            //Function for the road to be able to detect the wall and then put the gatehouses and stay straight. 
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

            //Preparing the road, detecting the wall and river, and saving variables for later when the turrets and bridge will be drawn up. COMPLETED
            int roadY = height / 2;

            //Bridge and river variables for later.
            int bridgeStartX = 0;
            int bridgeEndX = 0;
            int bridgeY = 0;
            bool onBridge = false;
            bool leftShore = false;

            //Wall variables for later.
            int wallStartX = 0;
            int wallY = 0;
            bool onWall = false;

            for (int x = 0; x < width; x++)
            {
                //Drawing the wall.
                backGround[x, roadY, 1] = ConsoleColor.DarkGray;
                foreGround[x, roadY, 1] = ConsoleColor.Gray;
                characters[x, roadY, 1] = '#';

                //Functions from earlier keeping track of where to place the bridge and making sure the road that follows the river knows what to do.
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
                    onBridge = false;
                    bridgeEndX = x;
                }

                //Functions from earlier keeping track of the walls position so that the turrets can be placed out later. 
                if (IsWall(x + 1, roadY))
                {
                    onWall = true;
                    wallStartX = x;
                    wallY = roadY;
                }

                if (IsWall(x - 1, roadY))
                {
                    onWall = false;
                }

                //Boolians to stop the road from moving when near the wall and river so it looks better.
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

            //Function for the road that follows the river to not draw itself above the road, only below.
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

            //Preparing for the road that follows the river and it's position
            int roadXMinus = width / 3;
            int roadX = width - roadXMinus;
            bool belowRoad = false;

            for (int y = 0; y < height; y++)
            {
                //Function from earlier.
                if (IsBelowRoad(roadX, y + 1))
                {
                    belowRoad = false;
                }
                else if (IsBelowRoad(roadX, y - 1))
                {
                    belowRoad = true;
                }

                //Using the stored values of how the river moved and moving the road in the same way.
                int roadDirection = riverStore[y];
                if (roadDirection <= 2)
                {
                    roadX--;
                }
                else if (roadDirection <= 4)
                {
                    roadX++;
                }

                //Using earlier functions to only draw itself when below the road.
                if (belowRoad == true)
                {
                    backGround[roadX, y, 1] = ConsoleColor.DarkGray;
                    foreGround[roadX, y, 1] = ConsoleColor.Gray;
                    characters[roadX, y, 1] = '#';
                }
            }

            //Preparing the bridge to be drawn with varibales saved from when the road was drawn so that it looks good. COMPLETED
            for (int i = bridgeStartX; i < bridgeEndX; i++)
            {
                backGround[i, bridgeY - 1, 2] = ConsoleColor.Gray;
                foreGround[i, bridgeY - 1, 2] = ConsoleColor.DarkYellow;
                characters[i, bridgeY - 1, 2] = '-';

                backGround[i, bridgeY + 1, 2] = ConsoleColor.Gray;
                foreGround[i, bridgeY + 1, 2] = ConsoleColor.DarkYellow;
                characters[i, bridgeY + 1, 2] = '-';
            }

            //Preparing the turrets to be drawn with variables saved from when the road was drawn so that it looks good. COMPLETED
            for (int i = -1; i < 2; i++)
            {
                backGround[wallStartX, wallY + i, 2] = ConsoleColor.Black;
                foreGround[wallStartX, wallY + i, 2] = ConsoleColor.Gray;
                characters[wallStartX, wallY + i, 2] = '[';

                backGround[wallStartX + 1, wallY + i, 2] = ConsoleColor.Black;
                foreGround[wallStartX + 1, wallY + i, 2] = ConsoleColor.Gray;
                characters[wallStartX + 1, wallY + i, 2] = ']';

                backGround[wallStartX - 1, wallY + i, 2] = ConsoleColor.Green;
                characters[wallStartX - 1, wallY + i, 2] = ' ';
            }

            //Preparing the title to be drawn and making sure it is in the middle of the map no matter the size. COMPLETED
            string title = "The Greatest Adventure Map";
            int namePlace = width / 2 - title.Length / 2;
            for (int i = 0; i < title.Length; i++)
            {
                backGround[namePlace + i, 1, 0] = ConsoleColor.DarkYellow;
                foreGround[namePlace + i, 1, 0] = ConsoleColor.Yellow;
                characters[namePlace + i, 1, 0] = title[i];
            }

            //Preparing the vertical border of the map to be drawn. COMPLETED
            for (int y = 0; y < height; y++)
            {
                backGround[0, y, 0] = ConsoleColor.DarkYellow;
                foreGround[0, y, 0] = ConsoleColor.Yellow;
                characters[0, y, 0] = '|';

                backGround[width - 1, y, 0] = ConsoleColor.DarkYellow;
                foreGround[width - 1, y, 0] = ConsoleColor.Yellow;
                characters[width - 1, y, 0] = '|';
            }

            //Preparing the horizontal border of the map to be drawn as well as the corners. COMPLETED
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

            //Drawing the map to console with all of the preperation from earlier, going line by line and layer by layer so everything displays correctly. COMPLETED
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
            //Calling Map
            Map(120, 30);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}