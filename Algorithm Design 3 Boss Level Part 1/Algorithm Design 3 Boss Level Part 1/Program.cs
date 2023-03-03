using System;
using System.Runtime.CompilerServices;

namespace Algorithm_Design_3_Boss_Level_Part_1
{
    internal class Program
    {
        static Random random = new Random();
        static void drawingAid(bool shouldDrawBorder, bool height)
        {
            int x = 0;
            int y = 0;

            if (x == 0 && y == 0)
            {
                shouldDrawBorder = true;

                while (x == 0 && y == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-");
                }
                if (x == 0 || y == height - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+");
                }
            }

        static void Map(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    
                }
            }
        }
        static void Main(string[] args)
        {
            Map(21, 61);
        }
    }
}
