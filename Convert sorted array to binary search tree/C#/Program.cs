using System;
using System.Collections.Generic;

namespace C_
{

  //Definition for singly-linked list.
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0)
    {
      this.val = val;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {

      SortedArrayToBST(new int[] {-3,-2,-1,0,1,2,3});
      SortedArrayToBST(new int[] {-4,-3,-2,-1,0,1,2,3, 4});
    }

    public static TreeNode SortedArrayToBST(int[] nums) 
    {
        
        if (nums == null || nums.Length == 0)
            return null;
        
        return MakeBST(nums, 0, nums.Length - 1);
    }

    public static TreeNode MakeBST(int[] nums, int low, int high) 
    {
        if (low > high)
            return null;
        
        int middle = (low + high) / 2;
        var root = new TreeNode(nums[middle]);
        root.left = MakeBST(nums, low, middle - 1);
        root.right = MakeBST(nums, middle + 1, high);
        
        return root;
    }
  }
}