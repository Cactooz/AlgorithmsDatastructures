namespace QuickSort {
    internal class Program {
        static void Main(string[] args) {
            int[] array = { 1,5,0,7,4,8,9,3 };
            QuickSort quickSort = new QuickSort();

            Console.WriteLine($"[ {String.Join(", ", quickSort.SortStart(array))} ]");
        }
    }
}
