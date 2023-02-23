using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lists_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lists and Variables
            var rollsList = new List<int>();
            var rollsTotalList = new List<int>();
            var random = new Random();
            int roll = 0;
            int rollTotal = 0;

            //Rolling
            for (int a = 0; a < 6; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    roll = random.Next(1, 7);
                    rollTotal += roll;
                    rollsList.Add(roll);
                }

                //Writing Rolls
                Console.Write("You roll ");
                foreach (var item in rollsList)
                    Console.Write($"{item}, ");
                Console.WriteLine();

                //Removing Lowest
                int lowest = rollsList.Min();
                rollTotal -= lowest;
                rollsList.Remove(lowest);
                rollsTotalList.Add(rollTotal);
                rollsTotalList.Sort();

                Console.WriteLine($"Your ability score is {rollTotal}");

                //Clearing Lists and Variables
                rollTotal= 0;
                rollsList.Clear();
            }
            Console.WriteLine();
            Console.Write("Your available ability scores are: ");
            foreach (var item in rollsTotalList)
            Console.Write($"{item}, ");
            Console.WriteLine();
        }
    }
}
