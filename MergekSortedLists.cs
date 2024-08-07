// 題目請見此網址
// https://leetcode.com/problems/merge-k-sorted-lists/description/

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}
 
public class sameValueNodes{
    public ListNode head, tail;

    public sameValueNodes(ListNode h, ListNode t){
        this.head = h;
        this.tail = t;
    }
}

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {

        SortedDictionary<int, sameValueNodes> sortedLists = new SortedDictionary<int, sameValueNodes>();
        ListNode result = null, node, prevNode = null;
        int value;
        int length = lists.Length;

        for(int i = 0; i < length; i++){
            node = lists[i];

            while(node != null){
                value = node.val;

                if(!sortedLists.ContainsKey(value)){
                    sortedLists[value] = new sameValueNodes(node, node);
                } else {
                    sortedLists[value].tail.next = node;
                    sortedLists[value].tail = node;
                }
                node = node.next;
            }
        }

        foreach(sameValueNodes n in sortedLists.Values){
            if(prevNode == null){
                result = n.head;
                prevNode = n.tail;
            } else {
                prevNode.next = n.head;
                prevNode = n.tail;
            }
        }

        return result;
    }
}