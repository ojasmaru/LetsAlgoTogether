using System;
using System.Collections.Generic;

namespace Roman_to_Integer
{
  class Program
  {
    static void Main(string[] args)
    {
      var romans = new string[] { "IV", "VI", "LX", "XL", "MMCVI", "MCMIV", "XXVII"};
      foreach(var roman in romans)
        Console.WriteLine($"{roman} = {RomanToInt(roman)}");
    }
    static int RomanToInt(string s)
    {
      var dict = new Dictionary<char, int>() {
          {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
      };

      var len = s.Length;

      //Store the last char value in result 
      //And then start traversing the string in reverse order
      //If the numbers are increasing (in reverse) then add
      //else subtract
      var result = dict[s[len - 1]];
      for (int i = len - 1; i > 0; i--)
      {
        if (dict[s[i - 1]] >= dict[s[i]])
          result += dict[s[i - 1]];
        else
          result -= dict[s[i - 1]];
      }

      return result;
    }
  }
}