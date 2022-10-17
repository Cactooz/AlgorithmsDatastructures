using System.Text.RegularExpressions;

namespace Hash {
	internal class Zip {
		private class Entry {
			private int zipCode;
			private string zipLocation;
			private int zipPopulation;

			public Entry(int code, string location, int population) {
				zipCode = code;
				zipLocation = location;
				zipPopulation = population;
			}

			public int ZipCode { get => zipCode; }
			public string ZipLocation { get => zipLocation; }
			public int ZipPopulation { get => zipPopulation; }

		}

		Entry[] data;
		private int max;

		public Zip(string file) {
			int lines = File.ReadAllLines(file).Count();
			data = new Entry[10000];

			using(StreamReader reader = new StreamReader(file)) {
				string line;
				int i = 0;

				while((line = reader.ReadLine()) != null) {
					string[] row = line.Split(",");
					data[i++] = new Entry(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));
				}
				max = i - 1;
			}
		}

		public bool Lookup(int code) {
			for(int i = 0; i < max; i++) {
				if(data[i].ZipCode.Equals(code))
					return true;
			}
			return false;
		}

	}
}
