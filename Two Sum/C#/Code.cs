public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        
        for(int i=0; i<nums.Length; i++)
        {
            /*************************************
            //Check if previous numbers are looking for this one or not
            //If match is found then we found our two numbers
            /*************************************/
            if (map.ContainsKey(nums[i]))
                return new int[] {map[nums[i]], i};

            /*************************************
            //Since match is not found
            //We store the required compliment in dictionary along with its index
            //We just check once if it exists, to avoid duplicates
            /*************************************/
            var compliment = target - nums[i];
            if (!map.ContainsKey(compliment))
                map.Add(compliment, i);
                //Console.WriteLine($"Number --> {nums[i]}, adding Key={compliment} at value={i}");
        }
        
        return null;
    }
}