using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public partial class Solution
    {
        /// <summary>
        /// LC_0001
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0002
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode startResult = new ListNode(0);
            ListNode tempStart = startResult;
            ListNode start1 = l1;
            ListNode start2 = l2;
            bool previousValueLarge10 = false;
            while (true)
            {
                var value = (start1 == null ? 0 : start1.val)
                + (start2 == null ? 0 : start2.val)
                + (previousValueLarge10 ? 1 : 0);
                ListNode newNode = null;
                if (value > 9)
                {
                    newNode = new ListNode(value % 10);
                    previousValueLarge10 = true;
                }
                else
                {
                    newNode = new ListNode(value);
                    previousValueLarge10 = false;
                }

                tempStart.next = newNode;
                tempStart = tempStart.next;

                start1 = start1?.next;
                start2 = start2?.next;
                if (start1 == null && start2 == null && previousValueLarge10 == false)
                    break;
            }
            return startResult.next;
        }

        /// <summary>
        /// LC_0003
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var maxLen = 1;
            var queue = new Queue<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    queue.Enqueue(s[i]);
                }
                else
                {
                    if (!queue.Contains(s[i]))
                    {
                        queue.Enqueue(s[i]);
                        maxLen = Math.Max(queue.Count, maxLen);
                    }
                    else
                    {
                        char temp = '\0';
                        do
                        {
                            temp = queue.Dequeue();
                        }
                        while (temp != s[i]);
                        queue.Enqueue(s[i]);
                    }
                }
            }
            return maxLen;
        }

        /// <summary>
        /// LC_0004
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0)
            {
                return GetMedian(nums2);
            }
            else if (nums2 == null || nums2.Length == 0)
            {
                return GetMedian(nums1);
            }
            var index1 = 0;
            var index2 = 0;
            var mainIndex = 0;
            int[] array = new int[nums1.Length + nums2.Length];
            while (true)
            {
                if (index1 < nums1.Length && index2 == nums2.Length)
                {
                    array[mainIndex] = nums1[index1];
                    index1++;
                    mainIndex++;
                }
                else if (index2 < nums2.Length && index1 == nums1.Length)
                {
                    array[mainIndex] = nums2[index2];
                    index2++;
                    mainIndex++;
                }
                else if (index1 < nums1.Length && index2 < nums2.Length)
                {
                    var currentValue1 = nums1[index1];
                    var currentValue2 = nums2[index2];
                    if (currentValue1 <= currentValue2)
                    {
                        array[mainIndex] = currentValue1;
                        index1++;
                    }
                    else
                    {
                        array[mainIndex] = currentValue2;
                        index2++;

                    }
                    mainIndex++;
                }
                else
                {
                    break;
                }
            }
            return GetMedian(array);
        }

        /// <summary>
        /// LC_0005
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            if (s.Length == 1)
            {
                return s;
            }
            var result = s.Last().ToString();
            for (int i = 0; i < (s.Length * 2 - 1); i++)
            {
                var left = 0;
                var right = 0;
                if (i % 2 == 0)
                {
                    var middle = i / 2;
                    left = middle;
                    right = middle;
                }
                else
                {
                    left = i / 2;
                    right = left + 1;
                }
                if (s[left] != s[right])
                    continue;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    if (left - 1 < 0)
                        break;
                    if (right + 1 >= s.Length)
                        break;
                    if (s[left - 1] != s[right + 1])
                        break;
                    left--;
                    right++;
                }

                var len = right - left + 1;
                if (len > result.Length)
                {
                    result = s.Substring(left, len);
                }
            }

            return result;
        }

        /// <summary>
        /// LC_0006
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1)
            {
                return s;
            }

            var matrix = new char[s.Length, numRows];
            var direction = 0;//0:down, 1:up
            int x = 0;
            int y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                matrix[x, y] = s[i];
                if (direction == 0)
                {
                    if (y == numRows - 1)
                    {
                        direction = 1;
                        x++;
                        y--;
                    }
                    else
                    {
                        y++;
                    }
                }
                else
                {
                    if (y == 0)
                    {
                        direction = 0;
                        y++;
                    }
                    else
                    {
                        x++;
                        y--;
                    }
                }
            }

            var result = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j <= x; j++)
                {
                    if (matrix[j, i] != '\0')
                    {
                        result += matrix[j, i];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// LC_0007
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            if (x == 0)
                return 0;

            var str = x.ToString();
            var symbol = x < 0 ? "-" : "";
            var number = x < 0 ? str.Substring(1) : str;

            var newStr = new string(number.Reverse().ToArray());
            var newValue = 0;
            int.TryParse($"{symbol}{newStr}", out newValue);
            return newValue;
        }

        /// <summary>
        /// LC_0008
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            var trimStr = str.Trim();
            if (string.IsNullOrWhiteSpace(trimStr))
                return 0;
            var availableChars = new List<char>() {
                '+','-',
                '0','1','2','3','4','5','6','7','8','9'};
            if (!availableChars.Contains(trimStr[0]))
                return 0;

            var realStr = "";
            for (int i = 0; i < trimStr.Length; i++)
            {
                var ch = trimStr[i];
                if (ch == '+' || ch == '-' || (ch >= '0' && ch <= '9'))
                {
                    if (i > 0 && (ch == '+' || ch == '-'))
                    {
                        break;
                    }
                    realStr += trimStr[i];
                }
                else
                {
                    break;
                }
            }

            if (realStr == "0" || realStr == "+" || realStr == "-")
                return 0;


            var lessZero = realStr.StartsWith('-');

            var result = 0;
            var success = int.TryParse(realStr, out result);

            if (!success)
            {
                if (lessZero)
                    return int.MinValue;
                else
                    return int.MaxValue;
            }
            return result;
        }

        /// <summary>
        /// LC_0009
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            var str = x.ToString();
            var newStr = new string(str.Reverse().ToArray());
            return str == newStr;
        }

        /// <summary>
        /// LC_0010
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
                return false;
            if (s == "" && p == "")
                return true;
            if (s != "" && p == "")
                return false;
            if (p[0] == '*')
                return false;
            var sIndex = 0;
            var pIndex = 0;
            while (sIndex < s.Length || pIndex < p.Length)
            {
                if (p[pIndex] == '*')
                {
                    if (p[pIndex - 1] == '.')
                    {

                    }
                    else if (p[pIndex - 1] == '*')
                    {
                        break;
                    }
                    else
                    {

                    }
                }
                else if (p[pIndex] == '.')
                {
                    pIndex++;
                    sIndex++;
                }
                else//a-z
                {
                    if (p[pIndex] == s[sIndex])
                    {
                        pIndex++;
                        sIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// LC_0011
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            var max = 0;
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                if (height[i] >= height[j])
                {
                    max = Math.Max(max, height[j] * (j - i));
                    j--;
                }
                else
                {
                    max = Math.Max(max, height[i] * (j - i));
                    i++;
                }
            }
            return max;
        }

        /// <summary>
        /// LC_0012
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            if (num <= 0)
                return "";
            var dic = new Dictionary<int, string>() {
                { 1000,"M" },
                { 900,"CM" },
                { 500,"D" },
                { 400,"CD" },
                { 100,"C" },
                { 90,"XC" },
                { 50,"L" },
                { 40,"XL" },
                { 10,"X" },
                { 9,"IX" },
                { 5,"V" },
                { 4,"IV" },
                { 1,"I" }
            };
            var value = num;
            var result = "";
            while (true)
            {
                if (value >= 1000)
                {
                    value -= 1000;
                    result += dic[1000];
                }
                else if (value >= 900 && value < 1000)
                {
                    value -= 900;
                    result += dic[900];
                }
                else if (value >= 500 && value < 900)
                {
                    value -= 500;
                    result += dic[500];
                }
                else if (value >= 400 && value < 500)
                {
                    value -= 400;
                    result += dic[400];
                }
                else if (value >= 100 && value < 400)
                {
                    value -= 100;
                    result += dic[100];
                }
                else if (value >= 90 && value < 100)
                {
                    value -= 90;
                    result += dic[90];
                }
                else if (value >= 50 && value < 100)
                {
                    value -= 50;
                    result += dic[50];
                }
                else if (value >= 40 && value < 50)
                {
                    value -= 40;
                    result += dic[40];
                }
                else if (value >= 10 && value < 40)
                {
                    value -= 10;
                    result += dic[10];
                }
                else if (value >= 9 && value < 10)
                {
                    value -= 9;
                    result += dic[9];
                }
                else if (value >= 5 && value < 9)
                {
                    value -= 5;
                    result += dic[5];
                }
                else if (value >= 4 && value < 5)
                {
                    value -= 4;
                    result += dic[4];
                }
                else if (value >= 1 && value < 4)
                {
                    value -= 1;
                    result += dic[1];
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0013
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var dic = new Dictionary<string, int>() {
                { "M", 1000 },
                { "CM",900},
                { "D", 500 },
                { "CD", 400 },
                { "C", 100},
                { "XC", 90},
                { "L", 50 },
                { "XL", 40 },
                { "X" , 10},
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 }
            };
            var value = 0;
            var result = s;
            while (result.Length > 0)
            {
                if (result.StartsWith("M"))
                {
                    result = result.Substring(1);
                    value += dic["M"];
                }
                else if (result.StartsWith("CM"))
                {
                    result = result.Substring(2);
                    value += dic["CM"];
                }
                else if (result.StartsWith("D"))
                {
                    result = result.Substring(1);
                    value += dic["D"];
                }
                else if (result.StartsWith("CD"))
                {
                    result = result.Substring(2);
                    value += dic["CD"];
                }
                else if (result.StartsWith("C"))
                {
                    result = result.Substring(1);
                    value += dic["C"];
                }
                else if (result.StartsWith("XC"))
                {
                    result = result.Substring(2);
                    value += dic["XC"];
                }
                else if (result.StartsWith("L"))
                {
                    result = result.Substring(1);
                    value += dic["L"];
                }
                else if (result.StartsWith("XL"))
                {
                    result = result.Substring(2);
                    value += dic["XL"];
                }
                else if (result.StartsWith("X"))
                {
                    result = result.Substring(1);
                    value += dic["X"];
                }
                else if (result.StartsWith("IX"))
                {
                    result = result.Substring(2);
                    value += dic["IX"];
                }
                else if (result.StartsWith("V"))
                {
                    result = result.Substring(1);
                    value += dic["V"];
                }
                else if (result.StartsWith("IV"))
                {
                    result = result.Substring(2);
                    value += dic["IV"];
                }
                else if (result.StartsWith("I"))
                {
                    result = result.Substring(1);
                    value += dic["I"];
                }
            }
            return value;
        }

        /// <summary>
        /// LC_0014
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";
            if (strs.Length == 1)
                return strs[0];
            var minLen = int.MaxValue;

            foreach (var str in strs)
            {
                if (str.Length < minLen)
                    minLen = str.Length;
            }
            if (minLen == 0)
                return "";
            var resultLen = 0;
            for (int i = 0; i < minLen; i++)
            {
                if (strs.All(x => x[i] == strs[0][i]))
                    resultLen++;
                else
                    break;
            }

            if (resultLen == 0)
                return "";
            else
                return strs[0].Substring(0, resultLen);
        }

        /// <summary>
        /// LC_0015
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var sortList = nums.OrderBy(x => x).ToList();
            IList<IList<int>> result = new List<IList<int>>();
            var hash = new HashSet<string>();
            for (int i = 0; i < sortList.Count; i++)
            {
                var left = i + 1;
                var right = sortList.Count - 1;
                while (left < right)
                {
                    var sum = sortList[i] + sortList[left] + sortList[right];
                    if (sum == 0)
                    {
                        var hashStr = $"{sortList[i]}{sortList[left]}{sortList[right]}";
                        if (!hash.Contains(hashStr))
                        {
                            result.Add(new List<int>() { sortList[i], sortList[left], sortList[right] });
                            hash.Add(hashStr);
                        }
                        var lValue = sortList[left];
                        do { left++; }
                        while (left < right && lValue == sortList[left]);

                        var rValue = sortList[right];
                        do { right--; }
                        while (left < right && rValue == sortList[right]);
                    }
                    else if (sum < 0)
                    {
                        var lValue = sortList[left];
                        do { left++; }
                        while (left < right && lValue == sortList[left]);
                    }
                    else
                    {
                        var rValue = sortList[right];
                        do { right--; }
                        while (left < right && rValue == sortList[right]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0016
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length < 3)
                return 0;
            var sortList = nums.OrderBy(x => x).ToList();
            var result = int.MaxValue;
            var distance = int.MaxValue;
            for (int i = 0; i < sortList.Count; i++)
            {
                var left = i + 1;
                var right = sortList.Count - 1;
                while (left < right)
                {
                    var sum = sortList[i] + sortList[left] + sortList[right];
                    if (sum == target)
                    {
                        return target;
                    }
                    else if (sum < target)
                    {
                        var dist = target - sum;
                        if (dist < distance)
                        {
                            distance = dist;
                            result = sum;
                        }
                        var lValue = sortList[left];
                        do { left++; }
                        while (left < right && lValue == sortList[left]);
                    }
                    else
                    {
                        var dist = sum - target;
                        if (dist < distance)
                        {
                            distance = dist;
                            result = sum;
                        }
                        var rValue = sortList[right];
                        do { right--; }
                        while (left < right && rValue == sortList[right]);
                    }
                }
            }
            return result;
        }
    }
}