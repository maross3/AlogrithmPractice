using System.Collections.Generic;
namespace AlgorithmPractice
{
    
    public class PracticeThree
    {
        // binary search a sorted array that was rotated xtimes
        public int SearchRotatedArray(int[] nums, int target) {
            int start = 0, end = nums.Length - 1;
    
            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] >= nums[start]) {
                    if (target >= nums[start] && target < nums[mid]) end = mid - 1;
                    else start = mid + 1;
                }
                else {
                    if (target <= nums[end] && target > nums[mid]) start = mid + 1;
                    else end = mid - 1;
                }
            }
            return -1;
        }
        
        // find minimum index in a randomly sorted array
        public int FindMin(int[] nums) {
            if(nums.Length == 1) return nums[0];
            int left = 0, right = nums.Length - 1;
            if(nums[right] > nums[0]) return nums[0];
        
            while (left <= right){
            
                var pivot = left + (right - left) / 2;
            
                var neighborRight = nums[pivot + 1];
        
                if(nums[pivot] > neighborRight) return neighborRight;
                if(nums[pivot] < nums[pivot - 1]) return nums[pivot];
            
                if(nums[pivot] > nums[0]) left = pivot + 1;
                else right = pivot - 1;
            }
    
            return -1;
        }
        
        // binary search in random seq numbers. each sequence is alternating descending/ascending
        public int FindPeakElement(int[] nums) {
            int left = 0, right = nums.Length - 1;

            while (left < right){
                // pivot = (left + right) / 2 
                var pivot = left + (right - left) / 2;
            
                if(nums[pivot] > nums[pivot + 1] ) right = pivot;
                else left = pivot + 1;
            }
            return left;
        }
        
        //where n is highest n, guess random number
        public int GuessNumber(int n) {
            int low = 1, high = n;
        
            while(low <= high){
                int pivot = low + ( high -  low) / 2;
            
                var response = Guess(pivot);
            
                if (response == 0) return pivot;
                if(response < 0) high = pivot - 1;
                else low = pivot + 1;
            }
            return low;
        }

        // // used to test GuessNumber && GuessNumber helper fn
        int numToGuess = 50;
        int Guess(int num)
        {
            if (num < 50) return 1;
            if (num > 50) return -1;
            return 0;
        }

        // brackets question
        public bool IsValid(string s)
        {
            var legend = new Dictionary<char, char>();
            PopulateDictionary(legend);
            Stack<char> stack = new Stack<char>();
            if (s.Length % 2 != 0) return false;

            var brackets = s.ToCharArray();
            for (int i = 0; i < brackets.Length; i++)
            {

                if (!legend.ContainsKey(s[i]) && !legend.ContainsValue(s[i])) return false;

                if (legend.ContainsKey(s[i])) stack.Push(s[i]);
                else
                {
                    char temp = stack.Peek();

                    if (legend.ContainsKey(temp) && legend[temp] == s[i]) stack.Pop();
                    else stack.Push(s[i]);
                }
            }

            return stack.Count == 0;
        }
        
        void PopulateDictionary(Dictionary<char, char> dict)
        {
            dict.Add('{', '}');
            dict.Add('(', ')');
            dict.Add('[', ']');
        }

    }
}