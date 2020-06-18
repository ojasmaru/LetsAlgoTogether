class QuickStart {
  public static void main(String[] args) {
    System.out.println("******************************************");
    System.out.println("12345 -- " + Reverse(12345));
    System.out.println("-6789 -- " + Reverse(-6789));
    System.out.println("2147483647 -- " + Reverse(2147483647));
    System.out.println("******************************************");
  }

  static int Reverse(int x) {
    var result = 0;
    var temp = 0;

    while (x != 0) {
      var lastDigit = x % 10;
      temp = result * 10 + lastDigit;

      //Check if Overflow happened 
      if ((temp - lastDigit) / 10 != result)
        return 0;

      result = temp;
      x = x / 10;
    }

    return result;
  }

  static int Reverse2(int x) {
    if (x == Integer.MIN_VALUE)
      return 0;

    var result = 0;
    var isNeg = (x < 0) ? 1 : 0;
    /*************************************
    * Integer.MaxValue = 2147483647
    * Integer.MinValue = -2147483648 
    * Notice they both differ by 1 (if sign is ignored). This is where isNeg=1 come in play
    * Integer.MaxValue / 10 = 214748364 
    * Integer.MaxValue % 10 = 7
    *************************************/
    var limit = Integer.MAX_VALUE / 10;
    var limit_digit = Integer.MAX_VALUE % 10;

    x = Math.abs(x);

    while (x != 0) {
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