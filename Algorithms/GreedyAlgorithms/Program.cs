namespace GreedyAlgorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Example start and finish times of activities
            int[] startTimes = { 1, 3, 0, 5, 8, 5 };
            int[] finishTimes = { 2, 4, 6, 7, 9, 9 };
            // Sort the activities based on finish times (ascending order)
            Array.Sort(finishTimes, startTimes);
            // Print the maximum set of activities
            ActivitySelectionProblem.PrintMaxActivities(startTimes, finishTimes);

            //Characters Frequency
            CharFreq cf = new CharFreq();
            string msg = "The output from Huffman's algorithm can be viewed as a variable length code table for encoding a source symbol. The algorithm derives this table from the estimated probability or frequency of occurrence for each possible value of the source symbol. as in other entropy encoding methods, more common symbols are generally represented using fewer bits than less common symbols. Huffman's method can be efficiently implemented, finding a code in time linear to the number of input weights if these weights are sorted. However, although optimal among methods encoding symbols separately, Huffman coding is not always optimal among all compression methods it is replaced with arithmetic coding or asymmetric numeral systems if better compression ratio is required.";
            //cf.ASCIIMethod(msg);
            cf.AnyCodeMethod(msg);


            //Huffman Coding
            Huffman huff = new Huffman(msg);
            foreach (char k in huff.codes.Keys)
            {
                Console.Write(k + " ");
                Console.WriteLine(huff.codes[k]);
            }

            //KnapSack Problem
            // Example items with weights and values
            Item[] items = {
            new Item(10, 60),
            new Item(20, 100),
            new Item(30, 120)
            };
            int capacity = 50;
            // Find the maximum value that can be obtained
            double maxValue = FractionalKnapsack.MaximizeValue(items, capacity);
            Console.WriteLine("Maximum value in Knapsack = " + maxValue);
        }

    }
}