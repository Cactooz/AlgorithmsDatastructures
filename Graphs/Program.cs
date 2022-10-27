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

			long t0 = Stopwatch.GetTimestamp();
			int? distance = paths.ShortestPath(map.Lookup(from), map.Lookup(to), max);
			long t1 = Stopwatch.GetTimestamp();

			if(distance.HasValue)
				Console.WriteLine($"Shortest: {distance} ({(t1 - t0) * nanosecondsPerTick}ns)");
			else
				Console.WriteLine($"No path found with max {max} distance ({(t1 - t0) * nanosecondsPerTick}ns)");
		}
	}
}
