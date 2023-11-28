using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms
{
    public class ActivitySelectionProblem
    {
        // Prints a maximum set of activities that can be done by a single person
        // Assumes activities are sorted by their finish times
        public static void PrintMaxActivities(int[] startTimes, int[] finishTimes)
        {
            int n = startTimes.Length;
            if (n <= 0 || finishTimes.Length != n)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("The following activities are selected:");

            // The first activity is always selected
            Console.Write("Activity 0 ");

            // Initialize the index of the next activity
            int i = 0;

            // Consider the rest of the activities
            for (int j = 1; j < n; j++)
            {
                // If this activity has a start time greater than or equal to
                // the finish time of the previously selected activity, then select it
                if (startTimes[j] >= finishTimes[i])
                {
                    Console.Write("Activity " + j + " ");
                    i = j;
                }
            }
            Console.WriteLine();
        }

    }
}
