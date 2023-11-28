using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class PriorityQueue
    {
        private struct PriorityData
        {
            public int Priority { get; set; }
            public int Data { get; set; }
        }

        private PriorityData[] data_list;
        private int size;

        public PriorityQueue()
        {
            data_list = new PriorityData[100]; // Adjust the initial size of the array as needed
            size = 0;
        }

        public void Enqueue(int priority, int data)
        {
            int i = size;
            data_list[i] = new PriorityData { Priority = priority, Data = data };
            size++;
            int parent_index = (i - 1) / 2;
            while (i != 0 && data_list[i].Priority < data_list[parent_index].Priority)
            {
                var temp = data_list[i];
                data_list[i] = data_list[parent_index];
                data_list[parent_index] = temp;
                i = parent_index;
                parent_index = (i - 1) / 2;
            }
        }

        public int[] Dequeue()
        {
            if (size == 0)
                return null;

            int i = 0;
            int data = data_list[i].Data;
            int priority = data_list[i].Priority;

            // Copy last node to root
            data_list[i] = data_list[size - 1];

            // Delete last node
            data_list[size - 1] = new PriorityData();
            size--;

            int left_index = 2 * i + 1;
            while (left_index < size)
            {
                int right_index = 2 * i + 2;

                int smaller_index = left_index;
                if (right_index < size && data_list[right_index].Priority < data_list[left_index].Priority)
                    smaller_index = right_index;

                if (data_list[smaller_index].Priority >= data_list[i].Priority)
                    break;

                // Swap
                var temp = data_list[i];
                data_list[i] = data_list[smaller_index];
                data_list[smaller_index] = temp;

                i = smaller_index;
                left_index = 2 * i + 1;
            }

            return new int[] { data, priority };
        }

        public bool HasData()
        {
            return size > 0;
        }

        public void Print()
        {
            string print_data = "";
            for (int i = 0; i < size; i++)
            {
                print_data += data_list[i].Data + " - ";
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
                    if (data_list[j].Data != 0)
                    {
                        str += data_list[j].Data + "[" + data_list[j].Priority + "]" + new String(' ', space_between);
                    }
                }
                str += new String(' ', space);
                Console.WriteLine(str);
            }
        }
    }
}
