using System.Diagnostics;

namespace Dijkstra {
	internal class Dijkstra {
		/// <summary>
		/// An <see cref="Entry"/> with a <see cref="City"/> with the current shortest <see cref="distance"/> path
		/// from the <see cref="previousCity"/> and the <see cref="City"/> objects location in the <see cref="queue"/> heap array.
		/// </summary>
		public class Entry {
			/// <summary>
			/// The current <see cref="City"/> that the <see cref="Entry"/> is for.
			/// </summary>
			private readonly City city;
			/// <summary>
			/// The distance from the start <see cref="City"/> to the current <see cref="City"/>.
			/// </summary>
			private int distance;
			/// <summary>
			/// Reference to the previous <see cref="City"/> object, that the current path came from.
			/// </summary>
			private City? previousCity;
			/// <summary>
			/// This <see cref="Entry"/> objects location in the <see cref="Queue"/> heap.
			/// </summary>
			private int? heapIndex;

			/// <summary>
			/// Create a new <see cref="Entry"/> for <paramref name="city"/>. Sets the current shortest <see cref="distance"/> from
			/// the start <see cref="City"/> to the current <see cref="city"/> as well as from which <see cref="City"/> the path came from.
			/// </summary>
			/// <param name="city">The current <see cref="City"/> for the <see cref="Entry"/>.</param>
			/// <param name="distance">The distance from the start <see cref="City"/> to the this <paramref name="city"/>.</param>
			/// <param name="previousCity">A <see cref="Nullable"/> reference to the previous <see cref="City"/> that the path came from.</param>
			/// <param name="heapIndex">The <see cref="Nullable"/> location in the <see cref="Queue"/> heap that <see langword="this"/> <see cref="Entry"/> is located.</param>
			public Entry(City city, int distance = 0, City? previousCity = null, int? heapIndex = null) {
				this.city = city;
				this.distance = distance;
				this.previousCity = previousCity;
				this.heapIndex = heapIndex;
			}

			/// <summary>
			/// Get the <see cref="City"/> associated with the <see cref="Entry"/>.
			/// </summary>
			public City City { get => city; }
			/// <summary>
			/// The distance from the start <see cref="City"/> to <see langword="this"/> <see cref="City"/>.
			/// </summary>
			public int Distance { get => distance; set => distance = value; }
			/// <summary>
			/// <see cref="Nullable"/> Reference to the <see cref="City"/> the path came from.
			/// </summary>
			public City? PreviousCity { get => previousCity; set => previousCity = value; }
			/// <summary>
			/// The index in the <see cref="Queue"/> heap array for the <see cref="Entry"/>.
			/// </summary>
			public int? HeapIndex { get => heapIndex; set => heapIndex = value; }
		}

		/// <summary>
		/// An <see cref="Entry"/> <see cref="Array"/> of all <see cref="Entry"/> objects that have been checked. 
		/// </summary>
		private Entry[] done;
		/// <summary>
		/// The heap queue for <see cref="Entry"/> objects to still check.
		/// </summary>
		private Queue queue;

		/// <summary>
		/// Get the <see cref="Entry"/> <see cref="Array"/> containing all <see cref="Entry"/> objects that have been checked.
		/// </summary>
		public Entry[] Done { get => done; }

		/// <summary>
		/// Create the <see cref="Dijkstra"/> <see cref="Graph"/> of all paths to other <see cref="City"/> objects
		/// from the inputted <paramref name="start"/> <see cref="City"/>.
		/// </summary>
		/// <param name="start">The <see cref="City"/> that all searches should start from.</param>
		public Dijkstra(City start) {
			done = new Entry[52];
			queue = new Queue(52);

			queue.Add(new Entry(start));
		}

		/// <summary>
		/// Get the shortest path from the start <see cref="City"/> to the chosen
		/// <paramref name="destination"/> <see cref="City"/>.
		/// </summary>
		/// <param name="destination">The <see cref="City"/> to find the shortest path for.</param>
        /// <param name="all"><see langword="true"/> to find all <see cref="City"/> objects distance from the start,
        /// <see langword="false"/> to stop when the <paramref name="destination"/> is found.</param>
        public void ShortestPath(City destination, bool all = false) {
			while(!queue.Empty()) {
				//Pop and get the first city from the heap
				Entry entry = queue.Remove()!;

				City city = entry.City;

				//If the destination is found don't check its connections
				if(city == destination && !all)
					break;

				int distance = entry.Distance;

				//Check all connections for the popped city
				for(int i = 0; i < city.Connections.Length; i++) {
					if(city.Connections[i] != null) {
						City.Connection connection = city.Connections[i];

						City to = connection.EndCity;

						//Check if the city the connection is to does not already have a path
						if(done[to.Id] == null) {
							//Create a new entry with the current distance and add it to the done array
							Entry add = new Entry(to, distance + connection.Length, city);
							done[to.Id] = add;

							//Add the connecting city to the heap
							queue.Add(add);
						} else {
							Entry check = done[to.Id];
							//Check if the new path length is shorter than the old path
							if(distance + connection.Length < check.Distance) {
								//Overwrite with the new shorter path distance
								check.Distance = distance + connection.Length;

								//If the element exists in the heap, swap it otherwise add it
								if(check.HeapIndex.HasValue)
									queue.Swap(check.HeapIndex!);
								else
									queue.Add(check);
							}
						}
					}
				}
			}
		}

		static void Main(string[] args) {
			//Variable for converting Stopwatch.GetTimestamp output to nanoseconds.
			long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

			//Get the path to the connections file
			string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\trains.csv"));
			Graph map = new Graph(file);

			string from = "Malmö";
			string to = "Göteborg";

			City fromCity = map.Lookup(from);
			City toCity = map.Lookup(to);

			Dijkstra dijkstra = new(fromCity);

			long t0 = Stopwatch.GetTimestamp();
			dijkstra.ShortestPath(toCity);
			long t1 = Stopwatch.GetTimestamp();

			Console.WriteLine($"Shortest: {dijkstra.Done[toCity.Id].Distance} ({(t1 - t0) * nanosecondsPerTick}ns)");
		}
	}
}
