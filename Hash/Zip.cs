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

		private class Buckets {
			private Entry code;
			private Buckets? next;

			/// <summary>
			/// Creates a new <see cref="Entry"/> and sets <see cref="next"/> to <c>null</c>.
			/// </summary>
			/// <param name="code">Data for <see cref="Entry.zipCode"/>.</param>
			/// <param name="location">Data for <see cref="Entry.zipLocation"/>.</param>
			/// <param name="population">Data for <see cref="Entry.zipPopulation"/>.</param>
			public Buckets(int code, string location, int population) {
				this.code = new Entry(code, location, population);
				next = null;
			}

			public Entry Code { get => code; }
			public Buckets? Next { get => next; set => next = value; }
		}

		Buckets[] data;
		int[] codes;
		private int max;
		int hash;

		public Zip(string file) {
			using(StreamReader reader = new StreamReader(file)) {
				//Get the amount of lines in the file
				int lines = 0;
				while(reader.ReadLine() != null)
					lines++;

				data = new Buckets[lines + 1];
				codes = new int[lines + 1];

				//Move the reader to the start
				reader.BaseStream.Position = 0;

				string line;
				int i = 0;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					int zip = int.Parse(Regex.Replace(row[0], @"\s+", ""));

					//Add the Entry to the data array 
					data[i] = new Buckets(zip, row[1], int.Parse(row[2]));

					//Save all zipcodes to array
					codes[i] = zip;

					//Save thee amount of codes added
					max = i++;
				}
			}
		}

		/// <summary>
		/// Constructor for <see cref="Zip"/> that reads all data from <paramref name="file"/>
		/// and hashes the <see cref="Entry.zipCode"/> with the inputted <paramref name="hash"/>.
		/// </summary>
		/// <param name="file">The .csv file to read all the data from.</param>
		/// <param name="hash">The value to hash the <see cref="Entry.zipCode"/> using modulo with.</param>
		public Zip(string file, int hash) {
			using(StreamReader reader = new StreamReader(file)) {
				data = new Buckets[hash];

				string line;

				//Save thee amount of codes added
				max = hash;
				this.hash = hash;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					//Get the zipcode and hash it
					int hashedZip = int.Parse(Regex.Replace(row[0], @"\s+", "")) % hash;

					if(data[hashedZip] != null) {
						//Pointer to look through the linked buckets
						Buckets pointer = data[hashedZip];

						//Go to the last linked Buckets
						while(pointer.Next != null)
							pointer = pointer.Next!;

						//Set the new zip to the next bucket
						pointer.Next = new Buckets(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));
					} else
						//Add the Entry to the data array of buckets
						data[hashedZip] = new Buckets(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));

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
				if(data[i].Code.ZipCode.Equals(code))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Find a <see cref="Entry.zipCode"/> in the hashed <see cref="data"/> <see cref="Array"/>
		/// using the hashed <paramref name="code"/>.
		/// </summary>
		/// <param name="code">The <see cref="Entry.zipCode"/> to search for.</param>
		/// <returns>The depth of the <see cref="Buckets"/> that the <see cref="Entry.zipCode"/> is located.</returns>
		public int? LookupHash(int code) {
			//Hash the inputted code
			int hashedCode = code % hash;
			
			Buckets pointer = data[hashedCode];

			int depth = 0;

			while(pointer != null) {
				//Go forward in the buckets list until the correct zipcode is found
				if(!pointer.Code.ZipCode.Equals(code)) {
					pointer = pointer.Next!;
					depth++;
				} else
					//Return the depth the zipcode was found on
					return depth;
			}

			//Return null if the input is not a zipcode
			return null;
		}

		public bool BinarySearch(int code) {
			int first = 0;
			int last = max;

			while(true) {
				//Set the mid between the first and last point
				int mid = (first + last) / 2;

				if(data[mid].Code.ZipCode.Equals(code))
					return true;
				//If the key is larger than the current value, set the first point to current mid
				if(data[mid].Code.ZipCode.CompareTo(code) < 0 && mid < last) {
					first = mid + 1;
					continue;
				}
				//If the key is smaller than the current value, set the last point to current mid
				else if(data[mid].Code.ZipCode.CompareTo(code) > 0 && mid > first) {
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
		public float Collisions(int mod) {
			int[] data = new int[mod];
			//Keeping track on the amount of collisions
			int[] collisions = new int[30];

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

			float averageCollisions = totalCollisions / (float)max;
			float score = (float)((1 - averageCollisions) / mod) * 100000;

            Console.WriteLine($"Mod: {mod} - Average collisions: {averageCollisions} - Score: {score}");

			//Print all collisions
			for(int i = 0; i < 15; i++) {
				Console.Write($"({i}){collisions[i]}\t");
			}

			Console.WriteLine();

			return score;
		}
	}
}