public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        return KSum(nums, 0, 3, 0);
    }
    
    /************************************************************************/
    //Recursing method to handle KSum(3 sum, 4 sum etc...)
    /************************************************************************/
    public IList<IList<int>> KSum(int[] nums, int index, int k, int target)
    {
        List<IList<int>> kList = null;
        if (k == 2)
        {
            kList = TwoSum(nums, index, nums.Length - 1, target);
        }
        else
        {
            kList = new List<IList<int>>();
            for(int i=index; i< nums.Length - k + 1; i++)
            {
                //Recursive call to KSum with k-1
                var temp = KSum(nums, i+1, k-1, target-nums[i]);
                if (temp != null && temp.Count > 0)
                {
                    foreach(var sumList in temp)
                    {
                        sumList.Insert(0, nums[i]);
                    }
                    
                    kList.AddRange((List<IList<int>>)temp);
                }
                
                //Ignore duplicates
                while (i<nums.Length-1 && nums[i] == nums[i+1])
                    i++;
            }
        }
        return kList;
    }
    
    /************************************************************************/
    //Two sum approach using 2 pointer algorithm
    //Add the 2 numbers from those pointers
    //  If sum is less than target then do left++
    //  else If sum is greater than target then do right--
    /************************************************************************/
    public List<IList<int>> TwoSum(int[] nums, int left, int right, int target)
    {
        var temp = new List<IList<int>>();
        while (left < right)
        {
            var sum = nums[left] + nums[right];
            if (sum < target)
                left++;
            else if (sum > target)
                right--;
            else
            {
                temp.Add(new List<int>(){nums[left], nums[right]});
                
                //Handle duplicate combinations
                while(left < right && nums[left] == nums[left+1])
                    left++;
                
                //Handle duplicate combinations
                while(left < right && nums[right] == nums[right-1])
                    right--;
                
                left++;
                right--;
            }
        }
        
        return temp;
    }
}