using System.Diagnostics;
using Benchmark;

namespace Sorting {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Benchmark started");

            long t0 = Stopwatch.GetTimestamp();
            Benchmarks.Average(InsertionSort.Sort, "graph", 10000, 10, 6500, 2, 1000);
            long t1 = Stopwatch.GetTimestamp();

            Console.WriteLine("Benchmark finished");
        }
    }
}
