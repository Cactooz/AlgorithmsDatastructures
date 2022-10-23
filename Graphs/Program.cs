namespace Graphs {
	internal class Program {
		static void Main(string[] args) {
            //Get the path to the connections file
            string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\trains.csv"));
            Graph graph = new Graph(file);

        }
	}
}
