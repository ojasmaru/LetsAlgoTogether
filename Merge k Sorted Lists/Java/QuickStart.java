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
    var l1 = ArrayToList(new int[] { 1, 3, 8, 10, 11, 13, 14, 100 });
    var l2 = ArrayToList(new int[] { 4, 5, 8, 12, 19, 20, 24, 25 });
    var l3 = ArrayToList(new int[] { 13, 14, 15, 16, 17, 18, 19, 20 });
    var l4 = ArrayToList(new int[] { 1, 3, 5, 7, 9, 11, 13, 15 });
    var lists = new ListNode[] { l1, l2, l3, l4 };

    for (int i = 0; i < lists.length; i++) {
      System.out.print("List" + i + " = ");
      PrintList(lists[i]);
    }

    System.out.print("Merged List = ");
    PrintList(MergeKLists(lists));
    //PrintList(MergeKLists_pq(lists));
    //PrintList(MergeKLists_Recur(lists, 0, lists.length - 1));
  }

  // ***********************************************
  // Merge K sorted lists into one using queue
  // and return the head of the merged list
  // ***********************************************/
  static ListNode MergeKLists(ListNode[] lists) {
    if (lists.length == 0)
      return null;

    Queue<ListNode> queue = new LinkedList<ListNode>();

    for (var node : lists)
      queue.add(node);

    while (queue.size() > 1) {
      var l1 = queue.remove();
      var l2 = queue.remove();

      var mergedList = MergeTwoLists(l1, l2);

      queue.add(mergedList);
    }

    return queue.remove();
  }

  // ***********************************************
  // Merge K sorted lists into one using recursive calls
  // and return the head of the merged list
  // ***********************************************/
  static ListNode MergeKLists_Recur(ListNode[] lists, int left, int right) {
    if (right < left)
      return null;
    if (right == left)
      return lists[left];

    var mid = left + (right - left) / 2;
    var l1 = MergeKLists_Recur(lists, left, mid);
    var l2 = MergeKLists_Recur(lists, mid + 1, right);

    return MergeTwoLists(l1, l2);
  }

  // ***********************************************
  // Merge K sorted lists into one using priorityqueue
  // and return the head of the merged list
  // ***********************************************/
  static ListNode MergeKLists_pq(ListNode[] lists) {

    if (lists.length == 0)
      return null;

    var pqueue = new PriorityQueue<ListNode>((o1, o2) -> o1.val - o2.val);

    var node = new ListNode(0);
    var head = node;

    for (var list_head : lists)
      pqueue.add(list_head);

    while (!pqueue.isEmpty()) {
      node.next = pqueue.poll();
      node = node.next;

      if (node.next != null)
        pqueue.add(node.next);
    }

    return head.next;

  }

  // ***********************************************
  // Merge two sorted lists into one
  // and return the head of the merged list
  // ***********************************************/
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