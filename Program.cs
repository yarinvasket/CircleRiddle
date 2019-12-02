using System;
using System.Collections.Generic;

namespace CircleRiddle
{
    class Program
    {
        public static Random rnd = new Random();
        public const int l = 4;

        static void Main(string[] args)
        {
            //Console.WriteLine("The estimated number is: " + RiddleEstimate(l));
            Console.WriteLine("The simulated number is: " + RiddleComplete(l));
        }

        //Currently doesn't work
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
            int timesExecuted = 1000000;

            for (int i = 0; i < timesExecuted; i++)
            {
                int[] randomArr = RandomArr(arrLength);
                List<int> indexes = new List<int>();
                bool isCircle = false;
                
                while (indexes.Count < arrLength)
                {
                    int circleLength = 1;
                    int num = GetNumOutside(randomArr, indexes);
                    indexes.Add(num);
                    int idx = randomArr[num];
                    while (!indexes.Contains(idx))
                    {
                        indexes.Add(idx);
                        idx = randomArr[idx];
                        circleLength++;
                    }

                    if (circleLength >= arrLength / 2)
                    {
                        isCircle = true;
                    }
                }
                if (isCircle)
                {
                    circles++;
                }
            }

            return (double)circles / timesExecuted;
        }

        public static int GetNumOutside(int[] larg, List<int> little)
        {
            List<int> dup = new List<int>();
            foreach (int e in larg)
            {
                dup.Add(e);
            }

            foreach (int e in little)
            {
                dup.Remove(e);
            }

            return dup[rnd.Next(0, dup.Count)];
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