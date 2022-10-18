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
			data = new Entry[100000];

			using(StreamReader reader = new StreamReader(file)) {
				string line;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					//Add the Entry with the zipcode used as index 
					data[int.Parse(Regex.Replace(row[0], @"\s+", ""))] = new Entry(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));
				}
			}
		}

		/// <summary>
		/// Find a <see cref="Entry.zipCode"/> in the <see cref="data"/> <see cref="Array"/> using the
		/// index as the <see cref="Entry.zipCode"/>.
		/// </summary>
		/// <param name="code">The <see cref="Entry.zipCode"/> to search for.</param>
		/// <returns><see cref="Boolean"/> if the <see cref="Entry.zipCode"/> could be found or not.</returns>
		public bool LookupIndex(int code) {
			if(data[code] != null)
				return true;
			else
				return false;
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