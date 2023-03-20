using System;

namespace Dice_Simulator_1_Mission_2
{
    internal class Program
    {
        static Random random = new Random();
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int roll = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                roll += random.Next(1, diceSides + 1);
            }
            roll += fixedBonus;
            return roll;
        }
        static int DiceRoll(string diceNotation)
        {
            DiceRoll(1, 6, 0);
            return DiceRoll(1, 6, 0);
        }
        static void Main(string[] args)
        {
            DiceRoll("Throwing");
        }
    }
}
