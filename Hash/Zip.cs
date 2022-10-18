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
		int[] codes;
		private int max;

		public Zip(string file) {
			//int lines = File.ReadAllLines(file).Count();
			data = new Entry[10000];
			codes = new int[10000];

			using(StreamReader reader = new StreamReader(file)) {
				string line;
				int i = 0;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					int zip = int.Parse(Regex.Replace(row[0], @"\s+", ""));

					//Add the Entry to the data array 
					data[i] = new Entry(zip, row[1], int.Parse(row[2]));

					//Save all zipcodes to array
					codes[i] = zip;

					//Save thee amount of codes added
					max = i++;
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
		/// <summary>
		/// Count the number of collisions between <see cref="Entry.zipCode"/>s when hashing
		/// them using <paramref name="mod"/> values.
		/// </summary>
		/// <param name="mod">The value that the <see cref="Entry.zipCode"/> are hashed with.</param>
		public void Collisions(int mod) {
			int[] data = new int[mod];
			//Keeping track on the amount of collisions
			int[] collisions = new int[15];

			for(int i = 0; i < max; i++) {
				//Get the index
				int index = codes[i] % mod;
				//Add a collisions 
				collisions[data[index]]++;
				//Store that a value has been hashed here
				data[index]++;
			}

			//Get average amount of collisions
			int maxCollisions = 0;
			int totalCollisions = 0;

			while(collisions[maxCollisions] > 0)
				totalCollisions += collisions[maxCollisions] * maxCollisions++;

			Console.WriteLine($"Mod: {mod} - Average collisions: {(float)(totalCollisions / (float)max)}");

			//Print all collisions
			for(int i = 0; i < 15; i++) {
				Console.Write($"({i}){collisions[i]}\t");
		}

			Console.WriteLine();
		}
	}
}