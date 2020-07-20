/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode removeElements(ListNode head, int val) {
        var dummy = new ListNode(0);
        dummy.next = head;

        var node = dummy;
        ListNode prev = null; 
        while (node != null) {
            if (node.val == val && prev != null)
                prev.next = node.next;
            else        
                prev = node;
            
            node = node.next;
        }
        return dummy.next;
    }
    
    public ListNode removeElements1(ListNode head, int val) {
        if (head == null) return null;
        head.next = removeElements(head.next, val);
        return head.val == val ? head.next : head;
    }
}