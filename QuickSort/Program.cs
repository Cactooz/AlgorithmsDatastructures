using System.Diagnostics;

namespace QuickSort {
    internal class Program {
        static void Main(string[] args) {
            //Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
            //Minimum size to test from
            int minSize = 2;
            //The size of the linkedList
            int maxSize = 100000;
            //The amount of times to run the tests
            int runAmount = 1000;

            Random random = new();
            QuickSort quickSort = new();
            QuickSortList quickSortList = new();

            for(int i = minSize; i < maxSize; i *= 2) {
                long arrayMinTime = long.MaxValue;
                long listMinTime = long.MaxValue;

                for(int j = 0; j < runAmount; j++) {

                    //Create the empty array
                    int number = random.Next(i*4);
                    int[] array = new int[i];
                    LinkedList list = new LinkedList(new LinkedList.Node(number, null));

                    //Fill the list and array with the same numbers
                    for(int k = 1; k < i; k++) {
                        number = random.Next(i*4);
                        array[k] = number;
                        list.Add(new LinkedList.Node(number, null));
                    }

                    //Array QuickSort
                    long arrayT0 = Stopwatch.GetTimestamp();

                    quickSort.SortStart(array);

                    long arrayT1 = Stopwatch.GetTimestamp();

                    long arrayTime = arrayT1 - arrayT0;

                    //Check if it is a new minimum time for the array
                    if(arrayTime < arrayMinTime)
                        arrayMinTime = arrayTime * nanosecondsPerTick;

                    //List QuickSort
                    long listT0 = Stopwatch.GetTimestamp();

                    quickSortList.SortStart(list);

                    long listT1 = Stopwatch.GetTimestamp();

                    long listTime = listT1 - listT0;

                    //Check if it is a new minimum time for the list
                    if(listTime < listMinTime)
                        listMinTime = listTime * nanosecondsPerTick;

                }
                Console.WriteLine($"{i}:\t({i},{arrayMinTime})\t({i},{listMinTime})");
            }

        }
    }
}
