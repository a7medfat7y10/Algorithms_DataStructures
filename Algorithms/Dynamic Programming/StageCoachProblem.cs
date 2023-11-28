using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class State
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Cost { get; set; }
    }

    public class StageCoachProblem
    {
        static string[] labels = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static int[,] data = {
            { 0, 2, 4, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 7, 4, 6, 0, 0, 0 },
            { 0, 0, 0, 0, 3, 2, 4, 0, 0, 0 },
            { 0, 0, 0, 0, 4, 1, 5, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 4, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 6, 3, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 3, 3, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        public static void FindMinCostPath()
        {
            int n = data.GetLength(0);
            var states = new List<State>();

            // Initialize the states list with default values
            for (int i = 0; i < n; i++)
            {
                states.Add(new State { From = labels[i], To = "", Cost = int.MaxValue });
            }

            states[n - 1].Cost = 0; // Set the cost for the last state (destination)

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (data[i, j] == 0) continue;

                    int newCost = data[i, j] + states[j].Cost;

                    if (newCost < states[i].Cost)
                    {
                        states[i].To = labels[j];
                        states[i].Cost = newCost;
                    }
                }
            }

            Console.WriteLine("States:");
            foreach (var state in states)
            {
                Console.WriteLine($"From: {state.From}, To: {state.To}, Cost: {state.Cost}");
            }

            var path = new List<string> { "A" };
            int k = 0;
            int l = 0;
            while (k < states.Count)
            {
                if (states[k].From == path[l])
                {
                    path.Add(states[k].To);
                    l++;
                }
                k++;
            }

            Console.WriteLine("Minimum Cost: " + states[0].Cost);
            Console.WriteLine("Minimum Path: " + string.Join(", ", path));
        }
    }
}
