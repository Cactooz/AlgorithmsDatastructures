namespace Graphs {
	internal class Connection {
		/// <summary>
		/// The <see cref="City"/> the connection starts in.
		/// </summary>
		private readonly City startCity;
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
		/// <param name="start">The starting <see cref="City"/>.</param>
		/// <param name="destination">The ending <see cref="City"/>.</param>
		/// <param name="distance">The distance between the two different <see cref="City">.</param>
		public Connection(City start, City destination, int distance) {
			startCity = start;
			endCity = destination;
			length = distance;
		}
	}
}
