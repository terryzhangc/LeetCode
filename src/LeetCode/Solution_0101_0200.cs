using LeetCode.Structs;
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

        /// <summary>
        /// LC_0141
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;
            ListNode slowCursor = head;
            ListNode fastCursor = head;
            var result = false;
            while (fastCursor != null && fastCursor.next != null)
            {
                slowCursor = slowCursor.next;
                fastCursor = fastCursor.next.next;
                if (slowCursor == fastCursor)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0142
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
                return null;
            ListNode slowCursor = head;
            ListNode fastCursor = head;
            var result = false;
            while (fastCursor != null && fastCursor.next != null)
            {
                slowCursor = slowCursor.next;
                fastCursor = fastCursor.next.next;
                if (slowCursor == fastCursor)
                {
                    result = true;
                    break;
                }
            }
            if (!result)
                return null;

            if (slowCursor == slowCursor.next)
                return slowCursor;

            var circleCount = 0;
            do
            {
                circleCount++;
                fastCursor = fastCursor.next;
            } while (fastCursor != slowCursor);

             slowCursor = head;
             fastCursor = head;

            while (circleCount > 0)
            {
                fastCursor = fastCursor.next;
                circleCount--;
            }

            while (fastCursor != slowCursor)
            {
                slowCursor = slowCursor.next;
                fastCursor = fastCursor.next;
            }
            return slowCursor;
        }

        /// <summary>
        /// LC_0143
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            ListNode slowCursor = head;
            ListNode fastCursor = head;
            ListNode preCursor = null;
            while (fastCursor != null && fastCursor.next != null)
            {
                preCursor = slowCursor;
                slowCursor = slowCursor.next;
                fastCursor = fastCursor.next.next;
            }

            preCursor.next = null;

            ListNode nextCursor = slowCursor;
            ListNode nextHeader = null;
            while (nextCursor != null)
            {
                var temp = nextCursor;
                nextCursor = nextCursor.next;
                temp.next = nextHeader;
                nextHeader = temp;
            }

            preCursor = head;
            nextCursor = nextHeader;

            while (preCursor != null && nextCursor != null)
            {
                var preTemp = preCursor;
                var nextTemp = nextCursor;
                preCursor = preCursor.next;
                nextCursor = nextCursor.next;
                preTemp.next = nextTemp;
                if (preCursor == null && nextCursor != null)
                    nextTemp.next = nextCursor;
                else
                    nextTemp.next = preCursor;
            }
        }

        /// <summary>
        /// LC_0147
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode result = null;
            ListNode cursor = null;
            ListNode preCursor = null;
            ListNode insert = head;
            cursor = head;
            // skip the sorted part
            while (cursor != null)
            {
                preCursor = cursor;
                cursor = cursor.next;
                if (cursor == null || preCursor.val > cursor.val)
                {
                    result = head;
                    preCursor.next = null;
                    insert = cursor;
                    break;
                }
            }
            preCursor = null;
            cursor = result;

            while (insert != null)
            {
                var temp = insert;
                insert = insert.next;

                while (cursor != null)
                {
                    if (preCursor == null && temp.val <= cursor.val)
                    {
                        temp.next = cursor;
                        result = temp;
                        break;
                    }
                    else if (preCursor != null && temp.val > preCursor.val && temp.val <= cursor.val)
                    {
                        temp.next = cursor;
                        preCursor.next = temp;
                        break;
                    }
                    else if (cursor.next == null && temp.val > cursor.val)
                    {
                        cursor.next = temp;
                        temp.next = null;
                        break;
                    }
                    preCursor = cursor;
                    cursor = cursor.next;
                }
                preCursor = null;
                cursor = result; //reset pointer
            }
            return result;
        }

        /// <summary>
        /// LC_0148
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            return null;
        }

        /// <summary>
        /// LC_0160
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode a = headA;
            ListNode b = headB;
            while (a != b)
            {
                a = (a == null ? headB : a.next);
                b = (b == null ? headA : b.next);
            }
            return a;
        }
    }
}
