namespace Graphs {
	internal class Paths {
		private City?[] path = new City[52];
		private int sp = 0;

		public Paths() {
			path = new City[52];
			sp = 0;
		}

		public int? ShortestPath(City from, City to, int max) {
			if(max < 0)
				return null;
			if(from == to)
				return 0;

			//Check if the the path have already been in the current city
			for(int i = 0; i < sp; i++) {
				if(path[i] == from)
					return null;
			}

			//Add the current city to the current path
			path[sp++] = from;

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

			//Remove the city from the path
			path[sp--] = null;

			return shortest;
		}
	}
}
