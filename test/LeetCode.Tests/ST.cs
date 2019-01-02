using Xunit;
using LeetCode.Structs;
namespace LeetCode.Tests
{
    public class ST
    {
        private Solution _s;
        public ST()
        {
            _s = new Solution();
        }
        [Fact]
        public void ST_Reverse_Test()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            _s.Reverse(ref arr1, 0, 3);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr1));

            var arr2 = new int[] { 1, 2, 3 };
            _s.Reverse(ref arr2, 0, 2);
            Assert.True(new int[] { 3, 2, 1 }.CompareArray(arr2));
        }

        [Fact]
        public void ST_ReOrder_Test()
        {
            var arr1 = new int[] { 1, 2 };
            _s.ReOrder(ref arr1, 0, 1, 1);
            Assert.True(new int[] { 2, 1 }.CompareArray(arr1));

            var arr11 = new int[] { 1, 2 };
            _s.ReOrder(ref arr11, 0, 1, 0);
            Assert.True(new int[] { 2, 1 }.CompareArray(arr11));

            var arr2 = new int[] { 4, 2, 1, 3 };
            _s.ReOrder(ref arr2, 0, 3, 3);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr2));


            var arr3 = new int[] { 1, 4, 3, 2 };
            _s.ReOrder(ref arr3, 0, 3, 0);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr3));

            var arr4 = new int[] { 4, 2, 3, 1 };
            _s.ReOrder(ref arr4, 0, 3, 1);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr4));

            var arr5 = new int[] { 4, 2, 3, 1 };
            _s.ReOrder(ref arr5, 0, 3, 2);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr5));

            var arr6 = new int[] { 4, 3, 2, 1 };
            _s.ReOrder(ref arr6, 0, 3, 2);
            Assert.True(new int[] { 4, 3, 2, 1 }.CompareArray(arr6));
        }

        [Fact]
        public void ST_MyCircularQueue_Test()
        {
            var _q = new MyCircularQueue(5);

            _q.EnQueue(1);
            _q.EnQueue(2);
            _q.EnQueue(3);
            _q.EnQueue(4);
            _q.EnQueue(5);
            Assert.False(_q.EnQueue(6));
            Assert.Equal(1, _q.Front());
            Assert.Equal(5, _q.Rear());
            Assert.True(_q.IsFull());

            Assert.True(_q.DeQueue());
            Assert.True(_q.DeQueue());
            Assert.True(_q.EnQueue(6));
            Assert.True(_q.EnQueue(7));
            Assert.True(_q.IsFull());
            Assert.False(_q.EnQueue(8));
            _q.DeQueue();
            _q.DeQueue();
            _q.DeQueue();
            _q.DeQueue();
            Assert.True(_q.Front() == 7 && _q.Rear() == 7);
            _q.DeQueue();
            Assert.True(_q.IsEmpty());


            MyCircularQueue circularQueue = new MyCircularQueue(2);

            circularQueue.EnQueue(8);
            circularQueue.EnQueue(8);
            var a = circularQueue.Front();
            circularQueue.EnQueue(4);
            circularQueue.DeQueue();

            circularQueue.EnQueue(1);
            circularQueue.EnQueue(1);
            circularQueue.DeQueue();
            Assert.True(circularQueue.Front() == 1 && circularQueue.Rear() == 1);
        }
    }
}
