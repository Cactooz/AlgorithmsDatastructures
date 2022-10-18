using System.Text.RegularExpressions;

namespace Hash {
	internal class ZipLinearHash {
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

		private Entry[] data;
		private int hash;

		public ZipLinearHash(string file, int hash) {
			using(StreamReader reader = new StreamReader(file)) {
				data = new Entry[15000];

				string line;

				//Move the reader to the start
				reader.BaseStream.Position = 0;

				//Save thee amount of codes added
				this.hash = hash;

				//Read all lines
				while((line = reader.ReadLine()) != null) {
					//Split the read line
					string[] row = line.Split(",");

					//Get the zipcode and hash it
					int hashedZip = int.Parse(Regex.Replace(row[0], @"\s+", "")) % hash;

					if(data[hashedZip] != null) {

						//Go to the first empty element
						while(data[hashedZip] != null)
							hashedZip++;

						//Set the new zip to the next element
						data[hashedZip] = new Entry(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));
					}
					else
						//Add the Entry to the data array of entries
						data[hashedZip] = new Entry(int.Parse(Regex.Replace(row[0], @"\s+", "")), row[1], int.Parse(row[2]));

				}
			}
		}

		public int? Lookup(int code) {
			//Hash the inputted code
			int hashedCode = code % hash;

			if(data[hashedCode] == null)
				return null;

			int depth = 0;
			int index = hashedCode + depth;

			//Go forward in the array until the correct zipcode is found
			while(data[index] != null) {
				if(data[index].ZipCode.Equals(code))
					return depth;
				
				depth++;
				index++;
			}
			
			//Return null if the input is not a zipcode
			return null;
		}

	}
}
