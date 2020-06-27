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
    var l1 = ArrayToList(new int[] { 1, 3, 8, 10, 5, 100, 7 });
    var l2 = ArrayToList(new int[] { 5, 10, 15, 20, 25 });

    var lists = new ListNode[] { l1, l2 };

    for (int i = 0; i < lists.length; i++) {
      System.out.print("List" + i + " = ");
      PrintList(lists[i]);
      if (i == 0)
        CreateCycle(lists[i], 3);

      var cycleNode = DetectCycle(lists[i]);
      if (cycleNode != null)
        System.out.println("List has cycle at = " + cycleNode.val);
      else
        System.out.println("List does not have has cycle");
    }

  }

  static ListNode DetectCycle(ListNode head) {
    if (head == null)
      return head;

    var isCycle = false;
    var slow = head;
    var fast = head;

    while (fast != null && fast.next != null) {

      slow = slow.next;
      fast = fast.next.next;
      if (slow == fast) {
        isCycle = true;
        break;
      }
    }

    if (isCycle) {
      var slow2 = head;
      while (slow != slow2) {
        slow = slow.next;
        slow2 = slow2.next;
      }
      return slow;
    }
    return null;

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
   * Creating arbitrary cycle in Linkedlist and index Assuming Index would be less
   * than the length of the list and root is not null
   ********************************************/
  static void CreateCycle(ListNode root, int index) {
    ListNode temp1 = null;

    var node = root;
    while (index != 0) {
      node = node.next;
      index--;
    }

    temp1 = node;

    while (node.next != null)
      node = node.next;

    node.next = temp1;
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