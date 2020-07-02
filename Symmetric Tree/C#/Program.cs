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
      /*
                  1
                /   \
               2     2
              / \   / \
             3   4 4   3
      */
      var root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right = new TreeNode(2);

      root.left.left = new TreeNode(3);
      root.right.right = new TreeNode(3);

      root.left.right = new TreeNode(4);
      root.right.left = new TreeNode(4);

      Console.WriteLine($"Is Tree Symmetric = {IsSymmetric(root)}");
    }

    public static bool IsSymmetric(TreeNode root)
    {
      if (root == null)
        return true;

      return IsSame(root.left, root.right);
    }

    public static bool IsSame(TreeNode left, TreeNode right)
    {
      if (left == null || right == null)
        return (left == right);

      if (left.val != right.val)
        return false;

      return IsSame(left.left, right.right) 
          && IsSame(left.right, right.left);
    }
  }
}