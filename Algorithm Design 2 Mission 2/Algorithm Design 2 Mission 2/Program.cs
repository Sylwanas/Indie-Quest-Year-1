using System;

namespace Algorithm_Design_2_Mission_2
{
    internal class Program
    {
        static int Factorial(int n) 
        {
            if (n == 0)
            { 
                return 1; 
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Factorial(i));
            }
        }
    }
}
