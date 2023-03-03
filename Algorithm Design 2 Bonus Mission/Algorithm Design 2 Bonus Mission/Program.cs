using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algorithm_Design_2_Bonus_Mission
{
    internal class Program
    {
        static void WriteAllPermutations(List<string> previousItems, List<string>endingItems)
        {
            if (endingItems.Count == 0)
            {
                Console.WriteLine(string.Join(", ", previousItems));
                return;
            }

            foreach (var item in endingItems) 
            { 
                var newPreviousItems = new List<string>(previousItems);
                newPreviousItems.Add(item);
                var newEndingItems = new List<string>(endingItems);
                newEndingItems.Remove(item);
                WriteAllPermutations(newPreviousItems, newEndingItems);
            }
        }
        static void WriteAllPermutations(List<string> items)
        {
            var emptyList = new List<string>();
            WriteAllPermutations(emptyList, items);
        }
        static void Main(string[] args)
        {
            var names = new List<string> { "Aragorn", "Boromir", "Bilbo", "Frodo", "Gandalf", "Gimli", "Legolas", "Merry", "Pippin", "Samwise" };

            WriteAllPermutations(names);
        }
    }
}
