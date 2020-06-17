import java.util.*;

class QuickStart {
  public static void main(String[] args) {
    String[] romans = new String[] { "IV", "VI", "LX", "XL", "MMCVI", "MCMIV", "XXVII" };
    for (String roman : romans) {
      System.out.printf("%s = %d %n", roman, romanToInt(roman));
    }
  }

  static int romanToInt(String s) {
    Map<Character, Integer> map = Map.of('I', 1, 'V', 5, 'X', 10, 'L', 50, 'C', 100, 'D', 500, 'M', 1000);

    int len = s.length();

    // Store the last char value in result
    // And then start traversing the string in reverse order
    // If the numbers are increasing (in reverse) then add
    // else subtract
    int result = map.get(s.charAt(len - 1));
    for (int i = len - 1; i > 0; i--) {
      if (map.get(s.charAt(i - 1)) >= map.get(s.charAt(i)))
        result += map.get(s.charAt(i - 1));
      else
      result -= map.get(s.charAt(i - 1));
    }

    return result;
  }

}