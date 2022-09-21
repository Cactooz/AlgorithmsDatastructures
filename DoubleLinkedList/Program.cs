using System.Diagnostics;

namespace DoubleLinkedList {
    internal class Program {
        static void Main(string[] args) {
            //Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
            long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
            //Prefix for the output to convert from nanoseconds
            int prefix = 1000;
            //Minimum size to test from
            int minSize = 10;
            //The size of the linkedList
            int maxSize = 50000;
            //The amount of times to run the tests
            int runAmount = 10000;
            //The amount of removeAdd operations that should be made
            int removeAddAmount = 1000;

            Random random = new Random();

            for(int i = minSize; i < maxSize; i *= 2) {
                long doubleTime = 0;
                long singleTime = 0;

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

                    long singleT0 = Stopwatch.GetTimestamp();

                    for(int k = 0; k < removeAddAmount; k++)
                        singleList.RemoveAdd(sequence[k]);

                    long singleT1 = Stopwatch.GetTimestamp();


                    doubleTime += (doubleT1 - doubleT0) * nanosecondsPerTick;
                    singleTime += (singleT1 - singleT0) * nanosecondsPerTick;
                }
                Console.WriteLine($"{i}: {doubleTime / runAmount / prefix} | {singleTime / runAmount / prefix}");
            }
        }
    }
}
