using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue
    {
        private int[] array;
        private int front;
        private int rear;
        private int capacity;
        private int size;

        public Queue(int size)
        {
            this.capacity = size;
            array = new int[size];
            front = 0;
            rear = -1;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == capacity;
        }

        public void Enqueue(int data)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }

            rear = (rear + 1) % capacity;
            array[rear] = data;
            size++;
        }

        public int? Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return null;
            }

            int dequeued = array[front];
            front = (front + 1) % capacity;
            size--;
            return dequeued;
        }

        public int? Front()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return null;
            }

            return array[front];
        }

        public void Display()
        {
            int count = 0;
            int i = front;
            while (count < size)
            {
                Console.Write(array[i] + " ");
                i = (i + 1) % capacity;
                count++;
            }
            Console.WriteLine();
        }
    }
}
