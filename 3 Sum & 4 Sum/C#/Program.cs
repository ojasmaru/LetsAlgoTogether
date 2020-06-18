using System;
using System.Collections.Generic;

namespace KSum
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums2d = new int[2][]
      {
        new int[]{1, 0, -1, 0, -2, 2},
        new int[]{1, 0, -1, 0, -2, 2, 3, -3}
      };

      foreach (var nums in nums2d)
      {
        var solutionSet = KSum(nums, 0);
        Console.WriteLine("*********************************");
        Console.WriteLine($"Nums Array = {string.Join(", ", nums)}");
        Console.WriteLine("Solution sets are -- ");
        foreach (var set in solutionSet)
        {
          //Console.WriteLine($"{string.Join(" + ", set)} = 0");
          Console.WriteLine($"[{string.Join(", ", set)}]");
        }
      }
    }

    public static IList<IList<int>> KSum(int[] nums, int target)
    {
      Array.Sort(nums);
      return KSum_Recursion(nums, 0, 4, target);
    }
    /************************************************************************/
    //Recursing method to handle KSum(3 sum, 4 sum etc...)
    /************************************************************************/
    public static IList<IList<int>> KSum_Recursion(int[] nums, int index, int k, int target)
    {
      List<IList<int>> kList = null;
      if (k == 2)
      {
        kList = TwoSum(nums, index, nums.Length - 1, target);
        return kList;
      }

      kList = new List<IList<int>>();
      for (int i = index; i < nums.Length - k + 1; i++)
      {
        //Recursive call to KSum with k-1
        var temp = KSum_Recursion(nums, i + 1, k - 1, target - nums[i]);
        if (temp != null && temp.Count > 0)
        {
          /************************************************************************/
          //Add the number which called KSum with k-1
          //For example if -2 called KSum_Recursion(k=2 & target=2)
          //KSum_Recursion(k=2 & target=2) would come back with [[1, 1], [0, 2]]
          //We would update those list such that they become [[-2, 1, 1], [-2, 0 ,2]]
          /************************************************************************/
          foreach (var sumList in temp)
          {
            sumList.Insert(0, nums[i]);
          }

          kList.AddRange((List<IList<int>>)temp);
        }

        //Ignore duplicates
        //Remember array is sorted
        while (i < nums.Length - 1 && nums[i] == nums[i + 1])
          i++;

      }
      return kList;
    }

    /************************************************************************/
    //Two sum approach using 2 pointer algorithm
    //Add the 2 numbers from those pointers
    //  If sum is less than target then do left++
    //  else If sum is greater than target then do right--
    /************************************************************************/
    public static List<IList<int>> TwoSum(int[] nums, int left, int right, int target)
    {
      var twosumList = new List<IList<int>>();
      while (left < right)
      {
        var sum = nums[left] + nums[right];
        if (sum < target)
          left++;
        else if (sum > target)
          right--;
        else
        {
          var temp = new List<int>{nums[left], nums[right] };
          twosumList.Add(temp);

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
}