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
    }
}
