using System;

namespace Arrays_Mission_1
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        {
            int numberResult;
            if (number > 10)
            {
                numberResult = (number / 10) % 10;
                if (numberResult == 1)
                {
                    return $"{number}th";
                }
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
        static string CreateDayDescription(int day, int month, int year)
        {
            string[] seasons = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            return $"It is the {OrdinalNumber(day)} of {seasons[month]}, {year} AD";
        }
        static void Main(string[] args)
        {
            for (int j = 0; j < 13; j++)
            {
                for (int i = 1; i < 32; i++)
                {
                    Console.WriteLine(CreateDayDescription(i, j, 1782));
                }
            }
        }
    }
}
