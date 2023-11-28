namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Queue elements:");
            queue.Display();  // Output: 1 2 3

            Console.WriteLine("Front element: " + queue.Front());  // Output: Front element: 1

            Console.WriteLine("Dequeued element: " + queue.Dequeue());  // Output: Dequeued element: 1
            Console.WriteLine("Queue elements after dequeue:");
            queue.Display();  // Output: 2 3
        }
    }
}