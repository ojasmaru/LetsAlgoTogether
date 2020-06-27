using System;
using System.Collections.Generic;

namespace Linked_List_Cycle_II
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
      var l1 = ArrayToList(new int[] { 1, 3, 8, 10, 5, 100, 7 });
      var l2 = ArrayToList(new int[] { 5, 10, 15, 20, 25 });

      var lists = new ListNode[] { l1, l2 };

      for (int i = 0; i < lists.Length; i++)
      {
        Console.Write($"List{i} = ");
        PrintList(lists[i]);
        if (i == 0)
          CreateCycle(lists[i], 3);
        var cycleNode = DetectCycle(lists[i]);
        if (cycleNode != null)
          Console.WriteLine($"List has cycle at = {cycleNode.val}");
        else
          Console.WriteLine($"List does not have has cycle");
      }
    }

    static ListNode DetectCycle(ListNode head)
    {
      if (head == null)
        return head;

      var isCycle = false;
      var slow = head;
      var fast = head;

      while (fast != null && fast.next != null)
      {
        //Console.WriteLine($"Slow={slow.val}, Fast={fast.val}");
        slow = slow.next;
        fast = fast.next.next;

        if (slow == fast)
        {
          isCycle = true;
          break;
        }
      }

      //Console.WriteLine($"Slow={slow.val}, Fast={fast.val}");
      if (isCycle)
      {
        var slow2 = head;
        while (slow != slow2)
        {
          //Console.WriteLine($"Slow2={slow2.val}, Slow={slow.val}");
          slow = slow.next;
          slow2 = slow2.next;
        }
        return slow;
      }

      return null;

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
    Creating arbitrary cycle in Linkedlist and index
    Assuming Index would be less than the length of the list
      and root is not null
    ********************************************/
    static void CreateCycle(ListNode root, int index)
    {
      ListNode temp1 = null;

      var node = root;
      while (index != 0)
      {
        node = node.next;
        index--;
      }

      temp1 = node;

      while (node.next != null)
        node = node.next;

      node.next = temp1;
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