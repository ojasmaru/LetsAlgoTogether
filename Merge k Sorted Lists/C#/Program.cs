using System;
using System.Collections.Generic;

namespace Merge_k_Sorted_Lists
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
      var l1 = ArrayToList(new int[] { 1, 3, 8, 10, 11, 13, 14, 100 });
      var l2 = ArrayToList(new int[] { 4, 5, 8, 12, 19, 20, 24, 25 });
      var l3 = ArrayToList(new int[] { 13, 14, 15, 16, 17, 18, 19, 20 });
      var l4 = ArrayToList(new int[] { 1, 3, 5, 7, 9, 11, 13, 15 });
      var lists = new ListNode[] { l1, l2, l3, l4 };

      for (int i = 0; i < lists.Length; i++)
      {
        Console.Write($"List{i} = ");
        PrintList(lists[i]);
      }

      Console.Write("Merged List = ");
      PrintList(MergeKLists(lists));
      //PrintList(MergeKLists_Recur(lists, 0, lists.Length - 1));
    }

    //***********************************************
    //Merge K sorted lists into one using queue
    //and return the head of the merged list
    //***********************************************/
    static ListNode MergeKLists(ListNode[] lists)
    {
      if (lists.Length == 0) return null;

      var queue = new Queue<ListNode>();

      foreach (var node in lists)
        queue.Enqueue(node);
      while (queue.Count > 1)
      {
        var l1 = queue.Dequeue();
        var l2 = queue.Dequeue();

        var mergedList = MergeTwoLists(l1, l2);

        queue.Enqueue(mergedList);
      }

      return queue.Dequeue();
    }

    //***********************************************
    //Merge K sorted lists into one using recursive calls
    //and return the head of the merged list
    //***********************************************/
    static ListNode MergeKLists_Recur(ListNode[] lists, int left, int right)
    {
      if (right < left) return null;
      if (right == left) return lists[left];

      var mid = left + (right - left) / 2;
      var l1 = MergeKLists_Recur(lists, left, mid);
      var l2 = MergeKLists_Recur(lists, mid + 1, right);

      return MergeTwoLists(l1, l2);
    }

    //***********************************************
    //Merge two sorted lists into one
    //and return the head of the merged list
    //***********************************************/
    static ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
      //Dummy Node
      var node = new ListNode(0);
      var head = node;

      while (l1 != null || l2 != null)
      {
        //Take node for L1 List
        if (l2 == null || (l1 != null && l1.val < l2.val))
        {
          node.next = l1;
          l1 = l1.next;
        }
        //Take node for L2 List
        else
        {
          node.next = l2;
          l2 = l2.next;
        }
        node = node.next;
      }

      return head.next;
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