using System;
using System.Collections.Generic;

namespace Single_Number
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums2d = new int[2][]
      {
        new int[]{3, 3, 2, 2, 10},
        new int[]{10, 2, 4, 10, 3, 4, 2}
      };

      foreach (var nums in nums2d)
      {
        Console.WriteLine("*********************************");
        Console.WriteLine($"Nums Array = {string.Join(", ", nums)}");
        Console.WriteLine($"Single Number = {SingleNumber(nums)}");
      }

    }

    static int SingleNumber(int[] nums)
    {
      int ans = 0;
      foreach (var num in nums)
      {
        ans ^= num;
      }
      return ans;
    }
  }
}
