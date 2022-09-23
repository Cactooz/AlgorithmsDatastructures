namespace Trees {
    internal class Program {
        static void Main(string[] args) {
            for(int i = 2; i < 100; i *= 2) {
                BinaryTree tree = new BinaryTree(i);
                tree.Print();
            }
        }
    }
}
