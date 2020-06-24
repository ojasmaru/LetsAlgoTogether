import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    int[][] nums2d = { new int[] { 3, 3, 2, 2, 10 }, new int[] { 10, 2, 4, 10, 3, 4, 2 } };
    for (int[] nums : nums2d) {
      System.out.println("*********************************");
      System.out.println("Nums Array = " + Arrays.toString(nums));
      System.out.println("Single Number = " + SingleNumber(nums));
    }
  }

  static int SingleNumber(int[] nums) {
    int ans = 0;
    for (var num : nums) {
      ans ^= num;
    }
    return ans;
  }
}