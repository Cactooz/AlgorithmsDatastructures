using System.Text.RegularExpressions;

namespace Graphs {
	internal class Graph {
		private class Buckets {
			private readonly City city;
			private Buckets? next;

			/// <summary>
			/// Creates a new <see cref="City"/> and sets <see cref="next"/> to <c>null</c>.
			/// </summary>
			/// <param name="name">The name of the new <see cref="City"/>.</param>
			public Buckets(string name) {
				city = new City(name);
				next = null;
			}

			public City City { get => city; }
			public Buckets? Next { get => next; set => next = value; }
		}

		Buckets[] cities;
		int mod;

		public Graph(string filepath) {
			//Read all connections from the file and add all cities and connections
			using(StreamReader reader = new StreamReader(filepath)) {
				mod = 541;
				cities = new Buckets[mod];

				string line;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					int firstHash = Hash(row[0]);
					int secondHash = Hash(row[1]);

					AddCity(firstHash, row[0]);
					AddCity(secondHash, row[1]);

					int length = int.Parse(Regex.Replace(row[2], @"\s+", ""));

					AddConnection(firstHash, row[0], secondHash, row[1], length);
				}
			}
		}

		/// <summary>
		/// Create a new <see cref="City"/> at the correct location in the <see cref="cities"/>
		/// <see cref="Array"/> of <see cref="Buckets"/>.
		/// </summary>
		/// <param name="index">The hashed location in the <see cref="cities"/> <see cref="Array"/>.</param>
		/// <param name="name">The name of the new <see cref="City"/>.</param>
		private void AddCity(int index, string name) {
			if(cities[index] != null) {
				//Pointer to look through the linked buckets
				Buckets pointer = cities[index];

				//Go to the last linked Buckets or stop if name is found
				while(!pointer.City.Name.Equals(name) && pointer.Next != null)
					pointer = pointer.Next!;

				//Set the new City to the next bucket if it does not exist
				if(!pointer.City.Name.Equals(name))
					pointer.Next = new Buckets(name);
			}
			else
				//Add the City to the data array of buckets
				cities[index] = new Buckets(name);
		}

		/// <summary>
		/// Add connections between two <see cref="City"/> objects. One in each direction,
		/// with the <paramref name="distance"/> between them.
		/// </summary>
		/// <param name="firstIndex">The hashed index of the first <see cref="City"/>.</param>
		/// <param name="first">The <see cref="City.name"/> of the first <see cref="City"/>.</param>
		/// <param name="secondIndex">The hashed index of the second <see cref="City"/>.</param>
		/// <param name="second">The <see cref="City.name"/> of the second <see cref="City"/>.</param>
		/// <param name="distance">The distance between the two <see cref="City"/>.</param>
		private void AddConnection(int firstIndex, string first, int secondIndex, string second, int distance) {
			//Pointer to look through the first city's linked buckets
			Buckets firstPointer = cities[firstIndex];

			//Pointer to look through the second city's linked buckets
			Buckets secondPointer = cities[secondIndex];

			//Go the where the first city is in the Buckets list
			while(!firstPointer.City.Name.Equals(first) && firstPointer.Next != null)
				firstPointer = firstPointer.Next!;

			//Go the where the second city is in the Buckets list
			while(!secondPointer.City.Name.Equals(second) && secondPointer.Next != null)
				secondPointer = secondPointer.Next!;

			//Add the connection between the two cities in both directions
			firstPointer.City.AddConnection(secondPointer.City, distance);
			secondPointer.City.AddConnection(firstPointer.City, distance);
		}

		/// <summary>
		/// Hash the <paramref name="name"/> using <see cref="mod"/>.
		/// </summary>
		/// <param name="name">The name to hash as a <see cref="string"/>.</param>
		/// <returns>The hashed <paramref name="name"/> as a <see cref="int"/>.</returns>
		private int Hash(string name) {
			int hash = 7;
			for(int i = 0; i < name.Length; i++)
				hash = (hash * 31 % mod) + name[i];

			return hash % mod;
		}

	}
}
