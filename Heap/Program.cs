using System.Diagnostics;

namespace Heap {
    internal class Program {
        static void Main(string[] args) {

			//BENCHMARKS FOR LINKEDLISTS

			/*//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
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
            }*/

			/*Heap heap = new();
            Random random = new();
            for(int i = 0; i < 64; i++)
                heap.Add(random.Next(100));

            for(int i = 0; i < 10;i++) {
				int value = random.Next(10, 20);
				int add = heap.Add(value);
				int push = heap.Push(value);
				Console.WriteLine($"Add: {add}\tPush:{push}");
			}*/

			//BENCHMARKS FOR HEAP AND HEAPARRAY

			//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
			long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
			//Minimum size to test from
			int minSize = 2;
			int dataPoints = 19;
			//The amount of times to run the tests
			int runAmount = 10000000;

			Random random = new();

			string[] addResult = new string[(int)Math.Log2(Math.Pow(2, dataPoints))];
			string[] removeResult = new string[(int)Math.Log2(Math.Pow(2, dataPoints))];
			int arrayIndex = 0;

			for(int i = minSize; i <= Math.Pow(2,dataPoints); i *= 2) {
				long addTime = 0;
				long removeTime = 0;

				HeapArray heap = new(i + 10);

				//Fill the heap
				for(int n = 0; n < i; n++)
					heap.Add(random.Next(n * 4));

				for(int j = 0; j < runAmount; j++) {
					//Generate random number for the node to add
					int number = random.Next(i * 4)+1;

					//Benchmark start
					long addT0 = Stopwatch.GetTimestamp();

					heap.Add(number);

					long addT1 = Stopwatch.GetTimestamp();

					//Save the total time
					addTime += (addT1 - addT0) * nanosecondsPerTick;

					long removeT0 = Stopwatch.GetTimestamp();

					heap.Remove();

					long removeT1 = Stopwatch.GetTimestamp();

					//Save the total time
					removeTime += (removeT1 - removeT0) * nanosecondsPerTick;
				}

				addResult[arrayIndex] = $"({i},{addTime / runAmount})";
				removeResult[arrayIndex] = $"({i},{removeTime / runAmount})";

				arrayIndex++;

				Console.WriteLine(string.Join("", addResult));
				Console.WriteLine(string.Join("", removeResult));
			}

		}
    }
}