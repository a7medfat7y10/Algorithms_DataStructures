namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<char> tree = new BinaryTree<char>();
            tree.Insert('A');
            tree.Insert('B');
            tree.Insert('C');
            tree.Insert('D');
            tree.Insert('E');
            tree.Insert('F');
            tree.Insert('G');
            tree.Insert('H');
            tree.Insert('I');
            tree.Print();

            Console.WriteLine("Height: " + tree.Height());
            tree.PreOrder();
            tree.InOrder();
            tree.PostOrder();


            BSTree.BinaryTree<int> tree2 = new BSTree.BinaryTree<int>();
            tree2.BSInsert(1);
            tree2.BSInsert(4);
            tree2.BSInsert(2);
            tree2.BSInsert(3);
            tree2.BSInsert(6);
            tree2.BSInsert(5);
            tree2.Print();
            Console.WriteLine(tree2.IsExsit(8));
            tree2.BsDelete(4);
            tree2.Print();
            tree2.BsDelete(6);
            tree2.Print();
            tree2.BsDelete(3);
            tree2.BsDelete(5);
            tree2.Print();
            tree2.BsDelete(7);
            tree2.Print();
            tree2.BsDelete(2);
            tree2.Print();
            tree2.BsDelete(1);
            tree2.Print();

            tree2.BSInsert(1);
            tree2.BSInsert(2);
            tree2.BSInsert(3);
            tree2.BSInsert(4);
            tree2.BSInsert(5);
            tree2.BSInsert(6);
            tree2.BSInsert(7);
            tree2.Print();

            tree2.Balance();
            tree2.Print();
        }
    }
}