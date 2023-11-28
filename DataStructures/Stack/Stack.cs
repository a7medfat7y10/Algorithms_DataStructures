using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        private int[] array;
        private int top;
        private int capacity;

        public Stack(int size)
        {
            array = new int[size];
            capacity = size;
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == capacity - 1;
        }

        public void Push(int data)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack overflow");
                return;
            }

            array[++top] = data;
        }

        public int? Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow");
                return null;
            }

            return array[top--];
        }

        public int? Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return null;
            }

            return array[top];
        }

        public void Display()
        {
            for (int i = 0; i <= top; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
