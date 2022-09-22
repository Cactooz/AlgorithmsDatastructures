using System.Diagnostics;

namespace DoubleLinkedList {
    internal class Program {
        static void Main(string[] args) {
            //Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
            //Prefix for the output to convert from nanoseconds
            int prefix = 1000;
            //Minimum size to test from
            int minSize = 2;
            //The size of the linkedList
            int maxSize = 100000;
            //The amount of times to run the tests
            int runAmount = 10000;
            //The amount of removeAdd operations that should be made
            int removeAddAmount = 100;

            Random random = new Random();

            for(int i = minSize; i < maxSize; i *= 2) {
                long doubleMinTime = long.MaxValue;
                long singleMinTime = long.MaxValue;

                //Fill upp the sequence of which elements should be removed and readded.
                int[] sequence = new int[removeAddAmount];
                for(int j = 0; j < removeAddAmount; j++)
                    sequence[j] = random.Next(i - 1);
                
                //Create the lists
                LinkedList list = new LinkedList(i);
                SingleLinkedList singleList = new SingleLinkedList(i);

                for(int j = 0; j < runAmount; j++) {
                    long doubleT0 = Stopwatch.GetTimestamp();
                    
                    for(int k = 0; k < removeAddAmount; k++)
                        list.RemoveAdd(sequence[k]);

                    long doubleT1 = Stopwatch.GetTimestamp();

                    long doubleTime = doubleT1 - doubleT0;

                    if(doubleTime < doubleMinTime)
                        doubleMinTime = doubleTime * nanosecondsPerTick;

                    long singleT0 = Stopwatch.GetTimestamp();

                    for(int k = 0; k < removeAddAmount; k++)
                        singleList.RemoveAdd(sequence[k]);

                    long singleT1 = Stopwatch.GetTimestamp();

                    long singleTime = singleT1 - singleT0;

                    if(singleTime < singleMinTime)
                        singleMinTime = singleTime * nanosecondsPerTick;
                }
                Console.WriteLine($"{i}:\t{doubleMinTime / prefix}\t{singleMinTime / prefix}\t{doubleMinTime / (double)singleMinTime}");
            }
        }
    }
}
