using System.Diagnostics;

namespace Sorting {
    internal class Program {
        static void Main(string[] args) {
            // Variable for converting GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

            //Amount of times to run the test for average time
            int runAmount = 10000;

            long time = 0;

            for(int i = 100; i < 100000; i*=2) {
                for(int j = 0; j < runAmount; j++) {
                    int[] array = Utilities.RandomArray(i);

                    long t0 = Stopwatch.GetTimestamp();
                    SelectionSort.Sort(array);
                    //InsertionSort.Sort(array);
                    long t1 = Stopwatch.GetTimestamp();

                    time += (t1 - t0) * nanosecondsPerTick;
                }
                Console.WriteLine($"{i}: {time / runAmount}ns");
            }
        }
    }
}
