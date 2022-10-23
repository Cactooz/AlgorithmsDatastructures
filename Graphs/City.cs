namespace Graphs {
	internal class City {
		/// <summary>
		/// The name of the <see cref="City"/>.
		/// </summary>
		private readonly string name;
		/// <summary>
		/// <see cref="Array"/> of all connections to other <see cref="City"/>.
		/// </summary>
		private Connection[] connections;

		/// <summary>
		/// Constructor for <see cref="City"/> setting its <see cref="name"/>.
		/// </summary>
		/// <param name="name">The <see cref="name"/> of the <see cref="City"/>.</param>
		public City(string name) {
			this.name = name;
			connections = new Connection[10];
		}

		/// <summary>
		/// The <see cref="name">name</see> of the <see cref="City"/>.
		/// </summary>
		public string Name { get => name; }

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
			connections[i] = new Connection(this, destination, distance);
		}

	}
}
