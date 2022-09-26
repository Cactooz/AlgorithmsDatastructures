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
            int maxSize = 130000;
            //The amount of times to run the tests
            int runAmount = 10000;
            //The amount of moveToStart operations that should be made
            int moveAmount = 1000;

            Random random = new Random();

            for(int i = minSize; i < maxSize; i *= 2) {
                long doubleMinTime = long.MaxValue;
                long singleMinTime = long.MaxValue;

                //Create the lists
                LinkedList list = new LinkedList(i, true);
                SingleLinkedList singleList = new SingleLinkedList(i, true);

                //Sequence of references to the elements that should be moved
                ListElement[] sequence = new ListElement[moveAmount];
                ListElement[] singleSequence = new ListElement[moveAmount];

                //Fill upp the sequence of which elements should be removed and readded.
                for(int j = 0; j < moveAmount; j++) {
                    sequence[j] = list.GetNode(random.Next(i - 1));
                    singleSequence[j] = singleList.GetNode(random.Next(i - 1));
                }

                for(int j = 0; j < runAmount; j++) {
                    //DoubleLinkedList
                    long doubleT0 = Stopwatch.GetTimestamp();
                    
                    //Move all the elements from the sequence
                    for(int k = 0; k < moveAmount; k++)
                        list.MoveToStart(sequence[k]);

                    long doubleT1 = Stopwatch.GetTimestamp();

                    long doubleTime = doubleT1 - doubleT0;

                    //Check if it is a new minimum time for the doubleLinkedList
                    if(doubleTime < doubleMinTime)
                        doubleMinTime = doubleTime * nanosecondsPerTick;

                    //SingleLinkedList
                    long singleT0 = Stopwatch.GetTimestamp();

                    //Move all the elements from the sequence
                    for(int k = 0; k < moveAmount; k++)
                        singleList.MoveToStart(singleSequence[k]);

                    long singleT1 = Stopwatch.GetTimestamp();

                    long singleTime = singleT1 - singleT0;

                    //Check if it is a new minimum time for the singleLinkedList
                    if(singleTime < singleMinTime)
                        singleMinTime = singleTime * nanosecondsPerTick;
                }
                Console.WriteLine($"{i}:\t({i},{doubleMinTime / prefix})\t({i},{singleMinTime / prefix})\t{doubleMinTime / (double)singleMinTime}");
            }
        }
    }
}
