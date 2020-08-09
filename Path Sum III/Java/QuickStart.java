/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
  public int pathSum(TreeNode root, int sum) {
      HashMap<Integer, Integer> map = new HashMap();
      map.put(0,1);
      return pathSum2(root, 0, sum, map);
  }
    
  public int pathSum2(TreeNode root, int runningSum, int target, HashMap<Integer, Integer> map) {
      if (root == null) {
          return 0;
      }

      runningSum += root.val;
      int count = map.getOrDefault(runningSum - target, 0);
      map.put(runningSum, map.getOrDefault(runningSum, 0) + 1);

      count += pathSum2(root.left, runningSum, target, map) 
        + pathSum2(root.right, runningSum, target, map);
    
      map.put(runningSum, map.get(runningSum) - 1);
      return count;
  }
  
  /*
  public int pathSum(TreeNode root, int sum) {  
    if (root == null)
      return 0;
    
    return pathSum(root.left, sum)
      + pathSum(root.right, sum)
      + pathSum2(root, sum);
  }
  
  public int pathSum2(TreeNode node, int sum) 
  { 
    if (node == null)
      return 0;
    
    var count = 0;
    if (node.val == sum)
      count = 1;
    
    var newSum = sum - node.val;
    count += pathSum2(node.left, newSum);
    count += pathSum2(node.right, newSum);
    
    return count;
  }
  */
}