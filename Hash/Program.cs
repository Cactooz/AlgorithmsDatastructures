using System.Diagnostics;

namespace Hash {
	internal class Program {
		static void Main(string[] args) {
			//Get the path to the .csv file containing all zipcodes
			string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\zipcodes.csv"));
			Zip zip = new Zip(file);

			//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
			long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
			//The amount of times to run the tests
			int runAmount = 1000;
			int averageAmount = 10;

			long minTime = long.MaxValue;

			//Run the benchmark runAmount times and take the mintime
			for(int i = 0; i < runAmount; i++) {

				long time = 0;

				//Run the test averageAmount times ang get averages
				for(int j = 0; j < averageAmount; j++) {
					//Benchmark start
					long t0 = Stopwatch.GetTimestamp();

					zip.Lookup("994 99");

					long t1 = Stopwatch.GetTimestamp();

					//Save the total time
					time += (t1 - t0) * nanosecondsPerTick;
				}

				//Get the average time
				time /= averageAmount;

				if(time < minTime)
					minTime = time;
			}

			Console.WriteLine($"{minTime} ns");
		}
	}
}
