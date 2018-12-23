using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public partial class Solution
    {
        /// <summary>
        /// LC_0121
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;
            var m = new int[2, prices.Length];
            //[0, ...n] n min purchase
            //[1, ...n] n max earn value  
            //max(n) => max(sold(n) - minPurchase(1..n-1), max(n-1))    
            for (int i = 0; i < prices.Length; i++)
            {
                if (i == 0)
                {
                    m[0, i] = prices[i];
                    m[1, i] = 0;
                }
                else
                {
                    if (prices[i] < m[0, i - 1])
                    {
                        m[0, i] = prices[i];
                    }
                    else
                    {
                        m[0, i] = m[0, i - 1];
                    }

                    if (prices[i] - m[0, i - 1] > m[1, i - 1])
                    {
                        m[1, i] = prices[i] - m[0, i - 1];
                    }
                    else
                    {
                        m[1, i] = m[1, i - 1];
                    }
                }
            }

            return m[1, prices.Length - 1];
        }
    }
}
