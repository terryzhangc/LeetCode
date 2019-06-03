using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution_0401_0500 : Solution
    {
        public Solution_0401_0500() : base()
        {

        }

        /// <summary>
        /// LC_0445
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var stack1 = new Stack<ListNode>();
            var stack2 = new Stack<ListNode>();
            var cursor1 = l1;
            var cursor2 = l2;
            ListNode result = null;
            while (cursor1 != null)
            {
                stack1.Push(cursor1);
                cursor1 = cursor1.next;
            }
            while (cursor2 != null)
            {
                stack2.Push(cursor2);
                cursor2 = cursor2.next;
            }
            var hasPre = false;
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                var value = (hasPre ? 1 : 0);
                value += stack1.Count > 0 ? stack1.Pop().val : 0;
                value += stack2.Count > 0 ? stack2.Pop().val : 0;
                hasPre = value > 9 ? true : false;
                var tempNode = new ListNode(hasPre ? value - 10 : value);
                tempNode.next = result;
                result = tempNode;
            }
            if (hasPre)
            {
                hasPre = false;
                var tempNode = new ListNode(1);
                tempNode.next = result;
                result = tempNode;
            }
            return result;
        }
    }
}
