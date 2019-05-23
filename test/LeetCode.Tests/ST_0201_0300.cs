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
        public void LC_0206_ReverseList()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1, 2, 3, 4, 5 });
            Assert.True(new int[] { 5, 4, 3, 2, 1 }.CompareArray(_s.ReverseList(linkList1).ToList().ToArray()));
        }
    }
}
