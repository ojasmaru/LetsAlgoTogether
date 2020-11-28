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
    
    /********************************
    Reverse output list twice approach
    *********************************/
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        var n1 = ListLength(l1);
        var n2 = ListLength(l2);
        
        var head = new ListNode(0);
        var carry = 0;
        while (n1 > 0 && n2 > 0)
        {
            var sum = carry;
            if (n1 >= n2)
            {
                sum += l1.val;
                l1 = l1.next;
                n1--;
            }
            
            if (n1 < n2)
            {
                sum += l2.val;
                l2 = l2.next;
                n2--;
            }
            
            var node = new ListNode(sum, head);
            head = node;
        }
        
        //Take care of carryover >= 10
        var temp = head;
        head = null;
        carry = 0;
        while (temp != null)
        {
            var newSum = temp.val + carry;
            var node = new ListNode(newSum % 10, head);
            head = node;
            
            carry = newSum / 10;
            temp = temp.next;
        }
        
        //Remove leading zero (no carry over on first digit)
        return (head.val == 0)? head.next : head;
    }
    
    public int ListLength(ListNode node)
    {
        var len = 0;
        while (node != null)
        {
            node = node.next;
            len++;
        }
        
        return len;
    }
    
    /********************************
    Stack approach
    *********************************/
    public ListNode AddTwoNumbers2(ListNode l1, ListNode l2) 
    {
        var stack1 = ListToStack(l1);
        var stack2 = ListToStack(l2);
        
        var dummy = new ListNode();
        var carry = 0;
        while (stack1.Count != 0 || stack2.Count != 0)
        {
            var sum = carry;
            sum += (stack1.Count > 0)? stack1.Pop() : 0;
            sum += (stack2.Count > 0)? stack2.Pop() : 0;
            
            dummy.val = sum % 10;
            carry = sum / 10;
            
            var head = new ListNode(carry, dummy);
            dummy = head;
        }
        
        //Check whether dummy (head) node contains carry over value
        return (dummy.val == 0)? dummy.next : dummy;
    }
    
    public Stack<int> ListToStack(ListNode node)
    {
        var stack = new Stack<int>();
        while (node != null)
        {
            stack.Push(node.val);
            node = node.next;
        }
        
        return stack;
    }
    
    /********************************
    Reverse List approach
    *********************************/
    public ListNode AddTwoNumbers1(ListNode l1, ListNode l2) 
    {
        l1 = ReverseList(l1);
        l2 = ReverseList(l2);
        
        var dummy = new ListNode();
        var curr = dummy;
        var carry = 0;
        while (l1 != null || l2 != null || carry > 0)
        {
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
            
            curr.next = new ListNode(sum);
            curr = curr.next;
            
            l1 = l1?.next;
            l2 = l2?.next;
        }
        
        return ReverseList(dummy.next);
    }
    
    
    public ListNode ReverseList(ListNode node) 
    {
        var dummy = new ListNode();
        ListNode prev = null;
        var curr = node;
        
        while (curr != null)
        {
            var temp = curr.next;
            curr.next = prev;
            
            prev = curr;
            curr = temp;
        }
        
        return prev;
    }
    
}