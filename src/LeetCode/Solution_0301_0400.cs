using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution_0301_0400 : Solution
    {
        public Solution_0301_0400() : base()
        {

        }

        /// <summary>
        /// LC_0328
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
                return head;
            var odd = head;
            var even = head.next;
            var evenList = head.next;
            while (odd?.next != null && even?.next != null)
            {
                odd.next = odd.next.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }
            odd.next = evenList;
            return head;
        }
    }
}
