namespace QuickSort {
    internal class Program {
        static void Main(string[] args) {
            //int[] array = { 1,5,0,7,4,8,9,3 };
            //QuickSort quickSort = new QuickSort();

            LinkedList list = new LinkedList(10);
            QuickSortList quickSort = new QuickSortList();

            list.PrintList();
            quickSort.SortStart(list);
            list.PrintList();
        }
    }
}
