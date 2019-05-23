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
    }
}
