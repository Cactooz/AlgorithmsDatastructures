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

		/// <summary>
		/// Linked <see cref="Buckets"/> containing all <see cref="City"/> objects.
		/// </summary>
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

					//Create or find the two cities
					City city1 = Lookup(row[0]);
					City city2 = Lookup(row[1]);

					//Convert the length of the connection to int
					int length = int.Parse(Regex.Replace(row[2], @"\s+", ""));

					//Add the connections between the two cities
					city1.AddConnection(city2, length);
					city2.AddConnection(city1, length);
				}
			}
		}

		/// <summary>
		/// Check if a <see cref="City"/> exist, otherwise create a new <see cref="City"/>
		/// at the correct location in the <see cref="cities"/> <see cref="Array"/> of <see cref="Buckets"/>.
		/// </summary>
		/// <param name="name">The name of the new <see cref="City"/>.</param>
		/// <returns>The searched for or added <see cref="City"/>.</returns>
		private City Lookup(string name) {
			int index = Hash(name);

			//Create a city if there are no yet
			if(cities[index] == null) {
				cities[index] = new Buckets(name);
				return cities[index].City;
			}

			//If there already is a city at the position check through the linked Buckets
			if(cities[index].City.Name != name) {
				//Pointer to look through the linked buckets
				Buckets pointer = cities[index];

				//Go to the last linked Buckets or stop if name is found
				while(!pointer.City.Name.Equals(name) && pointer.Next != null)
					pointer = pointer.Next!;

				//Set the new City to the next bucket if it does not exist
				if(!pointer.City.Name.Equals(name)) {
					pointer.Next = new Buckets(name);
					return pointer.Next.City;
				}
				else
					return pointer.City;
			}

			//Return the city.
			return cities[index].City;
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
