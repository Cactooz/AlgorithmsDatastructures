using System.Diagnostics;

namespace LinkedList {
    internal class Program {
        static void Main(string[] args) {
            //Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
            //Minimum size to test from
            int minSize = 10;
            //Maximum size to test to
            int maxSize = 1000000;
            //The amount of times to run the tests
            int runAmount = 10000;

            for(int i = minSize; i < maxSize; i *= 2) {
                long minTime = long.MaxValue;
                for(int j = 0; j < runAmount; j++) {

                    //Create a varying and a fixed size list
                    LinkedList list = GenerateList(i);
                    LinkedList fixedList = GenerateList(1000);

                    //Create a varying and a fixed size array
                    Arrays array = new Arrays(GenerateArray(i));
                    Arrays fixedArray = new Arrays(GenerateArray(1000));

                    long t0 = Stopwatch.GetTimestamp();
                    array.Append(fixedArray);
                    long t1 = Stopwatch.GetTimestamp();

                    //Save only  minimum time
                    long time = (t1 - t0) * nanosecondsPerTick;
                    if(time < minTime)
                        minTime = time;
                }
                Console.Write($"({i},{minTime})");
            }
        }

        /// <summary>
        /// Generate a new <seealso cref="LinkedList"/> with the inputted size.
        /// </summary>
        /// <param name="size">The size the new list should be.</param>
        /// <returns>A new <seealso cref="LinkedList"/>.</returns>
        private static LinkedList GenerateList(int size) {
            LinkedList list = new LinkedList(0, null);
            //Pointer to the list to not change the original list
            LinkedList pointer = list;

            //Loop through and add next references to create the list with the size
            for(int i = 0; i < size; i++) {
                pointer.SetNext(new LinkedList(i, null));
                pointer = pointer.GetNext();
            }

            return list;
        }

        /// <summary>
        /// Generate a new array with the inputted size.
        /// </summary>
        /// <param name="size">The size the new array should be.</param>
        /// <returns>A new int array.</returns>
        private static int[] GenerateArray(int size) {
            int[] array = new int[size];

            //Fill the array with numbers
            for(int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}
