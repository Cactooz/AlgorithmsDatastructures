namespace Dijkstra {
	/// <summary>
	/// A <see cref="City"/> with a <see cref="name"/> and <see cref="Array"/>
	/// of <see cref="Connection"/> to other <see cref="City"/> objects.
	/// </summary>
	internal class City {
		/// <summary>
		/// A connection between two <see cref="City"/>.
		/// </summary>
		internal class Connection {
			/// <summary>
			/// The <see cref="City"/> the connection ends in.
			/// </summary>
			private readonly City endCity;
			/// <summary>
			/// The distance between the start and end <see cref="City"/>.
			/// </summary>
			private readonly int length;

			/// <summary>
			/// Constructor for <see cref="Connection"/> between two <see cref="City"/>.
			/// </summary>
			/// <param name="destination">The ending <see cref="City"/>.</param>
			/// <param name="distance">The distance between the two different <see cref="City">.</param>
			public Connection(City destination, int distance) {
				endCity = destination;
				length = distance;
			}

			/// <summary>
			/// The <see cref="City"/> the <see cref="Connection"/> ends in.
			/// </summary>
			public City EndCity { get => endCity; }
			/// <summary>
			/// The length between the start <see cref="City"/> and <see cref="endCity"/>.
			/// </summary>
			public int Length { get => length; }
		}

		/// <summary>
		/// The name of the <see cref="City"/>.
		/// </summary>
		private readonly string name;
		/// <summary>
		/// <see cref="Array"/> of all connections to other <see cref="City"/>.
		/// </summary>
		private Connection[] connections;

		/// <summary>
		/// The index the <see cref="City"/> should use in the <see cref="Dijkstra.done"/> <see cref="Array"/>.
		/// </summary>
		private readonly int id;

		/// <summary>
		/// Constructor for <see cref="City"/> setting its <see cref="name"/>.
		/// </summary>
		/// <param name="name">The <see cref="name"/> of the <see cref="City"/>.</param>
		public City(string name, int id) {
			this.name = name;
			connections = new Connection[10];
			this.id = id;
		}

		/// <summary>
		/// The <see cref="name">name</see> of the <see cref="City"/>.
		/// </summary>
		public string Name { get => name; }
		/// <summary>
		/// The <see cref="Array"/> of <see cref="Connection"/> between this <see cref="City"/>
		/// and all other linked <see cref="City"/> objects.
		/// </summary>
		public Connection[] Connections { get => connections; }
		/// <summary>
		/// The <see cref="id"/> for the <see cref="City"/>.
		/// </summary>
		public int Id { get => id; }

		/// <summary>
		/// Adds a new connection from the current <see cref="City"/>
		/// to the inputted <paramref name="destination"/> <see cref="City"/>
		/// along with the <paramref name="distance"/> between the two cities.
		/// </summary>
		/// <param name="destination">The destination <see cref="City"/> that the <see cref="Connection"/> should end in.</param>
		/// <param name="distance">The <see cref="Connection.length">distance</see> between the start and end <see cref="City"/>.</param>
		public void AddConnection(City destination, int distance) {
			int i = 0;
			//Go to the first empty location in the array
			while(connections[i] != null)
				i++;

			//Create a new connection
			connections[i] = new Connection(destination, distance);
		}

	}
}
