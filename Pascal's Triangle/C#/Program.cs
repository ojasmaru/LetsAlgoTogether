using System;
using System.Collections.Generic;

namespace C_
{
  class Program
  {
    static void Main(string[] args)
    {
      var rows = 5;
      var result = Pascal_Triangle(rows);
      foreach (var row in result)
      {
        //Print blank spaces
        for (int i = 0; i < rows; i++)
          Console.Write(" ");

        Console.WriteLine(String.Join(" ", row));
        rows--;
      }
    }

    public static IList<IList<int>> Pascal_Triangle(int rows)
    {
      var result = new List<IList<int>>();

      if (rows == 0)
        return result;

      var row = new List<int>();
      for (int i = 0; i < rows; i++)
      {
        row.Insert(0, 1);
        for (int j = 1; j < i; j++)
        {
          row[j] = row[j] + row[j + 1];
        }
        result.Add(new List<int>(row));
      }
      return result;
    }

  }
}