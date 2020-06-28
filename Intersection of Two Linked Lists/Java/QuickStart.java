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
    var l1 = ArrayToList(new int[] { 1, 3, 5, 20, 30, 40 });
    var l2 = ArrayToList(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 20, 30, 40 });

    CauseListsToInterset(l1, 3, l2, 8);

    System.out.print("List1 = ");
    PrintList(l1);
    System.out.print("List2 = ");
    PrintList(l2);

    var commonNode = GetIntersectionNode(l1, l2);
    if (commonNode != null)
      System.out.println("Lists intersect at = " + commonNode.val);

  }

  static ListNode GetIntersectionNode(ListNode head1, ListNode head2) {
    if (head1 == null || head2 == null)
      return null;

    var node1 = head1;
    var node2 = head2;

    while (node1 != node2) {
      node1 = (node1 == null) ? head2 : node1.next;
      node2 = (node2 == null) ? head1 : node2.next;
    }

    return node1;
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

  /********************************************
   * Creating arbitrary Intersetion in Two Linkedlist
   ********************************************/
  static void CauseListsToInterset(ListNode l1, int i1, ListNode l2, int i2) {
    var temp1 = l1;
    var temp2 = l2;

    while (i1 != 1) {
      temp1 = temp1.next;
      i1--;
    }

    while (i2 != 1) {
      temp2 = temp2.next;
      i2--;
    }
    temp1.next = temp2.next;
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