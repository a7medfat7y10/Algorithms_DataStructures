namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            Console.WriteLine(list.Sum());
            list.PrintList();

            list.InsertAfter(list.Find(2), 98);
            list.PrintList();

            list.DeleteNode(list.Find(2));
            list.PrintList();

            list.InsertBefore(list.Find(98), 76);
            list.PrintList();

            list.DeleteNode(list.Find(1));
            list.PrintList();


            //DoublyLinkedList.LinkedList list = new DoublyLinkedList.LinkedList();
            //list.InsertLast(1);
            //list.InsertLast(2);
            //list.InsertLast(3);
            //Console.WriteLine(list.Sum());
            //list.PrintList();

            //list.InsertAfter(list.Find(2), 98);
            //list.PrintList();

            //list.DeleteNode(list.Find(2));
            //list.PrintList();

            //list.InsertBefore(list.Find(98), 76);
            //list.PrintList();

            //list.DeleteNode(list.Find(1));
            //list.PrintList();
        }
    }
}