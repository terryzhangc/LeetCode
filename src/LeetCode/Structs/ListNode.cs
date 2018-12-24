using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Structs
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public static ListNode GenerateList(int[] list)
        {
            if (list == null || list.Length == 0)
            {
                return null;
            }
            var head = new ListNode(0);
            var p = head;
            for (int i = 0; i < list.Length; i++)
            {
                var newNode = new ListNode(list[i]);
                p.next = newNode;
                p = p.next;
            }
            return head.next;
        }
    }
}
