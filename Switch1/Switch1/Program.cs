using System;

namespace Switch1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set price: ");
            string playerPrice = Console.ReadLine();
            string [] splitInput = playerPrice.Split(' ');
            decimal x;
            decimal y;
            decimal price;
            decimal lastInput = splitInput.Length -1;
            x = decimal.Parse(splitInput[0]);

            if (splitInput.Length > 1)
            {
                y = decimal.Parse(splitInput[(int)lastInput]);

                switch (splitInput[1]) 
                {
                    case "+": 
                    case "plus":
                        price = x + y; 
                        break;

                    case "-": 
                    case "minus":
                        price = x - y;
                        break;

                    case "*":
                    case "times":
                        price = x * y;
                        break;

                    case "/":
                    case "divided":
                        price = x / y;
                        break;

                    default: 
                        price = x; 
                        break;
                }
            }
            else 
            { 
                price = x;
            }
            Console.WriteLine($"Price set to {price}");
        }
    }
}
