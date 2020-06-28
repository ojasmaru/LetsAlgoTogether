using System;
using System.Collections.Generic;

namespace C_
{
  class Program
  {
    static void Main(string[] args)
    {
      var Xs = new int[] { 8, 120, 122 };
      foreach (var x in Xs)
      {
        Console.WriteLine($"Sqrt({x}) == {MySqrt(x)}");
      }
    }
    static int MySqrt(int x)
    {
      var left = 1;
      var right = x;

      if (x < 2)
        return x;

      while (left < right)
      {
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
}