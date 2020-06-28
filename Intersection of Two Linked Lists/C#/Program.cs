using System;
using System.Collections.Generic;

namespace C_
{

  //Definition for singly-linked list.
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
      this.val = val;
      this.next = next;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var l1 = ArrayToList(new int[] { 1, 3, 5, 20, 30, 40 });
      var l2 = ArrayToList(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 20, 30, 40 });

      CauseListsToInterset(l1, 3, l2, 8);

      Console.Write($"List1 = "); PrintList(l1);
      Console.Write($"List2 = "); PrintList(l2);
      var commonNode = GetIntersectionNode(l1, l2);
      if (commonNode != null)
        Console.WriteLine($"Lists intersect at = {commonNode.val}");
    }

    static ListNode GetIntersectionNode(ListNode head1, ListNode head2)
    {
      if (head1 == null || head2 == null)
        return null;

      var node1 = head1;
      var node2 = head2;

      while (node1 != node2)
      {
        node1 = (node1 == null) ? head2 : node1.next;
        node2 = (node2 == null) ? head1 : node2.next;
      }

      return node1;
    }

    static ListNode ArrayToList(int[] nums)
    {
      if (nums == null || nums.Length == 0)
        return null;

      var node = new ListNode(0);
      var head = node;
      foreach (var num in nums)
      {
        node.next = new ListNode(num);
        node = node.next;
      }
      return head.next;
    }

    /********************************************
    Creating arbitrary Intersetion in Two Linkedlist
    ********************************************/
    static void CauseListsToInterset(ListNode l1, int i1, ListNode l2, int i2)
    {
      var temp1 = l1;
      var temp2 = l2;

      while (i1 != 1)
      {
        temp1 = temp1.next;
        i1--;
      }

      while (i2 != 1)
      {
        temp2 = temp2.next;
        i2--;
      }
      temp1.next = temp2.next;
    }

    static void PrintList(ListNode root)
    {
      Console.Write($"{root.val}");
      if (root.next != null)
      {
        Console.Write("-->");
        PrintList(root.next);
      }
      else
        Console.WriteLine();
    }
  }
}