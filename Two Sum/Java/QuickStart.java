import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    int[] nums = new int[] { 1, 6, 12, 13, 3, 8, 15, 16 };
    var result = TwoSum(nums, 20);
    System.out.printf("Result is [%d, %d]%n", result[0], result[1]);
  }

  static int[] TwoSum(int[] nums, int target) {
    Map<Integer, Integer> map = new HashMap<Integer, Integer>();

    for (int i = 0; i < nums.length; i++) {
      /*************************************
       * Check if previous numbers are looking for this one or not
       * If match is found then we found our two numbers 
       *************************************/

      if (map.containsKey(nums[i]))
        return new int[] { map.get(nums[i]), i };

      /*************************************
       * Since match is not found, We store the required compliment in dictionary along with its index 
       * We just check once if it exists, to avoid duplicates
       *************************************/
      var compliment = target - nums[i];
      if (!map.containsKey(compliment))
        map.put(compliment, i);
      //Console.WriteLine($"Number --> {nums[i]}, adding Key={compliment} at value={i}");
      System.out.printf("Number --> %d, adding Key=%d at value=%d %n", nums[i], compliment, i);
    }

    return null;
  }

}