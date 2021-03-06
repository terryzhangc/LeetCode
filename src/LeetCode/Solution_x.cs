﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution_x : Solution 
    {
        public int MinPath(int[,] matrix)
        {
            var dp = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = matrix[0, 0];
                    }
                    else if (i == 0 && j > 0)
                    {
                        dp[i, j] = dp[0, j - 1] + matrix[0, j];
                    }
                    else if (i > 0 && j == 0)
                    {
                        dp[i, j] = dp[i - 1, 0] + matrix[i, 0];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + matrix[i, j];
                    }
                }
            }
            return 0;
        }

        public bool CheckExist(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (0 == (list[i] & list[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int TallestBillboardDFS(int[] rods)
        {
            var sum = 0;
            foreach (var item in rods)
            {
                sum += item;
            }
            var half = sum / 2;

            var dic = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < (1 << rods.Length); i++)
            {
                int value = 0;
                for (int index = 0; index < rods.Length; index++)
                {
                    if ((i & (1 << index)) != 0)
                    {
                        value += rods[index];
                    }
                }
                if (value <= 5000 && value <= half)
                {
                    if (dic.ContainsKey(value))
                    {
                        dic[value].Add(i);
                    }
                    else
                    {
                        dic.Add(value, new List<int>() { i });
                    }
                }
            }

            foreach (var pair in dic.Reverse())
            {
                if (CheckExist(pair.Value))
                {
                    return pair.Key;
                }
            }
            return 0;
        }

        public int ClimbStairs(int n)
        {
            var count = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    count[1] = 1;
                }
                else if (i == 2)
                {
                    count[2] = 2;
                }
                else
                {
                    count[i] = count[i - 1] + count[i - 2];
                }
            }
            //s(n) = s(n-1) + s(n-2)
            return count[n];
        }

        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            int res = nums[0];
            var values = new int[nums.Length];
            // s(...n) = max(s(...n-1)+nums[n],nums[n]);
            values[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (values[i - 1] + nums[i] > nums[i])
                {
                    values[i] = values[i - 1] + nums[i];
                }
                else
                {
                    values[i] = nums[i];
                }
                if (values[i] > res)
                {
                    res = values[i];
                }
            }
            return res;
        }

        public int TallestBillboard(int[] rods)
        {
            if (rods.Length == 0)
                return 0;
            var maxValue = 0;
            var dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < rods.Length; i++)
            {
                var currentBitValue = 1 << (rods.Length - i - 1);
                if (i == 0)
                {
                    dic.Add(rods[i], new List<int>() { currentBitValue });
                }
                else
                {
                    var previousSetList = dic.Keys.ToList();
                    foreach (var value in previousSetList)
                    {
                        var newValue = value + rods[i];

                        if (newValue == 10)
                        {

                        }

                        var newList = dic[value].Select(x => (x + currentBitValue)).ToList();
                        if (dic.ContainsKey(newValue))
                        {
                            dic[newValue].AddRange(newList);
                            if (CheckExist(dic[newValue]))
                                maxValue = Math.Max(maxValue, newValue);
                        }
                        else
                        {
                            dic.Add(newValue, newList);
                        }
                    }
                    var currentList = new List<int>() { currentBitValue };
                    if (dic.ContainsKey(rods[i]))
                    {
                        dic[rods[i]].AddRange(currentList);
                        if (CheckExist(dic[rods[i]]))
                            maxValue = Math.Max(maxValue, rods[i]);

                    }
                    else
                    {
                        dic.Add(rods[i], currentList);
                    }
                }
            }

            foreach (var item in dic)
            {
                System.Diagnostics.Debug.WriteLine(item.Key.ToString() + "********");
                item.Value.ForEach(x =>
                {
                    int sum = 0;
                    char[] bits = System.Convert.ToString(x, 2).PadLeft(6, '0').ToCharArray();
                    for (int i = 0; i < rods.Length; i++)
                    {
                        if (bits[i] == '1')
                        {
                            sum += rods[i];
                        }
                    }
                    System.Diagnostics.Debug.WriteLine(new string(bits) + $"={sum}");
                });
            }
            return maxValue;
        }

        public int NumIslands(char[,] grid)
        {
            var y = grid.GetLength(0);
            var x = grid.GetLength(1);
            var map = new int[y, x];
            var allPoints = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '1')
                    {
                        allPoints.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            var count = 0;
            while (allPoints.Count != 0)
            {
                var queue = new Queue<Tuple<int, int>>();
                var first = allPoints.First();
                queue.Enqueue(first);
                map[first.Item1, first.Item2] = 1;
                allPoints.Remove(first);
                while (queue.Count != 0)
                {
                    var viewedPoint = queue.Dequeue();
                    //[y,x]
                    var up = new Tuple<int, int>(viewedPoint.Item1 - 1, viewedPoint.Item2);
                    var right = new Tuple<int, int>(viewedPoint.Item1, viewedPoint.Item2 + 1);
                    var down = new Tuple<int, int>(viewedPoint.Item1 + 1, viewedPoint.Item2);
                    var left = new Tuple<int, int>(viewedPoint.Item1, viewedPoint.Item2 - 1);
                    //up
                    if (up.Item1 >= 0 && grid[up.Item1, up.Item2] == '1' && map[up.Item1, up.Item2] == 0)
                    {
                        map[up.Item1, up.Item2] = 1;
                        allPoints.Remove(up);
                        queue.Enqueue(up);
                    }
                    //right  
                    if (right.Item2 < x && grid[right.Item1, right.Item2] == '1' && map[right.Item1, right.Item2] == 0)
                    {
                        map[right.Item1, right.Item2] = 1;
                        allPoints.Remove(right);
                        queue.Enqueue(right);
                    }
                    //down
                    if (down.Item1 < y && grid[down.Item1, down.Item2] == '1' && map[down.Item1, down.Item2] == 0)
                    {
                        map[down.Item1, down.Item2] = 1;
                        allPoints.Remove(down);
                        queue.Enqueue(down);
                    }
                    //left
                    if (left.Item2 >= 0 && grid[left.Item1, left.Item2] == '1' && map[left.Item1, left.Item2] == 0)
                    {
                        map[left.Item1, left.Item2] = 1;
                        allPoints.Remove(left);
                        queue.Enqueue(left);
                    }
                }
                count++;
            }
            return count;
        }
    }
}
