using System;
using Xunit;
using LeetCode.Structs;

namespace LeetCode.Tests
{
    public class ST_0001_1000
    {
        private Solution _s;
        public ST_0001_1000()
        {
            _s = new Solution();
        }
        [Fact]
        public void LC_0001_TwoSum_Test()
        {
            Assert.Collection(_s.TwoSum(new int[] { 2, 7, 11, 15 }, 9),
                x => Assert.True(x == 0),
                x => Assert.True(x == 1));
        }
        [Fact]
        public void LC_0002_AddTwoNumbers_Test()
        {
            var l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);
            var l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);
            var lResult = _s.AddTwoNumbers(l1, l2);
            Assert.Equal(7, lResult.val);
            Assert.Equal(0, lResult.next.val);
            Assert.Equal(8, lResult.next.next.val);
        }

        [Fact]
        public void LC_0003_LengthOfLongestSubstring_Test()
        {
            Assert.Equal(3, _s.LengthOfLongestSubstring("abcabcbb"));
            Assert.Equal(1, _s.LengthOfLongestSubstring("bbbbb"));
            Assert.Equal(3, _s.LengthOfLongestSubstring("pwwkew"));
        }

        [Fact]
        public void LC_0004_FindMedianSortedArrays_Test()
        {
            Assert.Equal(2.5f, _s.FindMedianSortedArrays(new int[] { 1, 2, 3, 4 }, new int[0]));
            Assert.Equal(2.5f, _s.FindMedianSortedArrays(new int[0], new int[] { 1, 2, 3, 4 }));
            Assert.Equal(2f, _s.FindMedianSortedArrays(new int[] { 1, 2, 4 }, new int[0]));
            Assert.Equal(2f, _s.FindMedianSortedArrays(new int[0], new int[] { 1, 2, 4 }));
            Assert.Equal(1f, _s.FindMedianSortedArrays(new int[0], new int[] { 1 }));
            Assert.Equal(1.5f, _s.FindMedianSortedArrays(new int[0], new int[] { 1, 2 }));
            Assert.Equal(-1.5f, _s.FindMedianSortedArrays(new int[0], new int[] { -1, -2 }));
            Assert.Equal(3.5f, _s.FindMedianSortedArrays(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 }));
            Assert.Equal(1.5f, _s.FindMedianSortedArrays(new int[] { 1 }, new int[] { 2 }));
        }
        [Fact]
        public void LC_0005_LongestPalindrome_Test()
        {
            Assert.Equal("s", _s.LongestPalindrome("s"));
            var result = _s.LongestPalindrome("babad");
            Assert.True(result == "bab" || result == "aba");
            Assert.Equal("bb", _s.LongestPalindrome("cbbd"));
        }

        [Fact]
        public void LC_0006_Convert_Test()
        {
            Assert.Equal("LCIRETOESIIGEDHN", _s.Convert("LEETCODEISHIRING", 3));
            Assert.Equal("LDREOEIIECIHNTSG", _s.Convert("LEETCODEISHIRING", 4));
            Assert.Equal("1357246", _s.Convert("1234567", 2));
            Assert.Equal("1234567", _s.Convert("1234567", 1));
        }

        [Fact]
        public void LC_0007_Reverse_Test()
        {
            Assert.Equal(21, _s.Reverse(120));
            Assert.Equal(0, _s.Reverse(0));
            Assert.Equal(0, _s.Reverse(int.MaxValue));
            Assert.Equal(0, _s.Reverse(int.MinValue));
            Assert.Equal(-321, _s.Reverse(-123));
        }

        [Fact]
        public void LC_0008_MyAtoi_Test()
        {
            Assert.Equal(42, _s.MyAtoi("42"));
            Assert.Equal(-42, _s.MyAtoi("   -42"));
            Assert.Equal(4193, _s.MyAtoi("4193 with words"));
            Assert.Equal(0, _s.MyAtoi("words and 987"));
            Assert.Equal(int.MinValue, _s.MyAtoi("-91283472332"));
            Assert.Equal(int.MaxValue, _s.MyAtoi("91283472332"));
            Assert.Equal(0, _s.MyAtoi("+"));
            Assert.Equal(0, _s.MyAtoi("-"));
            Assert.Equal(12345678, _s.MyAtoi("  0000000000012345678"));
            Assert.Equal(0, _s.MyAtoi("    0000000000000   "));
            Assert.Equal(0, _s.MyAtoi("+-2"));
            Assert.Equal(-5, _s.MyAtoi("-5-"));
        }

        [Fact]
        public void LC_0009_IsPalindrome_Test()
        {
            Assert.True(_s.IsPalindrome(121));
            Assert.False(_s.IsPalindrome(-121));
            Assert.False(_s.IsPalindrome(10));
        }

        [Fact]
        public void LC_0011_MaxAreaTest()
        {
            Assert.Equal(49, _s.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Assert.Equal(1, _s.MaxArea(new int[] { 1, 2 }));
        }
        [Fact]
        public void LC_0012_IntToRoman_Test()
        {
            Assert.Equal("", _s.IntToRoman(0));
            Assert.Equal("III", _s.IntToRoman(3));
            Assert.Equal("IV", _s.IntToRoman(4));
            Assert.Equal("V", _s.IntToRoman(5));
            Assert.Equal("IX", _s.IntToRoman(9));
            Assert.Equal("LVIII", _s.IntToRoman(58));
            Assert.Equal("DXLIX", _s.IntToRoman(549));
            Assert.Equal("MMMCCX", _s.IntToRoman(3210));
        }
    }
}
