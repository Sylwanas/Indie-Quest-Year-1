using System;
using System.Runtime;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            var random = new Random();
            int tankDistance = random.Next(40, 71);
            int shells = 20;
            
            //Flavor text + userName
            Console.WriteLine("Lieutenant! Lieutenant wake up! There's a tank coming towards HQ! You don't need to worry though lieutenant, we have 83- *KABOOM* ... 5 shells left! Please you have to save us!\n");
            Console.WriteLine("Enter your name lieutenant.");
            string userName = Console.ReadLine();
            Console.Write("Lieutenant " + userName); Console.Write(" is it? Good, strong name.\n");
            Console.WriteLine("Now, our chief mapper drew this map for us to use, it's a bit primitive but shows the field at least, good luck!\n");

            //Actual Shooting
            while (shells > 0)
            {

                //Lose Condition check
                if (tankDistance < 1)
                {
                    Console.WriteLine("Oh no lieutenant! The enemy have broken through, this is all your fault!");
                    shells = 0;
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                //Drawing and Moving
                Console.Write("_/");
                for (int distanceToTank = 0; distanceToTank < tankDistance - 3; distanceToTank++)
                {
                    Console.Write("_");
                }
                Console.Write("T");
                for (int distanceToEnd = tankDistance; distanceToEnd < 80; distanceToEnd++)
                {
                    Console.Write("_");
                }
                Console.WriteLine("\n");
                Console.Write("On your command lieutenant " + userName); Console.Write("!\n");
                int tankMove = random.Next(1, 16);

                Console.Write("Enter distance: ");
                int aim = Convert.ToInt32(Console.ReadLine());
                aim -= -3;
                string shot = new string(' ', aim);
                Console.Write(shot + "  ");
                Console.WriteLine("*");
                shells--;

                tankDistance -= tankMove;
                Console.Clear();

                if (aim < tankDistance)
                {
                    Console.WriteLine("Miss! Too short lieutenant.");
                    Console.WriteLine($"{shells} shells left.");
                }
                if (aim > tankDistance)
                {
                    Console.WriteLine("Miss! Too far lieutenant.");
                    Console.WriteLine($"{shells} shells left.");
                }
                if (aim == tankDistance)
                {
                    Console.WriteLine("Hit! You did it lieutenant!");
                    Console.WriteLine("Press enter to go home to your family.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (shells == 0 && aim != tankDistance)
                {
                    Console.WriteLine("We're out of shells lieutenant! HQ demands we put you in next, sorry!");
                }
            }
        }
    }
}
