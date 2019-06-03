using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class ST_0401_0500
    {
        private Solution_0401_0500 _s;
        public ST_0401_0500()
        {
            _s = new Solution_0401_0500();
        }

        [Fact]
        public void LC_0445_AddTwoNumbers()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 7, 2, 4, 3 });
            var linkList2 = ListNode.GenerateList(new int[] { 5, 6, 4 });
            Assert.True(new int[] { 7, 8, 0, 7 }.CompareArray(_s.AddTwoNumbers(linkList1, linkList2).ToList().ToArray()));
        }
    }
}
