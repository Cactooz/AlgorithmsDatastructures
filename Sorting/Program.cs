using System.Diagnostics;

namespace Sorting {
    internal class Program {
        static void Main(string[] args) {
            long bubbleTime = 0;
            long selectionTime = 0;
            long insertionTime = 0;
            int runAmount = 1000;
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

            for(int i = 0; i < runAmount; i++) {
                int[] bubble = Utilities.RandomArray(10);
                int[] selection = Utilities.RandomArray(10);
                int[] insertion = Utilities.RandomArray(10);

                long t0 = Stopwatch.GetTimestamp();
                BubbleSort.Sort(bubble);
                long t1 = Stopwatch.GetTimestamp();

                bubbleTime += (t1 - t0) * nanosecondsPerTick;


                long t2 = Stopwatch.GetTimestamp();
                SelectionSort.Sort(selection);
                long t3 = Stopwatch.GetTimestamp();

                selectionTime += (t3 - t2) * nanosecondsPerTick;

                long t4 = Stopwatch.GetTimestamp();
                InsertionSort.Sort(insertion);
                long t5 = Stopwatch.GetTimestamp();

                insertionTime += (t5 - t4) * nanosecondsPerTick;
            }

            Console.WriteLine($"Bubble: {bubbleTime / runAmount}ns");
            Console.WriteLine($"Selection: {selectionTime / runAmount}ns");
            Console.WriteLine($"Insertion: {insertionTime / runAmount}ns");
        }
    }
}