﻿using System.Diagnostics;

namespace Hash {
	internal class Program {
		static void Main(string[] args) {
			//Get the path to the .csv file containing all zipcodes
			string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\zipcodes.csv"));

            Zip zip = new Zip(file);

			float maxScore = 0;
			int bestHash = 0;
			//Find best hash value score
			for(int i = 3000; i < 9000; i++) {
				float score = zip.Collisions(i);
				if(score > maxScore) {
                    maxScore = score;
					bestHash = i;
                }
			}

			Console.WriteLine($"Best Hash: {bestHash} with a score of {maxScore}");

			/*

            int hash = 8447;
			int code = 60591;
			
			Console.WriteLine($"Hash: {hash} Zip: {code}");

			ZipLinearHash linearZip = new ZipLinearHash(file, hash);

			Console.WriteLine(linearZip.Lookup(code));


			Console.WriteLine(zip.LookupHash(code));*/

			/*//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
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

					zip.LookupIndex(99499);

					long t1 = Stopwatch.GetTimestamp();

					//Save the total time
					time += (t1 - t0) * nanosecondsPerTick;
				}

				//Get the average time
				time /= averageAmount;

				if(time < minTime)
					minTime = time;
			}

			Console.WriteLine($"{minTime} ns");*/
		}
	}
}
