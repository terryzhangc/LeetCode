using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class ST_0201_0300
    {
        private Solution_0201_0300 _s;
        public ST_0201_0300()
        {
            _s = new Solution_0201_0300();
        }

        [Fact]
        public void LC_0203_RemoveElements()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1, 1 });
            var linkList2 = ListNode.GenerateList(new int[] { 1, 2, 3, 4 });
            Assert.True(_s.RemoveElements(linkList1, 1).ToArray().Length == 0);
            Assert.True(new int[] { 1, 2, 4 }.CompareArray(_s.RemoveElements(linkList2, 3).ToList().ToArray()));
        }

        [Fact]
        public void LC_0206_ReverseList()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1, 2, 3, 4, 5 });
            Assert.True(new int[] { 5, 4, 3, 2, 1 }.CompareArray(_s.ReverseList(linkList1).ToList().ToArray()));
        }

        [Fact]
        public void LC_0234_IsPalindrome()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1 });
            var linkList2 = ListNode.GenerateList(new int[] { 1, 2, 1 });
            var linkList3 = ListNode.GenerateList(new int[] { 1, 2, 2, 1 });
            var linkList4 = ListNode.GenerateList(new int[] { 1, 2 });
            Assert.True(_s.IsPalindrome(null));
            Assert.True(_s.IsPalindrome(linkList1));
            Assert.True(_s.IsPalindrome(linkList2));
            Assert.True(_s.IsPalindrome(linkList3));
            Assert.False(_s.IsPalindrome(linkList4));
        }
    }
}
