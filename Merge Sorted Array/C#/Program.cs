using System;
using System.Collections.Generic;

namespace C_
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums1 = new int[] { 1, 3, 5, 0, 0, 0, 0, 0 };
      var nums2 = new int[] { 2, 4, 6, 8, 10 }; ;
      Console.WriteLine($"Nums1 = {String.Join(", ", nums1)}");
      Console.WriteLine($"Nums2 = {String.Join(", ", nums2)}");

      Merge2Array(nums1, 3, nums2, 5);

      Console.WriteLine($"Merged Array = {String.Join(", ", nums1)}");

      Console.WriteLine("****************************************");

      nums1 = new int[] { 11, 12, 0, 0, 0, 0, 0 };
      nums2 = new int[] { 2, 4, 6, 8, 10 }; ;
      Console.WriteLine($"Nums1 = {String.Join(", ", nums1)}");
      Console.WriteLine($"Nums2 = {String.Join(", ", nums2)}");

      Merge2Array(nums1, 2, nums2, 5);

      Console.WriteLine($"Merged Array = {String.Join(", ", nums1)}");
    }
    public static void Merge2Array(int[] nums1, int len1, int[] nums2, int len2)
    {
      int i1 = len1 - 1;
      int i2 = len2 - 1;
      int j = len1 + len2 - 1;

      while (i1 >= 0 && i2 >= 0)
      {
        if (nums1[i1] > nums2[i2])
          nums1[j--] = nums1[i1--];
        else
          nums1[j--] = nums2[i2--];
      }

      while (i2 >= 0)
        nums1[j--] = nums2[i2--];
    }
  }
}