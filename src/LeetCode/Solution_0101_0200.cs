﻿using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution_0101_0200 : Solution
    {
        public Solution_0101_0200() : base()
        {

        }

        /// <summary>
        /// LC_0108
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return SortedListToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedListToBST(int[] list, int start, int end)
        {
            if (start > end)
                return null;
            var middle = (start + end) / 2;
            var treeNode = new TreeNode(list[middle]);
            treeNode.left = SortedListToBST(list, start, middle - 1);
            treeNode.right = SortedListToBST(list, middle + 1, end);
            return treeNode;
        }

        /// <summary>
        /// LC_0109
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return new TreeNode(head.val);
            //var list = new List<ListNode>();
            //var cursor = head;
            //while (cursor != null)
            //{
            //    list.Add(cursor);
            //    cursor = cursor.next;
            //}
            //return SortedListToBST(list, 0, list.Count - 1);

            ListNode preCursor = null;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                preCursor = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            var treeNode = new TreeNode(slow.val);
            preCursor.next = null;
            treeNode.left = SortedListToBST(head);
            treeNode.right = SortedListToBST(slow.next);
            return treeNode;
        }

        private TreeNode SortedListToBST(List<ListNode> list, int start, int end)
        {
            if (start > end)
                return null;
            var middle = (start + end) / 2;
            var treeNode = new TreeNode(list[middle].val);
            treeNode.left = SortedListToBST(list, start, middle - 1);
            treeNode.right = SortedListToBST(list, middle + 1, end);
            return treeNode;
        }

        /// <summary>
        /// LC_0121
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;
            var m = new int[2, prices.Length];
            //[0, ...n] n min purchase
            //[1, ...n] n max earn value  
            //max(n) => max(sold(n) - minPurchase(1..n-1), max(n-1))    
            for (int i = 0; i < prices.Length; i++)
            {
                if (i == 0)
                {
                    m[0, i] = prices[i];
                    m[1, i] = 0;
                }
                else
                {
                    if (prices[i] < m[0, i - 1])
                    {
                        m[0, i] = prices[i];
                    }
                    else
                    {
                        m[0, i] = m[0, i - 1];
                    }

                    if (prices[i] - m[0, i - 1] > m[1, i - 1])
                    {
                        m[1, i] = prices[i] - m[0, i - 1];
                    }
                    else
                    {
                        m[1, i] = m[1, i - 1];
                    }
                }
            }

            return m[1, prices.Length - 1];
        }

        /// <summary>
        /// LC_0138
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;
            Dictionary<Node, Node> dic = new Dictionary<Node, Node>();
            Node newHead = new Node();
            Node newCursor = newHead;
            Node cursor = head;
            while (cursor != null)
            {
                newCursor.next = new Node(cursor.val, null, null);
                dic.Add(cursor, newCursor.next);
                cursor = cursor.next;
                newCursor = newCursor.next;
            }
            cursor = head;
            while (cursor != null)
            {
                if (cursor.random == null)
                {
                    dic[cursor].random = null;
                }
                else
                {
                    dic[cursor].random = dic[cursor.random];
                }
                cursor = cursor.next;
            }
            return newHead.next;
        }
    }
}
