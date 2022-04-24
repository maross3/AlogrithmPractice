using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmPractice
{
    public class PracticeOne
    {
        // Binary Conversion
        public int BinaryGap(int n)
        {
            char[] compare = Convert.ToString(n, 2).PadLeft(1, '0').ToCharArray();

            int gap = 0;
            int runningSum = 0;

            foreach (var numStr in compare)
            {
                if (numStr == '1')
                {
                    if (runningSum > gap)
                        gap = runningSum;

                    runningSum = 0;
                }
                else runningSum += 1;
            }
            return gap;
        }
    
    //Binary search 
    public int PivotIndex(int[] nums)
    {
        var leftSum = 0;
        var sum = nums.Sum();

        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum == sum - leftSum - nums[i]) return i;
            leftSum += nums[i];
        }

        return -1;
    }
    
    // add one to an array of digits
    public int[] PlusOne(int[] digits)
    {

        for (int i = digits.Length - 1; i >= 0; i--)
        {

            if (digits[i] == 9)
                digits[i] = 0;
            else
            {
                digits[i] += 1;
                return digits;
            }

            if (i == 0)
            {
                int[] newDigits = new int[digits.Length + 1];
                newDigits[0] = 1;
                
                return newDigits;
            }
        }
        
        return digits;
    }
    
    
    // convert a string roman integer to an integer
    public int RomanToInt(string s)
    {
        var numerals = new Dictionary<char, int>();
        var charArr = s.ToCharArray();
        
        PopulateDictionary(numerals);
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var numberToArgue = numerals[charArr[i]];
            if (i + 1 < s.Length && numberToArgue < numerals[charArr[i + 1]]) result -= numberToArgue;
            else result += numberToArgue;
        }

        return result;
    }
    // Roman to int helper fn
    void PopulateDictionary(Dictionary<char, int> nums){
        nums.Add('I', 1);
        nums.Add('V', 5);
        nums.Add('X', 10);
        nums.Add('L', 50);
        nums.Add('C', 100);
        nums.Add('D', 500);
        nums.Add('M', 1000);
    }
    
    
}
}