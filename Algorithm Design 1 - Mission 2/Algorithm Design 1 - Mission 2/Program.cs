using System;
using System.Collections.Generic;
using System.Threading;

namespace Algorithm_Design_1___Mission_2
{
    internal class Program
    {
        static string JoinWithAnd2(List<string> items, bool useSerialComma = true)
        {
            int numberItems = items.Count;
            string result = "";
            //True
            if (useSerialComma == true && numberItems >= 3)
            {
                for (int i = 0; i < numberItems - 1; i++)
                {
                   result += $"{items[i]}, ";
                }
                result += $"and {items[numberItems - 1]}";
            }
            else if (useSerialComma == true && numberItems == 2)
            {
                for (int i = 0; i < numberItems - 1; i++)
                {
                    result += $"{items[i]} ";
                }
                result += $"and {items[numberItems - 1]}";
            }
            else if (useSerialComma == true && numberItems == 1)
            {
                result += $"{items[0]}";
            }

            //False
            if (useSerialComma == false && numberItems >= 3)
            {
                for (int i = 0; i < numberItems - 1; i++)
                {
                    result += $"{items[i]}";
                    if (i < numberItems- 2)
                    {
                        result += ", ";
                    }
                }
                result += $" and {items[numberItems - 1]}";
            }
            else if (useSerialComma == false && numberItems == 2)
            {
                for (int i = 0; i < numberItems - 1; i++)
                {
                    result += $"{items[i]} ";
                }
                result += $"and {items[numberItems - 1]}";
            }
            else if (useSerialComma == false && numberItems == 1)
            {
                result += $"{items[0]}";
            }
            return result;
        }

        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            int count = items.Count;
            switch (count) 
            {
                case 0:
                    return "";

                case 1:
                    return items[0];

                case 2:
                    return $"{items[0]} and {items[1]}";

                default:
                    var itemsCopy = new List<string>(items);
                    if (useSerialComma) 
                    {
                        string lastItem = $"and {items[count - 1]}";
                        itemsCopy[count - 1] = lastItem;
                    }
                    else 
                    { 
                        string joinedItems = $"{items[count - 2]} and {items[count - 1]}";
                        itemsCopy[count - 2] = joinedItems;
                        itemsCopy.RemoveAt(count - 1);
                    }
                    return string.Join ($", " , itemsCopy);
            }
        }
        static void Main(string[] args)
        {
            var gang = new List<string> { "Fred", "Velma", "Shaggy", "Daphne", "Scooby-Doo" };
            while (gang.Count >= 0) 
            {
                Console.WriteLine(JoinWithAnd(gang, true));
                Console.WriteLine();
                Console.WriteLine(JoinWithAnd(gang, false));
                Console.WriteLine();
                if (gang.Count == 0)
                {
                    break;
                }
                gang.Remove(gang[0]);
                
            }
            if (gang.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Aint no one left in the gang");
            }
        }
    }
}
