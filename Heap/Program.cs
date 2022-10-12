using System.Diagnostics;

namespace Heap {
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

            for(int i = minSize; i < maxSize; i *= 2) {
                long time = 0;

                for(int j = 0; j < runAmount; j++) {
                    //Create and fill the list
                    LinkedList list = new LinkedList(new LinkedList.Node(random.Next(i * 4), null));
                    for(int k = 1; k < i; k++)
                        list.AddSorted(new LinkedList.Node(random.Next(i * 4), null));

                    //Generate random number for the node to add
                    int number = random.Next(i * 4);

                    //Benchmark start
                    long t0 = Stopwatch.GetTimestamp();

                    list.AddSorted(new LinkedList.Node(number, null));

                    long t1 = Stopwatch.GetTimestamp();

                    //Save the total time
                    time += (t1 - t0) * nanosecondsPerTick;
                }

                Console.Write($"({i},{time / runAmount})");
            }

        }
    }
}
