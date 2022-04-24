using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmPractice
{
    public class PracticeFive
    {
        // get the longest common prefix
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 1) return "";
            if (strs.Length == 1) return strs[0];

            var max = GetMinLengthInArr(strs);
            var result = "";

            for (int i = 0; i < max; i++)
            {

                var charInQuestion = strs[0][i];

                for (int j = 0; j < strs.Length; j++)
                    if (strs[j][i] != charInQuestion)
                        return result;

                result += charInQuestion.ToString();
            }

            return result;
        }
        //longest common prefix helper fn
        int GetMinLengthInArr(string[] arr)
        {
            var min = 201;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i].Length) min = arr[i].Length;
            }

            return min;
        }
        
        // remove duplicates in an array of nums, returns the index
        public int RemoveDuplicates(int[] nums)
        {

            var currentIndex = 0;
            var currentNumber = -101;

            for (int i = 0; i < nums.Length; i++)
                if (currentNumber != nums[i])
                {
                    nums[currentIndex] = nums[i];
                    currentNumber = nums[i];
                    currentIndex++;
                }

            return currentIndex;
        }
        
        //same as above, but a number
        public int RemoveElement(int[] nums, int val)
        {

            int currentIndex = 0;
            int currentNumber = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                currentNumber = nums[i];

                if (currentNumber != val)
                {
                    nums[currentIndex] = currentNumber;
                    currentIndex++;
                }
            }

            return currentIndex;
        }
        
        // get the sum of contiguous ints in arr
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int[] newNums = new int[nums.Length];

            for (int i = 0; i < newNums.Length; i++)
                newNums[i] = nums[i];

            for (int i = 1; i < nums.Length; i++)
                newNums[i] = Math.Max(newNums[i - 1] + nums[i], nums[i]);

            Array.Sort(newNums);
            return newNums.Last();
        }
        
        // not the best, but gets length of last word
        public int LengthOfLastWord(string s)
        {

            Stack<Char> sentenceParser = new Stack<Char>();
            var sentence = s.ToCharArray();
            int result = 0;

            for (int i = 0; i < sentence.Length; i++)
            {

                if (sentence[i] == ' ') sentenceParser.Clear();
                else
                {
                    sentenceParser.Push(sentence[i]);
                    result = sentenceParser.Count;
                }
            }

            return result;
        }
    }
}