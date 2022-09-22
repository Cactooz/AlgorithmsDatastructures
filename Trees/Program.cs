namespace Trees {
    internal class Program {
        static void Main(string[] args) {
            BinaryTree tree = new BinaryTree();
            tree.Add(10, 3);
            tree.Add(8, 6);
            tree.Add(12, 10);
            tree.Add(9, 3);
            tree.Add(4, 1);
            tree.Add(11, 11);
            tree.Add(13, 5);
            tree.Add(7, 8);

            tree.Print();

            Console.WriteLine(tree.Lookup(12));
        }
    }
}
