namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Stack elements:");
            stack.Display();  // Output: 1 2 3

            Console.WriteLine("Peek top element: " + stack.Peek());  // Output: Peek top element: 3

            Console.WriteLine("Popped element: " + stack.Pop());  // Output: Popped element: 3
            Console.WriteLine("Stack elements after pop:");
            stack.Display();  // Output: 1 2
        }
    }
}