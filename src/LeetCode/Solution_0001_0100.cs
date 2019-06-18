using LeetCode.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        /// <summary>
        /// LC_0036
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[,] board)
        {
            var matrix = new HashSet<char>[3, 3];
            var iArray = new HashSet<char>[9];
            var jArray = new HashSet<char>[9];
            for (int i = 0; i < 9; i++)
            {
                iArray[i] = new HashSet<char>();
                jArray[i] = new HashSet<char>();
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = new HashSet<char>();
                }
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var ch = board[i, j];
                    if (ch != '.')
                    {
                        //i
                        if (iArray[i].Contains(ch))
                            return false;
                        else
                            iArray[i].Add(ch);
                        //j
                        if (jArray[j].Contains(ch))
                            return false;
                        else
                            jArray[j].Add(ch);
                        //area
                        if (matrix[i / 3, j / 3].Contains(ch))
                            return false;
                        else
                            matrix[i / 3, j / 3].Add(ch);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// LC_0037
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[,] board)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var ch = board[i, j];
                    if (ch == '.')
                    {
                        list.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            var result = BFSSolveSudoku(ref board, ref list, 0);
        }

        private bool BFSSolveSudoku(ref char[,] board, ref List<Tuple<int, int>> list, int index)
        {
            if (index == list.Count)
                return true;
            var location = list[index];
            var set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < 9; i++)
            {
                var chI = board[location.Item1, i];
                var chJ = board[i, location.Item2];
                if (chI != '.' && set.Contains(chI))
                {
                    set.Remove(chI);
                }
                if (chJ != '.' && set.Contains(chJ))
                {
                    set.Remove(chJ);
                }
            }
            var baseI = location.Item1 / 3;
            var baseJ = location.Item2 / 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var ch = board[3 * baseI + i, 3 * baseJ + j];
                    if (ch != '.' && set.Contains(ch))
                    {
                        set.Remove(ch);
                    }
                }
            }

             if (set.Count == 0)
                return false;

            foreach (var item in set)
            {
                board[location.Item1, location.Item2] = item;
                var result = BFSSolveSudoku(ref board, ref list, index + 1);
                if (result)
                {
                    return true;
                }
                else
                {
                    board[location.Item1, location.Item2] = '.';
                }
            }
            return false;
        }

        /// <summary>
        /// LC_0038
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            var list = new string[31];
            list[0] = "";
            list[1] = "1";
            list[2] = "11";
            list[3] = "21";
            list[4] = "1211";
            list[5] = "111221";
            //"312211"
            //"13112221"
            //"1113213211"
            //"31131211131221"
            if (n <= 5)
            {
                return list[n];
            }

            var index = 6;

            while (index <= n)
            {
                var pre = list[index - 1];
                var sb = new StringBuilder();
                char symbol = pre[0];
                int count = 1;
                for (int i = 1; i < pre.Length; i++)
                {
                    if (pre[i] != symbol)
                    {
                        sb.Append(count);
                        sb.Append(symbol);
                        symbol = pre[i];
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                    if (i==pre.Length -1)
                    {
                        sb.Append(count);
                        sb.Append(symbol);
                    }
                }
                list[index] = sb.ToString();
                index++;
            }
            return list[n];
        }

        /// <summary>
        /// LC_0039
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var tempList = new List<int>();
            CombinationSumDFS(ref result, ref candidates, target, 0, ref tempList);
            return result;
        }

        private void CombinationSumDFS(ref List<IList<int>> result, ref int[] candidates, int target, int index, ref List<int> temp)
        {
            if (target < 0)
                return;
            if (target == 0)
                result.Add(temp.Select(x => x).ToList());
            for (int i = index; i < candidates.Length; i++)
            {
                if (candidates[i] <= target)
                {
                    temp.Add(candidates[i]);
                    CombinationSumDFS(ref result, ref candidates, target - candidates[i], i, ref temp);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }

        /// <summary>
        /// LC_0040
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var keys = new HashSet<string>();
            var tempList = new List<int>();
            var temp = candidates.ToList();
            temp.Sort();
            var newCandidates = temp.ToArray();
            CombinationSum2DFS(ref result,ref keys, ref newCandidates, target, 0, ref tempList);
            return result;
        }

        private void CombinationSum2DFS(ref List<IList<int>> result, ref HashSet<string> keys, ref int[] candidates, int target, int index, ref List<int> temp)
        {
            if (target < 0)
                return;
            if (target == 0)
            {
                var key = string.Join("", temp);
                if (!keys.Contains(key))
                {
                    result.Add(temp.Select(x => x).ToList());
                    keys.Add(key);
                }
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                if (candidates[i] <= target)
                {
                    temp.Add(candidates[i]);
                    CombinationSum2DFS(ref result, ref keys, ref candidates, target - candidates[i], i + 1, ref temp);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }

        /// <summary>
        /// LC_0041
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            var hash = new HashSet<int>(nums);
            int min = int.MaxValue;
            if (!hash.Contains(1))
                min = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] > 0)
                {
                    var left = nums[i] - 1;
                    var right = nums[i] + 1;
                    if (left > 0 && !hash.Contains(left) && left < min)
                    {
                        min = left;
                    }

                    if (right > 0 && !hash.Contains(right) && right < min)
                    {
                        min = right;
                    }
                }
            }
            return min;
        }

        /// <summary>
        /// LC_0042
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            var sum = 0;
            if (height ==null || height.Length <= 2)
                return 0;

            var leftArray = new int[height.Length];
            var rightArray = new int[height.Length];
            for (int i = 0; i <= height.Length - 1; i++)
            {
                var left = i;
                var right = height.Length - 1 - i;
                if (i == 0)
                {
                    leftArray[left] = height[left];
                    rightArray[right] = height[right];
                }
                else
                {
                    if (leftArray[left - 1] > height[left])
                        leftArray[left] = leftArray[left - 1];
                    else
                        leftArray[left] = height[left];
                    
                    if (rightArray[right + 1] > height[right])
                        rightArray[right] = rightArray[right + 1];
                    else
                        rightArray[right] = height[right];
                }
            }

            for (int i = 1; i < height.Length - 1; i++)
            {
                sum += (Math.Min(leftArray[i], rightArray[i]) - height[i]);
            }
            return sum;
        }

        /// <summary>
        /// LC_0043
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";
            var result = "0";
            var dic = new Dictionary<int,string>();
            // = 10^(n-i) * a[i]  + ... 10^0 * a[n]
            for (int i = 0; i < num2.Length; i++)
            {
                var moveLeftLen = num2.Length - 1 - i;
                var number = num2[i] - '0';
                var cacheStr = "";
                if (dic.ContainsKey(number))
                {
                    cacheStr = dic[number];
                }
                else
                {
                    cacheStr = Multiply(num1, number);
                    dic.Add(number, cacheStr);
                }
                var str = new string('0', moveLeftLen);
                result = Add(result, cacheStr + str);
            }
            return result;
        }

        /// <summary>
        /// LC_0045
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums == null || nums.Length == 1)
                return 0;
            var steps = new HashSet<int>[nums.Length];
            var dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j > 0 && j <= nums[i] && i + j < nums.Length; j++)
                {
                    if (steps[i + j] == null)
                    {
                        steps[i + j] = new HashSet<int>();
                    }
                    steps[i + j].Add(i);
                }

                if (i == 0)
                {
                    dp[i] = 0;
                }
                else
                {
                    foreach (var item in steps[i])
                    {
                        if (dp[item] + 1 < dp[i])
                            dp[i] = dp[item] + 1;
                    }
                }
            }
            return dp[nums.Length - 1];
        }

        /// <summary>
        /// LC_0046
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            if (nums == null)
                return list;
            Permutation(ref nums, 0, ref list);
            return list;
        }

        /// <summary>
        /// LC_0047
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            if (nums == null)
                return list;
            Array.Sort(nums);
            PermutationUnique(ref nums, 0, ref list);
            return list;
        }

        private void PermutationUnique(ref int[] array, int start, ref List<IList<int>> outPut)
        {
            if (start == array.Length - 1)
            {
                outPut.Add(new List<int>(array));
                return;
            }
            for (int i = start; i < array.Length; i++)
            {
                //{start, i} start位置到i位置存在连续相同数字，则放弃本次i的交换，因为之前已经交换过，结果集相同.
                if (Same(ref array, start, i))
                {
                    continue;
                }
                Swap(ref array, i, start);
                PermutationUnique(ref array, start + 1, ref outPut);
                Swap(ref array, i, start);
            }
        }

        private bool Same(ref int[] nums, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (nums[i] == nums[end])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// LC_0048
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            if (matrix == null)
                return;
            var size = matrix.Length;
            //转置
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            //每行数组 前后翻转
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][size - j - 1];
                    matrix[i][size - j - 1] = temp;
                }
            }
        }

        /// <summary>
        /// LC_0049
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var dic = new Dictionary<string, IList<string>>();
            var charNums = new int[26];
            foreach (var str in strs)
            {
                Array.Fill(charNums, 0);
                foreach (var ch in str)
                {
                    charNums[ch - 'a']++;
                }
                var code = string.Join(",", charNums);
                if (dic.ContainsKey(code))
                    dic[code].Add(str);
                else
                    dic.Add(code, new List<string>() { str });
            }
            foreach (var item in dic)
            {
                result.Add(item.Value);
            }
            return result;
        }

        /// <summary>
        /// LC_0050
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            int N = n;
            double multi = x;
            if (n < 0)
            {
                multi = 1 / x;
                N = -n;
            }
            return fastPow(multi, N);
        }

        private double fastPow(double x, int n)
        {
            if (n == 0)
            {
                return 1.0;
            }
            double half = fastPow(x, n / 2);
            if (n % 2 == 0)
            {
                return half * half;
            }
            else
            {
                return half * half * x;
            }
        }

        /// <summary>
        /// LC_0061
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;
            if (k == 0)
                return head;

            var nodeCount = 0;
            ListNode tail = null;
            var pNode = head;
            while (pNode != null)
            {
                nodeCount++;
                tail = pNode;
                pNode = pNode.next;
            }
            if (nodeCount == k || (k % nodeCount) == 0)
                return head;

            ListNode PreNode = null;
            ListNode curNode = head;
            var number = 0;
            var destNumber = k < nodeCount ? k : k % nodeCount;
            while (curNode != null)
            {
                PreNode = curNode;
                curNode = curNode.next;
                number++;
                if (nodeCount - destNumber == number)
                    break;

            }
            tail.next = head;
            PreNode.next = null;
            return curNode;
        }

        /// <summary>
        /// LC_0082
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates1(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var cursor = head;
            ListNode preNode = null;
            while (cursor != null)
            {
                if (preNode != null && preNode.val == cursor.val)
                {
                    cursor = cursor.next;
                    preNode.next = cursor;
                    continue;
                }
                preNode = cursor;
                cursor = cursor.next;
            }
            return head;
        }

        /// <summary>
        /// LC_0083
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var cursor = head;
            ListNode preNode = null;
            while (cursor != null)
            {
                var startCursor = cursor;
                while (cursor.next != null && cursor.val == cursor.next.val)
                {
                    cursor = cursor.next;
                }
                if (startCursor != cursor)
                {
                    cursor = cursor.next;
                    if (preNode == null)
                        head = cursor;
                    else
                        preNode.next = cursor;
                }
                else
                {
                    preNode = cursor;
                    cursor = cursor.next;
                }
            }
            return head;
        }

        /// <summary>
        /// LC_0086
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null || head.next == null)
                return head;
            ListNode lessHead = null;
            ListNode lessCurosr = null;
            ListNode greaterHead = null;
            ListNode greaterCursor = null;
            var cursor = head;
            while (cursor != null)
            {
                if (cursor.val < x)
                {
                    if (lessHead == null)
                    {
                        lessHead = cursor;
                        lessCurosr = cursor;
                    }
                    else
                    {
                        lessCurosr.next = cursor;
                        lessCurosr = lessCurosr.next;
                    }
                }
                else
                {
                    if (greaterHead == null)
                    {
                        greaterHead = cursor;
                        greaterCursor = cursor;
                    }
                    else
                    {
                        greaterCursor.next = cursor;
                        greaterCursor = greaterCursor.next;
                    }
                }
                cursor = cursor.next;
            }
            if (lessHead == null)
            {
                return greaterHead;
            }
            if (greaterHead == null)
            {
                return lessHead;
            }
            greaterCursor.next = null;
            lessCurosr.next = greaterHead;
            return lessHead;
        }

        /// <summary>
        /// LC_0092
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || head.next == null)
                return head;
            if (m == n)
                return head;

            ListNode cursor = head;
            ListNode preCursor = null;
            ListNode nextCursor = null;
            ListNode reverseHead = null;
            ListNode reverseTail = null;

            for (int i = 1; i <= n; i++)
            {
                if (i >= m)
                {
                    var temp = cursor;
                    // append node to reverse list
                    if (reverseHead == null)
                    {
                        cursor = cursor.next;
                        reverseHead = temp;
                        temp.next = null;
                        reverseTail = temp;
                    }
                    else
                    {
                        cursor = cursor.next;
                        temp.next = reverseHead;
                        reverseHead = temp;
                    }
                }
                else
                {
                    preCursor = cursor;
                    cursor = cursor.next;
                }
            }
            nextCursor = cursor;

            if(preCursor == null)
            {
                reverseTail.next = nextCursor;
                return reverseHead;
            }
            else
            {
                preCursor.next = reverseHead;
                reverseTail.next = nextCursor;
                return head;
            }
        }

        public string Multiply(string num1, int num2)
        {
            if (num2 == 0)
                return "0";
            if (num2 == 1)
                return num1;
            var result = new List<char>();
            var preValue = 0;
            var index = num1.Length - 1;
            while (true)
            {
                if (preValue == 0 && index < 0)
                    break;
                var value1 = index >= 0 ? num1[index] - '0' : 0;
                var value = preValue + num2 * value1;
                if (value >= 10)
                {
                    preValue = value / 10;
                    result.Insert(0, (char)(value % 10 + 48));
                }
                else
                {
                    preValue = 0;
                    result.Insert(0, (char)(value + 48));
                }
                index--;
            }
            return new string(result.ToArray());
        }

        public string Add(string num1, string num2)
        {
            if (num1 == "0" && num2 == "0")
                return "0";
            if (num1 == "0")
                return num2;
            if (num2 == "0")
                return num1;

            var result = new List<char>();
            var index1 = num1.Length - 1;
            var index2 = num2.Length - 1;
            var preValue = 0;
            while(true)
            {
                if (preValue == 0 && index1 < 0 && index2 < 0)
                    break;
                var value1 = index1 >= 0 ? num1[index1] - '0' : 0;
                var value2 = index2 >= 0 ? num2[index2] - '0' : 0;
                var value = preValue + value1 + value2;

                if (value >= 10)
                {
                    preValue = 1;
                    result.Insert(0, (char)(value % 10 + 48));
                }
                else
                {
                    preValue = 0;
                    result.Insert(0, (char)(value + 48));
                }

                index1--;
                index2--;

            }
            return new string(result.ToArray());
        }

        /// <summary>
        /// LC_0094
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var temp = root;
            while (temp != null || stack.Count != 0)
            {
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.left;
                }
                if (stack.Count != 0)
                {
                    temp = stack.Pop();
                    result.Add(temp.val);
                    temp = temp.right;
                }
            }
            //InorderTraversal(root, result);
            return result;
        }

        private void InorderTraversal(TreeNode root, IList<int> result)
        {
            if (root == null)
                return;
            InorderTraversal(root.left, result);
            result.Add(root.val);
            InorderTraversal(root.right, result);
        }

        /// <summary>
        /// LC_0095
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> GenerateTrees(int n)
        {
            var result = new List<TreeNode>();
            if (n <= 0)
                return result;
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }
            result = GenerateTrees(ref array, 0, n - 1);
            return result;
        }

        private List<TreeNode> GenerateTrees(ref int[] array, int start, int end)
        {
            var result = new List<TreeNode>();
            if(start> end)
            {
                result.Add(null);
                return result;
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    var leftTrees = GenerateTrees(ref array, start, i - 1);
                    var rightTrees = GenerateTrees(ref array, i + 1, end);
                    foreach (var lNode in leftTrees)
                    {
                        foreach (var rNode in rightTrees)
                        {
                            var newRoot = new TreeNode(array[i]);
                            newRoot.left = lNode;
                            newRoot.right = rNode;
                            result.Add(newRoot);
                        }
                    }
                }
            }
            return result;
        }

        private TreeNode CloneTree(TreeNode root)
        {
            if (root == null)
                return null;
            var node = new TreeNode(root.val);
            node.left = CloneTree(root.left);
            node.right = CloneTree(root.right);
            return node;
        }

        /// <summary>
        /// LC_0096
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;
            var count = new int[n + 1];
            count[0] = 1;
            count[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                var sum = 0;
                for (int start = 1; start <= i; start++)
                {
                    sum += (count[start - 1] * count[i - start]);
                }
                count[i] = sum;
            }
            return count[n];
        }

        /// <summary>
        /// LC_0098
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        public bool IsValidBST(TreeNode root, int? min, int? max)
        {
            if (root == null)
                return true;
            var greaterThanMin = !min.HasValue ? true : min.Value < root.val;
            var lessThanMax = !max.HasValue ? true : root.val < max.Value;
            if (greaterThanMin && lessThanMax)
                return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
            else
                return false;
        }
    }
}