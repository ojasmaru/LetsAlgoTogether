import java.util.*;
import java.util.stream.Collectors;

class QuickStart {
  public static void main(String[] args) {

    var rows = 10;
    var result = Pascal_Triangle(rows);
    for (var row : result) {
      // Print blank spaces
      for (int i = 0; i < rows; i++)
        System.out.print(" ");

        String str = row.stream().map(String::valueOf).collect(Collectors.joining(" "));

      //System.out.println(String.join(" ", row));
      System.out.println(str);
      rows--;
    }

  }

  static List<List<Integer>> Pascal_Triangle(int rows) {

    var result = new ArrayList<List<Integer>>();

    if (rows == 0)
      return result;

    var row = new ArrayList<Integer>();
    for (int i = 0; i < rows; i++) {
      row.add(0, 1);
      for (int j = 1; j < i; j++) {
        row.set(j, row.get(j) + row.get(j + 1));
      }
      result.add(new ArrayList<Integer>(row));
    }
    return result;
  }
}