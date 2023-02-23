using System;

namespace Algorithm_design_1___Mission_3
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        {
            int numberResult;
            if (number > 10)
            {
                numberResult = number / 10;
                numberResult &= 10;
            }

                numberResult = number % 10;

            switch (numberResult)
            {
                case 1:
                    return $"{number}st";

                case 2:
                    return $"{number}nd";

                case 3:
                    return $"{number}rd";

                default:
                    return $"{number}th";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(OrdinalNumber(1));
            Console.WriteLine(OrdinalNumber(2));
            Console.WriteLine(OrdinalNumber(3));
            Console.WriteLine(OrdinalNumber(4));
            Console.WriteLine(OrdinalNumber(10));
            Console.WriteLine(OrdinalNumber(11));
            Console.WriteLine(OrdinalNumber(12));
            Console.WriteLine(OrdinalNumber(13));
            Console.WriteLine(OrdinalNumber(21));
            Console.WriteLine(OrdinalNumber(101));
            Console.WriteLine(OrdinalNumber(111));
            Console.WriteLine(OrdinalNumber(121));
            Console.WriteLine(OrdinalNumber(1100102321));
            Console.WriteLine(OrdinalNumber(1104812490));
        }
    }
}
