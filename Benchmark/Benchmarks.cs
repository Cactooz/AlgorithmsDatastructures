using System.Diagnostics;

namespace Benchmark {
    internal class Benchmarks {
        /// <summary>
        /// Variable for converting <seealso cref="Stopwatch.GetTimestamp"/> output to nanoseconds.
        /// </summary>
        private static readonly long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

        /// <summary>
        /// Benchmark the average time it takes to execute a method with arrays.
        /// </summary>
        /// <param name="BenchmarkMethod">The method that should be benchmarked.</param>
        /// <param name="type"> If the output should be for a <c>table</c>, <c>graph</c> or just print it.</param>
        /// <param name="runAmount">The amount of times each test should be run.</param>
        /// <param name="minSize">The minimum size of the array that should be tested.</param>
        /// <param name="maxSize">The maximum size of the array that should be tested.</param>
        /// <param name="increaseSize">What the last size should be multiplied by for the next array size.</param>
        /// <param name="prefix">The output is in nanoseconds, this divides the output by the inputted value.</param>
        /// <returns>Output formatted for LATEX table or graph, or just a simple print.</returns>
        public static void Average(Func<int[], int[]> BenchmarkMethod, string type, int runAmount, int minSize, int maxSize, int increaseSize, int prefix) {
            long time = 0;

            for(int i = minSize; i < maxSize; i *= increaseSize) {
                for(int j = 0; j < runAmount; j++) {
                    int[] array = RandomArray(i);

                    long t0 = Stopwatch.GetTimestamp();
                    BenchmarkMethod(array);
                    long t1 = Stopwatch.GetTimestamp();

                    time += (t1 - t0) * nanosecondsPerTick;
                }
                if(type.ToLower() == "table")
                    Console.WriteLine($"{i} & {time / runAmount / prefix}\\\\\n");
                else if(type.ToLower() == "graph")
                    Console.Write($"({i},{time / runAmount / prefix})");
                else
                    Console.WriteLine($"{i}: {time / runAmount}ns");
            }
        }

        /// <summary>
        /// Benchmark the minimum time it takes to execute a method with arrays.
        /// </summary>
        /// <param name="BenchmarkMethod">The method that should be benchmarked.</param>
        /// <param name="type"> If the output should be for a <c>table</c>, <c>graph</c> or just print it.</param>
        /// <param name="runAmount">The amount of times each test should be run.</param>
        /// <param name="minSize">The minimum size of the array that should be tested.</param>
        /// <param name="maxSize">The maximum size of the array that should be tested.</param>
        /// <param name="increaseSize">What the last size should be multiplied by for the next array size.</param>
        /// <param name="prefix">The output is in nanoseconds, this divides the output by the inputted value.</param>
        /// <returns>Output formatted for LATEX table or graph, or just a simple print.</returns>
        public static void Minimum(Func<int[], int[]> BenchmarkMethod, string type, int runAmount, int minSize, int maxSize, int increaseSize, int prefix) {
            long minTime = long.MaxValue;
            string output = "";

            for(int i = minSize; i < maxSize; i *= increaseSize) {
                for(int j = 0; j < runAmount; j++) {
                    int[] array = RandomArray(i);

                    long t0 = Stopwatch.GetTimestamp();
                    BenchmarkMethod(array);
                    long t1 = Stopwatch.GetTimestamp();

                    long time = (t1 - t0) * nanosecondsPerTick;
                    if(time < minTime)
                        minTime = time;
                }
                if(type.ToLower() == "table")
                    Console.WriteLine($"{i} & {minTime / prefix}\\\\\n");
                else if(type.ToLower() == "graph")
                    Console.Write($"({i},{minTime / prefix})");
                else
                    Console.WriteLine($"{i}: {minTime}ns");
            }
            Console.WriteLine(output);
        }

        /// <summary>
        /// Creates a array with the inputted <c>size</c> and fills it with random numbers.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        /// <returns>Array with random numbers.</returns>
        private static int[] RandomArray(int size) {
            Random random = new Random();
            int[] array = new int[size];
            for(int i = 0; i < array.Length; i++)
                array[i] = random.Next(array.Length * 5);
            return array;
        }
    }
}
