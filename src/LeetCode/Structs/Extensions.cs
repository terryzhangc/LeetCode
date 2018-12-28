using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Structs
{
    public static class Extensions
    {
        public static int[] ToArray(this ListNode head)
        {
            if (head == null)
                return new int[] { };
            var list = new List<int>();
            var p = head;
            while (p != null)
            {
                list.Add(p.val);
                p = p.next;
            }
            return list.ToArray();
        }

        public static void WriteLine<T>(this IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.Write("\n");
        }

        public static bool CompareArray<T>(this T[] source, T[] dest)
        {
            if (source == null && dest == null)
                return true;
            if (source != null && dest == null)
                return false;
            if (source == null && dest != null)
                return false;

            if (source.Length != dest.Length)
                return false;

            for (int i = 0; i < source.Length; i++)
            {
                if (!source[i].Equals(dest[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CompareSet<T>(this T[] source, T[] dest)
        {
            if (source == null && dest == null)
                return true;
            if (source != null && dest == null)
                return false;
            if (source == null && dest != null)
                return false;
            if (source.Length != dest.Length)
                return false;

            HashSet<T> srcSet = new HashSet<T>(source);
            return srcSet.SetEquals(dest);
        }
    }
}
