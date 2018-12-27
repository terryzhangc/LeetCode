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
        public void LC_0121_MaxProfit_Test()
        {
            Assert.Equal(5, _s.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }
    }
}
