using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class ST_0301_0400
    {
        private Solution_0301_0400 _s;
        public ST_0301_0400()
        {
            _s = new Solution_0301_0400();
        }

        [Fact]
        public void LC_0328_OddEvenList()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1, 2, 3, 4 });
            var linkList2 = ListNode.GenerateList(new int[] { 1, 2, 3, 4, 5 });
            Assert.True(new int[] { 1, 3, 2, 4 }.CompareArray(_s.OddEvenList(linkList1).ToList().ToArray()));
            Assert.True(new int[] { 1, 3, 5, 2, 4 }.CompareArray(_s.OddEvenList(linkList2).ToList().ToArray()));
        }
    }
}
