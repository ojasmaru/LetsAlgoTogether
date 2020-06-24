using System;
using System.Collections.Generic;

namespace Find_the_Difference
{
  class Program
  {
    static void Main(string[] args)
    {
      var str2d = new string[2][]
      {
        new string[]{"abcdef","fedcbaz"},
        new string[]{"aabbddee","abdeqabde"},
      };

      foreach (var strArr in str2d)
      {
        Console.WriteLine("*********************************");
        Console.WriteLine($"s1 = {strArr[0]}, s2 = {strArr[1]}");
        Console.WriteLine($"Difference = {FindTheDifference(strArr[0], strArr[1])}");
      }

    }

    static char FindTheDifference(string s1, string s2)
    {
      var len = s2.Length;
      char miss_ch = s2[len - 1];
      for (int i = 0; i < len - 1; i++)
      {
        miss_ch ^= s1[i];
        miss_ch ^= s2[i];
      }

      return miss_ch;
    }
  }
}
