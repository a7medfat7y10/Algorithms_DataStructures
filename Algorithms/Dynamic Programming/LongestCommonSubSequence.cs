using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class LongestCommonSubsequence
    {
        public static void LCS(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;

            int[,] dp = new int[m + 1, n + 1];
            int i;
            int j;

            // Building the dp matrix
            for (i = 0; i <= m; i++)
            {
                for (j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (text1[i - 1] == text2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            Console.WriteLine("Length of Longest Common Subsequence: " + dp[m, n]);

        }
    }
}
