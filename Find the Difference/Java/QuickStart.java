import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    String[][] nums2d = { new String[] { "abcdef", "fedcbaz" }, new String[] { "aabbddee", "abdeqabde" } };
    for (String[] strArr : nums2d) {
      System.out.println("*********************************");
      System.out.println("s1 = " + strArr[0] + " s2 = " + strArr[1]);
      System.out.println("Difference = " + FindTheDifference(strArr[0], strArr[1]));
    }
  }

  static char FindTheDifference(String s1, String s2) {
    var len = s2.length();
    char miss_ch = s2.charAt(len - 1);
    for (int i = 0; i < len - 1; i++) {
      miss_ch ^= s1.charAt(i);
      miss_ch ^= s2.charAt(i);
    }

    return miss_ch;
  }
}