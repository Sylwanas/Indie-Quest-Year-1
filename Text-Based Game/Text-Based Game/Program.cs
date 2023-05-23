using System;

namespace Text_Based_Game
{
    class MapTile
    {
        char character;
        ConsoleColor ForegroundColor;
        ConsoleColor BackgroundColor;
    }
    internal class Program
    {
        static Random random = new Random();
        static void Map(int width, int height)
        {
            //Preparing map variables for drawing with 3d arrays, with the different layers (width, height and depth, this  will decide position and layer.) COMPLETED
            int depth = 4;
            MapTile[,,] Map = new MapTile[width, height, depth];

            char[,,] characters = new char[width, height, depth];
            ConsoleColor[,,] foreGround = new ConsoleColor[width, height, depth];
            ConsoleColor[,,] backGround = new ConsoleColor[width, height, depth];

            //Preparing green field to be drawn, put all over the map on the second layer so that later detection for the wall works. COMPLETED
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Drawing field
                    int moveLeftRight = 0;
                    int moveUpDown = 0;
                    bool a = ((x * 8) / width) == moveLeftRight && ((y * 5) / height) == moveUpDown;
                    backGround[x, y, 2] = ConsoleColor.Green;
                    if (a)
                    {
                        backGround[x, y, 2] = ConsoleColor.Blue;
                        Console.WriteLine("  o  \r\n <)->\r\n  A  ");
                    }
                    characters[x, y, 2] = ' ';
                }
            }

            //Drawing vertical squares
            for (int y = 0; y < height; y++)
            {
                for (int i = 1; i < 8; i++)
                {
                    backGround[(width / 8) * i, y, 1] = ConsoleColor.DarkYellow;
                    foreGround[(width / 8) * i, y, 1] = ConsoleColor.Yellow;
                    characters[(width / 8) * i, y, 1] = '|';
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int i = 1; i < 5; i++)
                {
                    backGround[x, (height / 5) * i, 1] = ConsoleColor.DarkYellow;
                    foreGround[x, (height / 5) * i, 1] = ConsoleColor.Yellow;
                    characters[x, (height / 5) * i, 1] = '-';
                }
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
                        if (characters[x, y, z] != '\0')
                        {
                            Console.BackgroundColor = backGround[x, y, z];
                            Console.ForegroundColor = foreGround[x, y, z];
                            Console.Write(characters[x, y, z]);
                            break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            /*
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (OperatingSystem.IsWindows())
            {
                Console.BufferWidth = Console.WindowWidth;
                Console.BufferHeight = Console.WindowHeight;
            }

            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F11);

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            double foreach for arrow list and enemy list 
            class for each thing - if hp or more individual hp
            to track position hp etc 

            2d array for grid 
            integer coordinates 
            foreach square check if arrow 
            2d array either one unit for all units each tic check each element in the array if archer shoot arrow if enemy move left
            another 2d array for the arrows move right and check for character dont spaws if theres already one 
            */

            Map(81, 31);
            bool onBoard;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            if (!Console.BackgroundColor.Equals(ConsoleColor.Black) && !Console.ForegroundColor.Equals(ConsoleColor.White)) ;
            {
                onBoard = true;
            }
            Console.WriteLine("  o  \r\n <)->\r\n  A  ");
            Console.WriteLine("     \r\n>--->\r\n     ");
            Console.WriteLine("  o  \r\nE-|-/\r\n / \\");
        }
    }
}
