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
    
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var n1 = ListLength(l1);
        var n2 = ListLength(l2);
        
        var dummy = new ListNode(0);
        var carry = 0;
        
        while (n1 > 0 && n2 > 0) {
            var sum = carry;
            if (n1 >= n2) {
                sum += l1.val;
                l1 = l1.next;
                n1--;
            }
            
            if (n1 < n2) {
                sum += l2.val;
                l2 = l2.next;
                n2--;
            }
            
            var head = new ListNode(sum, dummy);
            dummy = head;
        }
        
        //Take care of carry & reverse the list
        var node = dummy;
        dummy = null;
        carry = 0;
        while (node != null) {
            var newSum = node.val + carry;
            var temp = new ListNode(newSum % 10, dummy);
            
            carry = newSum / 10;
            dummy = temp;
            node = node.next;
        }
        
        //Check whether dummy (head) node contains carry over value
        return (dummy.val == 0)? dummy.next : dummy;
    }
    
    public int ListLength(ListNode node) {
        var len = 0;
        while (node != null)
        {
            node = node.next;
            len++;
        }
        return len;
    }
    
    public ListNode addTwoNumbersStack(ListNode l1, ListNode l2) {
        
        var s1 = listToStack(l1);
        var s2 = listToStack(l2);
        
        var dummy = new ListNode();
        var carry = 0;
        
        while (!s1.empty() || !s2.empty()) {
            var sum = carry;
            if (!s1.empty()) sum += s1.pop();
            if (!s2.empty()) sum += s2.pop();
            
            dummy.val = sum % 10;
            carry = sum / 10;
            
            var head = new ListNode(carry, dummy);
            dummy = head;
        }
        
        //Check whether dummy (head) node contains carry over value
        return (dummy.val == 0)? dummy.next : dummy;
    }
    
    public Stack<Integer> listToStack(ListNode node) {
        var stack = new Stack<Integer>();
        
         while(node != null) {
            stack.push(node.val);
            node = node.next;
        };
        
        return stack;
    }
        
    public ListNode addTwoNumbersReverse(ListNode l1, ListNode l2) {
        l1 = reverseList(l1);
        l2 = reverseList(l2);
        
        //Head node for output list
        var dummy = new ListNode();
        var node = dummy;
        var carry = 0;
        while (l1 != null || l2 != null || carry > 0) {
            var sum = carry;
            sum += (l1 != null)? l1.val : 0;
            sum += (l2 != null)? l2.val : 0;
            
            if (sum >= 10)
            {
                sum = sum % 10;
                carry = 1;
            }
            else
                carry = 0;
            
            node.next = new ListNode(sum);
            node = node.next;
            
            l1 = (l1 == null)? l1: l1.next;
            l2 = (l2 == null)? l2: l2.next;
        }
        
        return reverseList(dummy.next);
    }
    
    public ListNode reverseList(ListNode node) {
        ListNode prev = null;
        while (node != null) {
            var temp = node.next;
            node.next = prev;
            
            prev = node;
            node = temp;
        }
        return prev;
    }
}