using System;

namespace ReverseInteger
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("******************************************");
      Console.WriteLine($"{12345,-10} -- {Reverse2(12345)}");
      Console.WriteLine($"{-6789,-10} -- {Reverse2(-6789)}");
      Console.WriteLine($"{2147483647,-10} -- {Reverse2(2147483647)}");
      Console.WriteLine("******************************************");
    }

    static int Reverse(int x)
    {
      var result = 0;
      var temp = 0;

      while (x != 0)
      {
        var lastDigit = x % 10;
        temp = result * 10 + lastDigit;
        //Check if Overflow happened
        //Console.WriteLine($"x={x}, result={result}, temp={temp}, lastDigit={lastDigit}");
        if ((temp - lastDigit) / 10 != result)
          return 0;

        result = temp;
        x = x / 10;
      }
      return result;
    }

    static int Reverse2(int x)
    {

      if (x == Int32.MinValue)
        return 0;

      var result = 0;
      var isNeg = (x < 0) ? 1 : 0;
      /*************************************
      * Int32.MaxValue = 2147483647
      * Int32.MinValue = -2147483648 
      * Notice they both differ by 1 (if sign is ignored). This is where isNeg=1 come in play
      * Int32.MaxValue / 10 = 214748364 
      * Int32.MaxValue % 10 = 7
      *************************************/
      var limit = Int32.MaxValue / 10;
      var limit_digit = Int32.MaxValue % 10;

      x = Math.Abs(x);

      while (x != 0)
      {
        var lastDigit = x % 10;

        //WillItOverflow
        if (result > limit || (result == limit && lastDigit > (limit_digit + isNeg)))
          return 0;

        result = result * 10 + lastDigit;
        x = x / 10;
      }

      return (isNeg == 1) ? -result : result;
    }
  }
}
