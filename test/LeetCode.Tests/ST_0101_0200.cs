using Xunit;
using LeetCode.Structs;
namespace LeetCode.Tests
{
    public class ST_0101_0200
    {
        private Solution_0101_0200 _s;
        public ST_0101_0200()
        {
            _s = new Solution_0101_0200();
        }

        [Fact]
        public void LC_0108_SortedArrayToBST()
        {
            _s.SortedArrayToBST(new int[] { 1, 2, 3, 4, 5 });
        }

        [Fact]
        public void LC_0109_SortedListToBST()
        {
            var linkList1 = ListNode.GenerateList(new int[] { -10, -3, 0, 5, 9 });
            var tree = _s.SortedListToBST(linkList1);
        }

        [Fact]
        public void LC_0121_MaxProfit_Test()
        {
            Assert.Equal(5, _s.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        [Fact]
        public void LC_0138_CopyRandomList()
        {
            /*
             
             {"$id":"1",
             "next":{"$id":"2",
             "next":{"$id":"3","next":{
             "$id":"4","next":null,"random":null,"val":4},
             "random":null,"val":3},
             "random":{"$ref":"3"},"val":2},
             "random":{"$ref":"3"},
             "val":1}
             */
            var node1 = new Node(1, null, null);
            var node2 = new Node(2, null, null);
            var node3 = new Node(3, null, null);
            var node4 = new Node(4, null, null);
            node1.next = node2;
            node1.random = node3;

            node2.next = node3;
            node2.random = node3;

            node3.next = node4;
            node3.random = null;

            var result = _s.CopyRandomList(node1);
        }

        [Fact]
        public void LC_0142_DetectCycle()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 3, 2, 0, -4 });
            linkList1.next.next.next.next = linkList1.next;
            var node = _s.DetectCycle(linkList1);
            Assert.True(node == linkList1.next);
        }

        [Fact]
        public void LC_0143_ReorderList()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 1, 2, 3, 4 });
            var linkList2 = ListNode.GenerateList(new int[] { 1, 2, 3, 4, 5 });
            _s.ReorderList(linkList1);
            _s.ReorderList(linkList2);
            Assert.True(new int[] { 1, 4, 2, 3 }.CompareArray(linkList1.ToList().ToArray()));
            Assert.True(new int[] { 1, 5, 2, 4, 3 }.CompareArray(linkList2.ToList().ToArray()));
        }

        [Fact]
        public void LC_0147_InsertionSortList()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 4, 3, 1, 2 });
            var linkList2 = ListNode.GenerateList(new int[] { 1 });
            var linkList3 = ListNode.GenerateList(new int[] { 2, 1 });
            var linkList4 = ListNode.GenerateList(new int[] { 1, 2 });
            var linkList5 = ListNode.GenerateList(new int[] { 1, 1 });
            var linkList6 = ListNode.GenerateList(new int[] { 4, 19, 14, 5, -3, 1, 8, 5, 11, 15 });
            Assert.True(new int[] { 1, 2, 3, 4 }.CompareArray(_s.InsertionSortList(linkList1).ToList().ToArray()));
            Assert.True(new int[] { 1 }.CompareArray(_s.InsertionSortList(linkList2).ToList().ToArray()));
            Assert.True(new int[] { 1, 2 }.CompareArray(_s.InsertionSortList(linkList3).ToList().ToArray()));
            Assert.True(new int[] { 1, 2 }.CompareArray(_s.InsertionSortList(linkList4).ToList().ToArray()));
            Assert.True(new int[] { 1, 1 }.CompareArray(_s.InsertionSortList(linkList5).ToList().ToArray()));
            Assert.True(new int[] { -3, 1, 4, 5, 5, 8, 11, 14, 15, 19 }.CompareArray(_s.InsertionSortList(linkList6).ToList().ToArray()));
        }

        [Fact]
        public void LC_0148_SortList()
        {
            _s.SortList(null);
        }

        [Fact]
        public void LC_0160_GetIntersectionNode()
        {
            var linkList1 = ListNode.GenerateList(new int[] { 4, 1, 8, 4, 5 });
            var linkList2 = new ListNode(5) { next = new ListNode(0) { next = new ListNode(1) { next = linkList1.next.next } } };
            Assert.True(linkList1.next.next == _s.GetIntersectionNode(linkList1, linkList2));
        }
    }
}
