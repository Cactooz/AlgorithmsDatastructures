using System.Text.RegularExpressions;

namespace Graphs {
	internal class Graph {

        City[] cities;

		public Graph(string filepath) {
            //Read all connections from the file and add all cities and connections
            using(StreamReader reader = new StreamReader(filepath)) {
                //Get the amount of lines in the file
                int lines = 0;
                while(reader.ReadLine() != null)
                    lines++;

                cities = new City[lines + 1];

                //Move the reader to the start
                reader.BaseStream.Position = 0;

                string line;
                int i = 0;

                //Read all lines
                while((line = reader.ReadLine()) != null) {
                    //Split the read line
                    string[] row = line.Split(",");

                    int length = int.Parse(Regex.Replace(row[2], @"\s+", ""));

                    //Add the Entry to the data array 
                    cities[i++] = new City(row[0]);
                    //Add the Entry to the data array 
                    cities[i++] = new City(row[1]);
                }
            }
        }

	}
}
