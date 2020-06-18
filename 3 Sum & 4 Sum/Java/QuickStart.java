import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    int [][] nums2d =
    {
      new int[]{1, 0, -1, 0, -2, 2},
      new int[]{1, 0, -1, 0, -2, 2, 3, -3}
    };

    for (int[] nums : nums2d)
      {
        var solutionSet = KSum(nums, 0);
        System.out.println("*********************************");
        System.out.println("Nums Array = " + Arrays.toString(nums));
        System.out.println("Solution sets are -- ");
        for(var set : solutionSet)
        {
          System.out.println(set);
        }
      }
  }

  static List<List<Integer>> KSum(int[] nums, int target) {
    Arrays.sort(nums);
    return KSum_Recursion(nums, 0, 4, target);
  }

  static List<List<Integer>> KSum_Recursion(int[] nums, int index, int k, int target) {
    List<List<Integer>> kList = null;
      if (k == 2) {
        kList = TwoSum(nums, index, nums.length - 1, target);
        return kList;
      }

      kList = new ArrayList<List<Integer>>();
      for (int i = index; i < nums.length - k + 1; i++) {
        //Recursive call to KSum with k-1
        var temp = KSum_Recursion(nums, i + 1, k - 1, target - nums[i]);

        if (temp != null && temp.size() > 0) {
          /************************************************************************/
          //Add the number which called KSum with k-1
          //For example if -2 called KSum_Recursion(k=2 & target=2)
          //KSum_Recursion(k=2 & target=2) would come back with [[1, 1], [0, 2]]
          //We would update those list such that they become [[-2, 1, 1], [-2, 0 ,2]]
          /************************************************************************/
          for (List<Integer> sumList : temp) {
            sumList.add(0, nums[i]);
          }

          kList.addAll(temp);
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
  static List<List<Integer>> TwoSum(int[] nums, int left, int right, int target){
    var twosumList = new ArrayList<List<Integer>>();
    while (left < right) {
      var sum = nums[left] + nums[right];
      if (sum < target)
          left++;
        else if (sum > target)
          right--;
        else {
          var temp = new ArrayList<Integer>();
          temp.add(nums[left]);
          temp.add(nums[right]);
          twosumList.add(temp);

          //Handle duplicate combinations
          //Remember array is sorted
          while (left < right && nums[left] == nums[left + 1])
            left++;

          //Handle duplicate combinations
          //Remember array is sorted
          while (left < right && nums[right] == nums[right - 1])
            right--;

          left++;
          right--;
        }
    }
    return twosumList;
  }
  

}