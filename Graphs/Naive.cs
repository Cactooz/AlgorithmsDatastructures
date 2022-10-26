namespace Graphs {
	/// <summary>
	/// A Naive way of finding the shortest path between two <see cref="City"/> objects.
	/// </summary>
	internal class Naive {
		/// <summary>
		/// Get the shortest path from the start <see cref="City"/> to the
		/// end <see cref="City"/>, with the maximum length.
		/// </summary>
		/// <param name="from">The <see cref="City"/> to start in.</param>
		/// <param name="to">The <see cref="City"/> to end at.</param>
		/// <param name="max">The max length between the two <see cref="City"/>.</param>
		/// <returns><see cref="Nullable"/> <see cref="int"/> of the shortest path.</returns>
		public static int? ShortestPath(City from, City to, int max) {
			if(max < 0)
				return null;
			if(from == to)
				return 0;

			//Save the shortest route
			int? shortest = null;

			//Loop through all connections
			for(int i = 0; i < from.Connections.Length; i++) {
				if(from.Connections[i] != null) {
					City.Connection connection = from.Connections[i];

					//Add the distance to the next city
					int? addShort = connection.Length;

					//Continue recursively down and find the shortest path
					int? distance = ShortestPath(connection.EndCity, to, max - connection.Length);

					//Add the returned path if its not null
					if(distance != null)
						addShort += distance;
					else
						continue;

					//Override the shortest if the new one is shorter
					if(addShort < shortest || shortest == null)
						shortest = addShort;
				}
			}

			return shortest;
		}
	}
}
