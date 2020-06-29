using System;
using System.Collections.Generic;

namespace C_
{
  class Program
  {
    static void Main(string[] args)
    {
      var Ns = new int[] { 3, 4, 5, 10 };
      foreach (var n in Ns)
      {
        Console.WriteLine($"We can climb {n} stairs in = {ClimbStairs(n)} ways");
      }

      Console.WriteLine("*****************************************");
      foreach (var n in Ns)
      {
        Console.WriteLine($"We can climb {n} stairs in = {ClimbStairs_Generic(n, new int[] { 1, 2 })} ways");
      }
    }
    public static int ClimbStairs(int n)
    {
      if (n <= 0) return 0;
      if (n == 1) return 1;
      if (n == 2) return 2;

      int NMinus2 = 1;
      int NMinus1 = 2;
      int total = 0;

      for (int i = 3; i <= n; i++)
      {
        total = NMinus2 + NMinus1;
        NMinus2 = NMinus1;
        NMinus1 = total;
      }

      return total;

    }

    public static int ClimbStairs_Generic(int n, int[] steps)
    {
      if (n <= 0) return 0;
      var dp = new int[n + 1];
      dp[0] = 1;

      for (int i = 1; i <= n; i++)
      {
        var ways = 0;
        foreach (var j in steps)
        {
          if (i - j >= 0)
            ways += dp[i - j];
        }

        dp[i] = ways;
      }

      return dp[n];

    }
  }
}