using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution_0001_0100 : Solution
    {
        public Solution_0001_0100() : base()
        {

        }

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

        /// <summary>
        /// LC_0017
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return result;
            var map = new string[] {
                " ",
                "*","abc", "def",
                "ghi","jkl","mno",
                "pqrs","tuv","wxyz"
            };

            var temp = new char[digits.Length];

            Search(ref result, ref map, ref digits, 0, ref temp);

            return result;
        }

        private void Search(ref List<string> result, ref string[] map, ref string digits, int index, ref char[] temp)
        {
            if (index == digits.Length)
            {
                result.Add(new string(temp));
                return;
            }
            var number = digits[index] - '0';
            var chars = map[number];

            foreach (var ch in chars)
            {
                temp[index] = ch;
                index++;
                Search(ref result, ref map, ref digits, index, ref temp);
                index--;
            }
        }

        /// <summary>
        /// LC_0018
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
                return result;
            var sortList = nums.OrderBy(x => x).ToList();
            var hash = new HashSet<string>();
            for (int i = 0; i < sortList.Count; i++)
            {
                for (int j = i + 1; j < sortList.Count;)
                {
                    if (j > sortList.Count - 2)
                        break;
                    var left = j + 1;
                    var right = sortList.Count - 1;
                    while (left < right)
                    {
                        var sum = sortList[i] + sortList[j] + sortList[left] + sortList[right] - target;
                        if (sum == 0)
                        {
                            var hashStr = $"{sortList[i]}{sortList[j]}{sortList[left]}{sortList[right]}";
                            if (!hash.Contains(hashStr))
                            {
                                result.Add(new List<int>() { sortList[i], sortList[j], sortList[left], sortList[right] });
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

                    var jValue = sortList[j];
                    do { j++; }
                    while (j < sortList.Count && jValue == sortList[j]);
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0019
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n <= 0)
                return head;
            if (head.next == null && n == 1)
                return null;

            var list = new List<ListNode>();
            ListNode p = head;
            while (p != null)
            {
                list.Add(p);
                p = p.next;
            }
            var index = list.Count - n;
            if (index == 0)
                return list[1];
            if (index == list.Count - 1)
            {
                list[index - 1].next = null;
            }
            else
            {
                list[index - 1].next = list[index + 1];
            }
            return head;
        }

        /// <summary>
        /// LC_0020
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(ch);
                }
                else
                {
                    if (ch == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (ch == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else if (ch == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
            }
            return stack.Count == 0;
        }

        /// <summary>
        /// LC_0021
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null && l2 != null)
                return l2;
            if (l1 != null && l2 == null)
                return l1;
            var head = new ListNode(0);
            var temp = head;
            var p1 = l1;
            var p2 = l2;
            while (true)
            {
                if (p1 == null)
                {
                    temp.next = p2;
                    break;
                }
                if (p2 == null)
                {
                    temp.next = p1;
                    break;
                }

                if (p1.val < p2.val)
                {
                    temp.next = p1;
                    temp = temp.next;
                    p1 = p1.next;
                }
                else
                {
                    temp.next = p2;
                    temp = temp.next;
                    p2 = p2.next;
                }
            }
            return head.next;
        }

        /// <summary>
        /// LC_0022
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var stack = new Stack<char>();
            var chars = new char[2] { '(', ')' };
            var temp = new char[2 * n];
            var max = 1 << (2 * n);
            for (int i = 0; i < max; i++)
            {
                var count = LookupTable[i >> 24]
                    + LookupTable[(i & 0x00FF0000) >> 16]
                    + LookupTable[(i & 0x0000FF00) >> 8]
                    + LookupTable[i & 0x000000FF];
                if (n != count)
                    continue;
                for (int index = 0; index < 2 * n; index++)
                {
                    if (stack.Count > n)
                        break;
                    var cIndex = (i & (1 << index)) == 0 ? 0 : 1;
                    var ch = chars[cIndex];
                    temp[index] = ch;
                    if (stack.Count == 0)
                    {
                        stack.Push(ch);
                    }
                    else
                    {
                        if (ch == ')' && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(ch);
                        }
                    }
                }

                if (stack.Count == 0)

                {
                    result.Add(new string(temp));
                }
                else
                {
                    stack.Clear();
                }
            }

            return result;
        }

        /// <summary>
        /// LC_0023
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            return MergeLists(lists, 0, lists.Length - 1);
        }

        private ListNode MergeLists(ListNode[] lists, int start, int end)
        {
            if (start == end)
            {
                return lists[start];
            }
            else
            {
                var middle = (start + end) / 2;
                var left = MergeLists(lists, start, middle);
                var right = MergeLists(lists, middle + 1, end);
                return MergeTwoLists(left, right);
            }
        }

        /// <summary>
        /// LC_0024
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;
            ListNode prev = null;
            ListNode prev1 = null;
            ListNode newHead = null;
            ListNode p = head;
            int count = 1;
            while (p != null)
            {
                if (count % 2 == 0)
                {
                    prev.next = p.next;
                    p.next = prev;
                    if (count == 2)
                    {
                        newHead = p;
                    }
                    else
                    {
                        prev1.next = p;
                    }
                    p = prev;
                    prev1 = p;
                }
                count++;
                prev = p;
                p = p.next;
            }

            return newHead;
        }

        /// <summary>
        /// LC_0025
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
                return null;
            if (k < 2)
                return head;
            var stack = new Stack<ListNode>();
            ListNode p = head;
            ListNode prev = null;
            ListNode newHead = null;
            do
            {
                stack.Push(p);
                p = p.next;
                if (stack.Count == k)
                {
                    while (stack.Count != 0)
                    {
                        var pop = stack.Pop();
                        pop.next = null;
                        if (newHead == null)
                        {
                            newHead = pop;
                        }
                        else
                        {
                            prev.next = pop;
                        }
                        prev = pop;
                    }
                }
            }
            while (p != null);

            if (stack.Count != 0 && stack.Count < k)
            {
                if (newHead == null)
                {
                    newHead = stack.Last();
                }
                else
                {
                    prev.next = stack.Last();
                }
            }
            return newHead;
        }

        /// <summary>
        /// LC_0026
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates1(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            var len = nums.Length;
            for (int i = 0, j = i + 1; i < len; i++, j = i + 1)
            {

                while (j < len && nums[i] == nums[j])
                {
                    j++;
                }
                if (1 == j - i)
                    continue;
                //merge array 
                for (int k = j; k < len; k++)
                {
                    nums[k - (j - i - 1)] = nums[k];
                }

                //recalculate len
                len -= (j - i - 1);
            }

            return len;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            var result = 1;
            var curValue = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (curValue != nums[i])
                {
                    curValue = nums[i];
                    nums[result] = nums[i];
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0027
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (val != nums[i])
                {
                    nums[result] = nums[i];
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0028
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }

        /// <summary>
        /// LC_0029
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (dividend == 0)
                return 0;
            if (divisor == 1)
                return dividend;
            if (divisor == -1 && dividend == int.MinValue)
                return int.MaxValue;
            if (divisor == -1)
                return -dividend;

            if (divisor == int.MinValue)
                return dividend == int.MinValue ? 1 : 0;

            var flag1 = dividend < 0;
            var flag2 = divisor < 0;
            var value = dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend);
            var div = Math.Abs(divisor);

            var result = 0;
            var i = 0;
            //value=result * div + r
            //value = result * div   //result = (2^l1+2^l2+……+2^ls)
            //result = value -r - div * (2^l1+2^l2+……+2^ls)
            while (value >= div)
            {
                if (value >= div << i)
                {
                    value -= div << i;
                    result += 1 << i;
                    i++;
                }
                else
                {
                    i--;
                }
            }

            if (dividend == int.MinValue) // add miss 1 back
            {
                value += 1;
                if (value >= div)
                {
                    result += 1;
                }
            }
            return flag1 == flag2 ? result : -result;
        }

        /// <summary>
        /// LC_0030
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            var charArray = s.ToArray();
            var result = new List<int>();

            if (words == null || words.Length == 0)
                return result;
            if (s == null)
                return result;

            if (words.Length > 0 && words.All(x => x == ""))
            {
                if (s.Length == 0)
                {
                    result.Add(0);
                    return result;
                }
                else
                {
                    for (int i = 0; i <= s.Length; i++)
                    {
                        result.Add(i);
                    }
                    return result;
                }
            }

            if (words.Length > 1 && words.Any(x => x.Length != words[0].Length))
            {
                return result;
            }
            var len = words[0].Length;
            var map = new int[s.Length];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = -1;
            }
            var dic = new Dictionary<string, List<int>>();
            var countDic = new Dictionary<int, int>();
            var hashSet = new Dictionary<int, int>();
            var wordsCount = words.Length;
            var noRepeatingWordsCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (dic.ContainsKey(words[i]))
                {
                    dic[words[i]].Add(i);
                }
                else
                {
                    dic.Add(words[i], new List<int>() { i });
                    noRepeatingWordsCount++;
                }
            }

            foreach (var pair in dic)
            {
                countDic.Add(pair.Value.First(), pair.Value.Count);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (i + len <= s.Length)
                {
                    var str = new string(charArray, i, len);
                    if (dic.ContainsKey(str))
                    {
                        map[i] = dic[str][0];
                    }
                    else
                    {
                        map[i] = -1;
                    }

                }
                if (i >= words.Length * len - 1)
                {
                    for (int k = 0, index = i - len + 1; k < words.Length; k++, index -= len)
                    {
                        var value = map[index];
                        if (value == -1)
                        {
                            hashSet.Clear();
                            break;
                        }
                        if (!hashSet.ContainsKey(value))
                        {
                            hashSet.Add(value, 1);
                            if (hashSet.Count == noRepeatingWordsCount
                                && countDic.All(c => hashSet.ContainsKey(c.Key) && hashSet[c.Key] == c.Value))
                            {
                                result.Add(index);
                                hashSet.Clear();
                            }
                        }
                        else
                        {
                            if (hashSet[value] < countDic[value])
                            {
                                hashSet[value]++;
                                if (hashSet.Count == noRepeatingWordsCount
                                && countDic.All(c => hashSet.ContainsKey(c.Key) && hashSet[c.Key] == c.Value))
                                {
                                    result.Add(index);
                                    hashSet.Clear();
                                }
                            }
                            else
                            {
                                hashSet.Clear();
                                break;
                            }
                        }
                    }
                    hashSet.Clear();
                }
            }
            return result;
        }

        /// <summary>
        /// LC_0031
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            var index = nums.Length - 1;
            while (index >= 1)
            {
                if (nums[index - 1] >= nums[index])
                {
                    index--;
                }
                else
                {
                    break;
                }
            }

            if (index == 0)
            {
                Reverse(ref nums, 0, nums.Length - 1);
                return;
            }

            //find  [nums.Length - 1... index] first > [index - 1]

            var findIndex = nums.Length - 1;
            while (findIndex >= index)
            {
                if (nums[findIndex] > nums[index - 1])
                    break;
                findIndex--;
            }

            Swap(ref nums, index - 1, findIndex);

            //move findIndex to Max=>Min order
            ReOrder(ref nums, index, nums.Length - 1, findIndex);
            //reverse
            Reverse(ref nums, index, nums.Length - 1);
        }

        /// <summary>
        /// LC_0032
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return 0;
            var max = 0;
            var dp = new int[s.Length];
            Stack<Tuple<char, int>> stack = new Stack<Tuple<char, int>>();

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (stack.Count != 0 && stack.Peek().Item1 == '(' && ch == ')')
                {
                    var pop = stack.Pop();
                    var leftIndex = pop.Item2;
                    if (i - leftIndex == 1)//...()
                    {
                        if (leftIndex - 1 >= 0 && dp[leftIndex - 1] != 0)
                        {
                            dp[i] = dp[leftIndex - 1] + 2;
                        }
                        else
                        {
                            dp[i] = 2;
                        }
                    }
                    else// > 1 (...)
                    {
                        if (i - 1 >= 0 && dp[i - 1] != 0)//left ... right
                        {
                            dp[i] = dp[i - 1] + 2;
                        }
                        if (leftIndex - 1 >= 0 && dp[leftIndex - 1] != 0)
                        {
                            dp[i] = dp[i] + dp[leftIndex - 1];
                        }
                    }
                    if (dp[i] > max)
                        max = dp[i];
                }
                else
                {
                    stack.Push(new Tuple<char, int>(ch, i));
                }
            }
            return max;
        }

        /// <summary>
        /// LC_0033
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            return Search(ref nums, 0, nums.Length - 1, target);
        }

        private int Search(ref int[] nums, int left, int right, int target)
        {
            if (left == right)
            {
                if (nums[left] == target)
                    return left;
                else
                    return -1;
            }

            var middle = (left + right) / 2;
            if (nums[left] < nums[middle])//left up continue
            {
                if (nums[left] <= target && target <= nums[middle])
                {
                    return Search(ref nums, left, middle, target);
                }
                else
                {
                    return Search(ref nums, middle + 1, right, target);
                }
            }
            else
            {
                if (nums[middle + 1] <= target && target <= nums[right])
                {
                    return Search(ref nums, middle + 1, right, target);
                }
                else
                {
                    return Search(ref nums, left, middle, target);
                }
            }
        }

        /// <summary>
        /// LC_0034
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[] { -1, -1 };
            if (nums == null || nums.Length == 0)
                return result;
            RangeSearch(ref nums, 0, nums.Length - 1, target, ref result);
            return result;
        }

        private void RangeSearch(ref int[] nums, int left, int right, int target, ref int[] result)
        {
            if (left == right)
            {
                if (nums[left] == target)
                {
                    if (result[0] == -1 || left < result[0])
                        result[0] = left;
                    if (result[1] == -1 || left > result[1])
                        result[1] = left;
                }
                return;
            }
            var middle = (left + right) / 2;
            if (nums[left] <= target && target <= nums[middle])
            {
                RangeSearch(ref nums, left, middle, target, ref result);
            }
            if (nums[middle + 1] <= target && target <= nums[right])
            {
                RangeSearch(ref nums, middle + 1, right, target, ref result);
            }
        }

        /// <summary>
        /// LC_0035
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var left = 0;
            var right = nums.Length;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (target < nums[mid])
                {
                    right = mid;
                }else if(target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return left;
        }
    }
}