using System;
using System.Collections.Generic;

namespace Valid_Parentheses
{
  class Program
  {
    static void Main(string[] args)
    {
      var strs = new string[] { "()[]{}", "(({{}}))", "(([[]]}" };
      foreach (var str in strs)
        Console.WriteLine($"{str} = {IsValid(str)}");
    }

    static bool IsValid(string s)
    {

      var stack = new Stack<char>();
      foreach (var c in s)
      {
        if (c == '(')
          stack.Push(')');
        else if (c == '{')
          stack.Push('}');
        else if (c == '[')
          stack.Push(']');
        else if (stack.Count == 0 || stack.Pop() != c)
          return false;
      }
      return stack.Count == 0;
    }
  }
}
