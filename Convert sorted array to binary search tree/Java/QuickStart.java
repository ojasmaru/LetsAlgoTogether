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
    SortedArrayToBST(new int[] { -3, -2, -1, 0, 1, 2, 3 });
    SortedArrayToBST(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 });

  }

  public static TreeNode SortedArrayToBST(int[] nums) {

    if (nums == null || nums.length == 0)
      return null;

    return MakeBST(nums, 0, nums.length - 1);
  }

  public static TreeNode MakeBST(int[] nums, int low, int high) {
    if (low > high)
      return null;

    int middle = (low + high) / 2;
    var root = new TreeNode(nums[middle]);
    root.left = MakeBST(nums, low, middle - 1);
    root.right = MakeBST(nums, middle + 1, high);

    return root;
  }

}