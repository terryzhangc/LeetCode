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
        /// LC_0203
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;
            ListNode newHead = new ListNode(0) { next = head };
            ListNode cursor = newHead;
            while (cursor.next != null)
            {
                if (cursor.next.val == val)
                {
                    cursor.next = cursor.next.next;
                }
                else
                {
                    cursor = cursor.next;
                }
            }
            return newHead.next;
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
        /// LC_0234
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;
            var slow = head;
            var fast = head;
            ListNode preEnd = null;
            ListNode reverseHead = null;
            while (fast != null && fast.next != null)
            {
                preEnd = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            preEnd.next = null;
            while (slow != null)
            {
                var temp = slow;
                slow = slow.next;
                temp.next = reverseHead;
                reverseHead = temp;
            }
            var left = head;
            var right = reverseHead;

            while (left != null && right != null)
            {
                if (left.val != right.val)
                    break;
                left = left.next;
                right = right.next;
            }
            if (left == null || right == null)
                return true;
            return false;
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
