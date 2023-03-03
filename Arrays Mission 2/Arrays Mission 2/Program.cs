using System;

namespace Arrays_Mission_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] monsters = new int[101];

            for (int i = 0; i < 101; i++)
            {
                monsters[i] = random.Next(1, 51);
            }
            Array.Sort(monsters);
            Console.Write("Number of monsters in levels: ");
            Console.Write(string.Join(", ", monsters));
            Console.WriteLine();
        }
    }
}
