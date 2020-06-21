import java.util.*;

class ListNode {
  int val;
  ListNode next;

  ListNode() {
  }

  ListNode(int val) {
    this.val = val;
    next = null;
  }

  ListNode(int val, ListNode next) {
    this.val = val;
    this.next = next;
  }
}

class QuickStart {
  public static void main(String[] args) {
    //var l1 = ArrayToList(new int[] { 1, 3, 8, 10 });
    //var l2 = ArrayToList(new int[] { 1, 4, 5, 6 });

    var l1 = ArrayToList(new int[] { 10, 20, 30 });
    var l2 = ArrayToList(new int[] { 1, 2, 3 });
    System.out.print("List1 = "); 
    PrintList(l1);
    System.out.print("List2 = ");
    PrintList(l2);
    System.out.print("Merged List = ");
    PrintList(MergeTwoLists(l1, l2));
  }

  static ListNode MergeTwoLists(ListNode l1, ListNode l2) {
    // Dummy Node
    var node = new ListNode(0);
    var head = node;

    while (l1 != null || l2 != null) {
      // Take node for L1 List
      if (l2 == null || (l1 != null && l1.val < l2.val)) {
        node.next = l1;
        l1 = l1.next;
      }
      // Take node for L2 List
      else {
        node.next = l2;
        l2 = l2.next;
      }
      node = node.next;
    }

    return head.next;
  }

  static ListNode ArrayToList(int[] nums) {
    if (nums == null || nums.length == 0)
      return null;
    var node = new ListNode(0);
    var head = node;

    for (var num : nums) {
      node.next = new ListNode(num);
      node = node.next;
    }

    return head.next;
  }

  static void PrintList(ListNode root) {
    System.out.print(root.val);
    if (root.next != null) {
      System.out.print("-->");
      PrintList(root.next);
    } else
      System.out.println();
  }

}