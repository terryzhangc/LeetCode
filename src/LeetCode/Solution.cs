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
    }
}
