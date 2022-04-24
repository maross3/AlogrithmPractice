using System;

namespace AlgorithmPractice
{
    public class PracticeSeven
    {
        // max weight limit on a boat, how many boats?
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int i = 0, j = people.Length - 1;
            int result = 0;

            while (i <= j)
            {
                result++;
                if (people[i] + people[j] <= limit) i++;
                j--;
            }

            return result;
        }
        
        // My own personal square root. Get your own.
        public int MySqrt(int x)
        {
            if (x < 2) return x;

            double first = x;
            double second = (first + x / first) / 2.0;
            
            while (Math.Abs(first - second) >= 1)
            {
                first = second;
                second = (first + x / first) / 2.0;
            }

            return (int) second;
        }
        
        // binary search
        public int ClimbStairs(int n)
        {
            int first = 1, second = 2;
        
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }

            return second;
        }
    }
}