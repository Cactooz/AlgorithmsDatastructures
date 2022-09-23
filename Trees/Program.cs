using System.Diagnostics;

namespace Trees {
    internal class Program {
        static void Main(string[] args) {
            //Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
            //Prefix for the output to convert from nanoseconds
            int prefix = 1000;
            //Minimum size to test from
            int minSize = 2;
            //The size of the linkedList
            int maxSize = 20000000;
            //The amount of times to run the tests
            int runAmount = 10000;

            Random random = new Random();

            Console.WriteLine("i:\tTree\tArray");
            for(int i = minSize; i < maxSize; i *= 2) {
                long treeTime = 0;
                long arrayTime = 0;

                BinaryTree tree = new BinaryTree(i);
                int[] array = ArrayFillSorted(new int[i]);

                for(int j = 0; j < runAmount; j++) {
                    int key = random.Next((i * 2) + 1);

                    long treeT0 = Stopwatch.GetTimestamp();

                    tree.Lookup(key);

                    long treeT1 = Stopwatch.GetTimestamp();

                    treeTime += (treeT1 - treeT0) * nanosecondsPerTick;

                    long arrayT0 = Stopwatch.GetTimestamp();

                    BinarySearch(array, key);

                    long arrayT1 = Stopwatch.GetTimestamp();

                    arrayTime += (arrayT1 - arrayT0) * nanosecondsPerTick;
                }
                Console.WriteLine($"{i}:\t{treeTime / runAmount}\t{arrayTime / runAmount}");
            }
        }

        /// <summary>
        /// Fill array with sorted random numbers, where there are no duplicate numbers.
        /// </summary>
        /// <param name="array">The array to fill with random numbers.</param>
        /// <returns>The same array with sorted random numbers.</returns>
        private static int[] ArrayFillSorted(int[] array) {
            Random random = new Random();
            int next = 0;
            for(int i = 0; i < array.Length; i++) {
                next += random.Next(6) + 1;
                array[i] = next;
            }
            return array;
        }

        /// <summary>
        /// Binary searching for <c>key</c> in inputted <c>array</c>.
        /// The <c>array</c> must be sorted.
        /// </summary>
        /// <param name="array">The array to search through.</param>
        /// <param name="key">The key to search for.</param>
        /// <returns>If the <c>key</c> can be found in the <c>array</c> or not.</returns>
        private static bool BinarySearch(int[] array, int key) {
            int first = 0;
            int last = array.Length - 1;

            while(true) {
                //Set the mid between the first and last point
                int mid = (first + last) / 2;

                if(array[mid] == key)
                    return true;
                //If the key is larger than the current value, set the first point to current mid
                if(array[mid] < key && mid < last) {
                    first = mid + 1;
                    continue;
                }
                //If the key is smaller than the current value, set the last point to current mid
                else if(array[mid] > key && mid > first) {
                    last = mid - 1;
                    continue;
                }
                //If first = last, then there are no value in the array matching the key
                return false;
            }
        }
    }
}
