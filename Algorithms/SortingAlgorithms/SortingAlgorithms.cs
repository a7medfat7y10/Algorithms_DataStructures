using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SortingAlgorithms
    {
        //choose the min element and swap it to the right position
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        //
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = 0;

                for  (j = i - 1; j >= 0; --j)
                {
                    if ((arr[j] > key))
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = key;

            }
        }

        //moving the bigger element to the end of the array
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //divide and conquer based on the recursion as you choose a pivot say the element at high
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {

                //seperate the lower elements to the left of the pivot
                if (arr[j] < pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            //take the pivot from the high position to the position of i+1 to be in the middle of the lower and higher elements
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            //return the pivot index
            return i + 1;
        }


        //Merge Sort
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int left_length = mid - left + 1;
            int right_length = right - mid;

            int[] Left_Array = new int[left_length];
            int[] Right_Array = new int[right_length];

            Array.Copy(arr, left, Left_Array, 0, left_length);
            Array.Copy(arr, mid + 1, Right_Array, 0, right_length);

            int i = 0, j = 0;
            int k = left;

            while (i < left_length && j < right_length)
            {
                if (Left_Array[i] <= Right_Array[j])
                {
                    arr[k] = Left_Array[i];
                    i++;
                }
                else
                {
                    arr[k] = Right_Array[j];
                    j++;
                }
                k++;
            }

            while (i < left_length)
            {
                arr[k] = Left_Array[i];
                i++;
                k++;
            }

            while (j < right_length)
            {
                arr[k] = Right_Array[j];
                j++;
                k++;
            }
        }
    }
}
