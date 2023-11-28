using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms
{
    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
        public double ValuePerWeight { get; set; }

        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
            ValuePerWeight = (double)value / weight;
        }
    }

    public class FractionalKnapsack
    {
        // Greedy algorithm to solve Fractional Knapsack problem
        public static double MaximizeValue(Item[] items, int capacity)
        {
            Array.Sort(items, (a, b) => b.ValuePerWeight.CompareTo(a.ValuePerWeight));

            double totalValue = 0.0;

            foreach (var item in items)
            {
                if (capacity >= item.Weight)
                {
                    // Take the whole item
                    totalValue += item.Value;
                    capacity -= item.Weight;
                }
                else
                {
                    // Take a fraction of the item
                    totalValue += (item.ValuePerWeight * capacity);
                    break;
                }
            }

            return totalValue;
        }

    }
}
