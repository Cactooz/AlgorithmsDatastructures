namespace Hash {
	internal class Zip {
		private class Entry {
			private string zipCode;
			private string zipLocation;
			private int zipPopulation;

			public Entry(string code, string location, int population) {
				zipCode = code;
				zipLocation = location;
				zipPopulation = population;
			}

			public string ZipCode { get => zipCode; }
			public string ZipLocation { get => zipLocation; }
			public int ZipPopulation { get => zipPopulation; }

		}

	}
}
