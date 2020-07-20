/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        
        var dummy = new ListNode(0);
        dummy.next = head;
        
        var node = dummy;
        ListNode prev = null; 
        while (node != null)
        {
            if (node.val == val && prev != null)
                prev.next = node.next;
            else        
                prev = node;
            
            node = node.next;
        }
        return dummy.next;
    }
    
    public ListNode RemoveElements1(ListNode head, int val) {
        if (head == null) return null;
        head.next = RemoveElements(head.next, val);
        return head.val == val ? head.next : head;
    }
}