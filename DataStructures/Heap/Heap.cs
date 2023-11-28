using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Heap
    {
        private int[] data_list;
        private int size;

        public Heap()
        {
            data_list = new int[100]; // Adjust the initial size of the array as needed
            size = 0;
        }

        public void Insert(int data)
        {
            int i = size;
            data_list[i] = data;
            size++;

            int parent_index = (i - 1) / 2;
            while (i != 0 && data_list[i] < data_list[parent_index])
            {
                int temp = data_list[i];
                data_list[i] = data_list[parent_index];
                data_list[parent_index] = temp;
                i = parent_index;
                parent_index = (i - 1) / 2;
            }
        }

        public int? Pop()
        {
            if (size == 0)
                return null;

            int i = 0;
            int data = data_list[i];
            data_list[i] = data_list[size - 1];
            data_list[size - 1] = 0; // Assuming 0 represents null or empty value
            size--;

            int left_index = 2 * i + 1;
            while (left_index < size)
            {
                int right_index = 2 * i + 2;

                int smaller_index = left_index;
                if (right_index < size && data_list[right_index] < data_list[left_index])
                    smaller_index = right_index;

                if (data_list[smaller_index] >= data_list[i])
                    break;

                int temp = data_list[i];
                data_list[i] = data_list[smaller_index];
                data_list[smaller_index] = temp;

                i = smaller_index;
                left_index = 2 * i + 1;
            }

            return data;
        }

        public void Print()
        {
            string print_data = "";
            for (int i = 0; i < size; i++)
            {
                print_data += data_list[i] + " - ";
            }
            Console.WriteLine(print_data);
        }

        public int Size()
        {
            return size;
        }

        public void Draw()
        {
            int levels_count = (int)Math.Log2(size) + 1;
            int line_width = (int)Math.Pow(2, levels_count - 1);

            int j = 0;
            for (int i = 0; i < levels_count; i++)
            {
                int nodes_count = (int)Math.Pow(2, i);
                int space = (int)Math.Ceiling(line_width - nodes_count / 2.0);
                int space_between = (int)Math.Ceiling(levels_count / (double)nodes_count);
                space_between = space_between < 1 ? 1 : space_between;
                int k = j;
                string str = new String(' ', space + space_between);
                for (; j < k + nodes_count; j++)
                {
                    if (j == size)
                    {
                        break;
                    }
                    if (data_list[j] != 0)
                    {
                        str += data_list[j] + new String(' ', space_between);
                    }
                }
                str += new String(' ', space);
                Console.WriteLine(str);
            }
        }
    }
}
