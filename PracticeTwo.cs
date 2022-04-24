namespace AlgorithmPractice
{
    public class PracticeTwo
    {
        int BinarySearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                var pivot = left + (right - left) / 2;
                
                if (nums[pivot] == target) return pivot;
                else if (nums[pivot] < target) left = pivot + 1;
                else if (nums[pivot] > target) right = pivot - 1;
            }
        
            return -1;
        }
        
        // recursive binary search tree
        public int RecursiveSearchTree(int[] nums, int target, int low, int high)
        {
            int pivot = low + (high - low) / 2;
        
            if(nums[pivot] == target) return pivot;
            if(pivot >= high) return -1;
        
            if(target < nums[pivot]) 
                high = pivot - 1;
            else
                low = pivot + 1;        
        
            return RecursiveSearchTree(nums, target, low, high);
        }
        
        // binary search that checks right neighbor
        int BinarySearchCheckRightNeighbor(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            int left = 0, right = nums.Length;
            while (left < right)
            {
                var pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;
                else if (nums[pivot] < target) left = pivot + 1;
                else right = pivot;
            }

            if (left != nums.Length && nums[left] == target) return left;
            return -1;
        }
        
        // binary search checks both neighbors
        int BinarySearchCheckBothNeighbors(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            int left = 0, right = nums.Length;
            while (left + 1 < right)
            {
                var pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;

                if (nums[pivot] < target) left = pivot;
                else right = pivot;
            }

            if (nums[left] == target) return left;
            if (nums[right] == target) return right;
            return -1;
        }
        
        

        // applying binary search to find a 'bad version'
        public int FirstBadVersion(int n) {
            int left = 0, right = n;
            while(left < right){
                var pivot = left +(right - left) / 2;
                var checkRight = IsBadVersion(pivot + 1);
                var checkLeft = IsBadVersion(pivot);
            
                if(!checkLeft && checkRight) return pivot + 1;
                else if(!checkLeft && !checkRight) left = pivot + 1;
                else right = pivot;
            }
            return left;
        }
        
        // used to test first bad version && FirstBadVersion helper fn
        private int badVersionNumber = 3234;
        bool IsBadVersion(int idx)
        {
            return (idx == badVersionNumber);
        }
    }
}