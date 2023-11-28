namespace Dynamic_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StageCoach Problem
            StageCoachProblem.FindMinCostPath();

            //Longest Common Subsequence
            string text1 = "ABCBDAB";
            string text2 = "BDCAB";
            LongestCommonSubsequence.LCS(text1, text2);

            //Knapsack
            List<Item> items = new List<Item>
        {
            new Item { Name = "#1", Weight = 1, Profit = 4 },
            new Item { Name = "#2", Weight = 3, Profit = 9 },
            new Item { Name = "#3", Weight = 5, Profit = 12 },
            new Item { Name = "#4", Weight = 4, Profit = 11 }
        };
            int maxWeight = 8;

            List<string> solution;
            int maxProfit = KnapsackProblem.Knapsack(items, maxWeight, out solution);

            Console.WriteLine("Max Profit: " + maxProfit);
            Console.Write("Solution: ");
            foreach (var item in solution)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}