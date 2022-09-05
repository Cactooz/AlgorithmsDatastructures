// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

class SortedData {
    /// <summary>
    /// Variable for converting GetTimestamp output to nanoseconds.
    /// </summary>
    private static long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

    /// <summary>
    /// Main public method to run the different tests
    /// </summary>
    public static void Main(string[] args) {
        //The amount of times the benchmark should be run
        int runAmount = 10000;

        //Do the benchmark for multiple array sizes
        for(int i = 1000; i <= 10000; i += 1000) {
            long minTime = long.MaxValue;
            long time = 0;
            int[] array = ArrayFillRandom(new int[25 * i]);

            //Chose if the array should be searched before the search or not
            bool sort = true;

            //Sort the array for sorted array search
            if(sort)
                Array.Sort(array);

            for(int j = 0; j < runAmount; j++) {
                //Measure the time it takes to search for the key
                long t0 = Stopwatch.GetTimestamp();
                Search(array, 5, sort);
                long t1 = Stopwatch.GetTimestamp();

                //Save only the fastest time
                time = (t1 - t0) * nanosecondsPerTick;
                if(time < minTime)
                    minTime = time;
            }

            Console.WriteLine($"{i}: {time}ns");
        }
    }

    /// <summary>
    /// Fill array with random numbers.
    /// </summary>
    /// <param name="array">The array to fill with random numbers.</param>
    /// <returns>The same array with random numbers.</returns>
    private static int[] ArrayFillRandom(int[] array) {
        Random random = new Random();
        for(int i = 0; i < array.Length; i++)
            array[i] = random.Next(array.Length);
        return array;
    }

    /// <summary>
    /// Searches for a <c>key</c> in an unsorted or sorted <c>array</c>.
    /// </summary>
    /// <param name="array">The array to search through.</param>
    /// <param name="key">The key to search for.</param>
    /// <param name="sorted">It the inputted array is sorted or not</param>
    /// <returns>If the <c>key</c> can be found in the <c>array</c> or not.</returns>
    private static bool Search(int[] array, int key, bool sorted) {
        for(int i = 0; i < array.Length; i++) {
            if(i > key && sorted)
                return false;
            else if(array[i] == key)
                return true;
        }
        return false;
    }
}
