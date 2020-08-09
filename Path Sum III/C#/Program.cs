/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
  
  public int PathSum(TreeNode root, int sum) 
  {  
    var dict = new Dictionary<int, int>();
    dict[0] = 1;
    return Traverse(root, dict, 0, sum);
  }
  
  public int Traverse(TreeNode node, Dictionary<int, int> dict, int running_sum, int target) 
  {
    if (node == null)
      return 0;
    
    running_sum += node.val;
    
    //Find the count
    dict.TryGetValue(running_sum - target, out var count);
    
    
    dict.TryGetValue(running_sum, out var temp);
    dict[running_sum] = temp + 1;
    
    count += Traverse(node.left, dict, running_sum, target);
    count += Traverse(node.right, dict, running_sum, target);
    
    dict[running_sum]--;
    
    return count;
  }
  
  /*
  public int PathSum(TreeNode root, int sum) {  
    if (root == null)
      return 0;
    
    return PathSum(root.left, sum)
      + PathSum(root.right, sum)
      + PathSum2(root, sum);
  }
  
  public int PathSum2(TreeNode node, int sum) 
  { 
    if (node == null)
      return 0;
    
    var count = 0;
    if (node.val == sum)
      count = 1;
    
    var newSum = sum - node.val;
    count += PathSum2(node.left, newSum);
    count += PathSum2(node.right, newSum);
    
    return count;
  }
  
  */
}
