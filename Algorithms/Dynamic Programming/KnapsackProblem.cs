using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Profit { get; set; }
    }

    public class KnapsackProblem
    {
        public static int Knapsack(List<Item> items, int maxWeight, out List<string> solution)
        {
            items.Insert(0, new Item { Name = "#0", Weight = 0, Profit = 0 });

            int n = items.Count;
            int[,] dp = new int[n, maxWeight + 1];
            solution = new List<string>();

            int i;
            int j;
            for (i = 1; i < n; i++)
            {
                for (j = 1; j <= maxWeight; j++)
                {
                    if (items[i].Weight <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], items[i].Profit + dp[i - 1, j - items[i].Weight]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            i = n - 1;
            j = maxWeight;
            int remain = maxWeight;
            while (remain >= 0 && j > 0)
            {
                if (dp[i, j] > dp[i - 1, j])
                {
                    solution.Add(items[i].Name);
                    remain -= items[i].Weight;
                    j = remain;
                    i--;
                }
                else
                {
                    i--;
                }
            }

            return dp[n - 1, maxWeight];
        }
    }

}
