namespace T9 {
	internal class Program {
		static void Main(string[] args) {
			//Get the path to the dictionary file
			string file = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kelly.txt"));

			T9 t9 = new(file);

			Console.WriteLine(t9.WordToNumbers("fem"));

			List<string> list = t9.Words("225");
			foreach(string word in list)
				Console.WriteLine(word);

			//Console.WriteLine(t9.CheckWord("HEJ"));

			/*Console.WriteLine(t9.CharToNumber('w'));
			Console.WriteLine(t9.CharToNumber('Q'));

			Console.WriteLine(t9.KeyIndex(1));
			Console.WriteLine(t9.KeyIndex(2));
			Console.WriteLine(t9.KeyIndex(3));
			Console.WriteLine(t9.KeyIndex(4));
			Console.WriteLine(t9.KeyIndex(5));

			Console.WriteLine(t9.WordToNumbers("aBcDeFg"));
			Console.WriteLine(t9.WordToNumbers("HiJkLmN"));
			Console.WriteLine(t9.WordToNumbers("oPrStuV"));
			Console.WriteLine(t9.WordToNumbers("xYzÅäÖ"));*/
		}
	}
}
