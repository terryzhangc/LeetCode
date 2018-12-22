using Xunit;
using LeetCode.Structs;
namespace LeetCode.Tests
{
    public class ST_0101_0200
    {
        private Solution _s;
        public ST_0101_0200()
        {
            _s = new Solution();
        }
        [Fact]
        public void LC_0101_TwoSum_Test()
        {
            Assert.Collection(_s.TwoSum(new int[] { 2, 7, 11, 15 }, 9),
                x => Assert.True(x == 0),
                x => Assert.True(x == 1));
        }
    }
}
