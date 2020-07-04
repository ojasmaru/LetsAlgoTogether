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
              2     3
            /     / \
            4     6   7
            \   /     \
              5 8       9
                \
                  10
    */
    var root = new TreeNode(1);
    root.left = new TreeNode(2);
    root.right = new TreeNode(3);

    // child of 2
    root.left.left = new TreeNode(4);
    root.left.left.right = new TreeNode(5);

    // Child of 3
    root.right.left = new TreeNode(6);
    root.right.right = new TreeNode(7);

    root.right.left.left = new TreeNode(8);
    root.right.left.left.right = new TreeNode(10);

    root.right.right.right = new TreeNode(9);

    System.out.println("Max Depth of the binary Tree = " + MaxDepth(root));

  }

  public static int MaxDepth(TreeNode root)
    {
      if (root == null)
        return 0;

      if (root.left == null && root.right == null)
        return 1;

      return Math.max(MaxDepth(root.left), 
      MaxDepth(root.right)) + 1;

    }

}