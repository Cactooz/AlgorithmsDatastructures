using System.Diagnostics;

namespace Graphs {
	internal class Program {
		static void Main(string[] args) {
			//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
			long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

			//Get the path to the connections file
			string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\trains.csv"));
			Graph map = new Graph(file);

			string from = "Malmö";
			string to = "Kiruna";
			int? max = null;

			Paths paths = new();

            City fromCity = map.Lookup(from);
            City toCity = map.Lookup(to);

            long minTime = long.MaxValue;
			int? distance = null;

            for(int j = 0; j < 10; j++) {
                long t0 = Stopwatch.GetTimestamp();
				distance = paths.ShortestPath(fromCity, toCity, max);
				long t1 = Stopwatch.GetTimestamp();

				long time = (t1 - t0) * nanosecondsPerTick;
				if(time < minTime)
					minTime = time;
            }

            if(distance.HasValue)
				Console.WriteLine($"Shortest: {distance} ({minTime/1000}μs)");
			else
				Console.WriteLine($"No path found with max {max} distance ({minTime/1000}μs)");
		}
	}
}
