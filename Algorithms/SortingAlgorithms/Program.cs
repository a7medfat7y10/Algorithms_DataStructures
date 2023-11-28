namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 9, 3, 7, 5 };
            SortingAlgorithms.SelectionSort(arr);
            SortingAlgorithms.InsertionSort(arr);
            SortingAlgorithms.BubbleSort(arr);
            SortingAlgorithms.QuickSort(arr, 0, 4);
            SortingAlgorithms.MergeSort(arr, 0, 4);

            Console.WriteLine("[" + arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3] + "," + arr[4] + "]");
        }
    }
}