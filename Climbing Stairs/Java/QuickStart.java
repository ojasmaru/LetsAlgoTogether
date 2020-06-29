import java.util.*;

class QuickStart {
  public static void main(String[] args) {

    var Ns = new int[] { 3, 4, 5, 10 };
    for (var n : Ns) {
      System.out.printf("We can climb %d stairs in = %d ways %n", n, ClimbStairs(n));
    }

    System.out.println("*****************************************");

    for (var n : Ns) {
      System.out.printf("We can climb %d stairs in = %d ways %n", n, ClimbStairs_Generic(n, new int[] { 1, 2 }));
    }
  }

  public static int ClimbStairs(int n) {
    if (n <= 0)
      return 0;
    if (n == 1)
      return 1;
    if (n == 2)
      return 2;

    int NMinus2 = 1;
    int NMinus1 = 2;
    int total = 0;

    for (int i = 3; i <= n; i++) {
      total = NMinus2 + NMinus1;
      NMinus2 = NMinus1;
      NMinus1 = total;
    }

    return total;
  }

  public static int ClimbStairs_Generic(int n, int[] steps) {
    if (n <= 0)
      return 0;
    var dp = new int[n + 1];
    dp[0] = 1;

    for (int i = 1; i <= n; i++) {
      var ways = 0;
      for (var j : steps) {
        if (i - j >= 0)
          ways += dp[i - j];
      }
      dp[i] = ways;
    }

    return dp[n];

  }

}