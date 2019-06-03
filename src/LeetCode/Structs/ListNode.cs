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
            ListNode head = null;
            ListNode p = null;
            for (int i = 0; i < list.Length; i++)
            {
                var newNode = new ListNode(list[i]);
                if (i == 0)
                {
                    head = newNode;
                    p = head;
                }
                else
                {
                    p.next = newNode;
                    p = p.next;
                }
            }
            return head;
        }

        public List<int> ToList()
        {
            var list = new List<int>();
            var pNode = this;
            while (pNode != null)
            {
                list.Add(pNode.val);
                pNode = pNode.next;
            }
            return list;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
