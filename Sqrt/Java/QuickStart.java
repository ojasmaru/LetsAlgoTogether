import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    var Xs = new int[] { 8, 120, 122 };
    for (var x : Xs) {
      System.out.printf("Sqrt(%d) == %d %n", x, MySqrt(x));
    }
  }

  static int MySqrt(int x) {
    var left = 1;
    var right = x;

    if (x < 2)
      return x;

    while (left < right) {
      var mid = (left + right) / 2;
      var temp = x / mid;
      if (temp == mid)
        return mid;
      else if (temp < mid)
        right = mid;
      else
        left = mid + 1;
    }

    return left - 1;
  }

}