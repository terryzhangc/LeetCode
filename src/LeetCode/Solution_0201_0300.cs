using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution_0201_0300 : Solution
    {
        public Solution_0201_0300() : base()
        {

        }


        /// <summary>
        /// LC_0206
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = null;
            ListNode cursor = head;
            while (cursor != null)
            {
                var temp = cursor;
                cursor = cursor.next;
                temp.next = newHead;
                newHead = temp;
            }
            return newHead;
        }

        /// <summary>
        /// LC_0237
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            ListNode preCursor = null;
            ListNode cursor = node;
            while (cursor.next != null)
            {
                preCursor = cursor;
                cursor = cursor.next;
                if (cursor != null)
                    preCursor.val = cursor.val;
            }
            preCursor.next = null;
        }
    }
}
