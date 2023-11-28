using static Searching_Algorithms.SearchAlgorithms;
namespace Searching_Algorithms
{
    internal class Program
    {
        public static void Main()
        {
            int[] arr = { 2, 4, 7, 10, 13, 18, 23, 27, 33 };

            int linearResult = LinearSearch(arr, 13);
            Console.WriteLine("Linear Search:");
            if (linearResult != -1)
                Console.WriteLine("Element found at index: " + linearResult);
            else
                Console.WriteLine("Element not found");

            int binaryResult = BinarySearch(arr, 13);
            Console.WriteLine("\nBinary Search:");
            if (binaryResult != -1)
                Console.WriteLine("Element found at index: " + binaryResult);
            else
                Console.WriteLine("Element not found");
        }
    }
}