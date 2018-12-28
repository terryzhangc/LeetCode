using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        protected readonly int[] LookupTable = new int[] {
            0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4,
            1,2,2,3,2,3,3,4,2,3,3,4,3,4,4,5,
            1,2,2,3,2,3,3,4,2,3,3,4,3,4,4,5,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            1,2,2,3,2,3,3,4,2,3,3,4,3,4,4,5,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            3,4,4,5,4,5,5,6,4,5,5,6,5,6,6,7,
            1,2,2,3,2,3,3,4,2,3,3,4,3,4,4,5,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            3,4,4,5,4,5,5,6,4,5,5,6,5,6,6,7,
            2,3,3,4,3,4,4,5,3,4,4,5,4,5,5,6,
            3,4,4,5,4,5,5,6,4,5,5,6,5,6,6,7,
            3,4,4,5,4,5,5,6,4,5,5,6,5,6,6,7,
            4,5,5,6,5,6,6,7,5,6,6,7,6,7,7,8
        };
        public Solution()
        {

        }
        public double GetMedian(int[] array)
        {
            if (array.Length % 2 == 0)
            {
                double sum = array[array.Length / 2] + array[(array.Length / 2) - 1];
                return sum / 2;
            }
            else
            {
                return array[array.Length / 2];
            }
        }

        protected void Swap(ref int[] array, int left, int right)
        {
            if (left >= array.Length || right >= array.Length)
                throw new IndexOutOfRangeException($"{nameof(left) } or {nameof(left)} out of range.");
            if (left == right)
                return;
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        public void Permutation(ref int[] array, int start, ref List<List<int>> outPut)
        {
            if (start == array.Length - 1)
            {
                outPut.Add(new List<int>(array));
            }
            for (int i = start; i < array.Length; i++)
            {
                Swap(ref array, i, start);
                Permutation(ref array, start + 1, ref outPut);
                Swap(ref array, i, start);
            }
        }
    }
}
