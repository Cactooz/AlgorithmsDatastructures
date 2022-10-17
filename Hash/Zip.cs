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

		public bool BinarySearch(int code) {
			int first = 0;
			int last = max;

			while(true) {
				//Set the mid between the first and last point
				int mid = (first + last) / 2;

				if(data[mid].ZipCode.Equals(code))
					return true;
				//If the key is larger than the current value, set the first point to current mid
				if(data[mid].ZipCode.CompareTo(code) < 0 && mid < last) {
					first = mid + 1;
					continue;
				}
				//If the key is smaller than the current value, set the last point to current mid
				else if(data[mid].ZipCode.CompareTo(code) > 0 && mid > first) {
					last = mid - 1;
					continue;
				}
				//If first = last, then there are no value in the array matching the key
				return false;
			}
		}

	}
}