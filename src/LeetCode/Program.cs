using System;
using System.Collections.Generic;
using LeetCode.Structs;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var _s = new Solution();
            var array = new int[] { 1, 2, 3, 4, 5 };
            var outPut = new List<List<int>>();
            _s.Permutation(ref array, 0, ref outPut);
            outPut.ForEach(x => x.WriteLine());



            var line = Console.ReadLine();
        }
    }
}
