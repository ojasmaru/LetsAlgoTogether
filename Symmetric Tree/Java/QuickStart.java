import java.util.*;

class TreeNode {
  public int val;
  public TreeNode left;
  public TreeNode right;

  public TreeNode(int val) {
    this.val = val;
  }
}

class QuickStart {
  public static void main(String[] args) {
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

    System.out.println("Is Tree Symmetric = " + IsSymmetric(root));

  }

  public static boolean IsSymmetric(TreeNode root) {
    if (root == null)
      return true;

    return IsSame(root.left, root.right);
  }

  public static boolean IsSame(TreeNode left, TreeNode right) {
    if (left == null || right == null)
      return (left == right);

    if (left.val != right.val)
      return false;

    return IsSame(left.left, right.right) 
        && IsSame(left.right, right.left);
  }

}