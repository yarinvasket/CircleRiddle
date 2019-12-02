using System;
using System.Collections.Generic;

namespace CircleRiddle
{
    class Program
    {
        public static Random rnd = new Random();
        public const int l = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("The estimated number is: " + RiddleEstimate(l));
            Console.WriteLine("The actual number is: " + RiddleComplete(l));
        }

        public static double RiddleEstimate(int arrLength)
        {
            double result = 1;
            int circleLength = arrLength / 2;

            if (arrLength < circleLength)
            {
                return 0;
            }

            for (int i = 0; i < circleLength - 1; i++)
            {
                result *= 1 - (1.0 / (arrLength - i));
            }

            return result;
        }

        public static double RiddleComplete(int arrLength)
        {
            int circles = 0;
            int timesExecuted = (int)Math.Pow(arrLength, 3);

            for (int i = 0; i < timesExecuted; i++)
            {
                int[] randomArr = RandomArr(arrLength);
                List<int> indexes = new List<int>();
                int circleLength = 1;
                indexes.Add(0);
                int idx = randomArr[0];
                while (!indexes.Contains(idx))
                {
                    indexes.Add(idx);
                    idx = randomArr[idx];
                    circleLength++;
                }

                if (circleLength >= arrLength / 2)
                {
                    circles++;
                }
            }

            return (double)circles / timesExecuted;
        }

        public static int[] RandomArr(int arrLength)
        {
            List<int> unshuffledArr = new List<int>();

            for (int i = 0; i < arrLength; i++)
            {
                unshuffledArr.Add(i);
            }

            int[] shuffledArr = new int[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                int idx = rnd.Next(0, unshuffledArr.Count);
                shuffledArr[i] = unshuffledArr[idx];
                unshuffledArr.RemoveAt(idx);
            }
            return shuffledArr;
        }
    }
}