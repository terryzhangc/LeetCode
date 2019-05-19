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

        public void Swap(ref int[] array, int left, int right)
        {
            if (left >= array.Length || right >= array.Length)
                throw new IndexOutOfRangeException($"{nameof(left) } or {nameof(left)} out of range.");
            if (left == right)
                return;
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        public void Permutation(ref int[] array, int start, ref List<IList<int>> outPut)
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

        public void QuickSort(ref int[] arr, int left, int right)
        {
            int i = left, j = right;
            int tmp;
            int pivot = arr[(left + right) / 2];
            /* partition */
            while (i <= j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            };
            /* recursion */
            if (left < j)
                QuickSort(ref arr, left, j);
            if (i < right)
                QuickSort(ref arr, i, right);
        }

        public void Reverse(ref int[] array, int left, int right)
        {
            if (left >= array.Length || right >= array.Length)
                throw new IndexOutOfRangeException($"{nameof(left) } or {nameof(left)} out of range.");
            if (left == right)
                return;
            while (left < right)
            {
                Swap(ref array, left, right);
                left++;
                right--;
            }
        }

        // array[0...n] in max=>min order, except index, Then Reorder this array.
        public void ReOrder(ref int[] array, int left, int right, int index)
        {
            if (left >= array.Length || right >= array.Length)
                throw new IndexOutOfRangeException($"{nameof(left) } or {nameof(left)} out of range.");
            if (left == right)
                return;
            if (index > right || index < left)
                throw new IndexOutOfRangeException($"index not in left...right range.");

            var moveToLeft = false;
            if (index == left)
            {
                moveToLeft = false;
            }
            else if (index == right)
            {
                moveToLeft = true;
            }
            else if (index > left && index < right)
            {
                if (array[index] <= array[index - 1] && array[index] >= array[index + 1])
                {
                    return;
                }
                else if (array[index] < array[index + 1])
                {
                    moveToLeft = false;
                }
                else
                {
                    moveToLeft = true;
                }
            }

            if (moveToLeft)
            {
                while (index - 1 >= left)// move to left
                {
                    if (array[index] > array[index - 1])
                    {
                        Swap(ref array, index, index - 1);
                        index--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                while (index + 1 <= right)// move to right
                {
                    if (array[index] < array[index + 1])
                    {
                        Swap(ref array, index, index + 1);
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
